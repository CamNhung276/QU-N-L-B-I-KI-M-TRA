using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class CuaSo : UserControl
    {
        private UserBLL userBLL = new UserBLL();
        private MonHocBLL monHocBLL = new MonHocBLL();
        private KetQuaBLL ketQuaBLL = new KetQuaBLL();
        private UserDTO currentUser;

        private int userId;
        
        private string userRole;
        public CuaSo(string role, UserDTO currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userRole = role;
            this.userId = currentUser.Id;
            string roleIcon = "👤";
            if (role == "Admin") roleIcon = "👑";
            else if (role == "Teacher") roleIcon = "📚";
            else if (role == "Student") roleIcon = "🎓";
            lblWelcome.Text = $"{roleIcon} Chào mừng, {role}!";
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            LoadUserCount();
            LoadMonHocCount();
            LoadKetQuaCount();
            HienThiTiLeDuoi5();
            HienThiTiLeDiem10();
            LoadThongBaoChuaDoc();
        }

        private void LoadUserCount()
        {
            int userCount = userBLL.GetUserCount();
            lblUserCount.Text = userCount + " người";
        }

        private void LoadMonHocCount()
        {
            int monHocCount = monHocBLL.GetCategoryCount();
            lblMonHocCount.Text = monHocCount + " môn học";
        }
        private void LoadKetQuaCount()
        {
            int count = ketQuaBLL.DemSoKetQua();
            lblKetQuaCount.Text = count + " kết quả";
        }

        private void LoadThongBaoChuaDoc()
        {
            Label lbSL = Controls.Find("lbSL", true).FirstOrDefault() as Label;
            if (userRole != "Student")
            {
                if (lbSL != null)
                {
                    lbSL.Visible = false;
                }
                return;
            }

            ThongBaoBLL thongBaoBLL = new ThongBaoBLL();
            int soThongBaoChuaDoc = thongBaoBLL.DemThongBaoChuaDoc(userId);
            if (lbSL != null)
            {
                lbSL.Text = soThongBaoChuaDoc > 0 ? soThongBaoChuaDoc.ToString() : "";
                lbSL.Visible = soThongBaoChuaDoc > 0;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void HienThiTiLeDuoi5()
        {
            KetQuaBLL bll = new KetQuaBLL();
            List<decimal> diemList = bll.LayTatCaDiem();

            if (diemList.Count == 0)
            {
                guna2CircleProgressBar1.Value = 0;
                guna2CircleProgressBar1.Text = "0%";
                return;
            }

            int soDuoi5 = diemList.Count(d => d < 5);
            int tong = diemList.Count;
            int tile = (int)Math.Round((double)soDuoi5 * 100 / tong);
            guna2CircleProgressBar1.Value = tile;
            guna2CircleProgressBar1.Text = tile + "%";

        }
        private void HienThiTiLeDiem10()
        {
            KetQuaBLL bll = new KetQuaBLL();
            List<decimal> diemList = bll.LayTatCaDiem();

            if (diemList.Count == 0)
            {
                guna2CircleProgressBar2.Value = 0;
                guna2CircleProgressBar2.Text = "0%";
                return;
            }

            int soDiem10 = diemList.Count(d => d == 10);
            int tong = diemList.Count;
            int tile = (int)Math.Round((double)soDiem10 * 100 / tong);
            guna2CircleProgressBar2.Value = tile;
            guna2CircleProgressBar2.Text = tile + "%";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CuaSo_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void awinTB_Click(object sender, EventArgs e)
        {            
            Control parent = this.Parent; 
            parent.Controls.Clear();
            ThongBao thongBaoControl = new ThongBao(userRole, userId, this);
            thongBaoControl.Dock = DockStyle.Fill;
            parent.Controls.Add(thongBaoControl);
            parent.Refresh();
        }

        private void lbSL_Click(object sender, EventArgs e)
        {

        }
    }
}