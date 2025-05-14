namespace GUI
{
    partial class LamBai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LamBai));
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDeThi = new System.Windows.Forms.ComboBox();
            this.buttonLui = new System.Windows.Forms.Button();
            this.buttonTiep = new System.Windows.Forms.Button();
            this.btNopBai = new System.Windows.Forms.Button();
            this.PanTN = new System.Windows.Forms.Panel();
            this.questionLabel = new System.Windows.Forms.Label();
            this.txtCH = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.answerTable = new System.Windows.Forms.TableLayoutPanel();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.txtB = new System.Windows.Forms.TextBox();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.txtC = new System.Windows.Forms.TextBox();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.DongHo = new System.Windows.Forms.Panel();
            this.lbDH = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.miniMapPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDatCo = new System.Windows.Forms.Button();
            this.PanTN.SuspendLayout();
            this.answerTable.SuspendLayout();
            this.DongHo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Làm bài kiểm tra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbbDeThi
            // 
            this.cbbDeThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDeThi.FormattingEnabled = true;
            this.cbbDeThi.Location = new System.Drawing.Point(181, 65);
            this.cbbDeThi.Margin = new System.Windows.Forms.Padding(4);
            this.cbbDeThi.Name = "cbbDeThi";
            this.cbbDeThi.Size = new System.Drawing.Size(320, 37);
            this.cbbDeThi.TabIndex = 1;
            this.cbbDeThi.SelectedIndexChanged += new System.EventHandler(this.cbbDeThi_SelectedIndexChanged);
            // 
            // buttonLui
            // 
            this.buttonLui.Location = new System.Drawing.Point(26, 309);
            this.buttonLui.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLui.Name = "buttonLui";
            this.buttonLui.Size = new System.Drawing.Size(35, 30);
            this.buttonLui.TabIndex = 3;
            this.buttonLui.Text = "<";
            this.buttonLui.UseVisualStyleBackColor = true;
            // 
            // buttonTiep
            // 
            this.buttonTiep.Location = new System.Drawing.Point(626, 299);
            this.buttonTiep.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTiep.Name = "buttonTiep";
            this.buttonTiep.Size = new System.Drawing.Size(35, 30);
            this.buttonTiep.TabIndex = 4;
            this.buttonTiep.Text = ">";
            this.buttonTiep.UseVisualStyleBackColor = true;
            // 
            // btNopBai
            // 
            this.btNopBai.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btNopBai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNopBai.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btNopBai.Location = new System.Drawing.Point(304, 503);
            this.btNopBai.Margin = new System.Windows.Forms.Padding(4);
            this.btNopBai.Name = "btNopBai";
            this.btNopBai.Size = new System.Drawing.Size(105, 38);
            this.btNopBai.TabIndex = 5;
            this.btNopBai.Text = "Nộp bài";
            this.btNopBai.UseVisualStyleBackColor = false;
            this.btNopBai.Click += new System.EventHandler(this.btNopBai_Click_1);
            // 
            // PanTN
            // 
            this.PanTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PanTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanTN.Controls.Add(this.questionLabel);
            this.PanTN.Controls.Add(this.txtCH);
            this.PanTN.Controls.Add(this.answerLabel);
            this.PanTN.Controls.Add(this.answerTable);
            this.PanTN.Location = new System.Drawing.Point(92, 156);
            this.PanTN.Name = "PanTN";
            this.PanTN.Size = new System.Drawing.Size(513, 314);
            this.PanTN.TabIndex = 6;
            // 
            // questionLabel
            // 
            this.questionLabel.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(164, 4);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(167, 32);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Câu hỏi";
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCH
            // 
            this.txtCH.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCH.Location = new System.Drawing.Point(44, 39);
            this.txtCH.Multiline = true;
            this.txtCH.Name = "txtCH";
            this.txtCH.Size = new System.Drawing.Size(435, 32);
            this.txtCH.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(179, 74);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(137, 33);
            this.answerLabel.TabIndex = 2;
            this.answerLabel.Text = "Đáp án";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.answerLabel.Click += new System.EventHandler(this.answerLabel_Click);
            // 
            // answerTable
            // 
            this.answerTable.ColumnCount = 2;
            this.answerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.answerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.answerTable.Controls.Add(this.radioB, 0, 1);
            this.answerTable.Controls.Add(this.txtB, 1, 1);
            this.answerTable.Controls.Add(this.radioC, 0, 2);
            this.answerTable.Controls.Add(this.txtC, 1, 2);
            this.answerTable.Controls.Add(this.radioD, 0, 3);
            this.answerTable.Controls.Add(this.radioA, 0, 0);
            this.answerTable.Controls.Add(this.txtA, 1, 0);
            this.answerTable.Controls.Add(this.txtD, 1, 3);
            this.answerTable.Location = new System.Drawing.Point(11, 110);
            this.answerTable.Name = "answerTable";
            this.answerTable.RowCount = 4;
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.79793F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.76166F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.8342F));
            this.answerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.64249F));
            this.answerTable.Size = new System.Drawing.Size(485, 195);
            this.answerTable.TabIndex = 3;
            // 
            // radioB
            // 
            this.radioB.Location = new System.Drawing.Point(3, 46);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(24, 24);
            this.radioB.TabIndex = 2;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(33, 46);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(435, 32);
            this.txtB.TabIndex = 3;
            // 
            // radioC
            // 
            this.radioC.Location = new System.Drawing.Point(3, 87);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(24, 24);
            this.radioC.TabIndex = 4;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(33, 87);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(435, 31);
            this.txtC.TabIndex = 5;
            // 
            // radioD
            // 
            this.radioD.Location = new System.Drawing.Point(3, 132);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(24, 24);
            this.radioD.TabIndex = 6;
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
            this.txtA.Size = new System.Drawing.Size(435, 32);
            this.txtA.TabIndex = 1;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(33, 132);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(435, 32);
            this.txtD.TabIndex = 7;
            // 
            // DongHo
            // 
            this.DongHo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DongHo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DongHo.Controls.Add(this.lbDH);
            this.DongHo.Font = new System.Drawing.Font("Digital-7 Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DongHo.ForeColor = System.Drawing.Color.Green;
            this.DongHo.Location = new System.Drawing.Point(611, 183);
            this.DongHo.Name = "DongHo";
            this.DongHo.Size = new System.Drawing.Size(90, 30);
            this.DongHo.TabIndex = 7;
            // 
            // lbDH
            // 
            this.lbDH.AutoSize = true;
            this.lbDH.Font = new System.Drawing.Font("Digital-7 Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDH.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbDH.Location = new System.Drawing.Point(2, 4);
            this.lbDH.Name = "lbDH";
            this.lbDH.Size = new System.Drawing.Size(120, 25);
            this.lbDH.TabIndex = 0;
            this.lbDH.Text = "Thời gian";
            this.lbDH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnBatDau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.Color.Navy;
            this.btnBatDau.Location = new System.Drawing.Point(508, 84);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(84, 34);
            this.btnBatDau.TabIndex = 8;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // miniMapPanel
            // 
            this.miniMapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miniMapPanel.Location = new System.Drawing.Point(18, 41);
            this.miniMapPanel.Name = "miniMapPanel";
            this.miniMapPanel.Size = new System.Drawing.Size(113, 100);
            this.miniMapPanel.TabIndex = 9;
            // 
            // btnDatCo
            // 
            this.btnDatCo.BackColor = System.Drawing.SystemColors.Control;
            this.btnDatCo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDatCo.Image = ((System.Drawing.Image)(resources.GetObject("btnDatCo.Image")));
            this.btnDatCo.Location = new System.Drawing.Point(596, 120);
            this.btnDatCo.Name = "btnDatCo";
            this.btnDatCo.Size = new System.Drawing.Size(31, 30);
            this.btnDatCo.TabIndex = 10;
            this.btnDatCo.UseVisualStyleBackColor = false;
            this.btnDatCo.Click += new System.EventHandler(this.btnDatCo_Click);
            // 
            // LamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDatCo);
            this.Controls.Add(this.miniMapPanel);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.DongHo);
            this.Controls.Add(this.PanTN);
            this.Controls.Add(this.btNopBai);
            this.Controls.Add(this.buttonTiep);
            this.Controls.Add(this.buttonLui);
            this.Controls.Add(this.cbbDeThi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LamBai";
            this.Size = new System.Drawing.Size(758, 616);
            this.Load += new System.EventHandler(this.LamBai_Load);
            this.PanTN.ResumeLayout(false);
            this.PanTN.PerformLayout();
            this.answerTable.ResumeLayout(false);
            this.answerTable.PerformLayout();
            this.DongHo.ResumeLayout(false);
            this.DongHo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDeThi;
        private System.Windows.Forms.Button buttonLui;
        private System.Windows.Forms.Button buttonTiep;
        private System.Windows.Forms.Button btNopBai;
        private System.Windows.Forms.Panel PanTN;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.TextBox txtCH;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TableLayoutPanel answerTable;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.Panel DongHo;
        private System.Windows.Forms.Label lbDH;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.FlowLayoutPanel miniMapPanel;
        private System.Windows.Forms.Button btnDatCo;
    }
}