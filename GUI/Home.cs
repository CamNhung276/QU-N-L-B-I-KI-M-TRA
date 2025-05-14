using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class Home : Form
    {
        private string userRole;
        private UserDTO currentUser;
        private int userId;
        private string role;
        public bool IsLoggedIn { get; set; } = false;

        public Home(string role, UserDTO currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userRole = role;
            this.userId = currentUser.Id;
            LoadControlToPanel(new CuaSo(role, currentUser));
            this.Load += Home_Load;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Ẩn tất cả nút chức năng
            guna2QLND.Visible = false;
            gunaQLMH.Visible = false;
            guna2BKT.Visible = false;
            guna2LamBai.Visible = false;
            guna2XemKQ.Visible = false;

            // Hiển thị nút phù hợp với vai trò
            if (userRole == "Admin")
            {
                guna2QLND.Visible = true;
                gunaQLMH.Visible = true;
                guna2XemKQ.Visible = true;
            }
            else if (userRole == "Teacher")
            {
                gunaQLMH.Visible = true;
                guna2BKT.Visible = true;
                guna2XemKQ.Visible = true;
            }
            else if (userRole == "Student")
            {
                guna2LamBai.Visible = true;
                guna2XemKQ.Visible = true;
            }
            ArrangeButtons();
        }

     
        private void LoadControlToPanel(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            panelContent.Controls.Add(control);
        }

        // Di chuyển hình trượt icon
        private void moveImageBox(object sender)
        {
            if (sender is Guna2Button b)
            {
                int x = b.Location.X + (b.Width - imgSlide.Width) / 2 + 26;
                int y = b.Location.Y + (b.Height - imgSlide.Height) / 2;
                imgSlide.Location = new Point(x, y);
                imgSlide.SendToBack();
            }
        }

      
        private void guna2Home_Click(object sender, EventArgs e) => LoadControlToPanel(new CuaSo(userRole, currentUser));
        private void guna2QLND_Click(object sender, EventArgs e) => LoadControlToPanel(new QLND());
        private void panelQLMH_Click(object sender, EventArgs e) => LoadControlToPanel(new QLMH());
        private void guna2Button4_Click(object sender, EventArgs e) => LoadControlToPanel(new QLBKT(currentUser));
        private void guna2XemKQ_Click(object sender, EventArgs e) => LoadControlToPanel(new KetQua(role, userId));
        private void guna2LamBai_Click(object sender, EventArgs e) => LoadControlToPanel(new LamBai(userId));

        private void guna2Button1_CheckedChanged(object sender, EventArgs e) => moveImageBox(sender);
        private void ArrangeButtons()
        {
            int topMargin = guna2Home.Top; // Nút đầu tiên (Home)
            int spacing = 68; // Khoảng cách giữa các nút

            Control[] buttons = new Control[]
            {
        guna2Home,
        guna2QLND,
        gunaQLMH,
        guna2BKT,
        guna2LamBai,
        guna2XemKQ
            };

            foreach (var btn in buttons)
            {
                if (btn.Visible)
                {
                    btn.Top = topMargin;
                    topMargin += btn.Height + spacing;
                }
            }
        }
        public void AnMenuSinhVien()
        {
            guna2Home.Visible = false;
            guna2LamBai.Visible = false;
            guna2XemKQ.Visible = false;
            btnDangXuat.Visible = false;
        }
        public void HienMenuSinhVien()
        {
            guna2Home.Visible = true;
            guna2LamBai.Visible = true;
            guna2XemKQ.Visible = true;
            btnDangXuat.Visible = true; 
        }



        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tìm form DangNhap đang tồn tại
                Form existingLoginForm = Application.OpenForms["DangNhap"];
                if (existingLoginForm != null)
                {
                    existingLoginForm.Show(); // Hiện form DangNhap đã tồn tại
                }
                else
                {
                    DangNhap loginForm = new DangNhap();
                    loginForm.Show(); // Hiện form DangNhap mới nếu chưa có
                }
                this.Close(); // Đóng form Home
            }
        }

       
    }
}
