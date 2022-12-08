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
    public partial class frmKhenThuongKyLuat : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmKhenThuongKyLuat()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadKT();
            LoadKL();
        }

        //tabKT
        public void LoadKT()
        {
            int i = 0;
            dgvKT.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT c.MaNV , n.TenNV, c.Thang, c.Nam, c.LyDo, c.TienThuong FROM NVien as n INNER JOIN KhenThuong as c on n.MaNV=c.MaNV  ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                int tienthuong = Int32.Parse(dr["TienThuong"].ToString());
                string tienthuong1 = tienthuong.ToString("N0");
                i++;
                dgvKT.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["LyDo"].ToString(), tienthuong1);
            }
            dr.Close();
            cn.Close();
        }

        
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // ModuleThuong moduleThuongPhat = new ModuleThuong(this);
            ModuleThuong moduleThuongPhat = new ModuleThuong(this);
            moduleThuongPhat.btnUpdate.Enabled = false;
            moduleThuongPhat.ShowDialog();
            moduleThuongPhat.cboTenNV.SelectedIndex = -1;
        }

        private void dgvKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                string colName = dgvKT.Columns[e.ColumnIndex].Name;
                if (colName == "DeleteKT")
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM KhenThuong WHERE MaNV LIKE '" + dgvKT[1, e.RowIndex].Value.ToString() + "'", cn);

                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (colName == "EditKT")
                {

                    ModuleThuong ModuleThuongPhat = new ModuleThuong(this);
                    ModuleThuongPhat.lblMaNV.Text = dgvKT[1, e.RowIndex].Value.ToString();
                    ModuleThuongPhat.cboTenNV.Text = dgvKT[2, e.RowIndex].Value.ToString();
                    ModuleThuongPhat.txtThang.Text = dgvKT[3, e.RowIndex].Value.ToString();
                    ModuleThuongPhat.txtNam.Text = dgvKT[4, e.RowIndex].Value.ToString();
                    ModuleThuongPhat.txtLyDo.Text = dgvKT[5, e.RowIndex].Value.ToString();
                    ModuleThuongPhat.txtTienThuong.Text = dgvKT[6, e.RowIndex].Value.ToString().Replace(",","");
                    ModuleThuongPhat.btnSave.Enabled = false;
                    ModuleThuongPhat.btnUpdate.Enabled = true;
                    ModuleThuongPhat.ShowDialog();

                }
                LoadKT();
            }
        }

        //tabKL

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            ModulePhat modulePhat = new ModulePhat(this);
            modulePhat.ShowDialog();
            modulePhat.cboTenNV.SelectedIndex = -1;
        }

        public void LoadKL()
        {
            int i = 0;
            dgvKL.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT c.MaNV , n.TenNV, c.Thang, c.Nam, c.LyDo, c.TienPhat, c.id FROM NVien as n INNER JOIN KyLuat as c on n.MaNV=c.MaNV  ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                int tienphat = Int32.Parse(dr["TienPhat"].ToString());
                string tienphat1 = tienphat.ToString("N0");
                i++;
                dgvKL.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["LyDo"].ToString(), tienphat1, dr["id"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvKL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                string colName = dgvKL.Columns[e.ColumnIndex].Name;
                if (colName == "DeleteKL")
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM KyLuat WHERE MaNV LIKE '" + dgvKL[1, e.RowIndex].Value.ToString() + "'", cn);

                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (colName == "EditKL")
                {

                    ModulePhat ModulePhat = new ModulePhat(this);
                    ModulePhat.lblID.Text = dgvKL[7, e.RowIndex].Value.ToString();
                    ModulePhat.cboTenNV.Text = dgvKL[2, e.RowIndex].Value.ToString();
                    ModulePhat.txtThang.Text = dgvKL[3, e.RowIndex].Value.ToString();
                    ModulePhat.txtNam.Text = dgvKL[4, e.RowIndex].Value.ToString();
                    ModulePhat.txtLyDo.Text = dgvKL[5, e.RowIndex].Value.ToString();
                    ModulePhat.txtTienPhat.Text = dgvKL[6, e.RowIndex].Value.ToString().Replace(",", "");
                    ModulePhat.btnSave.Enabled = false;
                    ModulePhat.btnUpdate.Enabled = true;
                    ModulePhat.ShowDialog();

                }
                LoadKL();
        }   }
    }
}
