using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DTO;
using BLL;

namespace GUI
{
    public partial class ThongBao : UserControl
    {
        private ThongBaoBLL thongBaoBLL;
        private DocThongBaoBLL docThongBaoBLL;
        private string userRole;
        private int userId;
        private CuaSo cuaSoCha;
      



        public ThongBao(string role, int id, CuaSo cuaSoCha)
        {
            InitializeComponent();
            thongBaoBLL = new ThongBaoBLL();
            if (role == "Student")
            {
                docThongBaoBLL = new DocThongBaoBLL(id);
            }
            userRole = role;
            userId = id;
            this.cuaSoCha = cuaSoCha;
            this.Load += ThongBao_Load;
            this.dgvThongBao.CellContentClick += dgvThongBao_CellContentClick;
            pnlTaoThongBao.Visible = CoQuyenQuanLyThongBao();
        }

        private bool CoQuyenQuanLyThongBao()
        {
            return userRole == "Admin" || userRole == "Teacher";
        }

        private void ThongBao_Load(object sender, EventArgs e)
        {
            dgvThongBao.Columns.Clear();
            dgvThongBao.AutoGenerateColumns = false;
            dgvThongBao.AllowUserToAddRows = false;
            dgvThongBao.RowHeadersVisible = false;
            dgvThongBao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvThongBao.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Cập nhật màu sắc cho DataGridView
            dgvThongBao.Font = new Font("Segoe UI", 10);
            dgvThongBao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvThongBao.DefaultCellStyle.ForeColor = Color.Black;
            dgvThongBao.DefaultCellStyle.BackColor = Color.White;
            dgvThongBao.EnableHeadersVisualStyles = false;
            dgvThongBao.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue; 
            dgvThongBao.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvThongBao.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvThongBao.RowTemplate.Height = 30;


            // Cột Đã đọc (chỉ hiển thị cho học sinh)
            if (userRole == "Student")
            {
                dgvThongBao.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    Name = "DaDoc",
                    HeaderText = "Đã đọc",
                    Width = 40,
                    ReadOnly = false
                });
            }

