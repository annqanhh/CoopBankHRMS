using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopBankHRMS
{
    
        class DBConnect
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;
            private string con;
            public string myConnection()
            {
                con = @"Data Source=ANN;Initial Catalog=CCFHRM;Integrated Security=True";
                return con;
            }
            public DataTable getTable(string qury)
            {
                cn.ConnectionString = myConnection();
                cm = new SqlCommand(qury, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

            public void ExecuteQuery(String sql)
            {
                try
                {
                    cn.ConnectionString = myConnection();
                    cn.Open();
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            public String getPassword(string username)
            {
                string password = "";
                cn.ConnectionString = myConnection();
                cn.Open();
                cm = new SqlCommand("SELECT MatKhau FROM TaiKhoan WHERE MaNV = '" + username + "'", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    password = dr["MatKhau"].ToString();
                }
                dr.Close();
                cn.Close();
                return password;
            }

            
        }
        
}
