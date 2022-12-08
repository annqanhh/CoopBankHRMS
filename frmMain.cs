using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopBankHRMS
{
    public partial class frmMain : Form
    {
        public frmMain(string ten)
        {
            InitializeComponent();
            customizeDesign();
            lblChaoMung.Text = "Chào mừng "+ten;
        }
        private void customizeDesign()
        {
            panelSubMenuHT.Visible = false;
            panelSubMenuDM.Visible = false;
            panelSubMenuLuong.Visible = false;
            panelSubMenuBC.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelSubMenuHT.Visible == true)
                panelSubMenuHT.Visible = false;
            if (panelSubMenuDM.Visible == true)
                panelSubMenuDM.Visible = false;
            if (panelSubMenuLuong.Visible == true)
                panelSubMenuLuong.Visible = false;
            if (panelSubMenuBC.Visible == true)
                panelSubMenuBC.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuHT);
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuLuong);
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuBC);
        }
        private Form activeForm = null;
        private void openDetailForm(Form detailForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = detailForm;
            detailForm.TopLevel = false;
            detailForm.FormBorderStyle = FormBorderStyle.None;
            detailForm.Dock = DockStyle.Fill;
            panelDetail.Controls.Add(detailForm);
            panelDetail.Tag = detailForm;
            detailForm.BringToFront();
            detailForm.Show();
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                frmLogin f = new frmLogin();
                f.Show();
            }
            else
                return;
            //...
            hideSubMenu();
        }

        private void btnHeThong_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuHT);
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuDM);
        }

        private void btnLuong_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuLuong);
        }

        private void btnBC_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuBC);
        }

        private void PictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void ctrlbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ctrlbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ctrlbMaximize_Click(object sender, EventArgs e)
        {

        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmChucVu());
        }

        private void btnPB_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmPhongBan());
        }

        private void btnDMNS_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmHoSoNhanSu());
        }

        private void btnQltk_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmQuanLyTaiKhoan());
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmDuAn());
        }

        private void btnKTKL_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmKhenThuongKyLuat());
        }

        private void btnQTCT_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmQuaTrinhCongTac());
        }

        private void btnHDB_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmChamCong());
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmChamCong());
        }

        private void btnBLNS_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBangLuong());
        }

        private void btnBLuong_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBlank());
            frmBaoCaoBangLuong f = new frmBaoCaoBangLuong();
            f.ShowDialog();
        }

        private void btnDSKL_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBlank());
            frmBaoCaoKyLuat f = new frmBaoCaoKyLuat();
            f.ShowDialog();

        }

        private void btnDSKT_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBlank());
            frmBaoCaoKhenThuong f = new frmBaoCaoKhenThuong();
            f.ShowDialog();
        }

        private void btnDSNS_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBlank());
            frmBaoCaoDSNS f = new frmBaoCaoDSNS();
            f.ShowDialog();
        }
    }
}
