using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using LlamaLibrary.Helpers;
using LlamaLibrary.Logging;
using LlamaLibrary.Memory;
using LlamaLibrary.RemoteWindows;
using TreeSharp;

namespace CompanyChest
{
    public class CompanyChest : BotBase
    {
        internal static readonly LLogger Log = new LLogger("CompanyChest", Colors.RoyalBlue);

        private Composite _root;
        public override string Name => "CompanyChest";
        public override PulseFlags PulseFlags => PulseFlags.All;
        public override bool IsAutonomous => true;
        public override bool RequiresProfile => false;
        public override Composite Root => _root;
        public override bool WantButton { get; } = true;
        private CompanyChestSettings _settings;
        private static bool _isDone = false;

        public override void Initialize()
        {
            OffsetManager.Init();
        }

        public override void OnButtonPress()
        {
            if (_settings == null || _settings.IsDisposed)
            {
                _settings = new CompanyChestSettings();
            }

            try
            {
                _settings.Show();
                _settings.Activate();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public override void Start()
        {
            _isDone = false;
            _root = new ActionRunCoroutine(r => Run());
        }

        private async Task<bool> Run()
        {
            if (_isDone) return false;

            if (_settings.ShouldDeposit || _settings.ShouldWithdraw)
            {
                if (await GetToChest())
                {
                    if (_settings.ShouldDeposit)
                    {
                        Log.Information("Depositing Items.");
                        await DepositItems();
                    }

                    if (_settings.ShouldWithdraw)
                    {
                        Log.Information("Withdrawing Items.");
                        await WithdrawItems();
                    }
                }
            }

            _isDone = true;
            TreeRoot.Stop("Done interacting with FC chest.");
            return false;
        }

        private static async Task<bool> GetToChest()
        {
            GameObject chest = GameObjectManager.GameObjects.FirstOrDefault(x => x.EnglishName == "Company Chest" && x.Distance(Core.Me) < 3.5f);
            if (chest == null)
            {
                Log.Error("Couldn't find a nearby company chest within interact range! Get a bit closer...");
                _isDone = true;
                TreeRoot.Stop("Couldn't find an FC Chest within interact range.");
                return false;
            }
            
            chest.Interact();
            await Coroutine.Wait(5000, () => FreeCompanyChest.Instance.IsOpen);
            if (!FreeCompanyChest.Instance.IsOpen)
            {
                Log.Error("Couldn't get the FreeCompanyChest window open.");
                return false;
            }

            return true;
        }

        private static IEnumerable<BagSlot> ChestSlots => InventoryManager
            .GetBagsByInventoryBagId(InventoryBagId.GrandCompany_Page1, InventoryBagId.GrandCompany_Page2, InventoryBagId.GrandCompany_Page3)
            .SelectMany(b => b.Select(x => x));

        private static async Task DepositItems()
        {
            foreach (ChestRule rule in SavedSettings.Instance.DepositList.Distinct())
            {
                foreach (BagSlot playerSlot in InventoryManager.FilledSlots.Where(x => x.TrueItemId == rule.ItemId && x.ValidForChest()))
                {
                    Log.Information($"Moving Slot#{playerSlot.Slot} {playerSlot.Name} to FC Chest.");
                    while (playerSlot.IsValid && playerSlot.IsFilled && playerSlot.TrueItemId == rule.ItemId && playerSlot.Count > 0)
                    {
                        BagSlot chestSlot = GetChestDestinationSlot(rule.ItemId);
                        if (chestSlot == null)
                        {
                            _isDone = true;
                            TreeRoot.Stop($"Couldn't find a destination slot for {rule.ItemId}. Is the FC chest full?");
                            return;
                        }

                        playerSlot.Move(chestSlot);
                        await Coroutine.Sleep(1500);
                    }
                }
            }
        }
        
        private static async Task WithdrawItems()
        {
            foreach (ChestRule rule in SavedSettings.Instance.WithdrawList.Distinct())
            {
                foreach (BagSlot chestSlot in ChestSlots.Where(x => x.TrueItemId == rule.ItemId))
                {
                    Log.Information($"Moving Slot#{chestSlot.Slot} {chestSlot.Name} to Player Inventory.");
                    while (chestSlot.IsValid && chestSlot.IsFilled && chestSlot.TrueItemId == rule.ItemId && chestSlot.Count > 0)
                    {
                        BagSlot playerSlot = GetPlayerDestinationSlot(rule.ItemId);
                        if (playerSlot == null)
                        {
                            _isDone = true;
                            TreeRoot.Stop($"Couldn't find a destination slot for {rule.ItemId}. Is the player inventory full?");
                            return;
                        }

                        chestSlot.Move(playerSlot);
                        await Coroutine.Sleep(1500);
                    }
                }
            }
        }

        private static BagSlot GetChestDestinationSlot(uint trueItemId)
        {
            foreach (BagSlot slot in ChestSlots)
            {
                if (!slot.IsValid) continue;
                if (slot.IsFilled && slot.TrueItemId == trueItemId && slot.Count < slot.Item.StackSize) return slot;
            }

            return ChestSlots.FirstOrDefault(x => x.IsValid && !x.IsFilled);
        }
        
        private static BagSlot GetPlayerDestinationSlot(uint trueItemId)
        {
            foreach (BagSlot slot in InventoryManager.FilledSlots)
            {
                if (!slot.IsValid) continue;
                if (slot.IsFilled && slot.TrueItemId == trueItemId && slot.Count < slot.Item.StackSize) return slot;
            }

            return InventoryManager.GetBagsByInventoryBagId(GeneralFunctions.MainBags).SelectMany(b => b.Select(x => x)).FirstOrDefault(x => x.IsValid && !x.IsFilled);
        }

        public override void Stop()
        {
            _isDone = true;
            _root = null;
        }
    }
}