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
    public partial class frmQuanLyTaiKhoan : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadTK();
        }

        public void LoadTK()
        {
            int i = 0;
            dgvTaiKhoan.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT t.MaNV, n.TenNV, t.TenDangNhap, t.MatKhau from TaiKhoan as t INNER JOIN NVien as n on t.MaNV = n.MaNV ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvTaiKhoan.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["TenDangNhap"].ToString(), dr["MatKhau"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleQuanLyTaiKhoan qltk = new ModuleQuanLyTaiKhoan(this);
            qltk.ShowDialog();
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvTaiKhoan.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM TaiKhoan WHERE MaNV LIKE '" + dgvTaiKhoan[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {

                ModuleQuanLyTaiKhoan moduleQuanLyTaiKhoan = new ModuleQuanLyTaiKhoan(this);
                moduleQuanLyTaiKhoan.cboNhanVien.SelectedValue = dgvTaiKhoan[1, e.RowIndex].Value.ToString();
                
                moduleQuanLyTaiKhoan.txtTenTK.Text = dgvTaiKhoan[3, e.RowIndex].Value.ToString();
                moduleQuanLyTaiKhoan.txtMatKhau.Text = dgvTaiKhoan[4, e.RowIndex].Value.ToString();




                moduleQuanLyTaiKhoan.btnSave.Enabled = false;
                moduleQuanLyTaiKhoan.btnUpdate.Enabled = true;
                moduleQuanLyTaiKhoan.ShowDialog();

            }
            LoadTK();
        }
    }
}