            // Cột Tiêu đề
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TieuDe",
                HeaderText = "Tiêu đề",
                DataPropertyName = "TieuDe",
                Width = 200
            });

            // Cột Nội dung
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NoiDung",
                HeaderText = "Nội dung",
                DataPropertyName = "NoiDung",
                Width = 600
            });

            // Cột Ngày tạo
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayTao",
                HeaderText = "Ngày tạo",
                DataPropertyName = "NgayTao",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột Ngày hết hạn
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayHetHan",
                HeaderText = "Hết hạn",
                DataPropertyName = "NgayHetHan",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột Người tạo
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NguoiTao",
                HeaderText = "Người tạo",
                DataPropertyName = "NguoiTao",
                Width = 170,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột nút Xóa nếu là Admin hoặc Teacher
            if (CoQuyenQuanLyThongBao())
            {
                dgvThongBao.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "btnXoa",
                    HeaderText = "Xóa",
                    Text = "🗑",
                    UseColumnTextForButtonValue = true,
                    Width = 70
                });
            }
            foreach (DataGridViewColumn column in dgvThongBao.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            LoadThongBao();
        }

        private void LoadThongBao()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ThongBaoDTO> danhSachThongBao = thongBaoBLL.LayThongBao(userId, userRole);

                if (danhSachThongBao == null || danhSachThongBao.Count == 0)
                {
                    dgvThongBao.Rows.Clear();
                    lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO (Không có thông báo)";
                    CapNhatChiBaoThongBao(0);
                    return;
                }

                dgvThongBao.SuspendLayout();
                dgvThongBao.Rows.Clear();

                foreach (var tb in danhSachThongBao)
                {
                    int rowIndex = dgvThongBao.Rows.Add();
                    DataGridViewRow row = dgvThongBao.Rows[rowIndex];

                    if (userRole == "Student")
                    {
                        row.Cells["DaDoc"].Value = docThongBaoBLL.KiemTraDaDoc(tb.Id);
                    }

                    row.Cells["TieuDe"].Value = tb.Title;
                    row.Cells["NoiDung"].Value = tb.Content;
                    row.Cells["NgayTao"].Value = tb.CreatedDate;
                    row.Cells["NgayHetHan"].Value = tb.ExpireDate;
                    row.Cells["NguoiTao"].Value = tb.CreatorName;
                    row.Tag = tb.Id;

                    if (!tb.IsRead)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    }
                }

                dgvThongBao.ResumeLayout();
                dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThongBao.Refresh();

                // Cập nhật số lượng thông báo chưa đọc
                int soThongBaoChuaDoc = userRole == "Student" ? 
                    docThongBaoBLL.DemThongBaoChuaDoc() : 
                    thongBaoBLL.DemThongBaoChuaDoc(userId);
                
                CapNhatChiBaoThongBao(soThongBaoChuaDoc);

                // Cập nhật tiêu đề danh sách
                if (userRole == "Student")
                {
                    if (soThongBaoChuaDoc > 0)
                    {
                        lblDanhSachThongBao.Text = $"DANH SÁCH THÔNG BÁO ({soThongBaoChuaDoc} chưa đọc)";
                    }
                    else
                    {
                        lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
                    }
                }
                else
                {
                    lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CapNhatChiBaoThongBao(int soLuong)
        {
            if (cuaSoCha != null)
            {
                Label lbSL = cuaSoCha.Controls.Find("lbSL", true).FirstOrDefault() as Label;
                if (lbSL != null)
                {
                    lbSL.Text = soLuong > 0 ? soLuong.ToString() : "";
                    lbSL.Visible = soLuong > 0;
                }
            }
        }
        private void AutoResizeDataGridViewHeight()
        {
            int totalHeight = dgvThongBao.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dgvThongBao.Rows)
                totalHeight += row.Height;

            dgvThongBao.Height = Math.Min(totalHeight + 2, 295);
        }

        private void btnTaoThongBao_Click(object sender, EventArgs e)
        {
            // Only Admin and Teacher can create notifications
            if (!CoQuyenQuanLyThongBao())
            {
                MessageBox.Show("Bạn không có quyền tạo thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            // Validate input data
            if (string.IsNullOrEmpty(tieuDe))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung thông báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }

            // Determine expiry date
            DateTime? ngayHetHan = null;
            if (!chkKhongHetHan.Checked)
            {
                ngayHetHan = dtpNgayHetHan.Value;

                // Check that expiry date is in the future
                if (ngayHetHan <= DateTime.Now)
                {
                    MessageBox.Show("Ngày hết hạn phải sau ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpNgayHetHan.Focus();
                    return;
                }
            }

            try
            {
                // Save the new notification
                bool result = thongBaoBLL.TaoThongBao(tieuDe, noiDung, ngayHetHan, userId, userRole);

                if (result)
                {
                    MessageBox.Show("Tạo thông báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form fields
                    ResetForm();

                    // Update the notification list
                    LoadThongBao();
                }
                else
                {
                    MessageBox.Show("Không thể tạo thông báo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtTieuDe.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(30);
            chkKhongHetHan.Checked = false;
        }

        private void chkKhongHetHan_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgayHetHan.Enabled = !chkKhongHetHan.Checked;
        }

        private void dgvThongBao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];
            if (row.Tag == null)
            {
                MessageBox.Show("Không tìm thấy ID của thông báo này!");
                return;
            }

            int id = Convert.ToInt32(row.Tag);

            // Nếu là nút Xóa
            if (CoQuyenQuanLyThongBao() && e.ColumnIndex == dgvThongBao.Columns["btnXoa"].Index)
            {
                var result = MessageBox.Show("Xác nhận xóa thông báo?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (thongBaoBLL.XoaThongBao(id, userRole))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThongBao();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (userRole == "Student" && e.ColumnIndex == dgvThongBao.Columns["DaDoc"].Index)
            {
                bool currentValue = Convert.ToBoolean(row.Cells["DaDoc"].Value);
                row.Cells["DaDoc"].Value = !currentValue;
                dgvThongBao.CommitEdit(DataGridViewDataErrorContexts.Commit);
                
                // Cập nhật trạng thái đọc ngay lập tức
                docThongBaoBLL.CapNhatTrangThaiDoc(id, !currentValue);
                
                // Cập nhật lại số lượng thông báo chưa đọc
                int soThongBaoChuaDoc = docThongBaoBLL.DemThongBaoChuaDoc();
                CapNhatChiBaoThongBao(soThongBaoChuaDoc);
                
                // Cập nhật giao diện
                if (!currentValue)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                }
                
                // Cập nhật tiêu đề danh sách
                if (soThongBaoChuaDoc > 0)
                {
                    lblDanhSachThongBao.Text = $"DANH SÁCH THÔNG BÁO ({soThongBaoChuaDoc} chưa đọc)";
                }
                else
                {
                    lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
                }
            }
            else
            {
                // Khi click vào nội dung thông báo
                string td = row.Cells["TieuDe"].Value?.ToString() ?? "";
                string nd = row.Cells["NoiDung"].Value?.ToString() ?? "";
                DateTime nt = row.Cells["NgayTao"].Value != null ? Convert.ToDateTime(row.Cells["NgayTao"].Value) : DateTime.Now;

                // Hiển thị chi tiết thông báo
                MessageBox.Show($"Tiêu đề: {td}\n\nNội dung: {nd}\n\nNgày tạo: {nt.ToString("dd/MM/yyyy HH:mm")}",
                    "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvThongBao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];
            if (row.Tag == null) return;

            int notificationId = Convert.ToInt32(row.Tag);

            // Nếu là cột checkbox "Đã đọc"
            if (userRole == "Student" && dgvThongBao.Columns[e.ColumnIndex].Name == "DaDoc")
            {
                bool isChecked = Convert.ToBoolean(row.Cells["DaDoc"].Value);
                docThongBaoBLL.CapNhatTrangThaiDoc(notificationId, isChecked);

                // Cập nhật lại số lượng thông báo chưa đọc
                int soThongBaoChuaDoc = docThongBaoBLL.DemThongBaoChuaDoc();
                CapNhatChiBaoThongBao(soThongBaoChuaDoc);

                // Cập nhật giao diện
                if (isChecked)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }

                // Cập nhật tiêu đề danh sách
                if (userRole == "Student")
                {
                    if (soThongBaoChuaDoc > 0)
                    {
                        lblDanhSachThongBao.Text = $"DANH SÁCH THÔNG BÁO ({soThongBaoChuaDoc} chưa đọc)";
                    }
                    else
                    {
                        lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
                    }
                }
                else
                {
                    lblDanhSachThongBao.Text = "DANH SÁCH THÔNG BÁO";
                }

                // Cập nhật lại tất cả các dòng để đảm bảo hiển thị đúng
                foreach (DataGridViewRow r in dgvThongBao.Rows)
                {
                    if (r.Tag != null)
                    {
                        int id = Convert.ToInt32(r.Tag);
                        bool daDoc = docThongBaoBLL.KiemTraDaDoc(id);
                        r.Cells["DaDoc"].Value = daDoc;
                        if (daDoc)
                        {
                            r.DefaultCellStyle.BackColor = Color.White;
                            r.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                        }
                        else
                        {
                            r.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                            r.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        }
                    }
                }

                // Cập nhật lại số lượng thông báo chưa đọc một lần nữa để đảm bảo chính xác
                soThongBaoChuaDoc = docThongBaoBLL.DemThongBaoChuaDoc();
                CapNhatChiBaoThongBao(soThongBaoChuaDoc);
            }
        }

        private void dgvThongBao_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvThongBao.IsCurrentCellDirty)
            {
                dgvThongBao.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}