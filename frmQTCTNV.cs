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
    public partial class frmQTCTNV : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public frmQTCTNV(string nv)
        {

            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            string manv = nv;
            LoadQTCT(manv);
            
            
        }
        
        public void Clear()
        {
            btnUpdate.Enabled = false;

            cboTenNV.Clear();
            cboCV.Clear();
            cboPB.Clear();
            dtbegin.Value = DateTime.Now;
            dtfinish.Value = DateTime.Now;
            txtLSCT.Clear();
        }
        public void LoadQTCT(string nv)
        {
            string manv = nv;
            int i = 0;
            dgvQTCT.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT q.MaNV, n.TenNV,q.TGBD,q.TGKT,p.TenPB,c.ChucVu,q.LSCT from QTCT as q INNER JOIN NVien as n on n.MaNV = q.MaNV INNER JOIN PBan as p on p.MaPB = q.MaPB INNER JOIN ChucVu as c on c.MaCV = q.MaCV WHERE q.MaNV = '" + manv + "' ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvQTCT.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["TGBD"].ToString(), dr["TGKT"].ToString(), dr["TenPB"].ToString(), dr["ChucVu"].ToString(), dr["LSCT"].ToString());
            }
            lblMaNV.Text = dgvQTCT["MaNV", 0].Value.ToString();
            cboTenNV.Text = dgvQTCT["TenNV", 0].Value.ToString();
            dtbegin.Value = DateTime.Parse(dgvQTCT["TGBD", 0].Value.ToString());
            dtfinish.Value = DateTime.Parse(dgvQTCT["TGKT", 0].Value.ToString());
            cboPB.Text = dgvQTCT["TenPB", 0].Value.ToString();
            cboCV.Text = dgvQTCT["ChucVu", 0].Value.ToString();
            txtLSCT.Text = dgvQTCT["LSCT", 0].Value.ToString();
            dr.Close();
            cn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("UPDATE QTCT SET TGBD=@tgbd, TGKT = @tgkt , MaCV = @macv , MaPB = @mapb, LSCT = @lsct WHERE MaNV LIKE '" + cboTenNV.Text + "'", cn);
            cm.Parameters.AddWithValue("@macv", cboCV.Text);
            cm.Parameters.AddWithValue("@mapb", cboPB.Text);
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
    }
}
