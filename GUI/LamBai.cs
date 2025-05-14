using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using BLL;
using DTO;

namespace GUI
{
    public partial class LamBai : UserControl
    {
        private DeThiBLL deThiBll = new DeThiBLL();
        private CauHoiBLL cauHoiBll = new CauHoiBLL();
        private DapAnBLL dapAnBll = new DapAnBLL();
        private Timer countdownTimer;
        private TimeSpan thoiGianConLai;
        private int thoiGianGoc;
        private List<CauHoiDTO> danhSachCauHoi = new List<CauHoiDTO>();
        private Dictionary<int, int> dapAnDaChon = new Dictionary<int, int>();
        private int chiSoCauHienTai = 0;
        private int userId;
        private DeThiDTO selectedDeThi;
        private List<Button> nutCauHoi = new List<Button>();
        private HashSet<int> cauHoiDuocDatCo = new HashSet<int>(); // Lưu ID câu hỏi đã được đặt cờ


        public LamBai(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            // Các event handler
            LoadDanhSachDeThi();
            XoaNoiDungHienThi();
            buttonTiep.Click += buttonTiep_Click;
            buttonLui.Click += buttonLui_Click;
            radioA.CheckedChanged += radioButton_CheckedChanged;
            radioB.CheckedChanged += radioButton_CheckedChanged;
            radioC.CheckedChanged += radioButton_CheckedChanged;
            radioD.CheckedChanged += radioButton_CheckedChanged;
            miniMapPanel.FlowDirection = FlowDirection.LeftToRight;
            miniMapPanel.WrapContents = true;
            miniMapPanel.Visible = false;
            btnDatCo.Visible = false;
            btnDatCo.Click -= btnDatCo_Click;
            btnDatCo.Click += btnDatCo_Click;


        }

        private bool isLoadingDeThi = false;

