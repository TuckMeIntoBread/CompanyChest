using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ff14bot.Managers;
using LlamaLibrary.RemoteAgents;

namespace CompanyChest
{
    public partial class CompanyChestSettings : Form
    {
        public CompanyChestSettings()
        {
            InitializeComponent();
        }

        private static void SetDoubleBuffer(Control dataGridView, bool doublebuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dataGridView,
                new object[] { doublebuffered });
        }

        private static IEnumerable<DataGridViewRow> GetSelectedRows(DataGridView dgView)
        {
            var distinctRowSet = new HashSet<int>();
            foreach (DataGridViewCell selectedCell in dgView.SelectedCells)
            {
                distinctRowSet.Add(selectedCell.RowIndex);
            }

            foreach (int rowId in distinctRowSet)
            {
                yield return dgView.Rows[rowId];
            }
        }

        private void CompanyChestSettings_Load(object sender, EventArgs e)
        {
            dgDeposit.AutoGenerateColumns = false;
            dgWithdraw.AutoGenerateColumns = false;
            SetDoubleBuffer(dgDeposit, true);
            SetDoubleBuffer(dgWithdraw, true);

            _bsDeposit = new BindingSource(SavedSettings.Instance, "DepositList");
            dgDeposit.DataSource = _bsDeposit;

            _bsWithdraw = new BindingSource(SavedSettings.Instance, "WithdrawList");
            dgWithdraw.DataSource = _bsWithdraw;

            propGridSettings.SelectedObject = SavedSettings.Instance;

            HotkeyManager.Register("CompanyChestDeposit", Keys.F1, System.Windows.Input.ModifierKeys.None, HotkeyDepositRule);
            HotkeyManager.Register("CompanyChestWithdraw", Keys.F2, System.Windows.Input.ModifierKeys.None, HotkeyWithdrawRule);
        }

        private void CompanyChestSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotkeyManager.Unregister("CompanyChestWithdraw");
            HotkeyManager.Unregister("CompanyChestDeposit");
        }

        private static void HotkeyDepositRule(Hotkey obj)
        {
            if (HoveredItemRule(out ChestRule rule))
            {
                SavedSettings.Instance.DepositList.Add(rule);
                SavedSettings.Instance.Save();
            }
        }

        private static void HotkeyWithdrawRule(Hotkey obj)
        {
            if (HoveredItemRule(out ChestRule rule))
            {
                SavedSettings.Instance.WithdrawList.Add(rule);
                SavedSettings.Instance.Save();
            }
        }

        private static bool HoveredItemRule(out ChestRule rule)
        {
            CompanyChest.Log.Information($"Item Hover: {DataManager.GetItem(AgentItemDetail.Instance.HoverOverItemID)} {AgentItemDetail.Instance.HoverOverItemID}");
            uint itemId = AgentItemDetail.Instance.HoverOverItemID;
            rule = new ChestRule(itemId);
            return itemId > 0;
        }

        private BindingSource _bsDeposit;

        private BindingSource _bsWithdraw;

        private void AddNewRule(object sender, EventArgs e)
        {
            if (sender == btnDepositAdd)
            {
                SavedSettings.Instance.DepositList.Add(new ChestRule(0));
            }
            else if (sender == btnWithdrawAdd)
            {
                SavedSettings.Instance.WithdrawList.Add(new ChestRule(0));
            }

            SavedSettings.Instance.Save();
        }

        private void DeleteRule(object sender, EventArgs e)
        {
            IReadOnlyList<ChestRule> toDeleteList = null;
            BindingList<ChestRule> ruleList = null;
            if (sender == btnDepositDelete)
            {
                toDeleteList = GetSelectedRows(dgDeposit).Select(x => x.DataBoundItem as ChestRule).ToList();
                ruleList = SavedSettings.Instance.DepositList;
            }
            else if (sender == btnWithdrawDelete)
            {
                toDeleteList = GetSelectedRows(dgWithdraw).Select(x => x.DataBoundItem as ChestRule).ToList();
                ruleList = SavedSettings.Instance.WithdrawList;
            }

            if (toDeleteList == null || ruleList == null) return;

            int itemCount = toDeleteList.Count;
            if (itemCount == 0) return;

            DialogResult warningBox = MessageBox.Show(
                $"Are you sure you want to delete {itemCount} item(s)?",
                "Really Delete?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);
            if (warningBox != DialogResult.Yes) return;

            foreach (ChestRule rule in toDeleteList)
            {
                ruleList.Remove(rule);
            }

            SavedSettings.Instance.Save();
        }
    }
}