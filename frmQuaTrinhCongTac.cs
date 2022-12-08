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
    public partial class frmQuaTrinhCongTac : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmQuaTrinhCongTac()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadQTCT();
        }

        public void LoadQTCT()
        {
            int i = 0;
            dgvQTCT.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT q.MaNV, n.TenNV,q.TGBD,q.TGKT,p.TenPB,c.ChucVu,q.LSCT from QTCT as q INNER JOIN NVien as n on n.MaNV = q.MaNV INNER JOIN PBan as p on p.MaPB = q.MaPB INNER JOIN ChucVu as c on c.MaCV = q.MaCV WHERE CONCAT(q.MaNV, n.TenNV,q.TGBD,q.TGKT,p.TenPB,c.ChucVu,q.LSCT) LIKE '%" + txtSearch.Text + "%'  ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvQTCT.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["TGBD"].ToString().Substring(0,dr["TGBD"].ToString().Length-11), dr["TGKT"].ToString().Substring(0, dr["TGBD"].ToString().Length - 11), dr["TenPB"].ToString(), dr["ChucVu"].ToString(), dr["LSCT"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvQTCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvQTCT.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM QTCT WHERE MaNV LIKE '" + dgvQTCT[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {

                ModuleQTCT categoryModule = new ModuleQTCT(this);
                categoryModule.lblMaNV.Text = dgvQTCT[1, e.RowIndex].Value.ToString();
                categoryModule.cboTenNV.Text = dgvQTCT[2, e.RowIndex].Value.ToString();
                categoryModule.dtbegin.Value = DateTime.Parse(dgvQTCT[3, e.RowIndex].Value.ToString());
                categoryModule.dtfinish.Value = DateTime.Parse(dgvQTCT[4, e.RowIndex].Value.ToString());
                categoryModule.cboPB.Text = dgvQTCT[5, e.RowIndex].Value.ToString();
                categoryModule.cboCV.Text = dgvQTCT[6, e.RowIndex].Value.ToString();
                categoryModule.txtLSCT.Text = dgvQTCT[7, e.RowIndex].Value.ToString();
                categoryModule.btnSave.Enabled = false;
                categoryModule.btnUpdate.Enabled = true;
                categoryModule.ShowDialog();

            }
            LoadQTCT();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleQTCT categoryModule = new ModuleQTCT(this);
            categoryModule.btnUpdate.Enabled = false;
            categoryModule.cboCV.SelectedIndex = -1;
            categoryModule.cboPB.SelectedIndex = -1;
            categoryModule.cboTenNV.SelectedIndex = -1;
            categoryModule.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadQTCT();
        }
    }
}
