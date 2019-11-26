namespace PalletScanMobileCE7
{
    partial class ItemsSummaryViewDialog
    {
        public void AttachVisibilityBindings(ControlCollection controls)
        {
            for (int i = 0; (i < controls.Count); i = (i + 1))
            {
                if ((controls[i].DataBindings["Visible"] != null))
                {
                    // Attach event handlers to auto-hide controls.
                    controls[i].DataBindings["Visible"].Format += new System.Windows.Forms.ConvertEventHandler(this.Visibility_Format);
                    controls[i].DataBindings["Visible"].DataSourceUpdateMode = System.Windows.Forms.DataSourceUpdateMode.Never;
                }
            }

        }
    
        public void Visibility_Format(object sender, System.Windows.Forms.ConvertEventArgs e)
        {
            if ((e.Value == System.DBNull.Value))
            {
                e.Value = false;
            }
            else
            {
                e.Value = true;
            }

        }
    
        public static ItemsSummaryViewDialog Instance(System.Windows.Forms.BindingSource bindingSource)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            if ((defaultInstance == null))
            {
                defaultInstance = new PalletScanMobileCE7.ItemsSummaryViewDialog();
                defaultInstance.itemsBindingSource.DataSource = bindingSource;
            }
            defaultInstance.AutoScrollPosition = new System.Drawing.Point(0, 0);
            defaultInstance.itemsBindingSource.Position = bindingSource.Position;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            return defaultInstance;
        }
    
        private static ItemsSummaryViewDialog defaultInstance;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label item_numberLabel;
            System.Windows.Forms.Label product_nameLabel;
            System.Windows.Forms.Label configurationLabel;
            System.Windows.Forms.Label sizeLabel;
            System.Windows.Forms.Label colorLabel;
            System.Windows.Forms.Label warehouseLabel;
            System.Windows.Forms.Label batch_numberLabel;
            System.Windows.Forms.Label locationLabel;
            System.Windows.Forms.Label serial_numberLabel;
            System.Windows.Forms.Label available_physicalLabel;
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.palletScanDS = new PalletScanMobileCE7.PalletScanDS();
            this.dateUpdatedLabel = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.item_numberLabel1 = new System.Windows.Forms.Label();
            this.product_nameLabel1 = new System.Windows.Forms.Label();
            this.configurationLabel1 = new System.Windows.Forms.Label();
            this.sizeLabel1 = new System.Windows.Forms.Label();
            this.colorLabel1 = new System.Windows.Forms.Label();
            this.warehouseLabel1 = new System.Windows.Forms.Label();
            this.batch_numberLabel1 = new System.Windows.Forms.Label();
            this.locationLabel1 = new System.Windows.Forms.Label();
            this.serial_numberLabel1 = new System.Windows.Forms.Label();
            this.available_physicalLabel1 = new System.Windows.Forms.Label();
            this.dateUpdatedLabel1 = new System.Windows.Forms.Label();
            this.topBorderPanel = new System.Windows.Forms.Panel();
            this.leftBorderPanel = new System.Windows.Forms.Panel();
            this.rightBorderPanel = new System.Windows.Forms.Panel();
            this.IsMatchedlabel1 = new System.Windows.Forms.Label();
            this.IsMatchedlabel = new System.Windows.Forms.Label();
            item_numberLabel = new System.Windows.Forms.Label();
            product_nameLabel = new System.Windows.Forms.Label();
            configurationLabel = new System.Windows.Forms.Label();
            sizeLabel = new System.Windows.Forms.Label();
            colorLabel = new System.Windows.Forms.Label();
            warehouseLabel = new System.Windows.Forms.Label();
            batch_numberLabel = new System.Windows.Forms.Label();
            locationLabel = new System.Windows.Forms.Label();
            serial_numberLabel = new System.Windows.Forms.Label();
            available_physicalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletScanDS)).BeginInit();
            this.SuspendLayout();
            // 
            // item_numberLabel
            // 
            item_numberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Item number", true));
            item_numberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            item_numberLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            item_numberLabel.Location = new System.Drawing.Point(4, 2);
            item_numberLabel.Name = "item_numberLabel";
            item_numberLabel.Size = new System.Drawing.Size(630, 16);
            item_numberLabel.Text = "Item number:";
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.palletScanDS;
            // 
            // palletScanDS
            // 
            this.palletScanDS.DataSetName = "PalletScanDS";
            this.palletScanDS.Prefix = "";
            this.palletScanDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // product_nameLabel
            // 
            product_nameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Product name", true));
            product_nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            product_nameLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            product_nameLabel.Location = new System.Drawing.Point(4, 38);
            product_nameLabel.Name = "product_nameLabel";
            product_nameLabel.Size = new System.Drawing.Size(630, 16);
            product_nameLabel.Text = "Product name:";
            // 
            // configurationLabel
            // 
            configurationLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Configuration", true));
            configurationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            configurationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            configurationLabel.Location = new System.Drawing.Point(4, 146);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new System.Drawing.Size(630, 16);
            configurationLabel.Text = "Configuration:";
            // 
            // sizeLabel
            // 
            sizeLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Size", true));
            sizeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            sizeLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            sizeLabel.Location = new System.Drawing.Point(4, 182);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new System.Drawing.Size(630, 16);
            sizeLabel.Text = "Size:";
            // 
            // colorLabel
            // 
            colorLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Color", true));
            colorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            colorLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            colorLabel.Location = new System.Drawing.Point(4, 218);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new System.Drawing.Size(630, 16);
            colorLabel.Text = "Color:";
            // 
            // warehouseLabel
            // 
            warehouseLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Warehouse", true));
            warehouseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            warehouseLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            warehouseLabel.Location = new System.Drawing.Point(4, 254);
            warehouseLabel.Name = "warehouseLabel";
            warehouseLabel.Size = new System.Drawing.Size(630, 16);
            warehouseLabel.Text = "Warehouse:";
            // 
            // batch_numberLabel
            // 
            batch_numberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Batch number", true));
            batch_numberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            batch_numberLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            batch_numberLabel.Location = new System.Drawing.Point(4, 290);
            batch_numberLabel.Name = "batch_numberLabel";
            batch_numberLabel.Size = new System.Drawing.Size(630, 16);
            batch_numberLabel.Text = "Batch number:";
            // 
            // locationLabel
            // 
            locationLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Location", true));
            locationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            locationLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            locationLabel.Location = new System.Drawing.Point(4, 326);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(630, 16);
            locationLabel.Text = "Location:";
            // 
            // serial_numberLabel
            // 
            serial_numberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Serial number", true));
            serial_numberLabel.Dock = System.Windows.Forms.DockStyle.Top;
            serial_numberLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            serial_numberLabel.Location = new System.Drawing.Point(4, 74);
            serial_numberLabel.Name = "serial_numberLabel";
            serial_numberLabel.Size = new System.Drawing.Size(630, 16);
            serial_numberLabel.Text = "Serial number (Pallet #):";
            // 
            // available_physicalLabel
            // 
            available_physicalLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Available physical", true));
            available_physicalLabel.Dock = System.Windows.Forms.DockStyle.Top;
            available_physicalLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            available_physicalLabel.Location = new System.Drawing.Point(4, 362);
            available_physicalLabel.Name = "available_physicalLabel";
            available_physicalLabel.Size = new System.Drawing.Size(630, 16);
            available_physicalLabel.Text = "Available physical:";
            // 
            // dateUpdatedLabel
            // 
            this.dateUpdatedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "DateUpdated", true));
            this.dateUpdatedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateUpdatedLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dateUpdatedLabel.Location = new System.Drawing.Point(4, 398);
            this.dateUpdatedLabel.Name = "dateUpdatedLabel";
            this.dateUpdatedLabel.Size = new System.Drawing.Size(630, 16);
            this.dateUpdatedLabel.Text = "Match Date:";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.menuItem4);
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Back";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Exit";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // item_numberLabel1
            // 
            this.item_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Item number", true));
            this.item_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Item number", true));
            this.item_numberLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.item_numberLabel1.Location = new System.Drawing.Point(4, 18);
            this.item_numberLabel1.Name = "item_numberLabel1";
            this.item_numberLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // product_nameLabel1
            // 
            this.product_nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Product name", true));
            this.product_nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Product name", true));
            this.product_nameLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.product_nameLabel1.Location = new System.Drawing.Point(4, 54);
            this.product_nameLabel1.Name = "product_nameLabel1";
            this.product_nameLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // configurationLabel1
            // 
            this.configurationLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Configuration", true));
            this.configurationLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Configuration", true));
            this.configurationLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configurationLabel1.Location = new System.Drawing.Point(4, 162);
            this.configurationLabel1.Name = "configurationLabel1";
            this.configurationLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // sizeLabel1
            // 
            this.sizeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Size", true));
            this.sizeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Size", true));
            this.sizeLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sizeLabel1.Location = new System.Drawing.Point(4, 198);
            this.sizeLabel1.Name = "sizeLabel1";
            this.sizeLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // colorLabel1
            // 
            this.colorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Color", true));
            this.colorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Color", true));
            this.colorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorLabel1.Location = new System.Drawing.Point(4, 234);
            this.colorLabel1.Name = "colorLabel1";
            this.colorLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // warehouseLabel1
            // 
            this.warehouseLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Warehouse", true));
            this.warehouseLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Warehouse", true));
            this.warehouseLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.warehouseLabel1.Location = new System.Drawing.Point(4, 270);
            this.warehouseLabel1.Name = "warehouseLabel1";
            this.warehouseLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // batch_numberLabel1
            // 
            this.batch_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Batch number", true));
            this.batch_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Batch number", true));
            this.batch_numberLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.batch_numberLabel1.Location = new System.Drawing.Point(4, 306);
            this.batch_numberLabel1.Name = "batch_numberLabel1";
            this.batch_numberLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // locationLabel1
            // 
            this.locationLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Location", true));
            this.locationLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Location", true));
            this.locationLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.locationLabel1.Location = new System.Drawing.Point(4, 342);
            this.locationLabel1.Name = "locationLabel1";
            this.locationLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // serial_numberLabel1
            // 
            this.serial_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Serial number", true));
            this.serial_numberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Serial number", true));
            this.serial_numberLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.serial_numberLabel1.Location = new System.Drawing.Point(4, 90);
            this.serial_numberLabel1.Name = "serial_numberLabel1";
            this.serial_numberLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // available_physicalLabel1
            // 
            this.available_physicalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "Available physical", true));
            this.available_physicalLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "Available physical", true));
            this.available_physicalLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.available_physicalLabel1.Location = new System.Drawing.Point(4, 378);
            this.available_physicalLabel1.Name = "available_physicalLabel1";
            this.available_physicalLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // dateUpdatedLabel1
            // 
            this.dateUpdatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "DateUpdated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd/MM/yyyy hh:mm:ss tt"));
            this.dateUpdatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "DateUpdated", true));
            this.dateUpdatedLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateUpdatedLabel1.Location = new System.Drawing.Point(4, 414);
            this.dateUpdatedLabel1.Name = "dateUpdatedLabel1";
            this.dateUpdatedLabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // topBorderPanel
            // 
            this.topBorderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBorderPanel.Location = new System.Drawing.Point(4, 0);
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.Size = new System.Drawing.Size(630, 2);
            // 
            // leftBorderPanel
            // 
            this.leftBorderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBorderPanel.Location = new System.Drawing.Point(0, 0);
            this.leftBorderPanel.Name = "leftBorderPanel";
            this.leftBorderPanel.Size = new System.Drawing.Size(4, 455);
            // 
            // rightBorderPanel
            // 
            this.rightBorderPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightBorderPanel.Location = new System.Drawing.Point(634, 0);
            this.rightBorderPanel.Name = "rightBorderPanel";
            this.rightBorderPanel.Size = new System.Drawing.Size(4, 455);
            // 
            // IsMatchedlabel1
            // 
            this.IsMatchedlabel1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "IsMatched", true));
            this.IsMatchedlabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemsBindingSource, "IsMatched", true));
            this.IsMatchedlabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsMatchedlabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IsMatchedlabel1.Location = new System.Drawing.Point(4, 126);
            this.IsMatchedlabel1.Name = "IsMatchedlabel1";
            this.IsMatchedlabel1.Size = new System.Drawing.Size(630, 20);
            // 
            // IsMatchedlabel
            // 
            this.IsMatchedlabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.itemsBindingSource, "IsMatched", true));
            this.IsMatchedlabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsMatchedlabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IsMatchedlabel.Location = new System.Drawing.Point(4, 110);
            this.IsMatchedlabel.Name = "IsMatchedlabel";
            this.IsMatchedlabel.Size = new System.Drawing.Size(630, 16);
            this.IsMatchedlabel.Text = "Status:";
            // 
            // ItemsSummaryViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.dateUpdatedLabel1);
            this.Controls.Add(this.dateUpdatedLabel);
            this.Controls.Add(this.available_physicalLabel1);
            this.Controls.Add(available_physicalLabel);
            this.Controls.Add(this.locationLabel1);
            this.Controls.Add(locationLabel);
            this.Controls.Add(this.batch_numberLabel1);
            this.Controls.Add(batch_numberLabel);
            this.Controls.Add(this.warehouseLabel1);
            this.Controls.Add(warehouseLabel);
            this.Controls.Add(this.colorLabel1);
            this.Controls.Add(colorLabel);
            this.Controls.Add(this.sizeLabel1);
            this.Controls.Add(sizeLabel);
            this.Controls.Add(this.configurationLabel1);
            this.Controls.Add(configurationLabel);
            this.Controls.Add(this.IsMatchedlabel1);
            this.Controls.Add(this.IsMatchedlabel);
            this.Controls.Add(this.serial_numberLabel1);
            this.Controls.Add(serial_numberLabel);
            this.Controls.Add(this.product_nameLabel1);
            this.Controls.Add(product_nameLabel);
            this.Controls.Add(this.item_numberLabel1);
            this.Controls.Add(item_numberLabel);
            this.Controls.Add(this.topBorderPanel);
            this.Controls.Add(this.leftBorderPanel);
            this.Controls.Add(this.rightBorderPanel);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ItemsSummaryViewDialog";
            this.Text = "Item Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItemsSummaryViewDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemsSummaryViewDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palletScanDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.Label item_numberLabel1;
        private System.Windows.Forms.Label product_nameLabel1;
        private System.Windows.Forms.Label configurationLabel1;
        private System.Windows.Forms.Label sizeLabel1;
        private System.Windows.Forms.Label colorLabel1;
        private System.Windows.Forms.Label warehouseLabel1;
        private System.Windows.Forms.Label batch_numberLabel1;
        private System.Windows.Forms.Label locationLabel1;
        private System.Windows.Forms.Label serial_numberLabel1;
        private System.Windows.Forms.Label available_physicalLabel1;
        private System.Windows.Forms.Label dateUpdatedLabel1;
        private System.Windows.Forms.Panel topBorderPanel;
        private System.Windows.Forms.Panel leftBorderPanel;
        private System.Windows.Forms.Panel rightBorderPanel;
        private PalletScanDS palletScanDS;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Label IsMatchedlabel1;
        private System.Windows.Forms.Label dateUpdatedLabel;
        private System.Windows.Forms.Label IsMatchedlabel;
    }
}