using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PalletScanMobile
{
    public partial class ItemsSummaryViewDialog : Form
    {
        public ItemsSummaryViewDialog()
        {
            InitializeComponent();
            // Attach event handlers to auto-hide controls.
            this.AttachVisibilityBindings(this.Controls);
        }
        public string PalletNum
        {
            get;
            set;
        }

        private void editMenuItemMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ItemsSummaryViewDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                this.AutoScrollPosition = new System.Drawing.Point(0, ((0 - this.AutoScrollPosition.Y)
                                - 16));
                e.Handled = true;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                this.AutoScrollPosition = new System.Drawing.Point(0, ((0 - this.AutoScrollPosition.Y)
                                + 16));
                e.Handled = true;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void ItemsSummaryViewDialog_Load(object sender, EventArgs e)
        {
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = new DBClass().GetItems(PalletNum); 
            //if (IsMatchedlabel1.Text.ToLower() == "true")
            //{
            //    IsMatchedlabel1.ForeColor = Color.Green;
            //    IsMatchedlabel1.Text = "Matched Successfully";
            //    dateUpdatedLabel.Text = "Match Date:";
            //}
            //else
            //{
            //    IsMatchedlabel1.ForeColor = Color.Red;
            //    IsMatchedlabel1.Text = "Not Matched";
            //    dateUpdatedLabel.Text = "Date Tried:";
            //}
            IsMatchedlabel.Visible = false;
            IsMatchedlabel1.Visible = false;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}