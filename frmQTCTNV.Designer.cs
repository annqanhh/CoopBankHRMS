
namespace CoopBankHRMS
{
    partial class frmQTCTNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQTCTNV));
            this.dgvQTCT = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtfinish = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtbegin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbCV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbPB = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbTenNV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtLSCT = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaNV = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboTenNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCV = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboPB = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQTCT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQTCT
            // 
            this.dgvQTCT.AllowUserToAddRows = false;
            this.dgvQTCT.AllowUserToDeleteRows = false;
            this.dgvQTCT.AllowUserToResizeColumns = false;
            this.dgvQTCT.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvQTCT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(95)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQTCT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQTCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.MaNV,
            this.TenNV,
            this.TGBD,
            this.TGKT,
            this.TenPB,
            this.ChucVu,
            this.LSCT,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQTCT.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQTCT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvQTCT.Location = new System.Drawing.Point(12, 464);
            this.dgvQTCT.Name = "dgvQTCT";
            this.dgvQTCT.RowHeadersVisible = false;
            this.dgvQTCT.Size = new System.Drawing.Size(229, 153);
            this.dgvQTCT.TabIndex = 8;
            this.dgvQTCT.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.dgvQTCT.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvQTCT.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvQTCT.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvQTCT.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvQTCT.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvQTCT.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvQTCT.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvQTCT.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(95)))), ((int)(((byte)(131)))));
            this.dgvQTCT.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQTCT.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQTCT.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvQTCT.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvQTCT.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvQTCT.ThemeStyle.ReadOnly = false;
            this.dgvQTCT.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.dgvQTCT.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQTCT.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvQTCT.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvQTCT.ThemeStyle.RowsStyle.Height = 22;
            this.dgvQTCT.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.dgvQTCT.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvQTCT.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 46;
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 64;
            // 
            // TenNV
            // 
            this.TenNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenNV.HeaderText = "Tên NV";
            this.TenNV.Name = "TenNV";
            // 
            // TGBD
            // 
            this.TGBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.TGBD.DefaultCellStyle = dataGridViewCellStyle3;
            this.TGBD.HeaderText = "Bắt đầu";
            this.TGBD.Name = "TGBD";
            this.TGBD.Width = 70;
            // 
            // TGKT
            // 
            this.TGKT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.TGKT.DefaultCellStyle = dataGridViewCellStyle4;
            this.TGKT.HeaderText = "Kết thúc";
            this.TGKT.Name = "TGKT";
            this.TGKT.Width = 72;
            // 
            // TenPB
            // 
            this.TenPB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenPB.HeaderText = "Phòng ban";
            this.TenPB.Name = "TenPB";
            this.TenPB.Width = 87;
            // 
            // ChucVu
            // 
            this.ChucVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.Width = 71;
            // 
            // LSCT
            // 
            this.LSCT.HeaderText = "Lịch sử công tác";
            this.LSCT.Name = "LSCT";
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(378, 39);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(85, 15);
            this.guna2HtmlLabel3.TabIndex = 86;
            this.guna2HtmlLabel3.Text = "Lịch sử công tác";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(28, 216);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(96, 15);
            this.guna2HtmlLabel2.TabIndex = 85;
            this.guna2HtmlLabel2.Text = "Thời gian kết thúc";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(28, 174);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(94, 15);
            this.guna2HtmlLabel1.TabIndex = 84;
            this.guna2HtmlLabel1.Text = "Thời gian bắt đầu";
            // 
            // dtfinish
            // 
            this.dtfinish.Checked = true;
            this.dtfinish.FillColor = System.Drawing.SystemColors.Control;
            this.dtfinish.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtfinish.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfinish.Location = new System.Drawing.Point(135, 207);
            this.dtfinish.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtfinish.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtfinish.Name = "dtfinish";
            this.dtfinish.Size = new System.Drawing.Size(124, 24);
            this.dtfinish.TabIndex = 4;
            this.dtfinish.Value = new System.DateTime(2022, 11, 20, 16, 52, 30, 93);
            // 
            // dtbegin
            // 
            this.dtbegin.Checked = true;
            this.dtbegin.FillColor = System.Drawing.SystemColors.Control;
            this.dtbegin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtbegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtbegin.Location = new System.Drawing.Point(135, 165);
            this.dtbegin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtbegin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtbegin.Name = "dtbegin";
            this.dtbegin.Size = new System.Drawing.Size(124, 24);
            this.dtbegin.TabIndex = 3;
            this.dtbegin.Value = new System.DateTime(2022, 11, 20, 16, 52, 30, 93);
            // 
            // lbCV
            // 
            this.lbCV.BackColor = System.Drawing.Color.Transparent;
            this.lbCV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCV.Location = new System.Drawing.Point(28, 83);
            this.lbCV.Name = "lbCV";
            this.lbCV.Size = new System.Drawing.Size(63, 15);
            this.lbCV.TabIndex = 80;
            this.lbCV.Text = "Tên chức vụ ";
            // 
            // lbPB
            // 
            this.lbPB.BackColor = System.Drawing.Color.Transparent;
            this.lbPB.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPB.Location = new System.Drawing.Point(28, 126);
            this.lbPB.Name = "lbPB";
            this.lbPB.Size = new System.Drawing.Size(82, 15);
            this.lbPB.TabIndex = 79;
            this.lbPB.Text = "Tên phòng ban ";
            // 
            // lbTenNV
            // 
            this.lbTenNV.BackColor = System.Drawing.Color.Transparent;
            this.lbTenNV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNV.Location = new System.Drawing.Point(28, 39);
            this.lbTenNV.Name = "lbTenNV";
            this.lbTenNV.Size = new System.Drawing.Size(75, 15);
            this.lbTenNV.TabIndex = 78;
            this.lbTenNV.Text = "Tên nhân viên ";
            // 
            // txtLSCT
            // 
            this.txtLSCT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLSCT.DefaultText = "";
            this.txtLSCT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLSCT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLSCT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLSCT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLSCT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLSCT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLSCT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLSCT.Location = new System.Drawing.Point(469, 30);
            this.txtLSCT.Multiline = true;
            this.txtLSCT.Name = "txtLSCT";
            this.txtLSCT.PasswordChar = '\0';
            this.txtLSCT.PlaceholderText = "";
            this.txtLSCT.SelectedText = "";
            this.txtLSCT.Size = new System.Drawing.Size(253, 201);
            this.txtLSCT.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BorderRadius = 15;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.Gray;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(643, 294);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 35);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BorderRadius = 15;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(558, 294);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 35);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblMaNV
            // 
            this.lblMaNV.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(643, 165);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(19, 15);
            this.lblMaNV.TabIndex = 91;
            this.lblMaNV.Text = "qw";
            this.lblMaNV.Visible = false;
            // 
            // cboTenNV
            // 
            this.cboTenNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboTenNV.DefaultText = "";
            this.cboTenNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cboTenNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cboTenNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboTenNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboTenNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTenNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTenNV.Location = new System.Drawing.Point(135, 30);
            this.cboTenNV.Name = "cboTenNV";
            this.cboTenNV.PasswordChar = '\0';
            this.cboTenNV.PlaceholderText = "";
            this.cboTenNV.SelectedText = "";
            this.cboTenNV.Size = new System.Drawing.Size(200, 36);
            this.cboTenNV.TabIndex = 0;
            // 
            // cboCV
            // 
            this.cboCV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboCV.DefaultText = "";
            this.cboCV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cboCV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cboCV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboCV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboCV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCV.Location = new System.Drawing.Point(135, 76);
            this.cboCV.Name = "cboCV";
            this.cboCV.PasswordChar = '\0';
            this.cboCV.PlaceholderText = "";
            this.cboCV.SelectedText = "";
            this.cboCV.Size = new System.Drawing.Size(200, 36);
            this.cboCV.TabIndex = 1;
            // 
            // cboPB
            // 
            this.cboPB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboPB.DefaultText = "";
            this.cboPB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.cboPB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.cboPB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboPB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cboPB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboPB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPB.Location = new System.Drawing.Point(135, 118);
            this.cboPB.Name = "cboPB";
            this.cboPB.PasswordChar = '\0';
            this.cboPB.PlaceholderText = "";
            this.cboPB.SelectedText = "";
            this.cboPB.Size = new System.Drawing.Size(200, 36);
            this.cboPB.TabIndex = 2;
            // 
            // frmQTCTNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 629);
            this.ControlBox = false;
            this.Controls.Add(this.cboPB);
            this.Controls.Add(this.cboCV);
            this.Controls.Add(this.cboTenNV);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dtfinish);
            this.Controls.Add(this.dtbegin);
            this.Controls.Add(this.lbCV);
            this.Controls.Add(this.lbPB);
            this.Controls.Add(this.lbTenNV);
            this.Controls.Add(this.txtLSCT);
            this.Controls.Add(this.dgvQTCT);
            this.Controls.Add(this.lblMaNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQTCTNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QTCTNV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQTCT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2DataGridView dgvQTCT;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        public Guna.UI2.WinForms.Guna2DateTimePicker dtfinish;
        public Guna.UI2.WinForms.Guna2DateTimePicker dtbegin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCV;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPB;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTenNV;
        public Guna.UI2.WinForms.Guna2TextBox txtLSCT;
        public Guna.UI2.WinForms.Guna2Button btnReset;
        public Guna.UI2.WinForms.Guna2Button btnUpdate;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSCT;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private Guna.UI2.WinForms.Guna2TextBox cboTenNV;
        private Guna.UI2.WinForms.Guna2TextBox cboCV;
        private Guna.UI2.WinForms.Guna2TextBox cboPB;
    }
}