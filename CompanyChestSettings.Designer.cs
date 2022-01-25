using System.ComponentModel;

namespace CompanyChest
{
    partial class CompanyChestSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgDeposit = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.labelWithdraw = new System.Windows.Forms.Label();
            this.btnDepositAdd = new System.Windows.Forms.Button();
            this.btnDepositDelete = new System.Windows.Forms.Button();
            this.btnWithdrawDelete = new System.Windows.Forms.Button();
            this.btnWithdrawAdd = new System.Windows.Forms.Button();
            this.dgWithdraw = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositEnabled = new System.Windows.Forms.CheckBox();
            this.withdrawEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdraw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDeposit
            // 
            this.dgDeposit.AllowUserToAddRows = false;
            this.dgDeposit.AllowUserToDeleteRows = false;
            this.dgDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemName});
            this.dgDeposit.Location = new System.Drawing.Point(12, 31);
            this.dgDeposit.Name = "dgDeposit";
            this.dgDeposit.Size = new System.Drawing.Size(305, 428);
            this.dgDeposit.TabIndex = 0;
            // 
            // ItemId
            // 
            this.ItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.FillWeight = 500F;
            this.ItemId.HeaderText = "ID";
            this.ItemId.MinimumWidth = 100;
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.FillWeight = 250F;
            this.ItemName.HeaderText = "Name";
            this.ItemName.MinimumWidth = 150;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 150;
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new System.Drawing.Point(9, 9);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(43, 13);
            this.labelDeposit.TabIndex = 2;
            this.labelDeposit.Text = "Deposit";
            // 
            // labelWithdraw
            // 
            this.labelWithdraw.AutoSize = true;
            this.labelWithdraw.Location = new System.Drawing.Point(352, 9);
            this.labelWithdraw.Name = "labelWithdraw";
            this.labelWithdraw.Size = new System.Drawing.Size(52, 13);
            this.labelWithdraw.TabIndex = 3;
            this.labelWithdraw.Text = "Withdraw";
            // 
            // btnDepositAdd
            // 
            this.btnDepositAdd.Location = new System.Drawing.Point(12, 465);
            this.btnDepositAdd.Name = "btnDepositAdd";
            this.btnDepositAdd.Size = new System.Drawing.Size(92, 25);
            this.btnDepositAdd.TabIndex = 4;
            this.btnDepositAdd.Text = "Add";
            this.btnDepositAdd.UseVisualStyleBackColor = true;
            this.btnDepositAdd.Click += new System.EventHandler(this.AddNewRule);
            // 
            // btnDepositDelete
            // 
            this.btnDepositDelete.Location = new System.Drawing.Point(110, 465);
            this.btnDepositDelete.Name = "btnDepositDelete";
            this.btnDepositDelete.Size = new System.Drawing.Size(92, 25);
            this.btnDepositDelete.TabIndex = 5;
            this.btnDepositDelete.Text = "Delete";
            this.btnDepositDelete.UseVisualStyleBackColor = true;
            this.btnDepositDelete.Click += new System.EventHandler(this.DeleteRule);
            // 
            // btnWithdrawDelete
            // 
            this.btnWithdrawDelete.Location = new System.Drawing.Point(453, 465);
            this.btnWithdrawDelete.Name = "btnWithdrawDelete";
            this.btnWithdrawDelete.Size = new System.Drawing.Size(92, 25);
            this.btnWithdrawDelete.TabIndex = 7;
            this.btnWithdrawDelete.Text = "Delete";
            this.btnWithdrawDelete.UseVisualStyleBackColor = true;
            this.btnWithdrawDelete.Click += new System.EventHandler(this.DeleteRule);
            // 
            // btnWithdrawAdd
            // 
            this.btnWithdrawAdd.Location = new System.Drawing.Point(355, 465);
            this.btnWithdrawAdd.Name = "btnWithdrawAdd";
            this.btnWithdrawAdd.Size = new System.Drawing.Size(92, 25);
            this.btnWithdrawAdd.TabIndex = 6;
            this.btnWithdrawAdd.Text = "Add";
            this.btnWithdrawAdd.UseVisualStyleBackColor = true;
            this.btnWithdrawAdd.Click += new System.EventHandler(this.AddNewRule);
            // 
            // dgWithdraw
            // 
            this.dgWithdraw.AllowUserToAddRows = false;
            this.dgWithdraw.AllowUserToDeleteRows = false;
            this.dgWithdraw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWithdraw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgWithdraw.Location = new System.Drawing.Point(355, 31);
            this.dgWithdraw.Name = "dgWithdraw";
            this.dgWithdraw.Size = new System.Drawing.Size(305, 428);
            this.dgWithdraw.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ItemId";
            this.dataGridViewTextBoxColumn1.FillWeight = 500F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn2.FillWeight = 250F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // depositEnabled
            // 
            this.depositEnabled.AutoSize = true;
            this.depositEnabled.Checked = true;
            this.depositEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depositEnabled.Location = new System.Drawing.Point(58, 8);
            this.depositEnabled.Name = "depositEnabled";
            this.depositEnabled.Size = new System.Drawing.Size(65, 17);
            this.depositEnabled.TabIndex = 9;
            this.depositEnabled.Text = "Enabled";
            this.depositEnabled.UseVisualStyleBackColor = true;
            // 
            // withdrawEnabled
            // 
            this.withdrawEnabled.AutoSize = true;
            this.withdrawEnabled.Checked = true;
            this.withdrawEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.withdrawEnabled.Location = new System.Drawing.Point(410, 8);
            this.withdrawEnabled.Name = "withdrawEnabled";
            this.withdrawEnabled.Size = new System.Drawing.Size(65, 17);
            this.withdrawEnabled.TabIndex = 10;
            this.withdrawEnabled.Text = "Enabled";
            this.withdrawEnabled.UseVisualStyleBackColor = true;
            // 
            // CompanyChestSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 498);
            this.Controls.Add(this.withdrawEnabled);
            this.Controls.Add(this.depositEnabled);
            this.Controls.Add(this.dgWithdraw);
            this.Controls.Add(this.btnWithdrawDelete);
            this.Controls.Add(this.btnWithdrawAdd);
            this.Controls.Add(this.btnDepositDelete);
            this.Controls.Add(this.btnDepositAdd);
            this.Controls.Add(this.labelWithdraw);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.dgDeposit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyChestSettings";
            this.ShowIcon = false;
            this.Text = "CompanyChestSettings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanyChestSettings_FormClosed);
            this.Load += new System.EventHandler(this.CompanyChestSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Label labelWithdraw;
        private System.Windows.Forms.Button btnDepositAdd;
        private System.Windows.Forms.Button btnDepositDelete;
        private System.Windows.Forms.Button btnWithdrawDelete;
        private System.Windows.Forms.Button btnWithdrawAdd;
        private System.Windows.Forms.DataGridView dgWithdraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox depositEnabled;
        private System.Windows.Forms.CheckBox withdrawEnabled;
    }
}