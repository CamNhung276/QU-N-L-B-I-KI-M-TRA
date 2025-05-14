
namespace GUI
{
    partial class ThongBao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTaoThongBao = new System.Windows.Forms.Panel();
            this.btnTaoThongBao = new System.Windows.Forms.Button();
            this.chkKhongHetHan = new System.Windows.Forms.CheckBox();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTaoThongBao = new System.Windows.Forms.Label();
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.lblDanhSachThongBao = new System.Windows.Forms.Label();
            this.pnlTaoThongBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTaoThongBao
            // 
            this.pnlTaoThongBao.BackColor = System.Drawing.Color.White;
            this.pnlTaoThongBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTaoThongBao.Controls.Add(this.btnTaoThongBao);
            this.pnlTaoThongBao.Controls.Add(this.chkKhongHetHan);
            this.pnlTaoThongBao.Controls.Add(this.dtpNgayHetHan);
            this.pnlTaoThongBao.Controls.Add(this.lblNgayHetHan);
            this.pnlTaoThongBao.Controls.Add(this.txtNoiDung);
            this.pnlTaoThongBao.Controls.Add(this.lblNoiDung);
            this.pnlTaoThongBao.Controls.Add(this.txtTieuDe);
            this.pnlTaoThongBao.Controls.Add(this.lblTieuDe);
            this.pnlTaoThongBao.Controls.Add(this.lblTaoThongBao);
            this.pnlTaoThongBao.Location = new System.Drawing.Point(67, 287);
            this.pnlTaoThongBao.Name = "pnlTaoThongBao";
            this.pnlTaoThongBao.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTaoThongBao.Size = new System.Drawing.Size(541, 259);
            this.pnlTaoThongBao.TabIndex = 0;
            // 
            // btnTaoThongBao
            // 
            this.btnTaoThongBao.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTaoThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoThongBao.ForeColor = System.Drawing.Color.White;
            this.btnTaoThongBao.Location = new System.Drawing.Point(158, 198);
            this.btnTaoThongBao.Name = "btnTaoThongBao";
            this.btnTaoThongBao.Size = new System.Drawing.Size(128, 44);
            this.btnTaoThongBao.TabIndex = 8;
            this.btnTaoThongBao.Text = "Tạo thông báo";
            this.btnTaoThongBao.UseVisualStyleBackColor = false;
            this.btnTaoThongBao.Click += new System.EventHandler(this.btnTaoThongBao_Click);
            // 
            // chkKhongHetHan
            // 
            this.chkKhongHetHan.AutoSize = true;
            this.chkKhongHetHan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKhongHetHan.Location = new System.Drawing.Point(313, 173);
            this.chkKhongHetHan.Name = "chkKhongHetHan";
            this.chkKhongHetHan.Size = new System.Drawing.Size(178, 24);
            this.chkKhongHetHan.TabIndex = 7;
            this.chkKhongHetHan.Text = "Không có ngày hết hạn";
            this.chkKhongHetHan.UseVisualStyleBackColor = true;
            this.chkKhongHetHan.CheckedChanged += new System.EventHandler(this.chkKhongHetHan_CheckedChanged);
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(163, 142);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayHetHan.TabIndex = 6;
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHetHan.Location = new System.Drawing.Point(13, 140);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(147, 25);
            this.lblNgayHetHan.TabIndex = 5;
            this.lblNgayHetHan.Text = "Ngày hết hạn:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(149, 97);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(281, 27);
            this.txtNoiDung.TabIndex = 4;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDung.Location = new System.Drawing.Point(15, 97);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(105, 25);
            this.lblNoiDung.TabIndex = 3;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDe.Location = new System.Drawing.Point(149, 51);
            this.txtTieuDe.Multiline = true;
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(281, 27);
            this.txtTieuDe.TabIndex = 2;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(15, 51);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(92, 25);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Tiêu đề:";
            // 
            // lblTaoThongBao
            // 
            this.lblTaoThongBao.AutoSize = true;
            this.lblTaoThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTaoThongBao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaoThongBao.ForeColor = System.Drawing.Color.Navy;
            this.lblTaoThongBao.Location = new System.Drawing.Point(10, 10);
            this.lblTaoThongBao.Name = "lblTaoThongBao";
            this.lblTaoThongBao.Size = new System.Drawing.Size(226, 28);
            this.lblTaoThongBao.TabIndex = 0;
            this.lblTaoThongBao.Text = "TẠO THÔNG BÁO MỚI";
            // 
            // dgvThongBao
            // 
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.dgvThongBao.ColumnHeadersHeight = 29;
            this.dgvThongBao.Location = new System.Drawing.Point(67, 78);
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.RowHeadersWidth = 51;
            this.dgvThongBao.RowTemplate.Height = 24;
            this.dgvThongBao.Size = new System.Drawing.Size(541, 190);
            this.dgvThongBao.TabIndex = 1;
            // 
            // lblDanhSachThongBao
            // 
            this.lblDanhSachThongBao.AutoSize = true;
            this.lblDanhSachThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachThongBao.ForeColor = System.Drawing.Color.Navy;
            this.lblDanhSachThongBao.Location = new System.Drawing.Point(149, 19);
            this.lblDanhSachThongBao.Name = "lblDanhSachThongBao";
            this.lblDanhSachThongBao.Size = new System.Drawing.Size(373, 32);
            this.lblDanhSachThongBao.TabIndex = 7;
            this.lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDanhSachThongBao);
            this.Controls.Add(this.dgvThongBao);
            this.Controls.Add(this.pnlTaoThongBao);
            this.Name = "ThongBao";
            this.Size = new System.Drawing.Size(1058, 715);
            this.pnlTaoThongBao.ResumeLayout(false);
            this.pnlTaoThongBao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTaoThongBao;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTaoThongBao;
        private System.Windows.Forms.Button btnTaoThongBao;
        private System.Windows.Forms.CheckBox chkKhongHetHan;
        private System.Windows.Forms.DataGridView dgvThongBao;
        private System.Windows.Forms.Label lblDanhSachThongBao;
    }
}
