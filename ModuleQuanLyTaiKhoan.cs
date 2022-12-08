using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopBankHRMS
{
    public partial class ModuleQuanLyTaiKhoan : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmQuanLyTaiKhoan qltk;
        public ModuleQuanLyTaiKhoan(frmQuanLyTaiKhoan frmQuanLyTaiKhoan)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            qltk = frmQuanLyTaiKhoan;
            LoadNV();
        }
        public void LoadNV()
        {
            cboNhanVien.Items.Clear();
            cboNhanVien.DataSource = dbcon.getTable("SELECT * FROM NVien");
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;
        }
        public void Clear()
        {
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

            cboNhanVien.SelectedIndex = -1;
            txtMatKhau.Clear();
            txtTenTK.Clear();

        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu tài khoản này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO TaiKhoan(MaNV, TenDangNhap, MatKhau)VALUES(@manv,@tk, @mk)", cn);
                    cm.Parameters.AddWithValue("@manv", cboNhanVien.SelectedValue);
                    cm.Parameters.AddWithValue("@tk", txtTenTK.Text);
                    cm.Parameters.AddWithValue("@mk", txtMatKhau.Text);
                    
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    qltk.LoadTK();
                }
                qltk.LoadTK();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE TaiKhoan SET TenDangNhap = @tk , MatKhau = @mk WHERE MaNV LIKE '" + cboNhanVien.SelectedValue + "'", cn);
            cm.Parameters.AddWithValue("@tk", txtTenTK.Text);
            cm.Parameters.AddWithValue("@mk", txtMatKhau.Text);
            
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Cập nhật thành công", "Co-op Bank");
            Clear();
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
