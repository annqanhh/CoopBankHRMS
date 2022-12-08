
namespace CoopBankHRMS
{
    partial class frmBaoCaoKhenThuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoKhenThuong));
            this.dtTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboPB = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXuatBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtTime
            // 
            this.dtTime.Checked = true;
            this.dtTime.FillColor = System.Drawing.Color.White;
            this.dtTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtTime.Location = new System.Drawing.Point(149, 18);
            this.dtTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(149, 36);
            this.dtTime.TabIndex = 0;
            this.dtTime.Value = new System.DateTime(2022, 11, 30, 19, 56, 10, 127);
            // 
            // cboPB
            // 
            this.cboPB.BackColor = System.Drawing.Color.Transparent;
            this.cboPB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPB.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPB.ItemHeight = 30;
            this.cboPB.Items.AddRange(new object[] {
            "Tất cả phòng ban"});
            this.cboPB.Location = new System.Drawing.Point(149, 60);
            this.cboPB.Name = "cboPB";
            this.cboPB.Size = new System.Drawing.Size(303, 36);
            this.cboPB.TabIndex = 1;
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.BorderColor = System.Drawing.Color.Empty;
            this.btnXuatBaoCao.BorderRadius = 15;
            this.btnXuatBaoCao.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatBaoCao.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(95)))), ((int)(((byte)(131)))));
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuatBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCao.Location = new System.Drawing.Point(351, 115);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(92)))));
            this.btnXuatBaoCao.Size = new System.Drawing.Size(101, 45);
            this.btnXuatBaoCao.TabIndex = 2;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Lọc theo Phòng ban :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Lọc theo Tháng : ";
            // 
            // frmBaoCaoKhenThuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 178);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.cboPB);
            this.Controls.Add(this.btnXuatBaoCao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoCaoKhenThuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo khen thưởng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtTime;
        private Guna.UI2.WinForms.Guna2ComboBox cboPB;
        private Guna.UI2.WinForms.Guna2Button btnXuatBaoCao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}