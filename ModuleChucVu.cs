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
    public partial class ModuleChucVu : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmChucVu chucvu;
        public ModuleChucVu(frmChucVu cv)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            chucvu = cv;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE ChucVu SET ChucVu =@chucvu WHERE MaCV LIKE'" + txtMaCV.Text + "'", cn);
            cm.Parameters.AddWithValue("@chucvu", txtTenCV.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu chức danh này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO ChucVu(MaCV,ChucVu)VALUES(@macv,@tencv)", cn);
                    cm.Parameters.AddWithValue("@macv", txtMaCV.Text);
                    cm.Parameters.AddWithValue("@tencv", txtTenCV.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    chucvu.LoadCV();
                }
                chucvu.LoadCV();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtMaCV.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtTenCV.Clear();
            txtMaCV.Focus();
        }


    }
}
