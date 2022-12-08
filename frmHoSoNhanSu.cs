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
    public partial class frmHoSoNhanSu : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmHoSoNhanSu()
        {
            
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadHSNS();
            

        }

        public void LoadHSNS()
        {
            int i = 0;
            dgvNhanSu.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT n.MaNV,n.TenNV,c.ChucVu,p.TenPB, h.NgSinh, h.NoiSinh, h.QQuan, h.DToc, h.TDo, h.HKTT, h.SoCCCD, h.NgCap,h.NoiCap, h.NgayKyHopDong,h.ThoiHanHopDong,h.GhiChu,h.GTinh,h.Anh, n.HSLCB,n.HSLPC,h.SoBHYT,h.SoBHXH,h.SDT FROM NVien as n INNER JOIN ChucVu as c on n.MaCV = c.MaCV INNER JOIN PBan as p on p.MaPB = n.MaPB INNER JOIN HoSoNV as h on h.MaNV = n.MaNV WHERE CONCAT(n.MaNV,n.TenNV,c.ChucVu,p.TenPB) LIKE '%" + txtSearch.Text + "%' ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanSu.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["ChucVu"].ToString(), dr["TenPB"].ToString(), dr["NgSinh"].ToString(), dr["NoiSinh"].ToString(), dr["QQuan"].ToString(), dr["DToc"].ToString(), dr["TDo"].ToString(), dr["HKTT"].ToString(), dr["SoCCCD"].ToString(), dr["NgCap"].ToString(), dr["NoiCap"].ToString(), dr["NgayKyHopDong"].ToString(), dr["ThoiHanHopDong"].ToString(), dr["GhiChu"].ToString(),dr["GTinh"].ToString(), dr["Anh"].ToString(),dr["HSLCB"].ToString(),dr["HSLPC"].ToString(),dr["SoBHYT"].ToString(),dr["SoBHXH"].ToString(),dr["SDT"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleHoSoNhanSu hsns = new ModuleHoSoNhanSu(this);
            hsns.ShowDialog();
        }

        private void dgvNhanSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvNhanSu.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM NVien WHERE MaNV LIKE '" + dgvNhanSu[1, e.RowIndex].Value?.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("DELETE FROM HoSoNV WHERE MaNV LIKE '" + dgvNhanSu[1, e.RowIndex].Value?.ToString() + "'", cn);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {

                ModuleHoSoNhanSu hsns = new ModuleHoSoNhanSu(this);
                hsns.txtMaNV.Text = dgvNhanSu["MaNV", e.RowIndex].Value?.ToString();
                
                hsns.txtTenNV.Text = dgvNhanSu["HoTen", e.RowIndex].Value?.ToString();
                hsns.cboCV.Text = dgvNhanSu["CV", e.RowIndex].Value?.ToString();
                hsns.cboPB.Text = dgvNhanSu["PB", e.RowIndex].Value?.ToString();
                
                hsns.dateNS.Value = DateTime.Parse(dgvNhanSu["NgSinh", e.RowIndex].Value?.ToString());
                hsns.txtNoiSinh.Text = dgvNhanSu["NoiSinh", e.RowIndex].Value?.ToString();
                hsns.txtQueQuan.Text = dgvNhanSu["QQ", e.RowIndex].Value?.ToString();
                hsns.txtDanToc.Text = dgvNhanSu["DToc", e.RowIndex].Value?.ToString();
                hsns.txtTrinhDo.Text = dgvNhanSu["TDo", e.RowIndex].Value?.ToString();
                hsns.txtHKTT.Text = dgvNhanSu["HKTT", e.RowIndex].Value?.ToString();
                hsns.txtCCCD.Text = dgvNhanSu["SoCCCD", e.RowIndex].Value?.ToString();
                hsns.txtSDT.Text = dgvNhanSu["SDT", e.RowIndex].Value?.ToString();
                hsns.dateNCCC.Value = DateTime.Parse(dgvNhanSu["NgCap", e.RowIndex].Value?.ToString());
                hsns.txtNoiCap.Text = dgvNhanSu["NoiCap", e.RowIndex].Value?.ToString();
                hsns.dateKyHD.Value = DateTime.Parse(dgvNhanSu["NgayKy", e.RowIndex].Value?.ToString());
                hsns.dateHanHD.Value = DateTime.Parse(dgvNhanSu["ThoiHan", e.RowIndex].Value?.ToString());
                hsns.txtGhiChu.Text = dgvNhanSu["GhiChu", e.RowIndex].Value?.ToString();
                hsns.cboGT.Text = dgvNhanSu["GTinh", e.RowIndex].Value?.ToString();
                hsns.lblPicLink.Text = dgvNhanSu["Anh", e.RowIndex].Value?.ToString();
                hsns.txtHSLCB.Text = dgvNhanSu["HSLCB", e.RowIndex].Value?.ToString();
                hsns.txtHSLPC.Text = dgvNhanSu["HSLPC", e.RowIndex].Value?.ToString();
                hsns.BHXH.Text = dgvNhanSu["SoBHXH", e.RowIndex].Value?.ToString();
                hsns.BHYT.Text = dgvNhanSu["SoBHYT", e.RowIndex].Value?.ToString();
                hsns.picAnh.ImageLocation = dgvNhanSu["Anh", e.RowIndex].Value?.ToString();

                hsns.btnSave.Enabled = false;
                hsns.btnUpdate.Enabled = true;
                hsns.ShowDialog();

            }
            LoadHSNS();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ModuleHoSoNhanSu hsns = new ModuleHoSoNhanSu(this);
            hsns.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadHSNS();
        }
    }
}
