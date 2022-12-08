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
    public partial class frmChamCong : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmChamCong()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCC();
            LoadThang();
            LoadNam();
        }
        public void LoadThang()
        {
            cboThang.Items.Clear();
            cboThang.DataSource = dbcon.getTable("SELECT DISTINCT Thang FROM ChamCong");
            cboThang.DisplayMember = "Thang";
            cboThang.ValueMember = "Thang";
            cboThang.Text = DateTime.Now.ToString("MM");
        }
        public void LoadNam()
        {
            cboNam.Items.Clear();
            cboNam.DataSource = dbcon.getTable("SELECT DISTINCT Nam FROM ChamCong");
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
            cboNam.Text = DateTime.Now.ToString("yyyy");

        }
        public void LoadCC()
        {
            int i = 0;
            dgvNhanSu.Rows.Clear();
            cn.Open();

            if (cbLoc.Checked)
            {
                cm = new SqlCommand("SELECT ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id,TUng from ChamCong inner join NVien as n on n.MaNV = ChamCong.MaNV WHERE CONCAT(ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id) LIKE '%" + txtSearch.Text + "%'  AND Thang = '" + cboThang.Text + "' and  Nam = '" + cboNam.Text + "'", cn);
            }
            else
            {
                cm = new SqlCommand("SELECT ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id,TUng from ChamCong inner join NVien as n on n.MaNV = ChamCong.MaNV WHERE CONCAT(ChamCong.MaNV, TenNV, NgHC,NgLe,NghiPhep,OT,Thang,Nam,id) LIKE '%" + txtSearch.Text + "%'", cn);
            }
            
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanSu.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["NgHC"].ToString(), dr["NgLe"].ToString(), dr["NghiPhep"].ToString(), dr["OT"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["id"].ToString(), dr["TUng"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleChamCong moduleChamCong = new ModuleChamCong(this);
            moduleChamCong.txtThang.Text = DateTime.Now.ToString("MM");
            moduleChamCong.txtNam.Text = DateTime.Now.ToString("yyyy");
            moduleChamCong.Show(); 
        }

        private void dgvNhanSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvNhanSu.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM ChamCong WHERE id LIKE '" + dgvNhanSu[9, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {

                ModuleChamCong hsns = new ModuleChamCong(this);
                hsns.cboNV.SelectedValue = dgvNhanSu[1, e.RowIndex].Value.ToString();
                hsns.txtThang.Text = dgvNhanSu[7, e.RowIndex].Value.ToString();
                hsns.txtNam.Text = dgvNhanSu[8, e.RowIndex].Value.ToString();
                hsns.lblID.Text = dgvNhanSu[9, e.RowIndex].Value.ToString();
                hsns.txtHC.Text = dgvNhanSu[3, e.RowIndex].Value.ToString();
                hsns.txtNL.Text = dgvNhanSu[4, e.RowIndex].Value.ToString();
                hsns.txtNP.Text = dgvNhanSu[5, e.RowIndex].Value.ToString();
                hsns.txtOT.Text = dgvNhanSu[6, e.RowIndex].Value.ToString();
                hsns.txtTamUng.Text=dgvNhanSu[10, e.RowIndex].Value.ToString();
                hsns.btnSave.Enabled = false;
                hsns.btnUpdate.Enabled = true;
                hsns.ShowDialog();

            }
            LoadCC();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCC();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCC();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCC();
        }

        private void cbLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadCC();
            if (cboThang.Visible == true)
            {
                cboThang.Visible = false;
                cboNam.Visible = false;
                guna2HtmlLabel3.Visible = false;
                guna2HtmlLabel2.Visible = false;
            }
            else
            {
                cboThang.Visible = true;
                cboNam.Visible = true;
                guna2HtmlLabel3.Visible = true;
                guna2HtmlLabel2.Visible = true;
            }
        }
    }
}
