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
    public partial class frmHSNSNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        frmHoSoNhanSu hoSoNhanSu;
        SqlDataReader dr;
        public frmHSNSNV(string nv)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCV();
            LoadPB();
            string manv = nv;
            LoadHSNS(manv);
           
        }
        public void LoadHSNS(string nv)
        {
            string manv = nv;
            int i = 0;
            dgvNhanSu.Rows.Clear();

            cn.Open();
            MessageBox.Show(manv);
            cm = new SqlCommand("SELECT n.MaNV,n.TenNV,c.ChucVu,p.TenPB, h.NgSinh, h.NoiSinh, h.QQuan, h.DToc, h.TDo, h.HKTT, h.SoCCCD, h.NgCap,h.NoiCap, h.NgayKyHopDong,h.ThoiHanHopDong,h.GhiChu,h.GTinh,h.Anh, n.HSLCB,n.HSLPC,h.SoBHYT,h.SoBHXH, h.SDT FROM NVien as n INNER JOIN ChucVu as c on n.MaCV = c.MaCV INNER JOIN PBan as p on p.MaPB = n.MaPB INNER JOIN HoSoNV as h on h.MaNV = n.MaNV WHERE n.MaNV = '"+manv+"'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanSu.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["ChucVu"].ToString(), dr["TenPB"].ToString(), dr["NgSinh"].ToString(), dr["NoiSinh"].ToString(), dr["QQuan"].ToString(), dr["DToc"].ToString(), dr["TDo"].ToString(), dr["HKTT"].ToString(), dr["SoCCCD"].ToString(), dr["NgCap"].ToString(), dr["NoiCap"].ToString(), dr["NgayKyHopDong"].ToString(), dr["ThoiHanHopDong"].ToString(), dr["GhiChu"].ToString(), dr["GTinh"].ToString(), dr["Anh"].ToString(), dr["HSLCB"].ToString(), dr["HSLPC"].ToString(), dr["SoBHYT"].ToString(), dr["SoBHXH"].ToString(),dr["SDT"].ToString());
            }
            txtMaNV.Text = dgvNhanSu["MaNV", 0].Value?.ToString();

            txtTenNV.Text = dgvNhanSu["HoTen", 0].Value?.ToString();
            cboCV.SelectedText = dgvNhanSu["CV", 0].Value?.ToString();
            cboPB.SelectedText = dgvNhanSu["PB", 0].Value?.ToString();

            dateNS.Value = DateTime.Parse(dgvNhanSu["NgSinh", 0].Value?.ToString());
            txtNoiSinh.Text = dgvNhanSu["NoiSinh", 0].Value?.ToString();
            txtQueQuan.Text = dgvNhanSu["QQ", 0].Value?.ToString();
            txtDanToc.Text = dgvNhanSu["DToc", 0].Value?.ToString();
            txtTrinhDo.Text = dgvNhanSu["TDo", 0].Value?.ToString();
            txtHKTT.Text = dgvNhanSu["HKTT", 0].Value?.ToString();
            txtCCCD.Text = dgvNhanSu["SoCCCD", 0].Value?.ToString();
            txtSDT.Text = dgvNhanSu["SDT", 0].Value?.ToString();
            dateNCCC.Value = DateTime.Parse(dgvNhanSu["NgCap", 0].Value?.ToString());
            txtNoiCap.Text = dgvNhanSu["NoiCap", 0].Value?.ToString();
            dateKyHD.Value = DateTime.Parse(dgvNhanSu["NgayKy", 0].Value?.ToString());
            dateHanHD.Value = DateTime.Parse(dgvNhanSu["ThoiHan", 0].Value?.ToString());
            txtGhiChu.Text = dgvNhanSu["GhiChu", 0].Value?.ToString();
            cboGT.Text = dgvNhanSu["GTinh", 0].Value?.ToString();
            lblPicLink.Text = dgvNhanSu["Anh", 0].Value?.ToString();
            txtHSLCB.Text = dgvNhanSu["HSLCB", 0].Value?.ToString();
            txtHSLPC.Text = dgvNhanSu["HSLPC", 0].Value?.ToString();
            BHXH.Text = dgvNhanSu["SoBHXH", 0].Value?.ToString();
            BHYT.Text = dgvNhanSu["SoBHYT", 0].Value?.ToString();
            picAnh.ImageLocation = dgvNhanSu["Anh", 0].Value?.ToString();
            
            dr.Close();
            cn.Close();
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
