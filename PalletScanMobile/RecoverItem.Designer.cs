namespace PalletScanMobile
{
    partial class RecoverItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lbItemsUmbatchedScanned = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.palletInfoDataGrid = new System.Windows.Forms.DataGrid();
            this.itemsTableStyleDataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.SuspendLayout();
            // 
            // lbItemsUmbatchedScanned
            // 
            this.lbItemsUmbatchedScanned.Location = new System.Drawing.Point(3, 9);
            this.lbItemsUmbatchedScanned.Name = "lbItemsUmbatchedScanned";
            this.lbItemsUmbatchedScanned.Size = new System.Drawing.Size(295, 20);
            this.lbItemsUmbatchedScanned.Text = "label1";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(0, 32);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(146, 20);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete and Insert";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(152, 32);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(146, 20);
            this.btnRecover.TabIndex = 2;
            this.btnRecover.Text = "Recover Scanned Items";
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // palletInfoDataGrid
            // 
            this.palletInfoDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.palletInfoDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palletInfoDataGrid.Location = new System.Drawing.Point(0, 58);
            this.palletInfoDataGrid.Name = "palletInfoDataGrid";
            this.palletInfoDataGrid.Size = new System.Drawing.Size(638, 397);
            this.palletInfoDataGrid.TabIndex = 10;
            this.palletInfoDataGrid.TableStyles.Add(this.itemsTableStyleDataGridTableStyle);
            // 
            // itemsTableStyleDataGridTableStyle
            // 
            this.itemsTableStyleDataGridTableStyle.MappingName = "Items";
            // 
            // RecoverItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.palletInfoDataGrid);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbItemsUmbatchedScanned);
            this.Menu = this.mainMenu1;
            this.Name = "RecoverItem";
            this.Text = "RecoverItem";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RecoverItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbItemsUmbatchedScanned;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.DataGrid palletInfoDataGrid;
        private System.Windows.Forms.DataGridTableStyle itemsTableStyleDataGridTableStyle;
    }
}