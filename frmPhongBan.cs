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
    public partial class frmPhongBan : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmPhongBan()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadPB();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModulePhongBan mdpb = new ModulePhongBan(this);
            mdpb.ShowDialog();
        }
        public void LoadPB()
        {
            int i = 0;
            dgvPhongBan.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * from PBan WHERE CONCAT(MaPB,TenPB) LIKE '%" + txtSearch.Text + "%' ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvPhongBan.Rows.Add(i, dr["MaPB"].ToString(), dr["TenPB"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvPhongBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPhongBan.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM PBan WHERE MaPB LIKE '" + dgvPhongBan[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {
               
                ModulePhongBan categoryModule = new ModulePhongBan(this);
                categoryModule.txtMaPB.Text = dgvPhongBan[1, e.RowIndex].Value.ToString();
                categoryModule.txtTenPB.Text = dgvPhongBan[2, e.RowIndex].Value.ToString();
                categoryModule.btnSave.Enabled = false;
                categoryModule.btnUpdate.Enabled = true;
                categoryModule.ShowDialog();
               
            }
            LoadPB();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPB();
        }
    }
}
