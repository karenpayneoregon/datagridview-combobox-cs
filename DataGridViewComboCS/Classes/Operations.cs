using System.Data;
using System.Data.SqlClient;

namespace DataGridViewCombo1.Classes
{
    public class Operations
    {
        private string ConnectionString = "Data Source=.\\sqlexpress;Initial " +
            "Catalog=DataGridViewCodeSample;Integrated Security=True";

        public DataTable ColorTable { get; set; }
        public DataTable VendorTable { get; set; }

        private DataTable _customerTable = new DataTable();
        public DataTable CustomerTable
        {
            get => _customerTable;
            set => _customerTable = value;
        }
        public void LoadDataGridViewTable()
        {
            CustomerTable = new DataTable();

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cn.Open();
                    
                    cmd.CommandText = "SELECT id,Item,ColorId,CustomerId, qty, InCart, VendorId  FROM Product";
                    CustomerTable.Load(cmd.ExecuteReader());
                    
                }
            }
        }

        public void LoadColorsReferenceTable()
        {
            ColorTable = new DataTable();

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cn.Open();
                    cmd.CommandText = "SELECT ColorId,ColorText FROM Colors";
                    ColorTable.Load(cmd.ExecuteReader());
                }
            }
        }
        public void LoadVendorsReferenceTable()
        {
            VendorTable = new DataTable();

            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cn.Open();
                    cmd.CommandText = "SELECT VendorId,VendorName FROM dbo.Vendors";
                    VendorTable.Load(cmd.ExecuteReader());
                }
            }
        }
    }
}
