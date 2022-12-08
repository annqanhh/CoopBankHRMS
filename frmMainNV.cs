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
    public partial class frmMainNV : Form
    {
        public string manv;
        public frmMainNV(string nv)
        {
            InitializeComponent();
            customizeDesign();
            manv = nv;
        }
        private void customizeDesign()
        {
            panelSubMenuQLTK.Visible = false;
            panelSubMenuDM.Visible = false;
            panelSubMenuLuong.Visible = false;
            panelSubMenuBC.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelSubMenuQLTK.Visible == true)
                panelSubMenuQLTK.Visible = false;
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

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuQLTK);
        }
        private void btnDM_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuDM);
        }
        private void btnLuong_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuLuong);
        }

        private void btnBC_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuBC);
        }

        private void ctrlbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ctrlbMaximize_Click(object sender, EventArgs e)
        {

        }
        private void ctrlbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuLuong);
        }

        private void btnDM_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuDM);
        }

        private void btnHSNS_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmHSNSNV(manv));
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

        private void btnQTCT_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmQTCTNV(manv));
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmDuAnNV(manv));
        }

        private void btnKTKL_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmThuongPhatNV(manv));
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmChamCongNV(manv));
        }

        private void btnBLNS_Click(object sender, EventArgs e)
        {
            openDetailForm(new frmBangLuongNV(manv));
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau ql = new frmDoiMatKhau(this);
            ql.ShowDialog();

        }
    }
}
