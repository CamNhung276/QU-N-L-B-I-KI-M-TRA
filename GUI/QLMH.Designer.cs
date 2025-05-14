namespace GUI
{
    partial class QLMH
    {
        private System.ComponentModel.IContainer components = null;

        // Declare controls
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.Panel panelCategoryInfo;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLMH));
            this.panelCategoryInfo = new System.Windows.Forms.Panel();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.panelCategoryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCategoryInfo
            // 
            this.panelCategoryInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelCategoryInfo.Controls.Add(this.btSave);
            this.panelCategoryInfo.Controls.Add(this.btnReset);
            this.panelCategoryInfo.Controls.Add(this.lblTitle);
            this.panelCategoryInfo.Controls.Add(this.lblCategoryName);
            this.panelCategoryInfo.Controls.Add(this.txtMonHoc);
            this.panelCategoryInfo.Location = new System.Drawing.Point(99, 255);
            this.panelCategoryInfo.Name = "panelCategoryInfo";
            this.panelCategoryInfo.Size = new System.Drawing.Size(465, 163);
            this.panelCategoryInfo.TabIndex = 1;
            // 
            // btSave
            // 
            this.btSave.BorderColor = System.Drawing.Color.SteelBlue;
            this.btSave.BorderRadius = 19;
            this.btSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSave.FillColor = System.Drawing.Color.MidnightBlue;
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.White;
            this.btSave.Location = new System.Drawing.Point(167, 122);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(69, 36);
            this.btSave.TabIndex = 15;
            this.btSave.Text = "Lưu";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnReset.BorderRadius = 19;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(292, 120);
            this.btnReset.Name = "btnReset";
            this.btnReset.PressedColor = System.Drawing.Color.DimGray;
            this.btnReset.Size = new System.Drawing.Size(69, 38);
            this.btnReset.TabIndex = 14;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(87, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(322, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin môn học";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.Location = new System.Drawing.Point(21, 64);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(69, 39);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Tên Môn học";
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtMonHoc.Location = new System.Drawing.Point(106, 64);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.Size = new System.Drawing.Size(303, 39);
            this.txtMonHoc.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(178, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(369, 51);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Quản lý môn học";
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHoc.Location = new System.Drawing.Point(49, 99);
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.Size = new System.Drawing.Size(570, 120);
            this.dgvMonHoc.TabIndex = 0;
            this.dgvMonHoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonHoc_CellContentClick);
            // 
            // QLMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.panelCategoryInfo);
            this.Name = "QLMH";
            this.Size = new System.Drawing.Size(903, 665);
            this.panelCategoryInfo.ResumeLayout(false);
            this.panelCategoryInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btSave;
    }
}
