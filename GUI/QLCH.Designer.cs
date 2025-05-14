using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class QLCH : UserControl
    {
        private DataGridView dgvCH;
        private System.Windows.Forms.TextBox txtCH;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtC;
        private TextBox txtD;
        private RadioButton radioA;
        private RadioButton radioB;
        private RadioButton radioC;
        private RadioButton radioD;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLCH));
            this.titleLabel = new System.Windows.Forms.Label();
            this.dgvCH = new System.Windows.Forms.DataGridView();
            this.PanelCH = new System.Windows.Forms.Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btLuu = new Guna.UI2.WinForms.Guna2Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.txtCH = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerTable = new System.Windows.Forms.TableLayoutPanel();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.txtA = new System.Windows.Forms.TextBox();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.txtB = new System.Windows.Forms.TextBox();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.txtD = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.btTroLai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tgLamBai = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChonThoiGian = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCH)).BeginInit();
            this.PanelCH.SuspendLayout();
            this.answerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgLamBai)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(296, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(304, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Quản lý câu hỏi";
            // 
            // dgvCH
            // 
            this.dgvCH.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.dgvCH.ColumnHeadersHeight = 29;
            this.dgvCH.Font = new System.Drawing.Font("Arial", 12F);
            this.dgvCH.Location = new System.Drawing.Point(169, 72);
            this.dgvCH.Name = "dgvCH";
            this.dgvCH.RowHeadersWidth = 51;
            this.dgvCH.Size = new System.Drawing.Size(550, 150);
            this.dgvCH.TabIndex = 1;
            // 
            // PanelCH
            // 
            this.PanelCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PanelCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCH.Controls.Add(this.btnReset);
            this.PanelCH.Controls.Add(this.btLuu);
            this.PanelCH.Controls.Add(this.questionLabel);
            this.PanelCH.Controls.Add(this.txtCH);
            this.PanelCH.Controls.Add(this.answerLabel);
            this.PanelCH.Controls.Add(this.answerTable);
            this.PanelCH.Location = new System.Drawing.Point(169, 256);
            this.PanelCH.Name = "PanelCH";
            this.PanelCH.Size = new System.Drawing.Size(550, 466);
            this.PanelCH.TabIndex = 2;
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
            this.btnReset.Location = new System.Drawing.Point(378, 402);
            this.btnReset.Name = "btnReset";
            this.btnReset.PressedColor = System.Drawing.Color.DimGray;
            this.btnReset.Size = new System.Drawing.Size(69, 38);
            this.btnReset.TabIndex = 17;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btLuu
            // 
            this.btLuu.BorderColor = System.Drawing.Color.SteelBlue;
            this.btLuu.BorderRadius = 19;
            this.btLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btLuu.FillColor = System.Drawing.Color.MidnightBlue;
            this.btLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.ForeColor = System.Drawing.Color.White;
            this.btLuu.Location = new System.Drawing.Point(226, 404);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(69, 36);
            this.btLuu.TabIndex = 16;
            this.btLuu.Text = "Lưu";
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.BackColor = System.Drawing.Color.SkyBlue;
            this.questionLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(167, 21);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(190, 32);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Câu hỏi";
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCH
            // 
            this.txtCH.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCH.Location = new System.Drawing.Point(56, 70);
            this.txtCH.Multiline = true;
            this.txtCH.Name = "txtCH";
            this.txtCH.Size = new System.Drawing.Size(435, 42);
            this.txtCH.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(199, 124);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(137, 37);
            this.answerLabel.TabIndex = 2;
            this.answerLabel.Text = "Đáp án";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // answerTable
            // 
            this.answerTable.ColumnCount = 2;
            this.answerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.answerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.answerTable.Controls.Add(this.radioA, 0, 0);
            this.answerTable.Controls.Add(this.txtA, 1, 0);
            this.answerTable.Controls.Add(this.radioB, 0, 1);
            this.answerTable.Controls.Add(this.txtB, 1, 1);
            this.answerTable.Controls.Add(this.radioC, 0, 2);
            this.answerTable.Controls.Add(this.radioD, 0, 3);
            this.answerTable.Controls.Add(this.txtD, 1, 3);
            this.answerTable.Controls.Add(this.txtC, 1, 2);
            this.answerTable.Location = new System.Drawing.Point(23, 164);
            this.answerTable.Name = "answerTable";
            this.answerTable.RowCount = 4;
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.answerTable.Size = new System.Drawing.Size(500, 217);
            this.answerTable.TabIndex = 3;
            // 
            // radioA
            // 
            this.radioA.Location = new System.Drawing.Point(3, 3);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(24, 24);
            this.radioA.TabIndex = 0;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(33, 3);
            this.txtA.Multiline = true;
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(430, 45);
            this.txtA.TabIndex = 1;
            // 
            // radioB
            // 
            this.radioB.Location = new System.Drawing.Point(3, 57);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(24, 24);
            this.radioB.TabIndex = 2;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(33, 57);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(430, 45);
            this.txtB.TabIndex = 3;
            // 
            // radioC
            // 
            this.radioC.Location = new System.Drawing.Point(3, 111);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(24, 24);
            this.radioC.TabIndex = 4;
            // 
            // radioD
            // 
            this.radioD.Location = new System.Drawing.Point(3, 165);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(24, 24);
            this.radioD.TabIndex = 6;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(33, 165);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(430, 45);
            this.txtD.TabIndex = 7;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(33, 111);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(430, 45);
            this.txtC.TabIndex = 5;
            // 
            // btTroLai
            // 
            this.btTroLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTroLai.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btTroLai.Location = new System.Drawing.Point(23, 25);
            this.btTroLai.Name = "btTroLai";
            this.btTroLai.Size = new System.Drawing.Size(93, 62);
            this.btTroLai.TabIndex = 3;
            this.btTroLai.Text = "🔙";
            this.btTroLai.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTroLai.UseVisualStyleBackColor = true;
            this.btTroLai.Click += new System.EventHandler(this.btTroLai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Giới hạn thời gian (phút)";
            // 
            // tgLamBai
            // 
            this.tgLamBai.Location = new System.Drawing.Point(57, 40);
            this.tgLamBai.Name = "tgLamBai";
            this.tgLamBai.Size = new System.Drawing.Size(99, 22);
            this.tgLamBai.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnChonThoiGian);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tgLamBai);
            this.panel1.Location = new System.Drawing.Point(739, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 119);
            this.panel1.TabIndex = 7;
            // 
            // btnChonThoiGian
            // 
            this.btnChonThoiGian.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnChonThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonThoiGian.Location = new System.Drawing.Point(135, 75);
            this.btnChonThoiGian.Name = "btnChonThoiGian";
            this.btnChonThoiGian.Size = new System.Drawing.Size(57, 38);
            this.btnChonThoiGian.TabIndex = 8;
            this.btnChonThoiGian.Text = "Chọn";
            this.btnChonThoiGian.UseVisualStyleBackColor = false;
            this.btnChonThoiGian.Click += new System.EventHandler(this.btnChonThoiGian_Click_1);
            // 
            // QLCH
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btTroLai);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dgvCH);
            this.Controls.Add(this.PanelCH);
            this.Name = "QLCH";
            this.Size = new System.Drawing.Size(982, 795);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCH)).EndInit();
            this.PanelCH.ResumeLayout(false);
            this.PanelCH.PerformLayout();
            this.answerTable.ResumeLayout(false);
            this.answerTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgLamBai)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SaveQuestionButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Question has been saved!");
        }
        public void SetQuestionText(string question)
        {
            txtCH.Text = question;
        }

        private Label titleLabel;
        private Panel PanelCH;
        private Label questionLabel;
        private Label answerLabel;
        private TableLayoutPanel answerTable;
        private Button btTroLai;
        private Guna.UI2.WinForms.Guna2Button btLuu;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Label label1;
        private NumericUpDown tgLamBai;
        private Panel panel1;
        private Button btnChonThoiGian;
    }
}