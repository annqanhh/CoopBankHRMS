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
    public partial class frmLogin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string _pass = "";
        int dem=0;
        public frmLogin()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            txtTenDN.Focus();
            logo.Parent = picBackground;
            logo.BackColor = Color.Transparent;
            btnLogin.Parent = picBackground;
            btnLogin.BackColor = Color.Transparent;
            btnClose.Parent = picBackground;
            btnClose.BackColor = Color.Transparent;
            btnMin.Parent = picBackground;
            btnMin.BackColor = Color.Transparent;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dem <3)
            {
                LoginAct();
            }
            else
            {
                Application.Exit();
                
            }
            
        }

        private void LoginAct()
        {
            string _username = "", _name = "", _role = "", _manv = "";
            try
            {
                bool found;
                cn.Open();
                //string tk = txtTenDN.Text;
                //string mk = txtMK.Text;
                cm = new SqlCommand("select n.MaNV, n.TenNV, m.TenDangNhap, m.MatKhau  from NVien as n inner join TaiKhoan as m on n.MaNV=m.MaNV where n.MaNV Like 'NV%' and TenDangNhap = @tendn and MatKhau = @matkhau", cn);
                cm.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                cm.Parameters.AddWithValue("@matkhau", txtMK.Text);
                dr = cm.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    found = true;
                    _manv = dr["MaNV"].ToString();
                    _username = dr["TenDangNhap"].ToString();
                    _name = dr["TenNV"].ToString();
                    _role = "Nhân viên";
                    _pass = dr["MatKhau"].ToString();
                    dr.Close();
                    cn.Close();
                }
                else
                {
                    dr.Close();
                    cm = new SqlCommand("select n.MaNV, n.TenNV, m.TenDangNhap, m.MatKhau  from NVien as n inner join TaiKhoan as m on n.MaNV=m.MaNV where n.MaNV Like 'QL%' and TenDangNhap = @tendn and MatKhau = @matkhau", cn);
                    cm.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                    cm.Parameters.AddWithValue("@matkhau", txtMK.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        found = true;
                        _manv = dr["MaNV"].ToString();
                        _username = dr["TenDangNhap"].ToString();
                        _name = dr["TenNV"].ToString();
                        _role = "Quản lý";
                        _pass = dr["MatKhau"].ToString();

                    }
                    else
                    {
                        found = false;
                    }
                    dr.Close();
                    cn.Close();
                }

               /* if (dr.Read() == true)
                {
                    //frmMain f = new frmMain();
                    this.Hide();
                    txtTenDN.Clear();
                    txtMK.Clear();
                    //f.ShowDialog();
                }
                else
                {
                    dem++;
                    if (dem < 3)
                    {
                        lblThongbao.Visible = true;
                        lblThongbao.Text = "Tài khoản hoặc mật khẩu không chính xác! Bạn còn " + (4 - dem).ToString() + " lần đăng nhập.";
                        txtTenDN.Clear();
                        txtMK.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Bạn đã nhập sai quá 3 lần! Chương trình sẽ thoát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }*/

                if (found)
                {

                    if (_role == "Nhân viên")
                    {
                        //MessageBox.Show("Chào mừng " + _name + " ", "ĐĂNG NHẬP THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenDN.Clear();
                        txtMK.Clear();
                        this.Hide();
                        frmMainNV main = new frmMainNV(_manv);
                        main.ShowDialog();
                    }
                    else
                    {
                        //MessageBox.Show("Chào mừng quản lý " + _name + " ", "ĐĂNG NHẬP THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTenDN.Clear();
                        txtMK.Clear();
                        this.Hide();
                        frmMain main = new frmMain(_manv);
                       
                        main.ShowDialog();
                    }
                }
                else
                {
                    lblThongbao.Visible = true;
                    lblThongbao.Text = "Tài khoản hoặc mật khẩu không chính xác!\nBạn còn " + (3 - dem).ToString() + " lần đăng nhập.";
                    //MessageBox.Show("Tên người dùng và mật khẩu không hợp lệ!", "ĐĂNG NHẬP THẤT BẠI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dem++;
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginAct();
            }
        }

        private void ctrlbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
