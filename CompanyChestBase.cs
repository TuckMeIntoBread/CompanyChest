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
using ff14bot.Navigation;
using ff14bot.Objects;
using ff14bot.Pathing.Service_Navigation;
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
            Navigator.NavigationProvider = new ServiceNavigationProvider();
            Navigator.PlayerMover = new SlideMover();
            _isDone = false;
            _root = new ActionRunCoroutine(r => Run());
        }

        private async Task<bool> Run()
        {
            if (_isDone) return false;

            if (_settings.ShouldDeposit || _settings.ShouldWithdraw)
            {
                if (await Nav.GetToChest())
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

        private static IEnumerable<BagSlot> ChestSlots => InventoryManager
            .GetBagsByInventoryBagId(InventoryBagId.GrandCompany_Page1, InventoryBagId.GrandCompany_Page2, InventoryBagId.GrandCompany_Page3)
            .SelectMany(b => b.Select(x => x));

        private static IEnumerable<BagSlot> PlayerSlots => InventoryManager
            .GetBagsByInventoryBagId(GeneralFunctions.MainBags)
            .SelectMany(b => b.Select(x => x));

        private static async Task DepositItems()
        {
            foreach (ChestRule rule in SavedSettings.Instance.DepositList.Distinct())
            {
                foreach (BagSlot playerSlot in InventoryManager.FilledSlots.Where(x => x.TrueItemId == rule.ItemId && x.ValidForChest()))
                {
                    Log.Information($"Moving Slot#{playerSlot.Slot} {playerSlot.Name} to FC Chest.");
                    if (!playerSlot.MoveToInventory(ChestSlots))
                    {
                        _isDone = true;
                        TreeRoot.Stop($"Couldn't find a destination slot for {rule.ItemId}. Is the FC Chest full?");
                        return;
                    }
                    await Coroutine.Sleep(1500);
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
                    if (!chestSlot.MoveToInventory(PlayerSlots))
                    {
                        _isDone = true;
                        TreeRoot.Stop($"Couldn't find a destination slot for {rule.ItemId}. Is the player inventory full?");
                        return;
                    }
                    await Coroutine.Sleep(1500);
                }
            }
        }

        public override void Stop()
        {
            _isDone = true;
            _root = null;
        }
    }
}