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
    public partial class frmChamCongNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string manv;
        public frmChamCongNV(string nv)
        {
            manv = nv;
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCC(manv);
            LoadThang();
            LoadNam();
        }
        public void LoadThang()
        {
            cboThang.Items.Clear();
            cboThang.DataSource = dbcon.getTable("SELECT DISTINCT Thang FROM ChamCong where MaNV = '"+manv+"'");
            cboThang.DisplayMember = "Thang";
            cboThang.ValueMember = "Thang";
            cboThang.Text = DateTime.Now.ToString("MM");
        }
        public void LoadNam()
        {
            cboNam.Items.Clear();
            cboNam.DataSource = dbcon.getTable("SELECT DISTINCT Nam FROM ChamCong  where MaNV = '" + manv + "'");
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
            cboNam.Text = DateTime.Now.ToString("yyyy");

        }
        public void LoadCC(string nv)
        {
            manv = nv;
            int i = 0;
            dgvNhanSu.Rows.Clear();
            
            cn.Open();
            if (cbLoc.Checked) {
                cm = new SqlCommand("SELECT ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id,TUng from ChamCong inner join NVien as n on n.MaNV = ChamCong.MaNV WHERE CONCAT(ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id) LIKE '%" + txtSearch.Text + "%' AND ChamCong.MaNV = '" + manv + "' AND Thang = '" + cboThang.Text + "' and  Nam = '" + cboNam.Text + "'", cn);
            }
            else
            {
                cm = new SqlCommand("SELECT ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id,TUng from ChamCong inner join NVien as n on n.MaNV = ChamCong.MaNV WHERE CONCAT(ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id) LIKE '%" + txtSearch.Text + "%' AND ChamCong.MaNV = '" + manv + "'", cn);
            }
            
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanSu.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["NgHC"].ToString(), dr["NgLe"].ToString(), dr["NghiPhep"].ToString(), dr["OT"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["id"].ToString(), dr["TUng"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cbLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadCC(manv);
            if(cboThang.Visible == true)
            {
                cboThang.Visible = false;
                cboNam.Visible = false;
                guna2HtmlLabel3.Visible = false;
                guna2HtmlLabel2.Visible = false;
            }
            else
            {
                cboThang.Visible = true;
                cboNam.Visible = true;
                guna2HtmlLabel3.Visible = true;
                guna2HtmlLabel2.Visible = true;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCC(manv);
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCC(manv);
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCC(manv);
        }
    }
}
