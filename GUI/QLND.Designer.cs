namespace GUI
{
    partial class QLND
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLND));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelUserInfo.Controls.Add(this.btnReset);
            this.panelUserInfo.Controls.Add(this.btSave);
            this.panelUserInfo.Controls.Add(this.txtUsername);
            this.panelUserInfo.Controls.Add(this.txtMK);
            this.panelUserInfo.Controls.Add(this.label1);
            this.panelUserInfo.Controls.Add(this.lblTitle);
            this.panelUserInfo.Controls.Add(this.lblName);
            this.panelUserInfo.Controls.Add(this.txtName);
            this.panelUserInfo.Controls.Add(this.lblPassword);
            this.panelUserInfo.Controls.Add(this.lblRole);
            this.panelUserInfo.Controls.Add(this.cboRole);
            this.panelUserInfo.Location = new System.Drawing.Point(75, 187);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(604, 310);
            this.panelUserInfo.TabIndex = 1;
            this.panelUserInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUserInfo_Paint);
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
            this.btnReset.Location = new System.Drawing.Point(408, 259);
            this.btnReset.Name = "btnReset";
            this.btnReset.PressedColor = System.Drawing.Color.DimGray;
            this.btnReset.Size = new System.Drawing.Size(69, 38);
            this.btnReset.TabIndex = 13;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btSave.Location = new System.Drawing.Point(283, 261);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(69, 36);
            this.btSave.TabIndex = 12;
            this.btSave.Text = "Lưu";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtUsername.Location = new System.Drawing.Point(186, 113);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(374, 39);
            this.txtUsername.TabIndex = 4;
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtMK.Location = new System.Drawing.Point(186, 165);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(374, 39);
            this.txtMK.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên đăng nhập";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(141, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(351, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin người dùng";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(40, 66);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(126, 33);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Họ và tên";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtName.Location = new System.Drawing.Point(188, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(372, 39);
            this.txtName.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(33, 167);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(133, 39);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(49, 217);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(131, 39);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Quyền";
            // 
            // cboRole
            // 
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cboRole.Items.AddRange(new object[] {
            "Admin",
            "Teacher",
            "Student"});
            this.cboRole.Location = new System.Drawing.Point(186, 214);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(374, 39);
            this.cboRole.TabIndex = 7;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.Columns});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.Location = new System.Drawing.Point(75, 63);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 60;
            this.dgvUsers.Size = new System.Drawing.Size(600, 107);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick_1);
            // 
            // Column
            // 
            this.Column.DataPropertyName = "Username";
            this.Column.HeaderText = "Tên đăng nhập";
            this.Column.MinimumWidth = 6;
            this.Column.Name = "Column";
            // 
            // Columns
            // 
            this.Columns.DataPropertyName = "Role";
            this.Columns.HeaderText = "Quyền";
            this.Columns.MinimumWidth = 6;
            this.Columns.Name = "Columns";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(202, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(433, 51);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Quản lý người dùng";
            // 
            // QLND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panelUserInfo);
            this.Name = "QLND";
            this.Size = new System.Drawing.Size(1105, 844);
            this.Load += new System.EventHandler(this.QLND_Load);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columns;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2Button btSave;
        private Guna.UI2.WinForms.Guna2Button btnReset;
    }
}