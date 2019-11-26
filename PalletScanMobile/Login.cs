using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using PalletScanMobile.WebRefFGSync;
using System.Net;

namespace PalletScanMobile
{
    public partial class Login : Form
    {
        Timer timeSync;
        int minutes = 5;//after 5 minutes;

        public Login()
        {
            InitializeComponent();

            timeSync = new Timer();
            timeSync.Interval = minutes * 60 * 1000;//after 5 minutes;
            timeSync.Tick += new EventHandler(timeSync_Tick);
        }

        void timeSync_Tick(object sender, EventArgs e)
        {
            TimeSpan tsStart=new TimeSpan(12,30,0);
            TimeSpan tsEnd=new TimeSpan(13,45,0);
            TimeSpan tsStart2 = new TimeSpan(16, 30, 0);
            TimeSpan tsEnd2 = new TimeSpan(17, 0, 0);
            if ((DateTime.Now.TimeOfDay >= tsStart && DateTime.Now.TimeOfDay <= tsEnd) ||
                (DateTime.Now.TimeOfDay >= tsStart2 && DateTime.Now.TimeOfDay <= tsEnd2))
            {
                //Checks and Uploads the data to server after an interval automatically. 
                try
                {
                    int size = 50;    //Chunk Size
                    DBClass db = new DBClass();
                    long topSyncId = long.Parse("0" + db.GetOptions(Option.LastSyncId));
                    List<WebRefFGSync.PalletEntity> data = db.GetFGData(topSyncId);
                    if (data.Count > 0)
                    {
                        List<WebRefFGSync.PalletEntity> dataChunks;
                        FGSyncService client = new FGSyncService();
                        if (data.Count < size)
                            size = data.Count;
                        dataChunks = data.Take(size).ToList();

                        client.BeginUpdateFGDesktop(dataChunks.ToArray(), new AsyncCallback(FGInventory), client);

                    }
                }
                catch (WebException exp)
                {
                    string msg = string.Empty;
                    if (exp.Status == WebExceptionStatus.ConnectFailure)
                        msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                    else
                        msg = exp.Message;

                    //MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                catch (Exception exp)
                {
                    //MessageBox.Show(exp.Message, "Dynamics AX [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
        }

        static void FGInventory(IAsyncResult result)
        {
            try
            {
                FGSyncService client = (FGSyncService)result.AsyncState;
                if (result.IsCompleted)
                {
                    long lastSyncId = 0;
                    bool returnResult = false;
                    client.EndUpdateFGDesktop(result, out lastSyncId, out returnResult);
                    if (returnResult)
                    {
                        DBClass db = new DBClass();
                        db.SaveOptions(Option.LastSyncId, lastSyncId.ToString());
                    }
                }
            }
            catch (WebException exp)
            {
                string msg = string.Empty;
                if (exp.Status == WebExceptionStatus.ConnectFailure)
                    msg = "Unable to connect to Dynamics AX. Please contact Network administrator.";
                else
                    msg = exp.Message;

                //MessageBox.Show(msg, "Connect Failure [" + AppVariables.DeviceName + "]", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exp)
            {
                string msg = exp.Message;
            }
        }

        public Home HomeForm { get; set; }

        private void Login_Load(object sender, EventArgs e)
        {
            AppVariables.DeviceName = System.Net.Dns.GetHostName();            
            lbVersion.Text = AppVariables.VersionNumber;

            timeSync.Enabled = true;

            tbUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
            {
                MessageBox.Show("Please enter 'Username' to continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                tbUsername.Focus();
            }
            else
            {
                UserInfo userInfo = new DBClass().CheckLogin(tbUsername.Text.Trim(), tbPassword.Text.Trim());
                if (userInfo != null)
                {                    
                    this.SuspendLayout();
                    AppVariables.UpdatedBy = userInfo.UserName;
                    if (userInfo.Role == "Employee")
                        AppVariables.RoleName = RoleType.Employee;
                    else if (userInfo.Role == "Supervisor")
                        AppVariables.RoleName = RoleType.Supervisor;
                    else if (userInfo.Role == "Admin")
                        AppVariables.RoleName = RoleType.Admin;

                    SystemSounds.Beep.Play();


                    Home homeScreen = null;
                    if (HomeForm != null)
                        homeScreen = HomeForm;
                    else
                        homeScreen = new Home();

                    homeScreen.LoginForm = this;
                    homeScreen.Show();

                    this.Hide();
                    this.ResumeLayout();
                }
                else
                {
                    MessageBox.Show("Login failed. Please enter correct username and/or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    tbUsername.Focus();
                    SystemSounds.Question.Play();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timeSync.Enabled = false;
            Application.Exit();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            //else if ((int)e.KeyChar == (int)Keys.Tab)
            //{
            //    tbUsername.Focus();
            //}
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            tbPassword.Text = string.Empty;
            tbUsername.Focus();
        }

        private void tbUsername_KeyUp(object sender, KeyEventArgs e)
        {
            //if ((int)e.KeyData == (int)Keys.Tab)
            //{
            //    //tbPassword.Focus();
            //}
            //else 
                if ((int)e.KeyData == (int)Keys.Enter)
            {
                tbPassword.Focus();
            }
        }
    }
}