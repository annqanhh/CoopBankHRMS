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
    public partial class ModulePhat : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmKhenThuongKyLuat ktkl;
        public ModulePhat(frmKhenThuongKyLuat kl)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            ktkl = kl;
            LoadTenNV();
        }

        public void LoadTenNV()
        {
            cboTenNV.Items.Clear();
            cboTenNV.DataSource = dbcon.getTable("SELECT * FROM NVien");
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";
            cboTenNV.SelectedIndex = -1;
        }

        public void Clear()
        {
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            cboTenNV.SelectedIndex = -1;
            cboTenNV.SelectedIndex = -1;
            txtThang.Clear();
            txtNam.Clear();
            txtLyDo.Clear();
            txtTienPhat.Clear();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu chức danh này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO KyLuat(MaNV,Thang,Nam,LyDo,TienPhat)VALUES(@manv,@thang, @nam, @lydo, @tienphat)", cn);
                    cm.Parameters.AddWithValue("@manv", cboTenNV.SelectedValue);
                    cm.Parameters.AddWithValue("@thang", txtThang.Text);
                    cm.Parameters.AddWithValue("@nam", txtNam.Text);
                    cm.Parameters.AddWithValue("@lydo", txtLyDo.Text);
                    cm.Parameters.AddWithValue("@tienphat", txtTienPhat.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    ktkl.LoadKL();
                }
                ktkl.LoadKL();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE KyLuat SET Thang = @thang , Nam = @nam , LyDo = @lydo, TienPhat = @tienphat WHERE id LIKE '" + lblID.Text + "'", cn);
           
            cm.Parameters.AddWithValue("@thang", txtThang.Text);
            cm.Parameters.AddWithValue("@nam", txtNam.Text);
            cm.Parameters.AddWithValue("@lydo", txtLyDo.Text);
            cm.Parameters.AddWithValue("@tienphat", txtTienPhat.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Cập nhật thành công", "Co-op Bank");
            Clear();
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
