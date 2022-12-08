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
    public partial class ModulePhongBan : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmPhongBan phongban;
        public ModulePhongBan(frmPhongBan pb)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            phongban = pb;
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
                    cm = new SqlCommand("INSERT INTO PBan(MaPB,TenPB)VALUES(@mapb,@pb)", cn);
                    cm.Parameters.AddWithValue("@mapb", txtMaPB.Text);
                    cm.Parameters.AddWithValue("@pb", txtTenPB.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    phongban.LoadPB();
                }
                phongban.LoadPB();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE PBan SET TenPB =@pb WHERE MaPB LIKE '" + txtMaPB.Text + "'", cn);
            cm.Parameters.AddWithValue("@pb", txtTenPB.Text);
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

        public void Clear()
        {
            txtMaPB.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtTenPB.Clear();
            txtMaPB.Focus();
        }
    }
}
