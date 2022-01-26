using ff14bot.Managers;

namespace CompanyChest
{
    public static class Extensions
    {
        public static bool ValidForChest(this BagSlot slot)
        {
            if (slot.SpiritBond > 0) return false;
            if (slot.Item.Untradeable) return false;

            return true;
        }
    }
}