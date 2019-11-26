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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime dtStart = new DateTime(dtpStart.Value.Year,
                dtpStart.Value.Month,
                dtpStart.Value.Day,
                dtpStartTime.Value.Hour,
                dtpStartTime.Value.Minute,
                0);
            DateTime dtEnd = new DateTime(dtpEnd.Value.Year,
                dtpEnd.Value.Month,
                dtpEnd.Value.Day,
                dtpEndTime.Value.Hour,
                dtpEndTime.Value.Minute,
                0);
            MessageBox.Show(
                new DBClass().GetStat(
                    dtStart,
                    dtEnd), 
                    "Statistics");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}