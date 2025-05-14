using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class QLBKT : UserControl
    {
        private DataGridView dgvBaiKiemTra;
        private TextBox txtBKT;
        private ComboBox CbbMon;



        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLBKT));
            this.titleLabel = new System.Windows.Forms.Label();
            this.dgvBaiKiemTra = new System.Windows.Forms.DataGridView();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.quizInfoLabel = new System.Windows.Forms.Label();
            this.quizTitleLabel = new System.Windows.Forms.Label();
            this.txtBKT = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.CbbMon = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiKiemTra)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(232, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(430, 51);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Quản lý bài kiểm tra";
            // 
            // dgvBaiKiemTra
            // 
            this.dgvBaiKiemTra.AllowUserToAddRows = false;
            this.dgvBaiKiemTra.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.dgvBaiKiemTra.ColumnHeadersHeight = 29;
            this.dgvBaiKiemTra.Font = new System.Drawing.Font("Arial", 14F);
            this.dgvBaiKiemTra.Location = new System.Drawing.Point(80, 88);
            this.dgvBaiKiemTra.Name = "dgvBaiKiemTra";
            this.dgvBaiKiemTra.RowHeadersVisible = false;
            this.dgvBaiKiemTra.RowHeadersWidth = 51;
            this.dgvBaiKiemTra.Size = new System.Drawing.Size(793, 211);
            this.dgvBaiKiemTra.TabIndex = 1;
            this.dgvBaiKiemTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaiKiemTra_CellContentClick_1);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.infoPanel.Controls.Add(this.btnReset);
            this.infoPanel.Controls.Add(this.btSave);
            this.infoPanel.Controls.Add(this.quizInfoLabel);
            this.infoPanel.Controls.Add(this.quizTitleLabel);
            this.infoPanel.Controls.Add(this.txtBKT);
            this.infoPanel.Controls.Add(this.categoryLabel);
            this.infoPanel.Controls.Add(this.CbbMon);
            this.infoPanel.Location = new System.Drawing.Point(80, 352);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(793, 258);
            this.infoPanel.TabIndex = 2;
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
            this.btnReset.Location = new System.Drawing.Point(582, 198);
            this.btnReset.Name = "btnReset";
            this.btnReset.PressedColor = System.Drawing.Color.DimGray;
            this.btnReset.Size = new System.Drawing.Size(69, 38);
            this.btnReset.TabIndex = 14;
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
            this.btSave.Location = new System.Drawing.Point(403, 200);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(79, 36);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "Lưu";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // quizInfoLabel
            // 
            this.quizInfoLabel.AutoSize = true;
            this.quizInfoLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizInfoLabel.Location = new System.Drawing.Point(268, 23);
            this.quizInfoLabel.Name = "quizInfoLabel";
            this.quizInfoLabel.Size = new System.Drawing.Size(323, 35);
            this.quizInfoLabel.TabIndex = 0;
            this.quizInfoLabel.Text = "Thông tin bài kiểm tra";
            // 
            // quizTitleLabel
            // 
            this.quizTitleLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizTitleLabel.Location = new System.Drawing.Point(19, 82);
            this.quizTitleLabel.Name = "quizTitleLabel";
            this.quizTitleLabel.Size = new System.Drawing.Size(238, 44);
            this.quizTitleLabel.TabIndex = 1;
            this.quizTitleLabel.Text = "Tên bài kiểm tra";
            // 
            // txtBKT
            // 
            this.txtBKT.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBKT.Location = new System.Drawing.Point(263, 73);
            this.txtBKT.Multiline = true;
            this.txtBKT.Name = "txtBKT";
            this.txtBKT.Size = new System.Drawing.Size(400, 43);
            this.txtBKT.TabIndex = 2;
            // 
            // categoryLabel
            // 
            this.categoryLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(75, 149);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(154, 34);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Môn";
            // 
            // CbbMon
            // 
            this.CbbMon.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbbMon.Location = new System.Drawing.Point(263, 143);
            this.CbbMon.Name = "CbbMon";
            this.CbbMon.Size = new System.Drawing.Size(400, 45);
            this.CbbMon.TabIndex = 4;
            // 
            // QLBKT
            // 
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dgvBaiKiemTra);
            this.Controls.Add(this.infoPanel);
            this.Name = "QLBKT";
            this.Size = new System.Drawing.Size(995, 742);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiKiemTra)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SaveQuizButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bài kiểm tra đã được lưu!");
        }

        private Label titleLabel;
        private Panel infoPanel;
        private Label quizInfoLabel;
        private Label quizTitleLabel;
        private Label categoryLabel;
        private Guna.UI2.WinForms.Guna2Button btSave;
        private Guna.UI2.WinForms.Guna2Button btnReset;
    }
   
}
