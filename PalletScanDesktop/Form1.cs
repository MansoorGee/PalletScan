using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace PalletScanDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = GetData();
        }

        SqlCeConnection _connection;
        void InitConnection()
        {
            string conString = ("Data Source ="                        
                        + (@"C:\PalletScanData\FG\Inventory\PalletScanS5.sdf;"
                        + ("Password =" + "\"111111\";")));

            
            /*conString = ("Data Source ="
                        + ("C:\\Inventory2017\\FG\\S9"
                        + ("\\PalletScan.sdf;"
                        + ("Password =" + "\"111111\";"))));*/
            
            _connection = new SqlCeConnection();
            _connection.ConnectionString = conString;
        }

        private List<PalletEntity> GetData()
        {
            InitConnection();
            List<PalletEntity> rows = new List<PalletEntity>();
            DataTable dt = new DataTable("Pallets");
            long topSyncId =  0;
            string sqlString = "SELECT p.*,i.[Item number],i.[Product name],i.Configuration,i.Size,i.Color,i.Warehouse,i.[Batch number],i.Location,i.[Available physical],i.SyncID FROM Pallets p LEFT OUTER JOIN Items i ON p.Pallet=i.[Serial Number] WHERE i.SyncID >= @p1 AND p.UpdatedBy != ''";
            
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
                    PalletEntity row = new PalletEntity()
                    {
                        palletField = dr["Pallet"].ToString(),
                        isMatchedField = dr["IsMatched"]!=DBNull.Value? (bool)dr["IsMatched"]:false,
                        isMatchedFieldSpecified=true,
                        presentInStockField = dr["PresentInStock"] != DBNull.Value ? (bool)dr["PresentInStock"] : false,
                        presentInStockFieldSpecified=true,
                        processByITField=true,
                        processByITFieldSpecified=true,
                        dateUpdatedField=(DateTime)dr["DateUpdated"],
                        dateUpdatedFieldSpecified=true,
                        updatedByField = dr["UpdatedBy"].ToString(),
                        isManualField = dr["IsManual"] != DBNull.Value ? (bool)dr["IsManual"] : false,
                        isManualFieldSpecified=true,
                        deviceNameField = dr["DeviceName"].ToString(),
                        syncIdField=long.Parse(dr["SyncID"].ToString()),
                        syncIdFieldSpecified=true,
                        itemNumberField=dr["Item number"].ToString(),
                        productNameField=dr["Product name"].ToString(),
                        configField = dr["Configuration"].ToString(),
                        sizeField=dr["Size"].ToString(),
                        colorField=dr["Color"].ToString(),
                        locationField=dr["Location"].ToString(),
                        warehouseField=dr["Warehouse"].ToString(),                          
                        availableFieldSpecified=true,
                        batchNumberField=dr["Batch number"].ToString()
                    };
                    if (dr["Available physical"] != DBNull.Value)
                        row.availableField = decimal.Parse(dr["Available physical"].ToString());
                    if (dr["DateUpdated"] == DBNull.Value)
                        row.dateUpdatedField = new DateTime(1753, 1, 1);
                    else
                        row.dateUpdatedField = (DateTime)dr["DateUpdated"];


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
