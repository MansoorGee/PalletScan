namespace PalletScanMobileCE7
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemStats = new System.Windows.Forms.MenuItem();
            this.menuItemTestServce = new System.Windows.Forms.MenuItem();
            this.menuItemUploadData = new System.Windows.Forms.MenuItem();
            this.menuItemResetUsers = new System.Windows.Forms.MenuItem();
            this.menuItemResetData = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemLoggoff = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemShrink = new System.Windows.Forms.MenuItem();
            this.menuItemGetUnmatched = new System.Windows.Forms.MenuItem();
            this.menuItemRecoverItems = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemSearch = new System.Windows.Forms.MenuItem();
            this.menuItemChangePassword = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPalletNo = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFail = new System.Windows.Forms.Panel();
            this.lbFailText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelSuccess = new System.Windows.Forms.Panel();
            this.lbSuccessText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelWait = new System.Windows.Forms.Panel();
            this.lblWait = new System.Windows.Forms.Label();
            this.lbDBName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelFail.SuspendLayout();
            this.panelSuccess.SuspendLayout();
            this.panelWait.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemFile);
            this.mainMenu1.MenuItems.Add(this.menuItemEdit);
            // 
            // menuItemFile
            // 
            this.menuItemFile.MenuItems.Add(this.menuItemStats);
            this.menuItemFile.MenuItems.Add(this.menuItemTestServce);
            this.menuItemFile.MenuItems.Add(this.menuItemUploadData);
            this.menuItemFile.MenuItems.Add(this.menuItemResetUsers);
            this.menuItemFile.MenuItems.Add(this.menuItemResetData);
            this.menuItemFile.MenuItems.Add(this.menuItem5);
            this.menuItemFile.MenuItems.Add(this.menuItemLoggoff);
            this.menuItemFile.MenuItems.Add(this.menuItem2);
            this.menuItemFile.MenuItems.Add(this.menuItem1);
            this.menuItemFile.MenuItems.Add(this.menuItemShrink);
            this.menuItemFile.MenuItems.Add(this.menuItemGetUnmatched);
            this.menuItemFile.MenuItems.Add(this.menuItemRecoverItems);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemStats
            // 
            this.menuItemStats.Text = "Statistics";
            this.menuItemStats.Click += new System.EventHandler(this.menuItemStats_Click);
            // 
            // menuItemTestServce
            // 
            this.menuItemTestServce.Text = "Test Service";
            this.menuItemTestServce.Click += new System.EventHandler(this.menuItemTestServce_Click);
            // 
            // menuItemUploadData
            // 
            this.menuItemUploadData.Text = "Upload Data";
            this.menuItemUploadData.Click += new System.EventHandler(this.menuItemUploadData_Click);
            // 
            // menuItemResetUsers
            // 
            this.menuItemResetUsers.Text = "Reset Users";
            this.menuItemResetUsers.Click += new System.EventHandler(this.menuItemResetUsers_Click);
            // 
            // menuItemResetData
            // 
            this.menuItemResetData.Text = "Reset Data";
            this.menuItemResetData.Click += new System.EventHandler(this.menuItemResetData_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "-";
            // 
            // menuItemLoggoff
            // 
            this.menuItemLoggoff.Text = "Logoff";
            this.menuItemLoggoff.Click += new System.EventHandler(this.menuItemLoggoff_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "E&xit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "-";
            // 
            // menuItemShrink
            // 
            this.menuItemShrink.Text = "Shrink DB";
            this.menuItemShrink.Click += new System.EventHandler(this.menuItemShrink_Click);
            // 
            // menuItemGetUnmatched
            // 
            this.menuItemGetUnmatched.Text = "Get Unmatched Data";
            this.menuItemGetUnmatched.Click += new System.EventHandler(this.menuItemGetUnmatched_Click);
            // 
            // menuItemRecoverItems
            // 
            this.menuItemRecoverItems.Text = "Recover Items";
            this.menuItemRecoverItems.Click += new System.EventHandler(this.menuItemRecoverItems_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.MenuItems.Add(this.menuItemSearch);
            this.menuItemEdit.MenuItems.Add(this.menuItemChangePassword);
            this.menuItemEdit.Text = "Edit";
            // 
            // menuItemSearch
            // 
            this.menuItemSearch.Text = "Search";
            this.menuItemSearch.Click += new System.EventHandler(this.menuItemSearch_Click);
            // 
            // menuItemChangePassword
            // 
            this.menuItemChangePassword.Text = "Change Password";
            this.menuItemChangePassword.Click += new System.EventHandler(this.menuItemChangePassword_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 20);
            this.label1.Text = "Enter Serial #:";
            // 
            // tbPalletNo
            // 
            this.tbPalletNo.BackColor = System.Drawing.Color.Black;
            this.tbPalletNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPalletNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPalletNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tbPalletNo.ForeColor = System.Drawing.Color.White;
            this.tbPalletNo.Location = new System.Drawing.Point(0, 20);
            this.tbPalletNo.MaxLength = 17;
            this.tbPalletNo.Name = "tbPalletNo";
            this.tbPalletNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPalletNo.Size = new System.Drawing.Size(310, 31);
            this.tbPalletNo.TabIndex = 1;
            this.tbPalletNo.TextChanged += new System.EventHandler(this.tbPalletNo_TextChanged);
            this.tbPalletNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPalletNo_KeyPress);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.DimGray;
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsert.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.Location = new System.Drawing.Point(0, 110);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(310, 35);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Search Pallet";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 145);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.tbLocation);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 55);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.tbPalletNo);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 55);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panelFail);
            this.panel2.Controls.Add(this.panelSuccess);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 150);
            // 
            // panelFail
            // 
            this.panelFail.BackColor = System.Drawing.Color.Black;
            this.panelFail.Controls.Add(this.lbFailText);
            this.panelFail.Controls.Add(this.label2);
            this.panelFail.Controls.Add(this.pictureBox2);
            this.panelFail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFail.Location = new System.Drawing.Point(0, 55);
            this.panelFail.Name = "panelFail";
            this.panelFail.Size = new System.Drawing.Size(310, 45);
            this.panelFail.Visible = false;
            // 
            // lbFailText
            // 
            this.lbFailText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFailText.ForeColor = System.Drawing.Color.White;
            this.lbFailText.Location = new System.Drawing.Point(34, 10);
            this.lbFailText.Name = "lbFailText";
            this.lbFailText.Size = new System.Drawing.Size(276, 35);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 10);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // panelSuccess
            // 
            this.panelSuccess.BackColor = System.Drawing.Color.Black;
            this.panelSuccess.Controls.Add(this.lbSuccessText);
            this.panelSuccess.Controls.Add(this.pictureBox1);
            this.panelSuccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuccess.Location = new System.Drawing.Point(0, 10);
            this.panelSuccess.Name = "panelSuccess";
            this.panelSuccess.Size = new System.Drawing.Size(310, 45);
            this.panelSuccess.Visible = false;
            // 
            // lbSuccessText
            // 
            this.lbSuccessText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSuccessText.ForeColor = System.Drawing.Color.White;
            this.lbSuccessText.Location = new System.Drawing.Point(36, 0);
            this.lbSuccessText.Name = "lbSuccessText";
            this.lbSuccessText.Size = new System.Drawing.Size(274, 45);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 10);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(4, 295);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(314, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(4, 295);
            // 
            // panelWait
            // 
            this.panelWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWait.BackColor = System.Drawing.Color.Black;
            this.panelWait.Controls.Add(this.lblWait);
            this.panelWait.Location = new System.Drawing.Point(0, 0);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(311, 280);
            this.panelWait.Visible = false;
            // 
            // lblWait
            // 
            this.lblWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblWait.ForeColor = System.Drawing.Color.White;
            this.lblWait.Location = new System.Drawing.Point(25, 75);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(264, 75);
            this.lblWait.Text = "Please wait. Resetting the data is in progress...";
            this.lblWait.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbDBName
            // 
            this.lbDBName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbDBName.Location = new System.Drawing.Point(4, 275);
            this.lbDBName.Name = "lbDBName";
            this.lbDBName.Size = new System.Drawing.Size(310, 20);
            this.lbDBName.Text = "label5";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 20);
            this.label5.Text = "Enter Location:";
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.Color.Black;
            this.tbLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tbLocation.ForeColor = System.Drawing.Color.White;
            this.tbLocation.Location = new System.Drawing.Point(0, 20);
            this.tbLocation.MaxLength = 17;
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLocation.Size = new System.Drawing.Size(310, 31);
            this.tbLocation.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.Controls.Add(this.lbDBName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelWait);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Home";
            this.Text = "Pallet Scan - Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.Closed += new System.EventHandler(this.Home_Closed);
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Home_Closing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelFail.ResumeLayout(false);
            this.panelSuccess.ResumeLayout(false);
            this.panelWait.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPalletNo;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFail;
        private System.Windows.Forms.Panel panelSuccess;
        private System.Windows.Forms.Label lbFailText;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbSuccessText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuItem menuItemStats;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItemTestServce;
        private System.Windows.Forms.MenuItem menuItemUploadData;
        private System.Windows.Forms.MenuItem menuItemLoggoff;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemChangePassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuItem menuItemResetData;
        private System.Windows.Forms.MenuItem menuItemShrink;
        private System.Windows.Forms.MenuItem menuItemGetUnmatched;
        private System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.MenuItem menuItemRecoverItems;
        private System.Windows.Forms.Label lbDBName;
        private System.Windows.Forms.MenuItem menuItemResetUsers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLocation;
    }
}

