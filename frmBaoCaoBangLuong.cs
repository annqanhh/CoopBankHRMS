using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CoopBankHRMS
{
    public partial class frmBaoCaoBangLuong : Form
    {
        private SqlCommand cm = new SqlCommand();
        private SqlConnection cn = new SqlConnection();
        private readonly DBConnect dbcon = new DBConnect();
        public frmBaoCaoBangLuong()
        {
            InitializeComponent();
            dtTime.Format = DateTimePickerFormat.Custom;
            dtTime.CustomFormat = "MM/yyyy";
            LoadPB();
            
        }
        public void LoadPB()
        {
            DataTable dataTable = dbcon.getTable("SELECT * FROM PBan " );
            dataTable.Rows.Add(0, "Tất cả phòng ban");

            cboPB.Items.Clear();
            cboPB.DataSource = dataTable;
            cboPB.DisplayMember = "TenPB";
            cboPB.ValueMember = "MaPB";
            cboPB.SelectedIndex = cboPB.Items.Count - 1;
            
        }
        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (cboPB.Text == "Tất cả phòng ban")
            {
                rptBLNS rpt = new rptBLNS();
                DataTable dt = dbcon.getTable("select n.TenNV,b.HSLCB,b.HSLPC, (1920000*(b.HSLCB+b.HSLPC)) as TienLCB, ((b.HSLCB+b.HSLPC)*3100000) as LuongBHXH, ((b.HSLCB+b.HSLPC)*3100000 * 0.08) as TruBHXH, ((b.HSLCB+b.HSLPC)*3100000 * 0.08*0.015) as TruBHYT, Round(((1920000*(b.HSLCB+b.HSLPC)) - ((b.HSLCB+b.HSLPC)*3100000 * 0.08) - ((b.HSLCB+b.HSLPC)*3100000 * 0.08*0.015)),-2) as TienLinh, TenPB, Thang,Nam from BangLuong as b inner join NVien as n on n.MaNV = b.MaNV inner join PBan as p on p.MaPB = n.MaPB where Thang = '" + dtTime.Value.Month+"' and Nam = '"+dtTime.Value.Year+"'");
                rpt.SetDataSource(dt);
                rpt.DataDefinition.FormulaFields["ThangLoc"].Text = "'" + dtTime.Value.Month + "'";
                rpt.DataDefinition.FormulaFields["NamLoc"].Text = "'" + dtTime.Value.Year + "'";
                frmShowBaoCao f = new frmShowBaoCao(rpt);
                f.ShowDialog();
            }
            else
            {
                rptBLNS rpt = new rptBLNS();
                DataTable dt = dbcon.getTable("select n.TenNV,b.HSLCB,b.HSLPC, (1920000*(b.HSLCB+b.HSLPC)) as TienLCB, ((b.HSLCB+b.HSLPC)*3100000) as LuongBHXH, ((b.HSLCB+b.HSLPC)*3100000 * 0.08) as TruBHXH, ((b.HSLCB+b.HSLPC)*3100000 * 0.08*0.015) as TruBHYT, Round(((1920000*(b.HSLCB+b.HSLPC)) - ((b.HSLCB+b.HSLPC)*3100000 * 0.08) - ((b.HSLCB+b.HSLPC)*3100000 * 0.08*0.015)),-2) as TienLinh, TenPB, Thang,Nam from BangLuong as b inner join NVien as n on n.MaNV = b.MaNV inner join PBan as p on p.MaPB = n.MaPB where Thang = '" + dtTime.Value.Month + "' and Nam = '" + dtTime.Value.Year + "' and n.MaPB = '" + cboPB.SelectedValue + "'");
                rpt.SetDataSource(dt);
                rpt.DataDefinition.FormulaFields["ThangLoc"].Text = "'" + dtTime.Value.Month + "'";
                rpt.DataDefinition.FormulaFields["NamLoc"].Text = "'" + dtTime.Value.Year + "'";
                frmShowBaoCao f = new frmShowBaoCao(rpt);
                f.ShowDialog();
            }
        }
    }
}
