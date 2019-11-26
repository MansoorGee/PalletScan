using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Net;
using PalletScanMobile.WebRefFGSync;

namespace PalletScanMobile
{
    public partial class Home : Form
    {
        string PrevSerialNum = string.Empty;
        public Login LoginForm { get; set; }
        DateTime? dtStart = null;

        public Home()
        {
            InitializeComponent();
                        
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbDBName.Text = new DBClass().getConn();

            tbPalletNo.Focus();
        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            panelFail.Visible = false;
            panelSuccess.Visible = false;
            panelFail.Refresh();
            panelSuccess.Refresh();

            if (!string.IsNullOrEmpty(tbPalletNo.Text.Trim()) && !string.IsNullOrEmpty(tbLocation.Text.Trim()))
            {
                dtStart = null;
                InsertPallet(tbPalletNo.Text.Trim(), tbLocation.Text.Trim(), true);
            }
            else
            {
                SystemSounds.Question.Play();
                tbPalletNo.Focus();
            }
        }

        private void tbLocation_TextChanged(object sender, EventArgs e)
        {
            if (tbLocation.Text.Length > 0)
            {
                tbLocation.Text = tbLocation.Text.ToUpper();
                tbLocation.SelectionStart = tbLocation.Text.Length;
                if (tbLocation.Text == "\r\n")
                {
                    tbLocation.Text = string.Empty;
                }
            }
        }

        private void tbPalletNo_TextChanged(object sender, EventArgs e)
        {            
            if (tbPalletNo.Text.Length > 0)
            {                
                tbPalletNo.Text = tbPalletNo.Text.ToUpper();
                tbPalletNo.SelectionStart = tbPalletNo.Text.Length;
                if (tbPalletNo.Text == "\r\n")
                {
                    tbPalletNo.Text = string.Empty;                    
                }
            }
        }

        private void tbLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!dtStart.HasValue)
            {
                dtStart = DateTime.Now;
            }

