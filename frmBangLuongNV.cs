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
    public partial class frmBangLuongNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string manv;
        public frmBangLuongNV(string nv)
        {
            manv = nv;
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadBL();
            LoadThang();
            LoadNam();
        }
        public void LoadThang()
        {
            cboThang.Items.Clear();
            cboThang.DataSource = dbcon.getTable("SELECT DISTINCT Thang FROM BangLuong where MaNV = '"+manv+"'");
            cboThang.DisplayMember = "Thang";
            cboThang.ValueMember = "Thang";
            cboThang.Text = DateTime.Now.ToString("MM");
        }
        public void LoadNam()
        {
            cboNam.Items.Clear();
            cboNam.DataSource = dbcon.getTable("SELECT DISTINCT Nam FROM BangLuong where MaNV = '" + manv + "'");
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
            cboNam.Text = DateTime.Now.ToString("yyyy");
        }
        public void LoadBL()
        {
            int i = 0;

            dgvBangLuong.Rows.Clear();
            cn.Open();
            if (cbLoc.Checked)
            {
                cm = new SqlCommand("SELECT b.id,b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu FROM BangLuong as b inner join NVien as n on n.MaNv = b.MaNV WHERE CONCAT( b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu) LIKE '%" + txtSearch.Text + "%' AND b.Thang = '" + cboThang.Text + "' AND b.Nam = '" + cboNam.Text + "'  AND b.MaNV = '" + manv + "'", cn);
            }
            else
            {
                cm = new SqlCommand("SELECT b.id,b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu FROM BangLuong as b inner join NVien as n on n.MaNv = b.MaNV WHERE CONCAT( b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu) LIKE '%" + txtSearch.Text + "%' AND b.MaNV = '" + manv + "' ", cn);
            }

            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                int tung = Int32.Parse(dr["TUng"].ToString());
                string tung1 = tung.ToString("N0");
                int bhxh = Int32.Parse(dr["NopBHXH"].ToString());
                string bhxh1 = bhxh.ToString("N0");
                int tong = Int32.Parse(dr["Tong"].ToString());
                string tong1 = tong.ToString("N0");
                int bhyt = Int32.Parse(dr["NopBHYT"].ToString());
                string bhyt1 = bhyt.ToString("N0");
                dgvBangLuong.Rows.Add(i, dr["id"].ToString(), dr["MaBangLuong"].ToString(), dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["HSLCB"].ToString(), dr["HSLPC"].ToString(), tung1, bhxh1, bhyt1, tong1, dr["GhiChu"].ToString());

            }
            dr.Close();
            cn.Close();
        }

        private void cbLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadBL();
            if (cboThang.Visible == true)
            {
                cboThang.Visible = false;
                cboNam.Visible = false;
                guna2HtmlLabel1.Visible = false;
                guna2HtmlLabel2.Visible = false;
            }
            else
            {
                cboThang.Visible = true;
                cboNam.Visible = true;
                guna2HtmlLabel1.Visible = true;
                guna2HtmlLabel2.Visible = true;
            }
        }
    }
}
