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
    public partial class QLBKT : UserControl
    {
        private int? editingQuizId = null;
        private UserDTO currentUser;

        public QLBKT(UserDTO currentUser)
        {
            if (currentUser == null)
            {
                MessageBox.Show("Lỗi: Người dùng không hợp lệ.");
                return;
            }

            InitializeComponent();
            this.currentUser = currentUser;  // Gán currentUser vào biến thành viên của class
            InitDataGridView_BaiKiemTra();
            LoadQuizData();
            LoadSubjects(); // Load danh sách môn học vào ComboBox
            dgvBaiKiemTra.CellContentClick += dgvBaiKiemTra_CellContentClick;
            
        }

        private void InitDataGridView_BaiKiemTra()
        {
            dgvBaiKiemTra.AutoGenerateColumns = false;
          
            dgvBaiKiemTra.Columns.Clear();
            dgvBaiKiemTra.RowHeadersVisible = false;
            dgvBaiKiemTra.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "QuizId",
                Name = "QuizId",
                Visible = false // Ẩn khỏi người dùng
            });
            dgvBaiKiemTra.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên bài kiểm tra",
                DataPropertyName = "QuizTitle",
                Name = "TenBaiKiemTra",
                Width = 300
            });

            dgvBaiKiemTra.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Môn",
                DataPropertyName = "CategoryName",
                Name = "Mon",
                Width = 250
            });

            dgvBaiKiemTra.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Chỉnh",
                Name = "ChinhSua",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 120
            });

            dgvBaiKiemTra.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Name = "Xoa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            dgvBaiKiemTra.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Câu hỏi",
                Name = "CauHoi",
                Text = "📋",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBaiKiemTra.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvBaiKiemTra.RowTemplate.Height = 32;
            dgvBaiKiemTra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBaiKiemTra.Columns["TenBaiKiemTra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBaiKiemTra.EnableHeadersVisualStyles = false;
            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBaiKiemTra.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvBaiKiemTra.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBaiKiemTra.Columns["ChinhSua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBaiKiemTra.Columns["Xoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBaiKiemTra.Columns["CauHoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadQuizData()
        {
            TestBLL bll = new TestBLL();
            var quizzes = bll.GetQuizWithCategory(currentUser.Id);
                  
            dgvBaiKiemTra.DataSource = null;

            if (quizzes != null && quizzes.Count > 0)
            {
                dgvBaiKiemTra.DataSource = quizzes;
            }
            else
            {
             
                MessageBox.Show("Không có bài kiểm tra nào.");
            }
        }

        private void LoadSubjects()
        {
            MonHocBLL monHocBLL = new MonHocBLL();
            var subjects = monHocBLL.GetCategories();
            
            CbbMon.Items.Clear();
            foreach (var subject in subjects)
            {
                CbbMon.Items.Add(subject.Name);
            }
        }

        private void dgvBaiKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvBaiKiemTra.Rows[e.RowIndex];
                string tenBaiKT = selectedRow.Cells["TenBaiKiemTra"].Value.ToString();

                if (dgvBaiKiemTra.Columns[e.ColumnIndex].Name == "ChinhSua")
                {
                    editingQuizId = Convert.ToInt32(selectedRow.Cells["QuizId"].Value);
                    txtBKT.Text = selectedRow.Cells["TenBaiKiemTra"].Value.ToString();
                    CbbMon.Text = selectedRow.Cells["Mon"].Value.ToString();
                }

                else if (dgvBaiKiemTra.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa bài kiểm tra '{tenBaiKT}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int quizId = Convert.ToInt32(selectedRow.Cells["QuizId"].Value);
                        TestBLL bll = new TestBLL();
                        bool deleteResult = bll.DeleteTest(quizId);

                        if (deleteResult)
                        {
                            MessageBox.Show("Xóa thành công!");
                            LoadQuizData(); // Cập nhật lại datagridview
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dgvBaiKiemTra.Columns[e.ColumnIndex].Name == "CauHoi")
                {
                    int quizId = Convert.ToInt32(selectedRow.Cells["QuizId"].Value);

                    QLCH qlchControl = new QLCH(quizId, currentUser); // Truyền quizId nếu QLCH cần
                    Control parent = this.Parent; // hoặc Form cha nếu có
                    parent.Controls.Clear();
                    parent.Controls.Add(qlchControl);
                    qlchControl.Dock = DockStyle.Fill;
                }
            }
        }
        private void dgvBaiKiemTra_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string Ten = txtBKT.Text.Trim();
            string Mon = CbbMon.Text.Trim();

            if (string.IsNullOrWhiteSpace(Ten) || string.IsNullOrWhiteSpace(Mon))
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy CategoryId từ tên môn
            TestBLL bll = new TestBLL();
            int categoryId = bll.GetCategoryIdByName(Mon);

            if (categoryId == -1)
            {
                MessageBox.Show("Không tìm thấy danh mục tương ứng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng TestDTO và gán ID người tạo là currentUser.Id
            TestDTO test = new TestDTO()
            {
                QuizTitle = Ten,
                CategoryName = Mon,
                CategoryId = categoryId,
                CreatedByUserId = currentUser.Id  // Gán người tạo bài kiểm tra
            };

            bool result = false;

            // Nếu có QuizId (tức là đang chỉnh sửa), sử dụng phương thức Update
            if (editingQuizId.HasValue)
            {
                test.QuizId = editingQuizId.Value;  // Nếu đang chỉnh sửa bài kiểm tra, gán QuizId
                result = bll.UpdateTest(test);  // Cập nhật bài kiểm tra
                editingQuizId = null;  // Reset trạng thái chỉnh sửa
            }
            else
            {
                result = bll.AddTest(test);  // Thêm bài kiểm tra mới
            }

            // Kiểm tra kết quả
            if (result)
            {
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuizData();  // Cập nhật lại danh sách bài kiểm tra
                txtBKT.Clear();
                CbbMon.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtBKT.Clear();
            CbbMon.SelectedIndex = -1;
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            quizInfoLabel.Text = "Thông tin bài kiểm tra";
        }
    }
}
