using System;
using System.ComponentModel;
using System.IO;
using ff14bot.Helpers;
using ff14bot.Managers;

namespace CompanyChest
{
    public class SavedSettings : JsonSettings
    {
        public SavedSettings()
            : base(FilePath)
        {
        }

        private static string FilePath => Path.Combine(SettingsPath, "CompanyChestSettings.json");

        private static SavedSettings _settings;

        public static SavedSettings Instance => _settings ?? (_settings = new SavedSettings());

        private BindingList<ChestRule> _withdrawList;

        private BindingList<ChestRule> _depositList;

        public BindingList<ChestRule> WithdrawList
        {
            get => _withdrawList ?? (_withdrawList = new BindingList<ChestRule>());
            set
            {
                if (_withdrawList == value) return;

                _withdrawList = value;
                Save();
            }
        }
        
        public BindingList<ChestRule> DepositList
        {
            get => _depositList ?? (_depositList = new BindingList<ChestRule>());
            set
            {
                if (_depositList == value) return;

                _depositList = value;
                Save();
            }
        }
    }

    public class ChestRule : IEquatable<ChestRule>
    {
        public uint ItemId { get; set; }

        private uint RawItemId
        {
            get
            {
                const int colOffset = 500_000;
                if (ItemId > HQOffset) return ItemId - HQOffset;
                if (ItemId > colOffset) return ItemId - colOffset;
                return ItemId;
            }
        }

        private const int HQOffset = 1_000_000;

        public string ItemName
        {
            get
            {
                if (ItemId == 0) return "UNK";

                try
                {
                    return DataManager.GetItem(RawItemId, ItemId > HQOffset).EnglishName;
                }
                catch (Exception)
                {
                    CompanyChest.Log.Error($"Couldn't find name for TrueItemId {ItemId}. RawId: {RawItemId}.");
                    return "UNK";
                }
            }
        }

        public ChestRule(uint itemId)
        {
            ItemId = itemId;
        }

        public bool Equals(ChestRule other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ItemId == other.ItemId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChestRule)obj);
        }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => (int)ItemId;
    }
}