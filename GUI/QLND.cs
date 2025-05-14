using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class QLND : UserControl
    {
        private UserBLL userBLL = new UserBLL();
        private UserDTO selectedUser = null;
      

        public QLND()
        {
            InitializeComponent();
            InitDataGridView(); 
            LoadUsers();
            dgvUsers.Font = new Font("Segoe UI", 10);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.DefaultCellStyle.BackColor = Color.White;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUsers.RowTemplate.Height = 30;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            
        }

        private void InitDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.RowHeadersVisible = false;

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "Username",
                Name = "Username"
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quyền",
                DataPropertyName = "Role",
                Name = "Role"
            });

            dgvUsers.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Chỉnh sửa",
                Name = "ChinhSua",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 60
            });

            dgvUsers.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Name = "Xoa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 60
            });
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userBLL.GetUsers();
        }
       

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                if (dgvUsers.Columns[e.ColumnIndex].Name == "ChinhSua")
                {
                    // Gán dữ liệu người dùng lên ô nhập
                    selectedUser = (UserDTO)dgvUsers.Rows[e.RowIndex].DataBoundItem;

                    txtUsername.Text = selectedUser.Username;
                    txtMK.Text = selectedUser.Password;
                    cboRole.Text = selectedUser.Role;
                    txtName.Text = selectedUser.Name;

                }
                else if (dgvUsers.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    string username = dgvUsers.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa người dùng '{username}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (userBLL.DeleteUser(username))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
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
        private void ClearForm()
        {
            txtUsername.Clear();
            txtMK.Clear();
            txtName.Clear();
            cboRole.SelectedIndex = -1;
            txtUsername.Enabled = true; 
            selectedUser = null; 
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panelUserInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QLND_Load(object sender, EventArgs e)
        {

        }

        private void dgvUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtMK.Text.Trim();
            string role = cboRole.Text.Trim();
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO user = new UserDTO()
            {
                Username = username,
                Password = password,
                Role = role,
                Name = name
            };

            if (selectedUser == null) // THÊM MỚI
            {
                var existingUser = userBLL.GetUserByUsername(username);
                if (existingUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool userAdded = userBLL.AddUser(user);
                if (userAdded)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var insertedUser = userBLL.GetUserByUsername(user.Username);
                    int userId = insertedUser?.Id ?? 0;

                    if (role == "Student" && userId > 0)
                    {
                        StudentDTO student = new StudentDTO()
                        {
                            Name = user.Name,
                            Email = $"{userId}_{user.Username}@edu.ou.vn",
                            UserId = userId
                        };

                        bool studentAdded = userBLL.AddStudent(student);
                    }
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // CHỈNH SỬA
            {
                string originalUsername = selectedUser.Username;
                if (username != originalUsername)
                {
                    var existingUser = userBLL.GetUserByUsername(username);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                bool result = userBLL.UpdateUser(user, originalUsername);

                if (result)
                {
                    // LẤY LẠI ID SAU UPDATE
                    var updatedUser = userBLL.GetUserByUsername(user.Username);
                    user.Id = updatedUser?.Id ?? 0;

                    if (role == "Student" && user.Id > 0)
                    {
                        StudentDTO existingStudent = userBLL.GetStudentByUserId(user.Id);
                        if (existingStudent != null)
                        {
                            existingStudent.Name = name;
                            existingStudent.Email = $"{user.Id}_{user.Username}@edu.ou.vn";

                            bool studentUpdated = userBLL.UpdateStudent(existingStudent);

                        }
                    }

                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadUsers();
            ClearForm();
            selectedUser = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblTitle.Text = "Thông tin người dùng";

        }
    }
}
