using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;

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
                    CompanyChest.Log.Debug($"Move {slot.DebugString()} to {destSlot.DebugString()}");
                    slot.Move(destSlot);
                    await Coroutine.Sleep(SavedSettings.Instance.MoveDelay);
                } while (slot.IsValid && slot.IsFilled && slot.GetSameItemSlot(invArray, out destSlot));

                return !slot.IsValid || !slot.IsFilled;
            }

            CompanyChest.Log.Debug($"Destination should be empty: Move {slot.DebugString()} to {destSlot.DebugString()}");
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

        private static string DebugString(this BagSlot slot)
        {
            uint slotCount = slot.IsValid && slot.IsFilled ? slot.Count : 0;
            return $"Slot#{slot.Slot}-{slot.EnglishName}-{(slotCount > 0 ? slotCount.ToString() : "Empty")}";
        }
    }
}