        private void LoadDanhSachDeThi()
        {
            isLoadingDeThi = true; // Bắt đầu gán dữ liệu

            List<DeThiDTO> danhSachDeThi = deThiBll.LayTatCaDe();

            if (danhSachDeThi == null || danhSachDeThi.Count == 0)
            {
                MessageBox.Show("Không có đề thi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbbDeThi.DisplayMember = "TenDeThi";
            cbbDeThi.ValueMember = "Id";
            cbbDeThi.DataSource = danhSachDeThi;

            cbbDeThi.SelectedIndex = -1;
            cbbDeThi.Text = "-- Chọn đề thi --";

            isLoadingDeThi = false; // Kết thúc gán dữ liệu
        }

        private void XoaNoiDungHienThi()
        {
            // Xóa nội dung câu hỏi
            txtCH.Text = "";

            // Đặt lại tiêu đề câu hỏi nếu có
            if (this.Controls.Find("lblCauHoi", true).Length > 0)
            {
                Label lblCauHoi = (Label)this.Controls.Find("lblCauHoi", true)[0];
                lblCauHoi.Text = "Câu hỏi";
            }

            // Xóa nội dung các TextBox đáp án và làm trống RadioButton
            TextBox[] txtDapAns = { txtA, txtB, txtC, txtD };
            RadioButton[] radios = { radioA, radioB, radioC, radioD };

            for (int i = 0; i < radios.Length; i++)
            {
                txtDapAns[i].Text = "";
                radios[i].Checked = false;
            }

            // Xóa danh sách câu hỏi và đáp án đã chọn
            danhSachCauHoi.Clear();
            dapAnDaChon.Clear();
            chiSoCauHienTai = 0;
        }

        private void LoadCauHoiTheoDe(int maDe)
        {
            danhSachCauHoi = cauHoiBll.LayCauHoiTheoDe(maDe);

            if (danhSachCauHoi == null || danhSachCauHoi.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi nào cho đề thi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCH.Clear();
                RadioButton[] radios = { radioA, radioB, radioC, radioD };
                foreach (var radio in radios)
                {
                    radio.Visible = false;
                }
                return;
            }

            chiSoCauHienTai = 0;
            dapAnDaChon.Clear();
            TaoMiniMap();
            HienThiCauHoi();
            CapNhatTrangThaiMiniMap();
        }

        private void HienThiCauHoi()
        {
            if (chiSoCauHienTai < 0 || chiSoCauHienTai >= danhSachCauHoi.Count)
                return;

            var cauHoi = danhSachCauHoi[chiSoCauHienTai];

            // Hiển thị nội dung câu hỏi vào TextBox
            txtCH.Text = cauHoi.Text;

            // Lấy danh sách đáp án cho câu hỏi hiện tại
            List<DapAnDTO> dapAnList = dapAnBll.GetAnswersByQuestionId(cauHoi.Id);

            if (dapAnList == null || dapAnList.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy đáp án cho câu hỏi ID: {cauHoi.Id}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mảng các RadioButton để chọn đáp án
            RadioButton[] radios = { radioA, radioB, radioC, radioD };

            // Mảng các TextBox để hiển thị nội dung đáp án
            TextBox[] txtDapAns = { txtA, txtB, txtC, txtD };

            for (int i = 0; i < radios.Length; i++)
            {
                if (i < dapAnList.Count)
                {
                    // Hiển thị RadioButton và TextBox tương ứng
                    radios[i].Visible = true;
                    txtDapAns[i].Visible = true;

                    // Gán nội dung đáp án vào TextBox
                    txtDapAns[i].Text = dapAnList[i].Text;

                    // Lưu ID của đáp án vào Tag của RadioButton để dùng khi chọn
                    radios[i].Tag = dapAnList[i].Id;

                    // Kiểm tra xem đáp án này đã được chọn trước đó chưa
                    int dapAnDuocChon = 0;
                    dapAnDaChon.TryGetValue(cauHoi.Id, out dapAnDuocChon);
                    radios[i].Checked = dapAnDuocChon == dapAnList[i].Id;
                }
                else
                {
                    radios[i].Visible = false;
                    txtDapAns[i].Visible = false;
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radio && radio.Checked)
            {
                int maDapAn = Convert.ToInt32(radio.Tag);
                int maCauHoi = danhSachCauHoi[chiSoCauHienTai].Id;
                dapAnDaChon[maCauHoi] = maDapAn;

                // Thêm dòng debug để kiểm tra
                Console.WriteLine($"Lưu đáp án: Câu hỏi ID {maCauHoi}, Đáp án ID {maDapAn}");
            }
        }

        private void buttonLui_Click(object sender, EventArgs e)
        {
            if (chiSoCauHienTai > 0)
            {
                chiSoCauHienTai--;
                HienThiCauHoi();
                CapNhatTrangThaiMiniMap();
            }
        }

        private double TinhDiem()
        {
            int soDung = 0;

            foreach (var cauHoi in danhSachCauHoi)
            {
                int maDapAnChon = 0;
                dapAnDaChon.TryGetValue(cauHoi.Id, out maDapAnChon);

                if (maDapAnChon == cauHoi.CorrectAnswerId)
                {
                    soDung++;
                }
            }

            return Math.Round((soDung * 10.0) / danhSachCauHoi.Count, 2); // Tính điểm: số câu đúng * 10 / tổng số câu
        }

        private void cbbDeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingDeThi || cbbDeThi.SelectedIndex == -1)
                return;

            if (cbbDeThi.SelectedItem is DeThiDTO selected)
            {
                if (selected.ThoiGianLamBai < 0)
                {
                    MessageBox.Show("Thời gian làm bài không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem đề thi có câu hỏi hay không
                List<CauHoiDTO> cauHois = cauHoiBll.LayCauHoiTheoDe(selected.Id);
                if (cauHois == null || cauHois.Count == 0)
                {
                    MessageBox.Show("Đề thi này không có câu hỏi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBatDau.Enabled = false; // Không cho phép bắt đầu
                    return;
                }

                selectedDeThi = selected; // Lưu lại đề thi đã chọn
                btnBatDau.Enabled = true; // Cho phép nhấn nút bắt đầu
            }

        }
        private void BatDauDemNguoc()
        {
            if (countdownTimer != null)
            {
                countdownTimer.Stop();
                countdownTimer.Dispose();
            }
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            countdownTimer.Start();
            CapNhatDongHo();
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            thoiGianConLai = thoiGianConLai.Subtract(TimeSpan.FromSeconds(1));
            CapNhatDongHo();

            if (thoiGianConLai.TotalSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Hết giờ! Bài làm sẽ được nộp tự động.", "Hết giờ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NopBai(true);
            }
        }
        private void CapNhatDongHo()
        {
            lbDH.Text = $"⏰ {thoiGianConLai:mm\\:ss}";
        }
        private void NopBai(bool tuDong = false)
        {
            if (!tuDong && dapAnDaChon.Count < danhSachCauHoi.Count)
            {
                DialogResult xacNhan = MessageBox.Show(
                    "Bạn chưa làm hết các câu hỏi. Bạn có chắc muốn nộp bài không?",
                    "Xác nhận nộp bài",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (xacNhan != DialogResult.Yes)
                    return;
            }

            try
            {
                double diem = TinhDiem();
                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm tính được không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StudentBLL studentBLL = new StudentBLL();
                int studentId = studentBLL.LayStudentIdTheoUserId(userId);

                if (studentId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                KetQuaDTO ketQua = new KetQuaDTO
                {
                    StudentId = studentId,
                    Score = (decimal)diem,
                    QuizId = (cbbDeThi.SelectedItem as DeThiDTO)?.Id ?? 0,
                    DateTaken = DateTime.Now
                };

                KetQuaBLL ketQuaBLL = new KetQuaBLL();
                bool thanhCong = ketQuaBLL.LuuKetQua(ketQua);

                if (thanhCong)
                {
                    MessageBox.Show($"Bạn đã làm xong! Điểm của bạn là: {diem:F2}/10\nKết quả đã được lưu.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hiện lại các nút menu sau khi nộp bài
                    Home homeForm = this.FindForm() as Home;
                    if (homeForm != null)
                    {
                        homeForm.HienMenuSinhVien(); // Bao gồm cả nút Đăng Xuất
                    }

                    // Load lại kết quả nếu cần
                    foreach (Control control in this.Parent.Controls)
                    {
                        if (control is KetQua ketQuaUC)
                        {
                            ketQuaUC.LoadKetQua();
                            break;
                        }
                    }

                    // Dừng đồng hồ đếm ngược
                    countdownTimer?.Stop();
                    countdownTimer?.Dispose();
                    ResetBaiLam();

                    // Xóa dữ liệu và reset UI
                    XoaNoiDungHienThi();
                    cbbDeThi.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu kết quả. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaoMiniMap()
        {
            miniMapPanel.Controls.Clear();
            nutCauHoi.Clear();

            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                var btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Width = 40;
                btn.Height = 40;
                btn.Margin = new Padding(5);
                btn.Tag = i; // lưu vị trí câu hỏi
                btn.BackColor = Color.Gray; // mặc định chưa trả lời

                btn.Click += MiniMapButton_Click;

                miniMapPanel.Controls.Add(btn);
                nutCauHoi.Add(btn);
            }
        }
        private void CapNhatTrangThaiMiniMap()
        {
            for (int i = 0; i < danhSachCauHoi.Count; i++)
            {
                int maCauHoi = danhSachCauHoi[i].Id;
                var nut = nutCauHoi[i];

                if (cauHoiDuocDatCo.Contains(maCauHoi))
                {
                    nut.BackColor = Color.Red; // Màu đỏ nếu được đặt cờ
                }
                else if (dapAnDaChon.ContainsKey(maCauHoi))
                {
                    nut.BackColor = Color.LightGreen; // Màu xanh nếu đã trả lời
                }
                else
                {
                    nut.BackColor = Color.Gray; // Màu xám nếu chưa trả lời
                }
            }

            // Tô màu cho câu hỏi hiện tại (chỉ nếu không được đặt cờ)
            if (chiSoCauHienTai >= 0 && chiSoCauHienTai < nutCauHoi.Count)
            {
                int maCauHoi = danhSachCauHoi[chiSoCauHienTai].Id;

                // Nếu câu hiện tại không được đặt cờ thì tô màu xanh dương
                if (!cauHoiDuocDatCo.Contains(maCauHoi))
                {
                    nutCauHoi[chiSoCauHienTai].BackColor = Color.LightBlue;
                }
                // Nếu có đặt cờ thì giữ màu đỏ
            }
        }
        private void MiniMapButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                int index = (int)btn.Tag;
                if (index >= 0 && index < danhSachCauHoi.Count)
                {
                    chiSoCauHienTai = index;
                    HienThiCauHoi();
                    CapNhatTrangThaiMiniMap();
                }
            }
        }
        private void lbDH_Click(object sender, EventArgs e)
        {

        }

        private void btNopBai_Click_1(object sender, EventArgs e)
        {
            NopBai(false);
        }

        private void buttonTiep_Click(object sender, EventArgs e)
        {
            if (chiSoCauHienTai < danhSachCauHoi.Count - 1)
            {
                chiSoCauHienTai++;
                HienThiCauHoi();
                CapNhatTrangThaiMiniMap();
            }
        }
        private void ResetBaiLam()
        {
            // Cho phép chọn lại đề thi và bắt đầu lại
            cbbDeThi.Enabled = true;
            cbbDeThi.SelectedIndex = -1;
            cbbDeThi.Text = "-- Chọn đề thi --";
            btnBatDau.Enabled = false;

            // Reset đồng hồ
            thoiGianConLai = TimeSpan.Zero;
            lbDH.Text = "Thời gian";

            // Dọn dữ liệu và UI
            XoaNoiDungHienThi();

            // Nếu có các panel bị ẩn thì hiện lại
            txtCH.Visible = true;
            txtA.Visible = txtB.Visible = txtC.Visible = txtD.Visible = true;
            radioA.Visible = radioB.Visible = radioC.Visible = radioD.Visible = true;
            buttonTiep.Enabled = buttonLui.Enabled = true;

            // Hiện lại menu nếu cần làm lại từ đầu
            Home homeForm = this.
                
                FindForm() as Home;
            if (homeForm != null)
            {
                homeForm.HienMenuSinhVien(); 
            }
            miniMapPanel.Visible = false;
            btnDatCo.Visible = false;


        }


        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (selectedDeThi == null)
            {
                MessageBox.Show("Vui lòng chọn đề thi trước khi bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnBatDau.Enabled = false;
            cbbDeThi.Enabled = false;
            Home homeForm = this.FindForm() as Home;
            if (homeForm != null)
            {
                homeForm.AnMenuSinhVien();
            }

            thoiGianGoc = selectedDeThi.ThoiGianLamBai;

            if (thoiGianGoc == 0)
            {
                // Nếu thời gian làm bài là 0, ẩn đồng hồ và không bắt đầu đếm ngược
                DongHo.Visible = false;
                thoiGianConLai = TimeSpan.Zero; // Không có thời gian giới hạn
                                                // Không khởi động đồng hồ đếm ngược nếu thời gian làm bài là 0
                if (countdownTimer != null)
                {
                    countdownTimer.Stop();
                    countdownTimer.Dispose();
                }
            }
            else
            {
                // Nếu có thời gian, bắt đầu đồng hồ
                thoiGianConLai = TimeSpan.FromMinutes(thoiGianGoc);
                DongHo.Visible = true;  // Hiển thị đồng hồ
                                      // Khởi động đồng hồ đếm ngược
                BatDauDemNguoc();
            }

            CapNhatDongHo();
            LoadCauHoiTheoDe(selectedDeThi.Id);
            miniMapPanel.Visible = true;
            btnDatCo.Visible = true;
        }

        private void LamBai_Load(object sender, EventArgs e)
        {

        }

        private void answerLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnDatCo_Click(object sender, EventArgs e)
        {
            int maCauHoi = danhSachCauHoi[chiSoCauHienTai].Id;

            if (cauHoiDuocDatCo.Contains(maCauHoi))
            {
                cauHoiDuocDatCo.Remove(maCauHoi); // Bỏ cờ
            }
            else
            {
                cauHoiDuocDatCo.Add(maCauHoi); // Đặt cờ
            }

            CapNhatTrangThaiMiniMap(); // Cập nhật màu trên mini-map
        }
    }
}
