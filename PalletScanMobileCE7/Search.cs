using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PalletScanMobileCE7
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        void DataBind()
        {
            lbNumOfRec.Text = "";
            this.SuspendLayout();
            panelMessageBg.Visible = true;
            
            this.ResumeLayout();
            
            if (!string.IsNullOrEmpty(tbSearch.Text.Trim()))
            {
                DataTable dt = new DBClass().SearchItems(tbSearch.Text.Trim());
                palletInfoDataGrid.DataSource = dt;
                lbNumOfRec.Text = "Records:" + dt.Rows.Count.ToString();
                lbTitle.Text = "Found Serials:";
                if (dt.Rows.Count == 0)
                {
                    lbTitle.Text = "No Serials:";
                    MessageBox.Show("No pallet found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                }
            }
            else
                MessageBox.Show("Enter some text in the 'Search' textbox to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            //palletInfoDataGrid.Refresh();
            panelMessageBg.Visible = false; 
            tbSearch.Focus();
            
        }
        void ViewDetail()
        {
            if (palletInfoDataGrid.CurrentRowIndex >= 0)
            {
                ItemsSummaryViewDialog vr = new ItemsSummaryViewDialog();
                DataTable dt = (DataTable)palletInfoDataGrid.DataSource;
                string pallNo = dt.Rows[palletInfoDataGrid.CurrentRowIndex]["Pallet"].ToString();

                vr.PalletNum = pallNo;
                vr.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataBind();
            tbSearch.Text = tbSearch.Text.Trim().Replace("\r\n", "");
        }

        private void palletInfoDataGrid_DoubleClick(object sender, EventArgs e)
        {
            ViewDetail();
        }

        
        private void menuItemView_Click(object sender, EventArgs e)
        {
            ViewDetail();
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (palletInfoDataGrid.DataSource == null)
            {
                MessageBox.Show("There is no pallet to delete. First search an pallet and then use Delete.", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                return;
            }
            DataTable dt = (DataTable)palletInfoDataGrid.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no pallet to delete. First search an pallet and then use Delete.", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                return;
            }
            
            DataRow pallNo = dt.Rows[palletInfoDataGrid.CurrentRowIndex];

            if (MessageBox.Show("Do you want to reset count of pallet# " + pallNo["Pallet"].ToString() + "?", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Item dr = new Item();
                dr.SerialNumber = pallNo["Pallet"].ToString();
                dr.DateUpdated = DateTime.Now;
                dr.IsMatched = false;
                dr.ProcessByIT = false;
                dr.IsManualUpdated = false;

                if (new DBClass().UpdatePallet(dr,true) > 0)
                {
                    MessageBox.Show("PalletNo: " + pallNo["Pallet"] + " has been reset successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    DataBind();
                    
                }
            }
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              

        private void tbPalletNo_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                tbSearch.Text = tbSearch.Text.ToUpper();
                tbSearch.SelectionStart = tbSearch.Text.Length;
                if (tbSearch.Text == "\r\n")
                    tbSearch.Text = string.Empty;
            }
        }

        private void tbPalletNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataBind();
                tbSearch.Text.Replace("\r\n", "");
                e.Handled = false;
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            tbSearch.Focus();
            panelMessageBg.Left = panelMessageBg.Top = labelMessage.Left = labelMessage.Top = 0;
            panelMessageBg.Width = labelMessage.Width = this.Width;
            panelMessageBg.Height = this.Height;
        }

        private void panelMessageBg_Validated(object sender, EventArgs e)
        {
            

        }

        private void Search_Activated(object sender, EventArgs e)
        {
            if (AppVariables.RoleName == RoleType.Admin)
            {
                menuItemDelete.Enabled = true;
                menuItemView.Enabled = true;
            }
            else if (AppVariables.RoleName == RoleType.Supervisor)
            {
                menuItemDelete.Enabled = true;
                menuItemView.Enabled = true;
            }
            else if (AppVariables.RoleName == RoleType.Employee)
            {
                menuItemDelete.Enabled = false;
                menuItemView.Enabled = false;
            }
            tbSearch.Focus();  
        }

        
    }
}