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
    public partial class frmDuAnNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string manv;
        public frmDuAnNV(string nv)
        {
            manv = nv;
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadDA(manv);
        }
        public void LoadDA(string nv)
        {
            manv = nv;
            int i = 0;
            dgvDSDA.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select d.MaDA, TenDA, NgBatDau, NgKetThuc,GhiChu from DuAn as d inner join CTDuAn as c on c.MaDA = d.MaDA where d.MaNV = '" + manv+"' ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvDSDA.Rows.Add(i, dr["MaDA"].ToString(), dr["TenDA"].ToString(), dr["NgBatDau"].ToString().Substring(0, dr["NgBatDau"].ToString().Length - 11), dr["NgKetThuc"].ToString().Substring(0, dr["NgKetThuc"].ToString().Length - 11), dr["GhiChu"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadNV(string mada)
        {
            int i = 0;
            dgvNhanVien.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select MaDA, DuAn.MaNV, TenNV,ViTri from DuAn inner join NVien on NVien.MaNV = DuAn.MaNV where MaDA LIKE '" + mada + "'", cn);

            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanVien.Rows.Add(i, dr["MaDA"].ToString(), dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["ViTri"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgvDSDA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < dgvDSDA.RowCount && i >= 0)
            {
                txtMaDA.Text = dgvDSDA.Rows[i].Cells["Column2"].Value.ToString();
                txtTenDA.Text = dgvDSDA.Rows[i].Cells["Column3"].Value?.ToString();
                dtBegin.Value = DateTime.Parse(dgvDSDA.Rows[i].Cells["Column4"].Value.ToString());
                dtEnd.Value = DateTime.Parse(dgvDSDA.Rows[i].Cells["Column5"].Value?.ToString());
                txtGhiChu.Text = dgvDSDA.Rows[i].Cells["Column6"].Value?.ToString();
                LoadNV(txtMaDA.Text);


            }
        }
    }
}
