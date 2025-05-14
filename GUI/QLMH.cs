using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class QLMH : UserControl
    {
        private MonHocBLL monHocBLL = new MonHocBLL();
        private MonHocDTO selectedMonHoc = null;

        public QLMH()
        {
            InitializeComponent();
            InitDataGridView();
            LoadMonHocs();
            dgvMonHoc.Font = new Font("Segoe UI", 10);
            dgvMonHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.DefaultCellStyle.ForeColor = Color.Black;
            dgvMonHoc.DefaultCellStyle.BackColor = Color.White;
            dgvMonHoc.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dgvMonHoc.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvMonHoc.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMonHoc.RowTemplate.Height = 30;
            
        }

        private void InitDataGridView()
        {
            dgvMonHoc.AutoGenerateColumns = false; // Tắt tính năng tự động tạo cột
            dgvMonHoc.Columns.Clear(); // Xóa tất cả cột trước khi thêm cột mới
            dgvMonHoc.RowHeadersVisible = false;
            // Cột tên môn học
            dgvMonHoc.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên môn học",
                DataPropertyName = "Name", // Tên trường trong DTO
                Name = "Name",  // Tên cột
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Tự động điều chỉnh độ rộng
            });

            // Cột chỉnh sửa
            dgvMonHoc.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Chỉnh sửa",
                Name = "ChinhSua",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });

            // Cột xóa
            dgvMonHoc.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Name = "Xoa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 100
            });
        }



        private void LoadMonHocs()
        {
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = monHocBLL.GetCategories();
        }


        private void ClearForm()
        {
            txtMonHoc.Clear();
            selectedMonHoc = null;
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && e.RowIndex < dgvMonHoc.Rows.Count)
            {
                if (dgvMonHoc.Columns[e.ColumnIndex].Name == "ChinhSua")
                {
                    selectedMonHoc = (MonHocDTO)dgvMonHoc.Rows[e.RowIndex].DataBoundItem;
                    txtMonHoc.Text = selectedMonHoc.Name;
                }
                else if (dgvMonHoc.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var monHocCanXoa = (MonHocDTO)dgvMonHoc.Rows[e.RowIndex].DataBoundItem;

                    if (monHocCanXoa == null)
                    {
                        MessageBox.Show("Không có môn học nào được chọn để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string name = monHocCanXoa.Name;
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa môn học '{name}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (monHocBLL.DeleteCategory(monHocCanXoa.Id))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMonHocs();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                   

                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string name = txtMonHoc.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng điền tên môn học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonHocDTO monHoc;

            if (selectedMonHoc == null) // Thêm mới
            {
                monHoc = new MonHocDTO(0, name); // ID = 0 khi thêm mới
            }
            else // Chỉnh sửa
            {
                monHoc = new MonHocDTO(selectedMonHoc.Id, name); // Cung cấp id từ selectedMonHoc
            }

            bool result = selectedMonHoc == null ? monHocBLL.AddCategory(monHoc) : monHocBLL.UpdateCategory(monHoc);

            if (result)
            {
                MessageBox.Show(selectedMonHoc == null ? "Thêm môn học thành công!" : "Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(selectedMonHoc == null ? "Thêm môn học thất bại!" : "Cập nhật môn học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadMonHocs();
            ClearForm();
            selectedMonHoc = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblTitle.Text = "Thông tin môn học";
        }
    }
}