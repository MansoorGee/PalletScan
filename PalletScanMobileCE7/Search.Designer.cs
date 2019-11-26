namespace PalletScanMobileCE7
{
    partial class Search
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
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemDelete = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemClose = new System.Windows.Forms.MenuItem();
            this.palletInfoDataGrid = new System.Windows.Forms.DataGrid();
            this.itemsTableStyleDataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colIsManual = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelMessageBg = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNumOfRec = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colLocation = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panelMessageBg.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemEdit);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.MenuItems.Add(this.menuItemView);
            this.menuItemEdit.MenuItems.Add(this.menuItemDelete);
            this.menuItemEdit.MenuItems.Add(this.menuItem2);
            this.menuItemEdit.MenuItems.Add(this.menuItemClose);
            this.menuItemEdit.Text = "Edit";
            // 
            // menuItemView
            // 
            this.menuItemView.Text = "View Details";
            this.menuItemView.Click += new System.EventHandler(this.menuItemView_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Text = "Reset Pallet";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Text = "Close Form";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // palletInfoDataGrid
            // 
            this.palletInfoDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.palletInfoDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palletInfoDataGrid.Location = new System.Drawing.Point(4, 105);
            this.palletInfoDataGrid.Name = "palletInfoDataGrid";
            this.palletInfoDataGrid.Size = new System.Drawing.Size(310, 190);
            this.palletInfoDataGrid.TabIndex = 9;
            this.palletInfoDataGrid.TableStyles.Add(this.itemsTableStyleDataGridTableStyle);
            this.palletInfoDataGrid.DoubleClick += new System.EventHandler(this.palletInfoDataGrid_DoubleClick);
            // 
            // itemsTableStyleDataGridTableStyle
            // 
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.colLocation);
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.itemsTableStyleDataGridTableStyle.GridColumnStyles.Add(this.colIsManual);
            this.itemsTableStyleDataGridTableStyle.MappingName = "Items";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Serial #";
            this.dataGridTextBoxColumn2.MappingName = "Pallet";
            this.dataGridTextBoxColumn2.NullText = " ";
            this.dataGridTextBoxColumn2.Width = 71;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Item Name";
            this.dataGridTextBoxColumn1.MappingName = "Product name";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Update by";
            this.dataGridTextBoxColumn3.MappingName = "UpdatedBy";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 70;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "dd/MM/yyyy hh:mm tt";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Date Updated";
            this.dataGridTextBoxColumn4.MappingName = "DateUpdated";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 110;
            // 
            // colIsManual
            // 
            this.colIsManual.Format = "0:No;1:Yes";
            this.colIsManual.FormatInfo = null;
            this.colIsManual.HeaderText = "Is Manual";
            this.colIsManual.MappingName = "IsManual";
            this.colIsManual.Width = 70;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 20);
            this.label1.Text = "Search Serial(s):";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 65);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.DimGray;
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tbSearch.ForeColor = System.Drawing.Color.White;
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.MaxLength = 17;
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSearch.Size = new System.Drawing.Size(240, 55);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbPalletNo_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPalletNo_KeyPress);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(240, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 55);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DimGray;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(245, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 55);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 10);
            // 
            // panelMessageBg
            // 
            this.panelMessageBg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMessageBg.BackColor = System.Drawing.Color.Black;
            this.panelMessageBg.Controls.Add(this.labelMessage);
            this.panelMessageBg.Location = new System.Drawing.Point(0, 102);
            this.panelMessageBg.Name = "panelMessageBg";
            this.panelMessageBg.Size = new System.Drawing.Size(314, 155);
            this.panelMessageBg.Visible = false;
            this.panelMessageBg.Validated += new System.EventHandler(this.panelMessageBg_Validated);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(25, 81);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(264, 38);
            this.labelMessage.Text = "Please wait. Searching is in progress...";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lbNumOfRec);
            this.panel2.Controls.Add(this.lbTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 20);
            // 
            // lbNumOfRec
            // 
            this.lbNumOfRec.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbNumOfRec.ForeColor = System.Drawing.Color.White;
            this.lbNumOfRec.Location = new System.Drawing.Point(210, 0);
            this.lbNumOfRec.Name = "lbNumOfRec";
            this.lbNumOfRec.Size = new System.Drawing.Size(100, 20);
            this.lbNumOfRec.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(94, 20);
            this.lbTitle.Text = "Check Serials:";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(4, 295);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(314, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(4, 275);
            // 
            // colLocation
            // 
            this.colLocation.Format = "";
            this.colLocation.FormatInfo = null;
            this.colLocation.HeaderText = "Location";
            this.colLocation.MappingName = "Location";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Controls.Add(this.panelMessageBg);
            this.Controls.Add(this.palletInfoDataGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.Menu = this.mainMenu1;
            this.Name = "Search";
            this.Text = "Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Search_Load);
            this.Activated += new System.EventHandler(this.Search_Activated);
            this.panel1.ResumeLayout(false);
            this.panelMessageBg.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid palletInfoDataGrid;
        private System.Windows.Forms.DataGridTableStyle itemsTableStyleDataGridTableStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemDelete;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemClose;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelMessageBg;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNumOfRec;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn colIsManual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridTextBoxColumn colLocation;

    }
}