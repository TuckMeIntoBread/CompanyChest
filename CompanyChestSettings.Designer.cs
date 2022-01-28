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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.dgWithdraw = new System.Windows.Forms.DataGridView();
            this.dgWithdrawIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgWithdrawNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWithdrawDelete = new System.Windows.Forms.Button();
            this.btnWithdrawAdd = new System.Windows.Forms.Button();
            this.btnDepositDelete = new System.Windows.Forms.Button();
            this.btnDepositAdd = new System.Windows.Forms.Button();
            this.labelWithdraw = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.dgDeposit = new System.Windows.Forms.DataGridView();
            this.dgDepositIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDepositNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.propGridSettings = new System.Windows.Forms.PropertyGrid();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeposit)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Location = new System.Drawing.Point(4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(674, 522);
            this.tabControl.TabIndex = 11;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.dgWithdraw);
            this.tabMain.Controls.Add(this.btnWithdrawDelete);
            this.tabMain.Controls.Add(this.btnWithdrawAdd);
            this.tabMain.Controls.Add(this.btnDepositDelete);
            this.tabMain.Controls.Add(this.btnDepositAdd);
            this.tabMain.Controls.Add(this.labelWithdraw);
            this.tabMain.Controls.Add(this.labelDeposit);
            this.tabMain.Controls.Add(this.dgDeposit);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(666, 496);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // dgWithdraw
            // 
            this.dgWithdraw.AllowUserToAddRows = false;
            this.dgWithdraw.AllowUserToDeleteRows = false;
            this.dgWithdraw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWithdraw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgWithdrawIdColumn, this.dgWithdrawNameColumn });
            this.dgWithdraw.Location = new System.Drawing.Point(352, 30);
            this.dgWithdraw.Name = "dgWithdraw";
            this.dgWithdraw.Size = new System.Drawing.Size(305, 428);
            this.dgWithdraw.TabIndex = 18;
            // 
            // dgWithdrawIdColumn
            // 
            this.dgWithdrawIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgWithdrawIdColumn.DataPropertyName = "ItemId";
            this.dgWithdrawIdColumn.FillWeight = 500F;
            this.dgWithdrawIdColumn.HeaderText = "ID";
            this.dgWithdrawIdColumn.MinimumWidth = 100;
            this.dgWithdrawIdColumn.Name = "dgWithdrawIdColumn";
            this.dgWithdrawIdColumn.ReadOnly = true;
            // 
            // dgWithdrawNameColumn
            // 
            this.dgWithdrawNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgWithdrawNameColumn.DataPropertyName = "ItemName";
            this.dgWithdrawNameColumn.FillWeight = 250F;
            this.dgWithdrawNameColumn.HeaderText = "Name";
            this.dgWithdrawNameColumn.MinimumWidth = 150;
            this.dgWithdrawNameColumn.Name = "dgWithdrawNameColumn";
            this.dgWithdrawNameColumn.ReadOnly = true;
            this.dgWithdrawNameColumn.Width = 150;
            // 
            // btnWithdrawDelete
            // 
            this.btnWithdrawDelete.Location = new System.Drawing.Point(450, 464);
            this.btnWithdrawDelete.Name = "btnWithdrawDelete";
            this.btnWithdrawDelete.Size = new System.Drawing.Size(92, 25);
            this.btnWithdrawDelete.TabIndex = 17;
            this.btnWithdrawDelete.Text = "Delete";
            this.btnWithdrawDelete.UseVisualStyleBackColor = true;
            this.btnWithdrawDelete.Click += new System.EventHandler(this.DeleteRule);
            // 
            // btnWithdrawAdd
            // 
            this.btnWithdrawAdd.Location = new System.Drawing.Point(352, 464);
            this.btnWithdrawAdd.Name = "btnWithdrawAdd";
            this.btnWithdrawAdd.Size = new System.Drawing.Size(92, 25);
            this.btnWithdrawAdd.TabIndex = 16;
            this.btnWithdrawAdd.Text = "Add";
            this.btnWithdrawAdd.UseVisualStyleBackColor = true;
            this.btnWithdrawAdd.Click += new System.EventHandler(this.AddNewRule);
            // 
            // btnDepositDelete
            // 
            this.btnDepositDelete.Location = new System.Drawing.Point(107, 464);
            this.btnDepositDelete.Name = "btnDepositDelete";
            this.btnDepositDelete.Size = new System.Drawing.Size(92, 25);
            this.btnDepositDelete.TabIndex = 15;
            this.btnDepositDelete.Text = "Delete";
            this.btnDepositDelete.UseVisualStyleBackColor = true;
            this.btnDepositDelete.Click += new System.EventHandler(this.DeleteRule);
            // 
            // btnDepositAdd
            // 
            this.btnDepositAdd.Location = new System.Drawing.Point(9, 464);
            this.btnDepositAdd.Name = "btnDepositAdd";
            this.btnDepositAdd.Size = new System.Drawing.Size(92, 25);
            this.btnDepositAdd.TabIndex = 14;
            this.btnDepositAdd.Text = "Add";
            this.btnDepositAdd.UseVisualStyleBackColor = true;
            this.btnDepositAdd.Click += new System.EventHandler(this.AddNewRule);
            // 
            // labelWithdraw
            // 
            this.labelWithdraw.AutoSize = true;
            this.labelWithdraw.Location = new System.Drawing.Point(349, 8);
            this.labelWithdraw.Name = "labelWithdraw";
            this.labelWithdraw.Size = new System.Drawing.Size(52, 13);
            this.labelWithdraw.TabIndex = 13;
            this.labelWithdraw.Text = "Withdraw";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new System.Drawing.Point(6, 8);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(43, 13);
            this.labelDeposit.TabIndex = 12;
            this.labelDeposit.Text = "Deposit";
            // 
            // dgDeposit
            // 
            this.dgDeposit.AllowUserToAddRows = false;
            this.dgDeposit.AllowUserToDeleteRows = false;
            this.dgDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgDepositIdColumn, this.dgDepositNameColumn });
            this.dgDeposit.Location = new System.Drawing.Point(9, 30);
            this.dgDeposit.Name = "dgDeposit";
            this.dgDeposit.Size = new System.Drawing.Size(305, 428);
            this.dgDeposit.TabIndex = 11;
            // 
            // dgDepositIdColumn
            // 
            this.dgDepositIdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDepositIdColumn.DataPropertyName = "ItemId";
            this.dgDepositIdColumn.FillWeight = 500F;
            this.dgDepositIdColumn.HeaderText = "ID";
            this.dgDepositIdColumn.MinimumWidth = 100;
            this.dgDepositIdColumn.Name = "dgDepositIdColumn";
            this.dgDepositIdColumn.ReadOnly = true;
            // 
            // dgDepositNameColumn
            // 
            this.dgDepositNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDepositNameColumn.DataPropertyName = "ItemName";
            this.dgDepositNameColumn.FillWeight = 250F;
            this.dgDepositNameColumn.HeaderText = "Name";
            this.dgDepositNameColumn.MinimumWidth = 150;
            this.dgDepositNameColumn.Name = "dgDepositNameColumn";
            this.dgDepositNameColumn.ReadOnly = true;
            this.dgDepositNameColumn.Width = 150;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.propGridSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(666, 496);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // propGridSettings
            // 
            this.propGridSettings.Location = new System.Drawing.Point(6, 6);
            this.propGridSettings.Name = "propGridSettings";
            this.propGridSettings.Size = new System.Drawing.Size(654, 484);
            this.propGridSettings.TabIndex = 0;
            // 
            // CompanyChestSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 529);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyChestSettings";
            this.ShowIcon = false;
            this.Text = "CompanyChestSettings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanyChestSettings_FormClosed);
            this.Load += new System.EventHandler(this.CompanyChestSettings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeposit)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView dgWithdraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgWithdrawIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgWithdrawNameColumn;
        private System.Windows.Forms.Button btnWithdrawDelete;
        private System.Windows.Forms.Button btnWithdrawAdd;
        private System.Windows.Forms.Button btnDepositDelete;
        private System.Windows.Forms.Button btnDepositAdd;
        private System.Windows.Forms.Label labelWithdraw;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.DataGridView dgDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDepositIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDepositNameColumn;
        private System.Windows.Forms.PropertyGrid propGridSettings;
    }
}