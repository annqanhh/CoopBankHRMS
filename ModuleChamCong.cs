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
    public partial class ModuleChamCong : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmChamCong chamcong;
        public ModuleChamCong(frmChamCong cc)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            chamcong = cc;
            LoadNV();
        }
        public void LoadNV()
        {
            cboNV.Items.Clear();
            cboNV.DataSource = dbcon.getTable("SELECT * FROM NVien");
            cboNV.DisplayMember = "TenNV";
            cboNV.ValueMember = "MaNV";
            cboNV.SelectedIndex = -1;
        }
        private void picClose_Click(object sender, EventArgs e)
        {
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
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu hồ sơ này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO ChamCong(MaNV,NgHC,NgLe,NghiPhep,OT,Thang,Nam,TUng)VALUES(@manv,@nghc, @ngle, @nghile,@ot,@thang,@nam,@tung)", cn);
                    cm.Parameters.AddWithValue("@manv", cboNV.SelectedValue);
                    cm.Parameters.AddWithValue("@nghc", Int32.Parse(txtHC.Text));
                    cm.Parameters.AddWithValue("@ngle", Int32.Parse(txtNL.Text));
                    cm.Parameters.AddWithValue("@nghile", Int32.Parse(txtNP.Text));
                    cm.Parameters.AddWithValue("@ot", Int32.Parse(txtOT.Text));
                    cm.Parameters.AddWithValue("@thang", txtThang.Text);
                    cm.Parameters.AddWithValue("@nam", txtNam.Text);
                    cm.Parameters.AddWithValue("@tung", Int32.Parse(txtTamUng.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();

                    
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Clear();
                    chamcong.LoadCC();
                }
                chamcong.LoadCC();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            cboNV.SelectedIndex = -1;
            txtThang.Clear();
            txtNam.Clear();
            txtHC.Clear();
            txtNL.Clear();
            txtNP.Clear();
            txtOT.Clear();
            txtTamUng.Clear();
           

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE ChamCong SET MaNV=@tennv, NgHC = @hc , NgLe = @ngle, NghiPhep = @nghiphep, OT = @ot, Thang = @thang, Nam = @nam ,TUng = @tung WHERE id LIKE '" + lblID.Text + "'", cn);
            cm.Parameters.AddWithValue("@tennv", cboNV.SelectedValue);
            cm.Parameters.AddWithValue("@hc", Int32.Parse(txtHC.Text));
            cm.Parameters.AddWithValue("@ngle", Int32.Parse(txtNL.Text));
            cm.Parameters.AddWithValue("@nghiphep", Int32.Parse(txtNP.Text));
            cm.Parameters.AddWithValue("@ot", Int32.Parse(txtOT.Text));
            cm.Parameters.AddWithValue("@thang", txtThang.Text);
            cm.Parameters.AddWithValue("@nam", txtNam.Text);
            cm.Parameters.AddWithValue("@tung", Int32.Parse(txtTamUng.Text));
            cm.ExecuteNonQuery();
            cn.Close();
            chamcong.LoadCC();

            MessageBox.Show("Cập nhật thành công", "Co-op Bank");
            Clear();
            this.Dispose();
        }
    }
}
