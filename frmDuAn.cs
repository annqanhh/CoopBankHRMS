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
    public partial class frmDuAn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmDuAn()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadDA();
            LoadCbNV();
            
        }
        public void LoadCbNV()
        {
            cboNV.Items.Clear();
            cboNV.DataSource = dbcon.getTable("SELECT * FROM NVien");
            cboNV.DisplayMember = "TenNV";
            cboNV.ValueMember = "MaNV";
            cboNV.SelectedIndex = -1;
        }
        public void LoadDA()
        {
            int i = 0;
            dgvDSDA.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select MaDA, TenDA, NgBatDau, NgKetThuc,GhiChu from CTDuAn WHERE CONCAT( MaDA, TenDA, NgBatDau, NgKetThuc,GhiChu) LIKE N'%" + txtSearch.Text + "%'  ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvDSDA.Rows.Add(i, dr["MaDA"].ToString(), dr["TenDA"].ToString(), dr["NgBatDau"].ToString().Substring(0, dr["NgBatDau"].ToString().Length - 11), dr["NgKetThuc"].ToString().Substring(0, dr["NgKetThuc"].ToString().Length - 11), dr["GhiChu"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadNV(string mada)
        {
            int i = 0;
            dgvNhanVien.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select MaDA, DuAn.MaNV, TenNV,ViTri from DuAn inner join NVien on NVien.MaNV = DuAn.MaNV where MaDA LIKE '" + mada+"'", cn);

            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvNhanVien.Rows.Add(i, dr["MaDA"].ToString(), dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["ViTri"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public bool checkDataSave()
        {
            if (string.IsNullOrEmpty(txtMaDA.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã dự án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDA.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenDA.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên dự án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDA.Focus();
                return false;
            }
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa thêm nhân viên vào dự án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return false;
            }
            if (string.IsNullOrEmpty(txtViTri.Text))
            {
                MessageBox.Show("Bạn chưa nhập vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtViTri.Focus();
                return false;
            }

            return true;
        }
        private void dgvDSDA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i = e.RowIndex;
            if (i < dgvDSDA.RowCount && i >= 0)
            {
                txtMaDA.Text = dgvDSDA.Rows[i].Cells["Column2"].Value.ToString();
                txtTenDA.Text = dgvDSDA.Rows[i].Cells["Column3"].Value?.ToString();
                dtBegin.Value = DateTime.Parse(dgvDSDA.Rows[i].Cells["Column4"].Value.ToString());
                dtEnd.Value = DateTime.Parse(dgvDSDA.Rows[i].Cells["Column5"].Value?.ToString());
                txtGhiChu.Text = dgvDSDA.Rows[i].Cells["Column6"].Value?.ToString();
                LoadNV(txtMaDA.Text);

                
            }
            btnSave.Visible = false;
            string colName = dgvDSDA.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    
                    foreach (DataGridViewRow row in dgvNhanVien.Rows)
                    {

                        cn.Open();
                        string MaNV = row.Cells[2].Value.ToString();
                        cm = new SqlCommand("DELETE FROM DuAn WHERE MaNV LIKE '" + MaNV + "' AND MaDA LIKE '"+txtMaDA.Text+"'", cn);

                        cm.ExecuteNonQuery();

                        cn.Close();

                    }
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM CTDuAn WHERE MaDA LIKE '" + dgvDSDA[1, e.RowIndex].Value.ToString() + "'", cn);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDA();
                    Clear();
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkDataSave())
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn lưu dự án này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("INSERT INTO CTDuAn(MaDA,TenDA,NgBatDau,NgKetThuc, GhiChu)VALUES(@mada,@tenda, @ngbd, @ngkt, @ghichu)", cn);
                        cm.Parameters.AddWithValue("@mada", txtMaDA.Text);
                        cm.Parameters.AddWithValue("@tenda", txtTenDA.Text);
                        cm.Parameters.AddWithValue("@ngbd", dtBegin.Value);
                        cm.Parameters.AddWithValue("@ngkt", dtEnd.Value);
                        cm.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                        
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();

                        foreach (DataGridViewRow row in dgvNhanVien.Rows)
                        {
                            string MaNV = row.Cells[2].Value.ToString();
                            string Vitri = row.Cells[4].Value.ToString();
                            

                            cm = new SqlCommand("INSERT INTO DuAn(MaDA,MaNV,ViTri) VALUES(@mada,@manv,@vitri)", cn);
                            
                            cm.Parameters.AddWithValue("@mada", txtMaDA.Text);
                            cm.Parameters.AddWithValue("@manv", MaNV);
                            cm.Parameters.AddWithValue("@vitri", Vitri);
                            cm.ExecuteNonQuery();


                        }

                        cn.Close();





                        MessageBox.Show("Lưu thành công", "Co-op Bank");



                        Clear();
                        LoadDA();
                        LoadNV(txtMaDA.Text);
                    }
                    LoadDA();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddDA_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Visible = true;
        }

        private void Clear()
        {
            txtMaDA.Clear();
            txtTenDA.Clear();
            dtBegin.Value = DateTime.Today;
            dtEnd.Value = DateTime.Today;
            dgvNhanVien.Rows.Clear();
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            if(txtViTri.Text != "" && cboNV.Text != "")
            {
                dgvNhanVien.Rows.Add(dgvNhanVien.Rows.Count + 1, txtMaDA.Text, cboNV.SelectedValue, cboNV.Text, txtViTri.Text);

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin nhân sự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                cn.Open();
                cm = new SqlCommand("UPDATE CTDuAn SET TenDA=@ten, NgBatDau = @ngbd, NgKetThuc = @ngkt, GhiChu = @gc WHERE MaDA LIKE '" + txtMaDA.Text + "'", cn);
                cm.Parameters.AddWithValue("@ten", txtTenDA.Text);
                cm.Parameters.AddWithValue("@ngbd", dtBegin.Value);
                cm.Parameters.AddWithValue("@ngkt", dtEnd.Value);
                cm.Parameters.AddWithValue("@gc", txtGhiChu.Text);
                cm.ExecuteNonQuery();
                cn.Close();

                int i = 0;

                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {
                    cn.Open();
                    
                    

                    string MaNV = row.Cells[2].Value.ToString();
                    string Vitri = row.Cells[4].Value.ToString();
                    cm = new SqlCommand("SELECT * FROM DuAn WHERE MaDA = '" + txtMaDA.Text + "' AND MaNV = '" + MaNV + "'", cn);
                    dr = cm.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        cn.Close();
                        cn.Open();
                        cm = new SqlCommand("INSERT INTO DuAn(MaDA,MaNV,ViTri)VALUES(@mada,@manv,@vitri)", cn);
                        cm.Parameters.AddWithValue("@mada", txtMaDA.Text);
                        cm.Parameters.AddWithValue("@manv", MaNV);
                        cm.Parameters.AddWithValue("@vitri", Vitri);
                        cm.ExecuteNonQuery();
                        
                    }

                    //MessageBox.Show(MaNV + " " + Vitri);
                    cn.Close();

                }

                



                MessageBox.Show("Cập nhật thành công", "Co-op Bank");
                Clear();
               
            }
        }

        private bool checkData()
        {
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvNhanVien.Columns[e.ColumnIndex].Name;
            if (colName == "DeleteNV")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân sự này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    dgvNhanVien.Rows.Remove(dgvNhanVien.Rows[e.RowIndex]);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDA();
        }
    }
}
