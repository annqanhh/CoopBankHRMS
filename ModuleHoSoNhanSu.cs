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
    public partial class ModuleHoSoNhanSu : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmHoSoNhanSu hoSoNhanSu;
        public ModuleHoSoNhanSu(frmHoSoNhanSu hs)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            hoSoNhanSu = hs;
            LoadCV();
            LoadPB();
            
        }
        public void LoadCV()
        {
            cboCV.Items.Clear();
            cboCV.DataSource = dbcon.getTable("SELECT * FROM ChucVu");
            cboCV.DisplayMember = "ChucVu";
            cboCV.ValueMember = "MaCV";
            
        }
        public void LoadPB()
        {
            cboPB.Items.Clear();
            cboPB.DataSource = dbcon.getTable("SELECT * FROM PBan");
            cboPB.DisplayMember = "TenPB";
            cboPB.ValueMember = "MaPB";
            
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu hồ sơ này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO NVien(MaNV,TenNV,MaCV,MaPB,HSLCB,HSLPC)VALUES(@manv,@ten, @cv, @pb, @lcb, @lpc)", cn);
                    cm.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cm.Parameters.AddWithValue("@ten", txtTenNV.Text);
                    cm.Parameters.AddWithValue("@cv", cboCV.SelectedValue);
                    cm.Parameters.AddWithValue("@pb", cboPB.SelectedValue);
                    cm.Parameters.AddWithValue("@lcb", txtHSLCB.Text);
                    cm.Parameters.AddWithValue("@lpc", txtHSLPC.Text);
                    
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("INSERT INTO HoSoNV(MaNV,NgSinh,NoiSinh,QQuan,DToc,TDo,HKTT,SoCCCD,NgCap,NoiCap,NgayKyHopDong,ThoiHanHopDong,GhiChu,GTinh,Anh,SDT)VALUES(@manv,@ngsinh,@noisinh,@qq,@dt,@td,@hktt,@socc,@ngcap,@noicap,@ngky,@han,@ghichu,@gt,@anh,@sdt)", cn);
                    cm.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cm.Parameters.AddWithValue("@ngsinh", dateNS.Value);
                    cm.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
                    cm.Parameters.AddWithValue("@qq", txtQueQuan.Text);
                    cm.Parameters.AddWithValue("@dt", txtDanToc.Text);
                    cm.Parameters.AddWithValue("@td", txtTrinhDo.Text);
                    cm.Parameters.AddWithValue("@hktt", txtHKTT.Text);
                    cm.Parameters.AddWithValue("@socc", txtCCCD.Text);
                    cm.Parameters.AddWithValue("@ngcap", dateNCCC.Value);
                    cm.Parameters.AddWithValue("@noicap", txtNoiCap.Text);
                    cm.Parameters.AddWithValue("@ngky", dateKyHD.Value);
                    cm.Parameters.AddWithValue("@han", dateHanHD.Value);
                    cm.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                    cm.Parameters.AddWithValue("@gt", cboGT.Text);
                    cm.Parameters.AddWithValue("@anh", lblPicLink.Text);
                    cm.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Lưu thành công", "Co-op Bank");
                    Utilities.ClearAllControls(this);
                    hoSoNhanSu.LoadHSNS();
                }
                hoSoNhanSu.LoadHSNS();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE NVien SET TenNV=@tennv, MaPB = @mapb , MaCV = @macv, HSLCB = @lcb, HSLPC=@lpc  WHERE MaNV LIKE '" + txtMaNV.Text + "'", cn);
            cm.Parameters.AddWithValue("@macv", cboCV.SelectedValue);
            cm.Parameters.AddWithValue("@mapb", cboPB.SelectedValue);
            cm.Parameters.AddWithValue("@tennv", txtTenNV.Text);
            cm.Parameters.AddWithValue("@lcb", txtHSLCB.Text);
            cm.Parameters.AddWithValue("@lpc", txtHSLPC.Text);

            cm.ExecuteNonQuery();
            cn.Close();
            
            

            cn.Open();
            cm = new SqlCommand("UPDATE HoSoNV SET NgSinh=@ngsinh, NoiSinh = @noisinh , QQuan = @qq , DToc = @dt, TDo = @td, HKTT=@hktt, SoCCCD=@socc, NoiCap=@noicap,NgayKyHopDong=@ngky,ThoiHanHopDong=@han,GhiChu=@ghichu,GTinh=@gt,Anh=@anh, SDT=@sdt WHERE MaNV LIKE '" + txtMaNV.Text + "'", cn);
            cm.Parameters.AddWithValue("@manv", txtMaNV.Text);
            cm.Parameters.AddWithValue("@ngsinh", dateNS.Value);
            cm.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
            cm.Parameters.AddWithValue("@qq", txtQueQuan.Text);
            cm.Parameters.AddWithValue("@dt", txtDanToc.Text);
            cm.Parameters.AddWithValue("@td", txtTrinhDo.Text);
            cm.Parameters.AddWithValue("@hktt", txtHKTT.Text);
            cm.Parameters.AddWithValue("@socc", txtCCCD.Text);
            cm.Parameters.AddWithValue("@ngcap", txtNoiCap.Text);
            cm.Parameters.AddWithValue("@noicap", txtNoiCap.Text);
            cm.Parameters.AddWithValue("@ngky", dateKyHD.Value);
            cm.Parameters.AddWithValue("@han", dateHanHD.Value);
            cm.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
            cm.Parameters.AddWithValue("@gt", cboGT.Text);
            cm.Parameters.AddWithValue("@anh", lblPicLink.Text);
            cm.Parameters.AddWithValue("@sdt", txtSDT.Text);
            cm.ExecuteNonQuery();
            cn.Close();



            MessageBox.Show("Cập nhật thành công", "Co-op Bank");
            Utilities.ClearAllControls(this);
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Utilities.ClearAllControls(this);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                lblPicLink.Text = opnfd.FileName;
                picAnh.ImageLocation = lblPicLink.Text;
            }
        }
    }
}
