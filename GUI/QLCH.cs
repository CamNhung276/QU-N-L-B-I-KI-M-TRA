using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DTO;

namespace GUI
{
    public partial class QLCH : UserControl
    {
        private int quizId;
        private int? editingQuestionId = null;
        private DapAnBLL dapAnBLL = new DapAnBLL();
        private CauHoiBLL cauHoiBLL = new CauHoiBLL();
        private bool isLoading = false;
        private UserDTO currentUser;  // Thêm trường currentUser

     
        public QLCH(int quizId, UserDTO currentUser)
        {
            InitializeComponent();
            this.quizId = quizId;
            this.currentUser = currentUser;  // Gán currentUser cho đối tượng
            this.btLuu.Click -= btLuu_Click;
            this.btLuu.Click += btLuu_Click;

            this.dgvCH.CellContentClick -= dgvCH_CellContentClick;
            this.dgvCH.CellContentClick += dgvCH_CellContentClick;

            InitDataGridView_CH();
         
            LoadQuestions();
            LoadQuizTime();
        }

        private void InitDataGridView_CH()
        {
            dgvCH.AutoGenerateColumns = false;
            dgvCH.Columns.Clear();
            dgvCH.RowHeadersVisible = false;

            dgvCH.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Câu hỏi kiểm tra",
                DataPropertyName = "Text",
                Name = "Text",
                Width = 400
            });

            dgvCH.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Chỉnh sửa",
                Name = "ChinhSua",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            dgvCH.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Name = "Xoa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            dgvCH.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCH.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCH.RowTemplate.Height = 30;
            dgvCH.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCH.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCH.EnableHeadersVisualStyles = false;
            dgvCH.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        private void LoadQuestions()
        {
            CauHoiDAL dal = new CauHoiDAL();
            var danhSachCauHoi = dal.GetQuestionsByQuizId(quizId);
            dgvCH.DataSource = danhSachCauHoi;
        }

        private void btTroLai_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            parent.Controls.Remove(this);  // Xóa control hiện tại (QLCH)

            // Tạo lại control QLBKT với tham số currentUser
            QLBKT qlbktControl = new QLBKT(currentUser);  // Truyền currentUser
            qlbktControl.Dock = DockStyle.Fill;  // Đặt Dock của control

