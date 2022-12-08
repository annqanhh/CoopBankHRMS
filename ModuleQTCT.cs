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
    public partial class ModuleQTCT : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmQuaTrinhCongTac qtct;
        public ModuleQTCT(frmQuaTrinhCongTac frmQuaTrinhCongTac)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            qtct = frmQuaTrinhCongTac;
            LoadTenNV();
            LoadCV();
            LoadPB();
            
        }
        public void LoadTenNV()
        {
            cboTenNV.Items.Clear();
            cboTenNV.DataSource = dbcon.getTable("SELECT * FROM NVien");
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";
            cboTenNV.SelectedIndex = -1;
        }
        public void LoadCV()
        {
            cboCV.Items.Clear();
            cboCV.DataSource = dbcon.getTable("SELECT * FROM ChucVu");
            cboCV.DisplayMember = "ChucVu";
            cboCV.ValueMember = "MaCV";
            cboCV.SelectedIndex = -1;
        }
        public void LoadPB()
        {
            cboPB.Items.Clear();
            cboPB.DataSource = dbcon.getTable("SELECT * FROM PBan");
            cboPB.DisplayMember = "TenPB";
            cboPB.ValueMember = "MaPB";
            cboPB.SelectedIndex = -1;
        }   
            public void Clear()
        {
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            cboTenNV.SelectedIndex = -1;
            cboCV.SelectedIndex = -1;
            cboPB.SelectedIndex = -1;
            dtbegin.Value = DateTime.Now;
            dtfinish.Value = DateTime.Now;
            txtLSCT.Clear();
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
                    cm = new SqlCommand("INSERT INTO QTCT(MaNV,TGBD,TGKT,MaCV,MaPB,LSCT)VALUES(@manv,@tgbd, @tgkt, @macv, @mapb, @lsct)", cn);
                    cm.Parameters.AddWithValue("@manv", cboTenNV.SelectedValue);
                    cm.Parameters.AddWithValue("@macv", cboCV.SelectedValue);
                    cm.Parameters.AddWithValue("@mapb", cboPB.SelectedValue);
                    cm.Parameters.AddWithValue("@tgbd", dtbegin.Value);
                    cm.Parameters.AddWithValue("@tgkt", dtfinish.Value);
                    cm.Parameters.AddWithValue("@lsct", txtLSCT.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    qtct.LoadQTCT();
                }
                qtct.LoadQTCT();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE QTCT SET TGBD=@tgbd, TGKT = @tgkt , MaCV = @macv , MaPB = @mapb, LSCT = @lsct WHERE MaNV LIKE '" + cboTenNV.SelectedValue + "'", cn);
            cm.Parameters.AddWithValue("@macv", cboCV.SelectedValue);
            cm.Parameters.AddWithValue("@mapb", cboPB.SelectedValue);
            cm.Parameters.AddWithValue("@tgbd", dtbegin.Value);
            cm.Parameters.AddWithValue("@tgkt", dtfinish.Value);
            cm.Parameters.AddWithValue("@lsct", txtLSCT.Text);
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

        private void ModuleQTCT_Load(object sender, EventArgs e)
        {

        }
    }
}
