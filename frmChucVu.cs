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
    public partial class frmChucVu : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmChucVu()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadCV();
        }
        public void LoadCV()
        {
            int i = 0;
            dgvChucVu.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * from ChucVu ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvChucVu.Rows.Add(i, dr["MaCV"].ToString(), dr["ChucVu"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleChucVu mdcv = new ModuleChucVu(this);
            mdcv.ShowDialog();
        }

        private void dgvChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvChucVu.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá chức vụ này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM ChucVu WHERE MaCV LIKE '" + dgvChucVu[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (colName == "Edit")
            {
                ModuleChucVu categoryModule = new ModuleChucVu(this);
                categoryModule.txtMaCV.Text = dgvChucVu[1, e.RowIndex].Value.ToString();
                categoryModule.txtTenCV.Text = dgvChucVu[2, e.RowIndex].Value.ToString();
                categoryModule.btnSave.Enabled = false;
                categoryModule.btnUpdate.Enabled = true;
                categoryModule.ShowDialog();

            }
            LoadCV();
        }
    }
}