            // Thêm QLBKT vào control cha
            parent.Controls.Add(qlbktControl);
        }

        private void dgvCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvCH.Rows[e.RowIndex];
                var question = selectedRow.DataBoundItem as CauHoiDTO;

                if (dgvCH.Columns[e.ColumnIndex].Name == "ChinhSua")
                {
                    editingQuestionId = question.Id;
                    txtCH.Text = question.Text;

                    // Cập nhật thời gian làm bài
                    UpdateQuizTime();

                    // Lấy danh sách đáp án
                    var dapAns = dapAnBLL.GetAnswersByQuestionId(question.Id);
                    if (dapAns != null && dapAns.Count > 0)
                    {
                        txtA.Text = dapAns[0].Text;
                        txtB.Text = dapAns[1].Text;
                        txtC.Text = dapAns[2].Text;
                        txtD.Text = dapAns[3].Text;

                        // Đặt radio button cho đáp án đúng
                        int correctAnswerId = question.CorrectAnswerId;
                        radioA.Checked = dapAns[0].Id == correctAnswerId;
                        radioB.Checked = dapAns[1].Id == correctAnswerId;
                        radioC.Checked = dapAns[2].Id == correctAnswerId;
                        radioD.Checked = dapAns[3].Id == correctAnswerId;
                    }
                }
                else if (dgvCH.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa câu hỏi này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = cauHoiBLL.DeleteQuestion(question.Id);

                        if (success)
                        {
                            MessageBox.Show("Xóa câu hỏi thành công!");
                            LoadQuestions();
                        }
                        else
                        {
                            MessageBox.Show("Xóa câu hỏi thất bại!");
                        }
                    }
                }
                else if (dgvCH.Columns[e.ColumnIndex].Name == "SaoChep") // Thêm xử lý cho nút sao chép
                {
                    // Cập nhật thời gian làm bài khi nhấn vào nút sao chép
                    UpdateQuizTime();
                }
            }
        }

        private void ResetForm()
        {
            editingQuestionId = null;
            txtCH.Text = string.Empty;
            txtA.Text = string.Empty;
            txtB.Text = string.Empty;
            txtC.Text = string.Empty;
            txtD.Text = string.Empty;

            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
        }

        private void AddAllAnswers(int questionId)
        {
            dapAnBLL.InsertAnswer(txtA.Text, questionId, radioA.Checked);
            dapAnBLL.InsertAnswer(txtB.Text, questionId, radioB.Checked);
            dapAnBLL.InsertAnswer(txtC.Text, questionId, radioC.Checked);
            dapAnBLL.InsertAnswer(txtD.Text, questionId, radioD.Checked);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (isLoading) return;

            string noiDungCH = txtCH.Text.Trim();
            string dapAnA = txtA.Text.Trim();
            string dapAnB = txtB.Text.Trim();
            string dapAnC = txtC.Text.Trim();
            string dapAnD = txtD.Text.Trim();

            if (string.IsNullOrEmpty(noiDungCH))
            {
                MessageBox.Show("Bạn chưa nhập nội dung câu hỏi!", "Thiếu câu hỏi");
                return;
            }

            if (string.IsNullOrEmpty(dapAnA) || string.IsNullOrEmpty(dapAnB) ||
                string.IsNullOrEmpty(dapAnC) || string.IsNullOrEmpty(dapAnD))
            {
                MessageBox.Show("Vui lòng điền đầy đủ 4 đáp án.", "Thiếu đáp án");
                return;
            }

            if (!radioA.Checked && !radioB.Checked && !radioC.Checked && !radioD.Checked)
            {
                MessageBox.Show("Vui lòng chọn 1 đáp án đúng.", "Chưa chọn đáp án đúng");
                return;
            }

            try
            {
                if (editingQuestionId.HasValue)
                {
                    var ch = new CauHoiDTO
                    {
                        Id = editingQuestionId.Value,
                        Text = noiDungCH,
                        QuizId = quizId
                    };

                    cauHoiBLL.UpdateQuestion(ch);
                    dapAnBLL.DeleteAnswersByQuestionId(ch.Id);
                    AddAllAnswers(ch.Id);

                    MessageBox.Show("Cập nhật câu hỏi thành công!", "Thành công");
                }
                else
                {
                    var ch = new CauHoiDTO
                    {
                        Text = noiDungCH,
                        QuizId = quizId
                    };

                    int newQuestionId = cauHoiBLL.InsertAndGetId(ch);
                    AddAllAnswers(newQuestionId);

                    MessageBox.Show("Thêm câu hỏi mới thành công!", "Thành công");
                }

                isLoading = true;
                ResetForm();
                LoadQuestions();
                isLoading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQuizTime()
        {
            DeThiBLL deThiBLL = new DeThiBLL();
            var deThi = deThiBLL.LayDeThiTheoId(quizId);
            if (deThi != null)
            {
                tgLamBai.Value = deThi.ThoiGianLamBai;
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void tgLamBai_ValueChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            try
            {
                int thoiGian = (int)tgLamBai.Value;
                DeThiDTO deThi = new DeThiDTO
                {
                    Id = quizId,
                    ThoiGianLamBai = thoiGian
                };
                DeThiBLL deThiBLL = new DeThiBLL();
                
                deThiBLL.UpdateThoiGianLamBai(deThi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thời gian làm bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChonThoiGian_Click_1(object sender, EventArgs e)
        {
            try
            {
                int thoiGian = (int)tgLamBai.Value;
                DeThiDTO deThi = new DeThiDTO
                {
                    Id = quizId,
                    ThoiGianLamBai = thoiGian
                };

                DeThiBLL deThiBLL = new DeThiBLL();
                deThiBLL.UpdateThoiGianLamBai(deThi);

                MessageBox.Show($"Đã cập nhật thời gian làm bài: {thoiGian} phút!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thời gian làm bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuizTime()
        {
            DeThiBLL deThiBLL = new DeThiBLL();
            var deThi = deThiBLL.LayDeThiTheoId(quizId);
            if (deThi != null)
            {
                tgLamBai.Value = deThi.ThoiGianLamBai;
            }
        }
    }
}
