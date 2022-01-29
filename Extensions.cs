using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using LlamaLibrary.Logging;

namespace CompanyChest
{
    public static class Extensions
    {
        public static bool IsValidForChest(this BagSlot slot)
        {
            if (slot.SpiritBond > 0) return false;
            if (slot.Item.Untradeable) return false;

            return true;
        }

        public static async Task<bool> MoveToInventory(this BagSlot slot, IEnumerable<BagSlot> inventory)
        {
            if (!slot.IsValid || !slot.IsFilled || !slot.IsValidForChest()) return false;
            var invArray = inventory.ToArray();
            if (invArray.Contains(slot)) return true;
            if (!slot.GetSameItemSlot(invArray, out BagSlot destSlot)) return false;

            if (destSlot.IsFilled)
            {
                do
                {
                    if (CompanyChest.Log.IsEnabled(LogLevel.Debug))
                    {
                        uint destSlotCount = destSlot.IsValid && destSlot.IsFilled ? destSlot.Count : 0;
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"Move Slot#{slot.Slot}-{slot.EnglishName} to Slot#{destSlot.Slot}-");
                        sb.Append(destSlotCount > 0 ? $"{destSlot.EnglishName} x{destSlotCount}" : "Empty");
                        CompanyChest.Log.Debug(sb.ToString());
                    }
                    slot.Move(destSlot);
                    await Coroutine.Sleep(SavedSettings.Instance.MoveDelay);
                } while (slot.IsValid && slot.IsFilled && slot.GetSameItemSlot(invArray, out destSlot));

                return !slot.IsValid || !slot.IsFilled;
            }

            if (CompanyChest.Log.IsEnabled(LogLevel.Debug))
            {
                uint destSlotCount = destSlot.IsValid && destSlot.IsFilled ? destSlot.Count : 0;
                StringBuilder sb = new StringBuilder();
                sb.Append($"Move Slot#{slot.Slot}-{slot.EnglishName} to Slot#{destSlot.Slot}-");
                sb.Append(destSlotCount > 0 ? $"{destSlot.EnglishName} x{destSlotCount}" : "Empty");
                sb.Append(" : Should Be Empty!");
                CompanyChest.Log.Debug(sb.ToString());
            }
            slot.Move(destSlot);
            await Coroutine.Sleep(SavedSettings.Instance.MoveDelay);
            return true;
        }

        private static bool GetSameItemSlot(this BagSlot slot, IReadOnlyList<BagSlot> inventory, out BagSlot destSlot)
        {
            destSlot = null;
            int freeSlotIndex = -1;
            for (var i = 0; i < inventory.Count; i++)
            {
                BagSlot invSlot = inventory[i];
                if (!invSlot.IsValid) continue;
                if (!invSlot.IsFilled)
                {
                    if (freeSlotIndex < 0) freeSlotIndex = i;
                    continue;
                }
                if (invSlot.TrueItemId != slot.TrueItemId) continue;
                if (invSlot.Count >= invSlot.Item.StackSize) continue;
                destSlot = invSlot;
                CompanyChest.Log.Debug($"Found occupied destination for {slot.EnglishName}! Slot#{destSlot.Slot} in Bag {destSlot.BagId}");
                return true;
            }

            if (freeSlotIndex < 0)
            {
                CompanyChest.Log.Debug($"Couldn't find a destination for {slot.EnglishName}. Destination inventory full?");
                return false;
            }
            destSlot = inventory[freeSlotIndex];
            CompanyChest.Log.Debug($"Found unoccupied destination for {slot.EnglishName}! Slot#{destSlot.Slot} in Bag {destSlot.BagId}");
            return true;
        }
    }
}