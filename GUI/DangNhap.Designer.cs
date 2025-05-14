
namespace GUI
{
    partial class DangNhap
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
            this.btDNhap = new Guna.UI2.WinForms.Guna2Button();
            this.checkMK = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btDNhap
            // 
            this.btDNhap.BorderColor = System.Drawing.Color.SteelBlue;
            this.btDNhap.BorderRadius = 19;
            this.btDNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btDNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btDNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btDNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btDNhap.FillColor = System.Drawing.Color.MidnightBlue;
            this.btDNhap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDNhap.ForeColor = System.Drawing.Color.White;
            this.btDNhap.Location = new System.Drawing.Point(155, 430);
            this.btDNhap.Name = "btDNhap";
            this.btDNhap.Size = new System.Drawing.Size(190, 53);
            this.btDNhap.TabIndex = 11;
            this.btDNhap.Text = "Đăng nhập";
            this.btDNhap.Click += new System.EventHandler(this.btDNhap_Click);
            // 
            // checkMK
            // 
            this.checkMK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkMK.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.checkMK.ForeColor = System.Drawing.Color.Black;
            this.checkMK.Location = new System.Drawing.Point(320, 380);
            this.checkMK.Name = "checkMK";
            this.checkMK.Size = new System.Drawing.Size(170, 30);
            this.checkMK.TabIndex = 6;
            this.checkMK.Text = "Hiện mật khẩu";
            this.checkMK.UseVisualStyleBackColor = true;
            this.checkMK.CheckedChanged += new System.EventHandler(this.checkMK_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTen.ForeColor = System.Drawing.Color.Black;
            this.txtTen.Location = new System.Drawing.Point(21, 129);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(140, 28);
            this.txtTen.TabIndex = 2;
            this.txtTen.Text = "Tên đăng nhập";
            // 
            // txtMK
            // 
            this.txtMK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMK.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.txtMK.Location = new System.Drawing.Point(59, 309);
            this.txtMK.Multiline = true;
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(408, 45);
            this.txtMK.TabIndex = 5;
            this.txtMK.Text = "123";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.txtName.Location = new System.Drawing.Point(59, 176);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(408, 43);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "HS1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(120, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vui lòng đăng nhập để tiếp tục.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(88, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng đã đến!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GUI.Properties.Resources.ảnh_ĐN1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(999, 522);
            this.Controls.Add(this.btDNhap);
            this.Controls.Add(this.checkMK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkMK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btDNhap;
        private System.Windows.Forms.Label label1;
    }
}