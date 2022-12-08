using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CoopBankHRMS
{
    public partial class frmBaoCaoDSNS : Form
    {
        private SqlCommand cm = new SqlCommand();
        private SqlConnection cn = new SqlConnection();
        private readonly DBConnect dbcon = new DBConnect();
        public frmBaoCaoDSNS()
        {
            InitializeComponent();
            LoadPB();
        }
        public void LoadPB()
        {
            DataTable dataTable = dbcon.getTable("SELECT * FROM PBan ");
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
                rptDSNSAll rpt = new rptDSNSAll();
                DataTable dt = dbcon.getTable("select TenNV,ChucVu,TenPB,SDT, HKTT from NVien AS n inner join HoSoNV as h on n.MaNV=h.MaNV inner join PBan as p on n.MaPB=p.MaPB inner join ChucVu as c on c.MaCV=n.MaCV ");
                rpt.SetDataSource(dt);
                frmShowBaoCao f = new frmShowBaoCao(rpt);
                f.ShowDialog();
            }
            else
            {
                rptDSNSAll rpt = new rptDSNSAll();
                DataTable dt = dbcon.getTable("select TenNV,ChucVu,TenPB,SDT, HKTT from NVien AS n inner join HoSoNV as h on n.MaNV=h.MaNV inner join PBan as p on n.MaPB=p.MaPB inner join ChucVu as c on c.MaCV=n.MaCV where  n.MaPB = '" + cboPB.SelectedValue + "'");
                rpt.SetDataSource(dt);
                frmShowBaoCao f = new frmShowBaoCao(rpt);
                f.ShowDialog();
            }
        }
    }
}
