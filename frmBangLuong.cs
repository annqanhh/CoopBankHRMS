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
    public partial class frmBangLuong : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public frmBangLuong()
        {
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadBL();
            LoadThang();
            LoadNam();
            //cboThang.Text = DateTime.Now.ToString("M");
            //cboNam.Text = DateTime.Now.ToString("yyyy");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            cn.Open();

            cm = new SqlCommand("SELECT * FROM ChamCong WHERE Nam LIKE '"+txtNam.Text+"' AND Thang LIKE '"+txtThang.Text+"'", cn);
            dr = cm.ExecuteReader();
            if (!dr.HasRows)
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu chấm công");
                cn.Close();
                dr.Close();
                LoadBL();
                LoadThang();
                LoadNam();
            }
            else if(dr.HasRows)
            {
                cn.Close();
                dr.Close();
                cn.Open();
                cm = new SqlCommand("SELECT * FROM BangLuong WHERE Nam LIKE '" + txtNam.Text + "' AND Thang LIKE '" + txtThang.Text + "'", cn);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Đã tồn tài dữ liệu bảng lương tháng này!");
                    cn.Close();
                    dr.Close();
                    LoadBL();
                    LoadThang();
                    LoadNam();
                }
                else if (!dr.HasRows)
                {
                    MessageBox.Show("Bạn chắc chắn muốn tạo bảng lương?", "Tạo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    cn.Close();
                    dr.Close();
                    int i = 0;
                    dgvChamCong.Rows.Clear();
                    cn.Open();

                    cm = new SqlCommand("SELECT ChamCong.MaNV, TenNV,NgHC,NgLe,NghiPhep,OT,Thang,Nam,id,HSLCB,HSLPC, TUng from ChamCong inner join NVien as n on n.MaNV = ChamCong.MaNV WHERE Nam LIKE '" + txtNam.Text + "' AND Thang LIKE '" + txtThang.Text + "' ", cn);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        dgvChamCong.Rows.Add(i, dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["NgHC"].ToString(), dr["NgLe"].ToString(), dr["NghiPhep"].ToString(), dr["OT"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["id"].ToString(), dr["HSLCB"].ToString(), dr["HSLPC"].ToString(),dr["TUng"].ToString());
                    }
                    dr.Close();
                    cn.Close();

                    string mabl = TaoMaBangLuong(txtThang.Text, txtNam.Text);
                    string SQL = "", tableName = "BangLuong";
                    for (int j = 0; j < dgvChamCong.Rows.Count; j++)
                    {
                        SQL = @"INSERT INTO " + tableName + "(MaBangLuong,MaNV,Thang,Nam,HSLCB,HSLPC,TUng) VALUES ('"+mabl+"','"+dgvChamCong.Rows[j].Cells["cMaNV"].Value.ToString()+"','"+txtThang.Text+"','"+txtNam.Text+"','"+ dgvChamCong.Rows[j].Cells["HSLCB"].Value.ToString() +"','"+ dgvChamCong.Rows[j].Cells["HSLPC"].Value.ToString()+"','"+dgvChamCong.Rows[j].Cells["TUng"].Value?.ToString()+"')";
                        string finalSQL = SQL;
                        
                        
                        cn.Open();
                        cm = new SqlCommand(finalSQL, cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                    }
                    
                    //cboNam.Text = txtNam.Text;
                    //cboThang.Text = txtThang.Text;
                    LoadBL();
                    //LoadThang();
                    //LoadNam();
                }
            }
        }

        string TaoMaBangLuong(string thang, string nam)
        {
            if(thang.Length < 2)
            {
                thang = "0" + thang;
            }
            string mabl;
            mabl = "B" + thang + nam;
            return mabl;
        }
        
        public void LoadThang()
        {
            cboThang.Items.Clear();
            cboThang.DataSource = dbcon.getTable("SELECT DISTINCT Thang FROM BangLuong");
            cboThang.DisplayMember = "Thang";
            cboThang.ValueMember = "Thang";
            //cboThang.Text = DateTime.Now.ToString("MM");
        }
        public void LoadNam()
        {
            cboNam.Items.Clear();
            cboNam.DataSource = dbcon.getTable("SELECT DISTINCT Nam FROM BangLuong");
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
            //cboNam.Text = DateTime.Now.ToString("yyyy");
        }
        public void LoadBL()
        {
            int i = 0;
            
            dgvBangLuong.Rows.Clear();
            cn.Open();
            if (cbLoc.Checked)
            {
                cm = new SqlCommand("SELECT b.id,b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu FROM BangLuong as b inner join NVien as n on n.MaNv = b.MaNV WHERE CONCAT( b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu) LIKE '%" + txtSearch.Text + "%' AND b.Thang = '" + cboThang.Text + "' AND b.Nam = '" + cboNam.Text + "'", cn);
            }
            else
            {
                cm = new SqlCommand("SELECT b.id,b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu FROM BangLuong as b inner join NVien as n on n.MaNv = b.MaNV WHERE CONCAT( b.MaBangLuong, b.MaNV, n.TenNV, b.Thang, b.Nam, n.HSLCB, n.HSLPC, b.TUng, b.NopBHXH, b.NopBHYT, b.Tong, b.GhiChu) LIKE '%" + txtSearch.Text + "%' ", cn);
            }
            
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                double tung = Int32.Parse(dr["TUng"].ToString());                
                string tung1 = tung.ToString("N0");

                double bhxh = Int32.Parse(dr["NopBHXH"].ToString());                
                string bhxh1 = bhxh.ToString("N0");

                double tong = Int32.Parse(dr["Tong"].ToString());                
                string tong1 = tong.ToString("N0");

                double bhyt = Int32.Parse(dr["NopBHYT"].ToString());                
                string bhyt1 = bhyt.ToString("N0");
                dgvBangLuong.Rows.Add(i, dr["id"].ToString(), dr["MaBangLuong"].ToString(), dr["MaNV"].ToString(), dr["TenNV"].ToString(), dr["Thang"].ToString(), dr["Nam"].ToString(), dr["HSLCB"].ToString(), dr["HSLPC"].ToString(), tung1, bhxh1, bhyt1, tong1, dr["GhiChu"].ToString());

            }
            dr.Close();
            cn.Close();
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBL();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBL();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBL();
        }

        private void dgvBangLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBangLuong.Columns[e.ColumnIndex].Name;
            if (colName == "DeleteBL")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá danh mục này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM BangLuong WHERE id LIKE '" + dgvBangLuong[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();


                    MessageBox.Show("Đã xoá thành công", "Co-op Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadBL();
            }
        }

        private void cbLoc_CheckedChanged(object sender, EventArgs e)
        {
            LoadBL();
            if (cboThang.Visible == true)
            {
                cboThang.Visible = false;
                cboNam.Visible = false;
                guna2HtmlLabel1.Visible = false;
                guna2HtmlLabel2.Visible = false;
            }
            else
            {
                cboThang.Visible = true;
                cboNam.Visible = true;
                guna2HtmlLabel1.Visible = true;
                guna2HtmlLabel2.Visible = true;
            }
        }
    }
}
