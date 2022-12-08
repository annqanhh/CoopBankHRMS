using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoopBankHRMS
{
    public partial class frmThuongPhatNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string manv;
        public frmThuongPhatNV(string nv)
        {
            manv = nv;

            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadKT(manv);
            LoadKL(manv);
        }
        public void LoadKT(string nv)
        {
            string manv = nv;
            int i = 0;
            dgvKT.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT c.MaNV , n.TenNV, c.Thang, c.Nam, c.LyDo, c.TienThuong FROM NVien as n INNER JOIN KhenThuong as c on n.MaNV=c.MaNV WHERE c.MaNV = '" + manv + "'  ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvKT.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["LyDo"].ToString(), dr["TienThuong"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadKL(string nv)
        {
            string manv = nv;
            int i = 0;
            dgvKL.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT c.MaNV , n.TenNV, c.Thang, c.Nam, c.LyDo, c.TienPhat FROM NVien as n INNER JOIN KyLuat as c on n.MaNV=c.MaNV WHERE c.MaNV = '"+manv+"' ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvKL.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["LyDo"].ToString(), dr["TienPhat"].ToString());
            }
            dr.Close();
            cn.Close();
        }

    }
}
