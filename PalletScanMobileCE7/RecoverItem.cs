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
    public partial class RecoverItem : Form
    {
        public RecoverItem()
        {
            InitializeComponent();
        }

        private void RecoverItem_Load(object sender, EventArgs e)
        {
            dataBound();
        }
        
        void dataBound()
        {
            DataTable dt = new DBClass().ItemsScanned();
            palletInfoDataGrid.DataSource = dt;
            lbItemsUmbatchedScanned.Text = "Total items scanned unmatched: "+dt.Rows.Count.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            new DBClass().RecoverDelAndInsert();

            MessageBox.Show("done");

            dataBound();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            new DBClass().RecoverItems();

            MessageBox.Show("done");

            dataBound();
        }

        private void palletInfoDataGrid_DoubleClick(object sender, EventArgs e)
        {

        }

        
    }
}