            if((int)e.KeyChar == (int)Keys.Enter)
            {
                TimeSpan ts = new TimeSpan();

                panelFail.Visible = false;
                panelSuccess.Visible = false;
                panelFail.Refresh();
                panelSuccess.Refresh();

                if (dtStart.HasValue)
                {
                    ts = DateTime.Now - dtStart.Value;
                    dtStart = null;
                    //MessageBox.Show("Number of Seconds Delay: " + ts.TotalMilliseconds.ToString());
                }

                if (!string.IsNullOrEmpty(tbPalletNo.Text.Trim()))
                {
                    /*if (e.KeyChar == (char)Keys.LineFeed)
                    {
                        if (!string.IsNullOrEmpty(PrevSerialNum))
                        {
                            InsertPallet(PrevSerialNum, false);
                            PrevSerialNum = string.Empty;
                        }
                    }
                    else*/

                    if (ts.TotalMilliseconds > 500)//if manually entered
                        InsertPallet(tbPalletNo.Text.Trim(), tbLocation.Text.Trim(), true);
                    else                            //if entered by scanner
                        InsertPallet(tbPalletNo.Text.Trim(), tbLocation.Text.Trim(), false);
                }
                else
                    SystemSounds.Question.Play();
                
                e.Handled = false;
            }
        }
        
        private void tbPalletNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
                tbLocation.Focus();
        }

        private void InsertPallet(string palletNum, string location ,bool isManualUpdated)
        {
            panelFail.SuspendLayout();
            panelSuccess.SuspendLayout();
            try
            {
                Item dr = new Item();
                dr.SerialNumber = palletNum;
                dr.Location = location;
                dr.IsMatched = true;
                dr.ProcessByIT = true;
                dr.DateUpdated = DateTime.Now;
                dr.UpdatedBy = AppVariables.UpdatedBy;
                dr.IsManualUpdated = isManualUpdated;
                dr.DeviceName = System.Net.Dns.GetHostName();
                PalletMatch rowsAffected = new DBClass().Search(dr);
                if (rowsAffected == PalletMatch.Matched)
                {
                    dr.IsMatched = true;
                    lbSuccessText.Text = palletNum + " has been matched successfully.";
                    panelSuccess.Visible = true;
                    panelFail.Visible = false;
                    
                    SystemSounds.Beep.Play();
                }
                else if (rowsAffected == PalletMatch.MatchedWrongLocation)
                {
                    lbFailText.Text = palletNum + " has been matched but Location is wrong.";
                    panelFail.Visible = true;
                    panelSuccess.Visible = false;

                    SystemSounds.Question.Play();
                }
                else
                {
                    lbFailText.Text = palletNum + " has not been matched.";
                    panelFail.Visible = true;
                    panelSuccess.Visible = false;

                    SystemSounds.Question.Play();
                }

                PrevSerialNum = palletNum;
                tbPalletNo.Text = tbLocation.Text = string.Empty;
                tbPalletNo.Focus();

                
                
            }
            catch (System.Data.SqlServerCe.SqlCeException exp)
            {
                if (exp.Message.StartsWith("A duplicate value cannot be inserted into a unique index."))
                {
                    MessageBox.Show("Serial# already inserted. Cannot insert again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    palletNum = string.Empty;
                    tbPalletNo.Focus();
                }
                else
                    MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                panelSuccess.Visible = false;
                panelFail.Visible = false;
            }
            panelFail.ResumeLayout();
            panelSuccess.ResumeLayout();
        }

        

        private void Home_Closed(object sender, EventArgs e)
        {
            
        }

        

        private void menuItemSearch_Click(object sender, EventArgs e)
        {
            panelSuccess.Visible = false;
            panelFail.Visible = false;

            Search frmSearch = new Search();
            frmSearch.ShowDialog();
        }

        private void Home_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();

        }

        private void menuItemStats_Click(object sender, EventArgs e)
        {
            panelSuccess.Visible = false;
            panelFail.Visible = false;

            Statistics frmStatistics = new Statistics();
            frmStatistics.Show();
        }

        private void menuItemLoggoff_Click(object sender, EventArgs e)
        {
            panelSuccess.Visible = false;
            panelFail.Visible = false;
            tbPalletNo.Text = string.Empty;
            dtStart = null;

            AppVariables.UpdatedBy = string.Empty;
            AppVariables.RoleName = RoleType.Employee;

            Login loginScreen = LoginForm;
            loginScreen.HomeForm = this;
            loginScreen.Show();

            this.Hide();
        }

        private void menuItemTestServce_Click(object sender, EventArgs e)
        {
            try
            {
                panelSuccess.Visible = false;
                panelFail.Visible = false;

                FGSyncService client = new FGSyncService();
                string strMsg = client.GetPing();
                SystemSounds.Beep.Play();
                MessageBox.Show(strMsg, "Testing Webservice");
                
            }
            catch (WebException exp)
            {
                string msg = string.Empty;
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                else
                    msg = exp.Message;

                MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void menuItemUploadData_Click(object sender, EventArgs e)
        {
            FGSyncService client = new FGSyncService();
            DBClass db = new DBClass();
            long lastSyncId = 0, dataLen = 0;
            int counted = 0, size = 50;
            bool result = false;
            
            panelSuccess.Visible = false;
            panelFail.Visible = false;

            try
            {
                long topSyncId = 0;//long.Parse("0" + db.GetOptions(Option.LastSyncId));
                List<WebRefFGSync.PalletEntity> data = db.GetFGData(topSyncId);
                List<WebRefFGSync.PalletEntity> dataChunks;
                dataLen = data.Count;

                while (dataLen > 0)
                {
                    dataChunks = data.Skip(counted).Take(size).ToList();
                    client.UpdateFGDesktop(dataChunks.ToArray(), out lastSyncId, out result);
                    dataLen -= size;
                    counted += size;
                }
                if (counted == 0)
                {
                    MessageBox.Show("All data has already been uploaded. No more new data to upload.", "Syncing Data",MessageBoxButtons.OK,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                }
                if (result)
                {
                    db.SaveOptions(Option.LastSyncId, lastSyncId.ToString());
                    MessageBox.Show("Data has been uploaded to server successfully", "Syncing Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            catch (WebException exp)
            {
                string msg = string.Empty;
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                else
                    msg = exp.Message;

                MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            this.Text = "FG: " + AppVariables.DeviceName + " / " + AppVariables.UpdatedBy;
            //if (menuItemFile.MenuItems.Contains(menuItemStats)) menuItemFile.MenuItems.Remove(menuItemStats);
            //if (menuItemFile.MenuItems.Contains(menuItemTestServce)) menuItemFile.MenuItems.Remove(menuItemTestServce);
            //if (menuItemFile.MenuItems.Contains(menuItemUploadData)) menuItemFile.MenuItems.Remove(menuItemUploadData);

            if (AppVariables.RoleName == RoleType.Admin)
            {
                menuItemStats.Enabled = true;
                if (!menuItemFile.MenuItems.Contains(menuItemTestServce)) menuItemFile.MenuItems.Add(menuItemTestServce);
                if (!menuItemFile.MenuItems.Contains(menuItemUploadData)) menuItemFile.MenuItems.Add(menuItemUploadData);
                if (!menuItemFile.MenuItems.Contains(menuItemResetUsers)) menuItemFile.MenuItems.Add(menuItemResetUsers);
                if (!menuItemFile.MenuItems.Contains(menuItemResetData)) menuItemFile.MenuItems.Add(menuItemResetData);
                if (!menuItemFile.MenuItems.Contains(menuItemShrink)) menuItemFile.MenuItems.Add(menuItemShrink);
                if (!menuItemFile.MenuItems.Contains(menuItemGetUnmatched)) menuItemFile.MenuItems.Add(menuItemGetUnmatched);
                if (!menuItemEdit.MenuItems.Contains(menuItemChangePassword)) menuItemEdit.MenuItems.Add(menuItemChangePassword);
                if (!menuItemFile.MenuItems.Contains(menuItemRecoverItems)) menuItemFile.MenuItems.Add(menuItemRecoverItems);
            }
            else if (AppVariables.RoleName == RoleType.Supervisor)
            {                
                menuItemStats.Enabled = true;
                if (menuItemFile.MenuItems.Contains(menuItemTestServce)) menuItemFile.MenuItems.Remove(menuItemTestServce);
                if (menuItemFile.MenuItems.Contains(menuItemUploadData)) menuItemFile.MenuItems.Remove(menuItemUploadData);
                if (menuItemFile.MenuItems.Contains(menuItemResetUsers)) menuItemFile.MenuItems.Remove(menuItemResetUsers);
                if (menuItemFile.MenuItems.Contains(menuItemResetData)) menuItemFile.MenuItems.Remove(menuItemResetData);
                if (menuItemFile.MenuItems.Contains(menuItemShrink)) menuItemFile.MenuItems.Remove(menuItemShrink);
                if (menuItemFile.MenuItems.Contains(menuItemGetUnmatched)) menuItemFile.MenuItems.Remove(menuItemGetUnmatched); 
                if (menuItemEdit.MenuItems.Contains(menuItemChangePassword)) menuItemEdit.MenuItems.Remove(menuItemChangePassword);
                if (menuItemFile.MenuItems.Contains(menuItemRecoverItems)) menuItemFile.MenuItems.Remove(menuItemRecoverItems);
            }
            else if (AppVariables.RoleName == RoleType.Employee)
            {                
                menuItemStats.Enabled = false;
                if (menuItemFile.MenuItems.Contains(menuItemTestServce)) menuItemFile.MenuItems.Remove(menuItemTestServce);
                if (menuItemFile.MenuItems.Contains(menuItemUploadData)) menuItemFile.MenuItems.Remove(menuItemUploadData);
                if (menuItemFile.MenuItems.Contains(menuItemShrink)) menuItemFile.MenuItems.Remove(menuItemShrink);
                if (menuItemFile.MenuItems.Contains(menuItemResetUsers)) menuItemFile.MenuItems.Remove(menuItemResetUsers);
                if (menuItemFile.MenuItems.Contains(menuItemResetData)) menuItemFile.MenuItems.Remove(menuItemResetData);
                if (menuItemFile.MenuItems.Contains(menuItemGetUnmatched)) menuItemFile.MenuItems.Remove(menuItemGetUnmatched); 
                if (menuItemEdit.MenuItems.Contains(menuItemChangePassword)) menuItemEdit.MenuItems.Remove(menuItemChangePassword);
                if (menuItemFile.MenuItems.Contains(menuItemRecoverItems)) menuItemFile.MenuItems.Remove(menuItemRecoverItems);
            }
            tbPalletNo.Focus();  
        }

        private void menuItemChangePassword_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void menuItemResetData_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            this.Refresh();
            this.SuspendLayout();
            panelWait.Visible = true;
            this.ResumeLayout();

            try
            {
                DialogResult dialogRes = MessageBox.Show("Do you want to reset the Data on this device?", "Reset Data [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dialogRes == DialogResult.Yes)
                {
                    DateTime dtStart = DateTime.Now;

                    bool isResume = true;
                    int iCount = 0;
                    FGSyncService client = new FGSyncService();
                    DBClass db = new DBClass();

                    //List<WebRefFGSync.PalletEntity> data = client.ResetData().ToList();                    
                    //int total = db.ResetDataAll(data);
                    //delete all data from mobile device
                    db.ResetDataAll();
                    //now add data into device.
                    do
                    {
                        List<InventAvailContract> data = client.GetFGYearInventory(iCount, true).ToList();
                        if (data.Count.Equals(0))
                            isResume = false;
                        else
                        {
                            iCount = db.InsertDataAll(data);
                            iCount++;
                        }
                    }
                    while (isResume);
                    client.Dispose();
                    DateTime dtEnd = DateTime.Now;
                    var dateDiff = (dtEnd - dtStart).TotalMinutes;
                    MessageBox.Show("Data has been reset. Total number of rows Imported: " + iCount.ToString() + "\nTime taken (Minutes): " + dateDiff.ToString(), "Reset Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                
            }
            catch (WebException exp)
            {
                if (exp.Status == WebExceptionStatus.ConnectFailure)                
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";                
                else
                    msg = exp.Message;

                MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                panelWait.Visible = false;
            }
        }

        private void menuItemShrink_Click(object sender, EventArgs e)
        {           
            if (new DBClass().ShrinkDatabase())
            {
                MessageBox.Show("Database has been shrinked successfully.", "Shrink DB [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuItemGetUnmatched_Click(object sender, EventArgs e)
        {
            int numOfRecSource, numOfRecUpdated, numOfRecInserted;
            new DBClass().UpdateUnmatchedRecords(out numOfRecSource, out numOfRecUpdated, out numOfRecInserted);

            MessageBox.Show("Number of Source Rec:" + numOfRecSource.ToString() + "\r\nNum of Updated Rec:" + numOfRecUpdated.ToString()+"\r\nNum of Inserted Rec:"+numOfRecInserted.ToString());
        }

        private void menuItemRecoverItems_Click(object sender, EventArgs e)
        {
            new RecoverItem().Show();
        }

        private void menuItemResetUsers_Click(object sender, EventArgs e)
        {
            FGSyncService client = new FGSyncService();
            DBClass db = new DBClass();
            List<UserInfo> users = new List<UserInfo>();

            try
            {
                panelWait.Visible = true;
                DialogResult dialogRes = MessageBox.Show("Do you want to reset User Records on this device?", "Reset Users [" + AppVariables.DeviceName + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dialogRes == DialogResult.Yes)
                {
                    List<UserData> data = client.GetUserData().ToList();
                    foreach (UserData oneRec in data)
                    {
                        users.Add(new UserInfo() { UserName = oneRec.UserName, Password = oneRec.Password, Role = oneRec.UserType });
                    }
                    client.Dispose();
                    db.InsertBulkUsers(users);

                    MessageBox.Show("Bulk user have been reset successfully.", "Reset Users [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                panelWait.Visible = false;
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        

        

        

        

        

        
    }
}