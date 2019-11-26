using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace PalletScanMobile
{
    public class DBClass
    {
        SqlCeConnection _connection;
        string conString;

        public DBClass()
        {
            InitConnection();
        }

        void InitConnection()
        {
            conString = ("Data Source ="
                        + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                        + ("\\PalletScan.sdf;"
                        + ("Password =" + "\"111111\";"))));

            
            /*conString = ("Data Source ="
                        + ("C:\\Inventory2017\\FG\\S9"
                        + ("\\PalletScan.sdf;"
                        + ("Password =" + "\"111111\";"))));*/
            
            _connection = new SqlCeConnection();
            _connection.ConnectionString = conString;
        }

        public string getConn()
        {
            return conString;
        }

        public bool ShrinkDatabase()
        {
            try
            {
                SqlCeEngine engine = new SqlCeEngine(_connection.ConnectionString);

                engine.Compact(_connection.ConnectionString);
                engine.Shrink();
            }
            catch (Exception exp)
            {
                string msg = exp.Message;
                //System.Windows.Forms.MessageBox.Show(msg);
                return false;
            }
            return true;
        }

        public bool UpdateUnmatchedRecords(out int numOfRecSource, 
            out int numOfRecUpdated,
            out int numOfRecInserted)
        {            
            long syncId = GetTopSyncID();
            //if saved SyncId in Options table is greater than MAX sync Id then start from Saved Sync ID
            long savedSyncId = long.Parse("0" + GetOptions(Option.LastSyncId));
            if (savedSyncId > syncId)
                syncId = savedSyncId;
            syncId = syncId + 1;

            numOfRecSource = 0; 
            numOfRecUpdated = 0;
            numOfRecInserted = 0;
            string conUnmatched = conString.Replace("PalletScan.sdf", "PalletScan_Unmatched.sdf");
            SqlCeConnection conn = new SqlCeConnection(conUnmatched);

            string sqlString = "SELECT * FROM Pallets;";
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    numOfRecSource++;

                    SqlCeCommand cmd2 = new SqlCeCommand();
                    sqlString = "SELECT Pallet FROM Pallets WHERE Pallet=@p1;";

                    try
                    {
                        cmd2.Parameters.Add("@p1", SqlDbType.NVarChar);
                        cmd2.Parameters[0].Value = dr["Pallet"].ToString();

                        cmd2.CommandText = sqlString;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = this._connection;

                        if (this._connection.State != ConnectionState.Open)
                            this._connection.Open();
                        var drHas = cmd2.ExecuteScalar();
                        if (drHas != null && drHas.ToString() == dr["Pallet"].ToString())
                        {
                            Item row = new Item()
                            {
                                SerialNumber = dr["Pallet"].ToString(),
                                DateUpdated = (DateTime)dr["DateUpdated"],
                                DeviceName = dr["DeviceName"].ToString(),
                                IsManualUpdated = (bool)dr["IsManual"],
                                IsMatched = true,
                                UpdatedBy = dr["UpdatedBy"].ToString(),
                                SyncId = syncId
                            };
                            syncId++;
                            if (this.UpdatePallet(row,false) == MatchResult.Matched)
                                numOfRecUpdated++;
                        }
                        else
                        {
                            Item row = new Item()
                            {
                                SerialNumber = dr["Pallet"].ToString(),
                                PresentInStock = false,
                                DateUpdated = (DateTime)dr["DateUpdated"],
                                DeviceName = dr["DeviceName"].ToString(),
                                IsManualUpdated = (bool)dr["IsManual"],
                                IsMatched = (bool)dr["IsMatched"],
                                UpdatedBy = dr["UpdatedBy"].ToString(),
                                Location = dr["Location"].ToString(),
                                SyncId = syncId
                            };
                            syncId++;
                            if (this.InsertPallet(row) > 0)
                                numOfRecInserted++;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            finally
            {
                conn.Close();
                this._connection.Close();
            }
            return true;
        }

        public bool DeleteUser(int userId)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Users WHERE UserId = @p1;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int);
                cmd.Parameters["@p1"].Value = userId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;  
        }

        public bool InsertBulkUsers(List<UserInfo> users)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Users;";
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                {
                    foreach (UserInfo user in users)
                    {
                        ChangeUserInfo(user);
                    }
                    return true;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        public bool ChangeUserInfo(UserInfo user)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "";
            try
            {
                if (user.UserId.Equals(0))
                {
                    sqlString = "INSERT INTO Users (UserName, Password, Role) VALUES (@p1, @p2, @p3)";
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

                    cmd.Parameters["@p1"].Value = user.UserName;
                    cmd.Parameters["@p2"].Value = user.Password;
                    cmd.Parameters["@p3"].Value = user.Role;
                }
                else
                {
                    sqlString = "UPDATE Users SET UserName=@p1, Password=@p2, Role=@p3 WHERE UserId=@p4;";
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p4", SqlDbType.Int);

                    cmd.Parameters["@p1"].Value = user.UserName;
                    cmd.Parameters["@p2"].Value = user.Password;
                    cmd.Parameters["@p3"].Value = user.Role;
                    cmd.Parameters["@p4"].Value = user.UserId;
                }

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }            
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return false;   
        }

        public UserInfo CheckLogin(string userName, string password)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT * FROM Users WHERE UserName=@p1 AND Password=@p2;";

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.NVarChar);

                cmd.Parameters[0].Value = userName;
                cmd.Parameters[1].Value = password;
                
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    UserInfo info = new UserInfo()
                    {
                        UserId = int.Parse(dr["UserId"].ToString()),
                        UserName = dr["UserName"].ToString(),
                        Role = dr["Role"].ToString()
                    };

                    sqlString = "INSERT INTO LoginInfo (Username, LoginDate) Values (@p1, @p2);";
                    cmd = new SqlCeCommand();
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.DateTime);

                    cmd.Parameters[0].Value = userName;
                    cmd.Parameters[1].Value = DateTime.Now;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;
                    cmd.ExecuteNonQuery();

                    return info;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return null;
        }

        public long GetTopSyncID()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            long topSyncId = 0;

            string sqlString = "SELECT MAX(SyncID) AS MaxSyncId FROM Pallets;";

            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this._connection;

            if (this._connection.State != ConnectionState.Open)
                this._connection.Open();
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                topSyncId = Int64.Parse(result.ToString());
            }


            return topSyncId;
        }

        public void RecoverDelAndInsert()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Pallets where UpdatedBy is null;";

            try
            {
                //Reset Item Table
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                sqlString = "INSERT into Pallets (Pallet, SyncId, DateUpdated) select [Serial number], SyncId, '2018-12-26T08:15:00.000' from Items;";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void RecoverItems()
        {
            DataTable dt = ItemsScanned();
            long syncId = GetTopSyncID();

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string sqlString = "Update Pallets SET IsMatched=1, UpdatedBy=@p1, DeviceName=@p2, IsManual=@p3, DateUpdated=@p4, SyncId=@p6 "+
                    "WHERE Pallet=@p5 AND PresentInStock=1 AND UpdatedBy IS null;";

                    SqlCeCommand cmd = new SqlCeCommand();
                    cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p3", SqlDbType.Bit);
                    cmd.Parameters.Add("@p4", SqlDbType.DateTime);
                    cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@p6", SqlDbType.BigInt);

                    cmd.Parameters["@p1"].Value = dr["UpdatedBy"].ToString();
                    cmd.Parameters["@p2"].Value = dr["DeviceName"].ToString();
                    cmd.Parameters["@p3"].Value = bool.Parse(dr["IsManual"].ToString());
                    cmd.Parameters["@p4"].Value = DateTime.Parse(dr["DateUpdated"].ToString());
                    cmd.Parameters["@p5"].Value = dr["Pallet"].ToString();
                    cmd.Parameters["@p6"].Value = ++syncId;

                    cmd.CommandText = sqlString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = this._connection;

                    if (this._connection.State != ConnectionState.Open)
                        this._connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        cmd = new SqlCeCommand();
                        sqlString = "DELETE from Pallets where Pallet=@p1 and PresentInStock=@p2 and UpdatedBy=@p3;";
                        cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@p2", SqlDbType.Bit);
                        cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

                        cmd.Parameters["@p1"].Value = dr["Pallet"].ToString();                        
                        cmd.Parameters["@p2"].Value = false;
                        cmd.Parameters["@p3"].Value = dr["UpdatedBy"].ToString();

                        cmd.CommandText = sqlString;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = this._connection;

                        if (this._connection.State != ConnectionState.Open)
                            this._connection.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                this._connection.Close();
            }
        }

        public DataTable ItemsScanned()
        {
            DataTable dt = new DataTable("Items");
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT * FROM Pallets WHERE UpdatedBy is not null;";

            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                adapter.Fill(dt);
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }


        public void ResetDataAll()//List<WebRefFGSync.PalletEntity> data)
        {
            
            //reset Options table
            SaveOptions(Option.LastSyncId, "0");


            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "DELETE FROM Items;";

            try
            {
                //Reset Item Table
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                //Reset Item History table
                sqlString = "DELETE FROM Pallets;";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }

        }

        public int InsertDataAll(List<WebRefFGSync.InventAvailContract> data)//List<WebRefFGSync.PalletEntity> data)
        {
            int lastSyncId = 0;

            try
            {
                //foreach (WebRefFGSync.PalletEntity row in data)
                foreach (WebRefFGSync.InventAvailContract availCount in data)
                {

                    WebRefFGSync.PalletEntity row = new WebRefFGSync.PalletEntity()
                    {
                        ItemNumber = availCount.itemIdField,
                        ProductName = availCount.productNameField,
                        Config = availCount.configurationIdField,
                        Size = availCount.sizeIdField,
                        Color = availCount.colorIdField,
                        Warehouse = availCount.locationIdField,
                        BatchNumber = availCount.batchIdField,
                        Location = availCount.wMSLocationIdField,
                        Pallet = availCount.serialIdField,
                        Available = availCount.availPhysicalField,
                        AvailableSpecified = true,
                        SyncId = availCount.syncIdField,
                        SyncIdSpecified = true
                    };
                    lastSyncId = availCount.syncIdField;

                    if (InsertPalletOnReset(row) > 0)
                    {
                        //iCount++;
                        InsertItemOnReset(row);
                    }
                }
                SaveOptions(Option.LastSyncId, lastSyncId.ToString());
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return lastSyncId;
        }
        
        
        public DataTable GetItems(string search)
        {
            DataTable dt=new DataTable("Items");
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT TOP (20) * FROM Items  ";
            if (!string.IsNullOrEmpty(search))
                sqlString += " WHERE [Serial number] LIKE '%" + search + "%'";
            sqlString += " ORDER BY DateUpdated DESC;";

            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                adapter.Fill(dt);
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }

        public DataTable SearchItems(string search)
        {
            DataTable dt = new DataTable("Items");
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT TOP (20) p.Pallet,i.[Product name], p.UpdatedBy, p.DateUpdated, p.IsManual, p.Location FROM Pallets p LEFT OUTER JOIN Items i ON p.Pallet=i.[Serial Number] WHERE (p.[IsMatched] = 1 OR DeviceName != '') ";
            if (!string.IsNullOrEmpty(search))
                sqlString += " AND p.Pallet LIKE '%" + search + "%'";
            sqlString += " ORDER BY p.Pallet;";

            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                adapter.Fill(dt);
            }
            finally
            {
                this._connection.Close();
            }
            return dt;
        }




        public PalletMatch Search(Item row)
        {
            PalletMatch result = PalletMatch.NotMatched;
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT * FROM Pallets WHERE Pallet=@p1;";

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                
                cmd.Parameters[0].Value = row.SerialNumber;
                                
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (row.Location != dr["Location"].ToString())
                    {
                        row.PresentInStock = false;
                        row.IsMatched = false;
                        result = PalletMatch.MatchedWrongLocation;

                        InsertPallet(row);
                    }
                    else
                    {
                        row.PresentInStock = bool.Parse(dr["PresentInStock"].ToString());
                        if (row.PresentInStock)
                        {
                            row.IsMatched = true;
                            result = PalletMatch.Matched;
                        }
                        else
                            row.IsMatched = false;

                        UpdatePallet(row, true);
                    }
                }
                else
                {
                    row.PresentInStock = false;
                    row.IsMatched = false;

                    InsertPallet(row);
                    
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return result;
        }

        public string GetStat(DateTime start, DateTime end)
        {
            string result = string.Empty;
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "SELECT COUNT(*) FROM Pallets;";

            try
            {                
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                string strData = cmd.ExecuteScalar().ToString();
                result = "OVERALL STATS on: " + System.Net.Dns.GetHostName() + "\r\n--------------------";
                result += "\r\nTotal pallets in DB: "+strData;

                sqlString = "SELECT COUNT(*) FROM Pallets WHERE IsMatched=1;";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                strData = cmd.ExecuteScalar().ToString();
                result += "\r\nTotal pallets Matched: "+strData;

                sqlString = "SELECT COUNT(*) FROM Pallets WHERE PresentInStock=0;";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                strData = cmd.ExecuteScalar().ToString();
                result += "\r\nTotal pallets Un-Matched: " + strData;

                result += "\r\n--------------------";
                result += "\r\nSTATS BETWEEN " + start.ToString("dd/MM/yyyy hh:mm tt") + " & " + end.ToString("dd/MM/yyyy hh:mm tt") + ":\r\n--------------------";

                sqlString = "SELECT COUNT(*) FROM Pallets WHERE IsMatched=1 AND DateUpdated BETWEEN '" + start.ToString("yyyy-MM-ddTHH:mm:ss") + "' AND '" + end.ToString("yyyy-MM-ddTHH:mm:ss") + "';";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                strData = cmd.ExecuteScalar().ToString();
                result += "\r\nPallets Matched: " + strData;

                sqlString = "SELECT COUNT(*) FROM Pallets WHERE PresentInStock=0 AND DateUpdated BETWEEN '" + start.ToString("yyyy-MM-ddTHH:mm:ss") + "' AND '" + end.ToString("yyyy-MM-ddTHH:mm:ss") + "';";
                cmd = new SqlCeCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;
                strData = cmd.ExecuteScalar().ToString();
                result += "\r\nPallets Un-Matched: " + strData;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return result;
        }
        
        public MatchResult UpdatePallet(Item dr, bool isCloseConn)
        {
            long syncId = GetTopSyncID() + 1;
            dr.SyncId = syncId;

            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "UPDATE Pallets SET IsMatched=@p1, DateUpdated=@p2, UpdatedBy=@p3, IsManual=@p4, DeviceName=@p6,SyncId=@p7 " +
                "WHERE [Pallet]=@p5;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.Bit);
                cmd.Parameters.Add("@p2", SqlDbType.DateTime);
                cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p4", SqlDbType.Bit);
                cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p6", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p7", SqlDbType.NVarChar); 
                                
                cmd.Parameters[0].Value = dr.IsMatched;
                cmd.Parameters[1].Value = dr.DateUpdated;
                cmd.Parameters[2].Value = dr.UpdatedBy;
                cmd.Parameters[3].Value = dr.IsManualUpdated;
                cmd.Parameters[4].Value = dr.SerialNumber;
                cmd.Parameters[5].Value = dr.DeviceName;
                cmd.Parameters[6].Value = dr.SyncId;
                
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return MatchResult.Matched;
                else
                {
                    return MatchResult.NotMatched;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (isCloseConn)
                    this._connection.Close();
            }
            return MatchResult.NoResult;
        }

        public int InsertPalletOnReset(WebRefFGSync.PalletEntity dr)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "INSERT INTO Pallets (Pallet, SyncId, Location) " +
                "VALUES (@p1, @p2, @p3);";

            cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p2", SqlDbType.BigInt);
            cmd.Parameters.Add("@p3", SqlDbType.NVarChar);

            cmd.Parameters["@p1"].Value = dr.Pallet;
            cmd.Parameters["@p2"].Value = dr.SyncId;
            cmd.Parameters["@p3"].Value = dr.Location;

            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this._connection;

            adapter.SelectCommand = cmd;

            if (this._connection.State != ConnectionState.Open)
                this._connection.Open();

            return cmd.ExecuteNonQuery();
                        
        }

        public int InsertItemOnReset(WebRefFGSync.PalletEntity dr)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "INSERT INTO Items ([Item number], [Product name], Configuration, Size, Color, Warehouse, [Batch number], Location, [Serial number], [Available Physical], SyncID) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11);";

            cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p2", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p4", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p6", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p7", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p8", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p9", SqlDbType.NVarChar);
            cmd.Parameters.Add("@p10", SqlDbType.Real);
            cmd.Parameters.Add("@p11", SqlDbType.BigInt);

            cmd.Parameters["@p1"].Value = dr.ItemNumber;
            cmd.Parameters["@p2"].Value = dr.ProductName;
            cmd.Parameters["@p3"].Value = dr.Config;
            cmd.Parameters["@p4"].Value = dr.Size;
            cmd.Parameters["@p5"].Value = dr.Color;
            cmd.Parameters["@p6"].Value = dr.Warehouse;
            cmd.Parameters["@p7"].Value = dr.BatchNumber;
            cmd.Parameters["@p8"].Value = dr.Location;
            cmd.Parameters["@p9"].Value = dr.Pallet;
            cmd.Parameters["@p10"].Value = dr.Available;
            cmd.Parameters["@p11"].Value = dr.SyncId;

            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = this._connection;

            adapter.SelectCommand = cmd;

            if (this._connection.State != ConnectionState.Open)
                this._connection.Open();
            return cmd.ExecuteNonQuery();
        }

        public int InsertPallet(Item dr)
        {
            long syncId = GetTopSyncID();

            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "INSERT INTO Pallets (Pallet, IsMatched, PresentInStock, DateUpdated, UpdatedBy, IsManual, DeviceName, SyncId, Location) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9);";
            syncId = syncId + 1;

            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.Bit);
                cmd.Parameters.Add("@p3", SqlDbType.Bit);
                cmd.Parameters.Add("@p4", SqlDbType.DateTime);
                cmd.Parameters.Add("@p5", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p6", SqlDbType.Bit);
                cmd.Parameters.Add("@p7", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p8", SqlDbType.BigInt);
                cmd.Parameters.Add("@p9", SqlDbType.NVarChar);

                cmd.Parameters[0].Value = dr.SerialNumber;
                cmd.Parameters[1].Value = dr.IsMatched;
                cmd.Parameters[2].Value = dr.PresentInStock;
                cmd.Parameters[3].Value = dr.DateUpdated;
                cmd.Parameters[4].Value = dr.UpdatedBy;
                cmd.Parameters[5].Value = dr.IsManualUpdated;
                cmd.Parameters[6].Value = dr.DeviceName;
                cmd.Parameters[7].Value = syncId;
                cmd.Parameters[8].Value = dr.Location;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return 0;
        }

        public MatchResult Update(Item dr)
        {            
            long syncId = GetTopSyncID();
            //if saved SyncId in Options table is greater than MAX sync Id then start from Saved Sync ID
            long savedSyncId = long.Parse("0" + GetOptions(Option.LastSyncId));
            if (savedSyncId > syncId)
                syncId = savedSyncId;
            syncId = syncId + 1;
            dr.SyncId = syncId;

            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "UPDATE Items SET IsMatched=@p1, DateUpdated=@p2, ProcessByIT=@p4, SyncID=@p5 " +
                "WHERE [Serial number]=@p3;";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.Bit);
                cmd.Parameters.Add("@p2", SqlDbType.DateTime);
                cmd.Parameters.Add("@p3", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p4", SqlDbType.Bit);
                cmd.Parameters.Add("@p5", SqlDbType.BigInt);

                cmd.Parameters[0].Value = dr.IsMatched;
                cmd.Parameters[1].Value = dr.DateUpdated;
                cmd.Parameters[2].Value = dr.SerialNumber;
                cmd.Parameters[3].Value = dr.ProcessByIT;
                cmd.Parameters[4].Value = syncId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return MatchResult.Matched;
                else
                {
                    if (Insert(dr) > 0)
                        return MatchResult.NotMatched;
                    else
                        return MatchResult.NoResult;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return MatchResult.NoResult;
        }

        
        public int Insert(Item dr)
        {
            //long syncId = GetTopSyncID() + 1;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "INSERT INTO Items ([Serial number], IsMatched, DateUpdated, ProcessByIT, SyncID) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5);";
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar);
                cmd.Parameters.Add("@p2", SqlDbType.Bit);
                cmd.Parameters.Add("@p3", SqlDbType.DateTime);
                cmd.Parameters.Add("@p4", SqlDbType.Bit);
                cmd.Parameters.Add("@p5", SqlDbType.BigInt);

                cmd.Parameters[0].Value = dr.SerialNumber;
                cmd.Parameters[1].Value = false;
                cmd.Parameters[2].Value = dr.DateUpdated;
                cmd.Parameters[3].Value = dr.ProcessByIT;
                cmd.Parameters[4].Value = dr.SyncId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                adapter.SelectCommand = cmd;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
            return 0;
        }

        public string GetOptions(Option option)
        {
            SqlCeCommand cmd = new SqlCeCommand();

            string sqlString = "SELECT top (1) * FROM Options;";
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                SqlCeDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (option == Option.LastSyncId)
                    {
                        if (result["LastSyncID"] != DBNull.Value)
                            return result["LastSyncID"].ToString();
                        else
                            return "0";
                    }
                }
            }
            catch (Exception exp)
            {
                string abc = exp.Message;
            }
            finally
            {
                this._connection.Close();
            }
            return "";
        }

        public bool SaveOptions(Option option, string value)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            SqlCeCommand cmd = new SqlCeCommand();
            string sqlString = "UPDATE Options SET ";
            try
            {
                if (option == Option.LastSyncId)
                {
                    sqlString += "LastSyncID = @p1";
                    cmd.Parameters.Add("@p1", SqlDbType.BigInt);
                    cmd.Parameters["@p1"].Value = long.Parse(value);
                }

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                this._connection.Close();
            }
            return false;
        }

        public DataTable AllUsers()
        {
            DataTable dt = new DataTable("Users");
            
            string sqlString = "SELECT * FROM Users";
            
            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter da=new SqlCeDataAdapter(cmd);
            try
            {
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                da.Fill(dt);
            }
            finally
            {
                this._connection.Close();
            }

            return dt;
        }

        //use to submit the data to Desktop App
        public List<WebRefFGSync.PalletEntity> GetFGData(long topSyncId)
        {
            List<WebRefFGSync.PalletEntity> rows = new List<WebRefFGSync.PalletEntity>();
            DataTable dt = new DataTable("Pallets");
            //long topSyncId = long.Parse("0"+GetOptions(Option.LastSyncId));
            if (topSyncId.Equals(1))
                topSyncId = 0;
            string sqlString = "SELECT p.*,i.[Item number],i.[Product name],i.Configuration,i.Size,i.Color,i.Warehouse,i.[Batch number],i.Location,i.[Available physical] FROM Pallets p LEFT OUTER JOIN Items i ON p.Pallet=i.[Serial Number] WHERE p.SyncID >= @p1 AND p.UpdatedBy != ''";
            
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                cmd.Parameters.Add("@p1", SqlDbType.BigInt);
                cmd.Parameters[0].Value = topSyncId;

                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this._connection;

                if (this._connection.State != ConnectionState.Open)
                    this._connection.Open();

                SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    WebRefFGSync.PalletEntity row = new WebRefFGSync.PalletEntity()
                    {
                        Pallet = dr["Pallet"].ToString(),
                        IsMatched = dr["IsMatched"]!=DBNull.Value? (bool)dr["IsMatched"]:false,
                        IsMatchedSpecified=true,
                        PresentInStock = dr["PresentInStock"] != DBNull.Value ? (bool)dr["PresentInStock"] : false,
                        PresentInStockSpecified=true,
                        ProcessByIT=true,
                        ProcessByITSpecified=true,
                        DateUpdated=(DateTime)dr["DateUpdated"],
                        DateUpdatedSpecified=true,
                        UpdatedBy = dr["UpdatedBy"].ToString(),
                        IsManual = dr["IsManual"] != DBNull.Value ? (bool)dr["IsManual"] : false,
                        IsManualSpecified=true,
                        DeviceName = dr["DeviceName"].ToString(),
                        SyncId=long.Parse(dr["SyncId"].ToString()),
                        SyncIdSpecified=true,
                        ItemNumber=dr["Item number"].ToString(),
                        ProductName=dr["Product name"].ToString(),
                        Config = dr["Configuration"].ToString(),
                        Size=dr["Size"].ToString(),
                        Color=dr["Color"].ToString(),
                        Location=dr["Location"].ToString(),
                        Warehouse=dr["Warehouse"].ToString(),                          
                        AvailableSpecified=true,
                        BatchNumber=dr["Batch number"].ToString()
                    };
                    if (dr["Available physical"] != DBNull.Value)
                        row.Available = decimal.Parse(dr["Available physical"].ToString());
                    if (dr["DateUpdated"] == DBNull.Value)
                        row.DateUpdated = new DateTime(1753, 1, 1);
                    else
                        row.DateUpdated = (DateTime)dr["DateUpdated"];


                    rows.Add(row);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                this._connection.Close();
            }
                       
            return rows;
        }
    }

    
}
