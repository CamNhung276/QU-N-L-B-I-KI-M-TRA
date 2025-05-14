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
using DTO;


namespace GUI
{
    public partial class DangNhap : Form
    {
        private LoginBLL loginBLL = new LoginBLL();  

        public DangNhap()
        {
            InitializeComponent();
            //nhấn enter để đăng nhập
            this.AcceptButton = btDNhap;

        }

        private void checkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMK.Checked)
            {
                // Hiện mật khẩu 
                txtMK.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu, hiển thị dấu *
                txtMK.PasswordChar = '*';
            }
        }

        private void btDNhap_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtMK.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoginDTO login = new LoginDTO(username, password);
            string role;
            int userId;

            if (loginBLL.AuthenticateUser(login, out role, out userId))
            {
                MessageBox.Show($"Đăng nhập thành công với quyền: {role}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lấy thông tin người dùng sau khi đăng nhập thành công
                UserDTO currentUser = loginBLL.GetUserByUsername(username);
                using (Home frmMain = new Home(role, currentUser))
                {
                    this.Hide(); // Ẩn form DangNhap
                    frmMain.ShowDialog();

                    // Sau khi form Home đóng thì reset thông tin đăng nhập
                    txtName.Clear();
                    txtMK.Clear();
                    checkMK.Checked = false;
                    txtMK.PasswordChar = '*'; // Đảm bảo mật khẩu vẫn ẩn sau khi reset

                    this.Show(); // Hiện lại form DangNhap
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
