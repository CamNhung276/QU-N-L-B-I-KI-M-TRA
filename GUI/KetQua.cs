using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using BLL;
using DTO;

namespace GUI
{
    public partial class KetQua : UserControl
    {
        private KetQuaBLL ketQuaBLL = new KetQuaBLL();
        private string userRole;
        private int userId;
        private bool isInitialLoad = true; // Biến kiểm tra lần load đầu tiên

        public KetQua(string role, int id)
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
            userRole = role;
            userId = id;
            InitGrid();
            LoadKetQua();
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            // Định dạng cho DataGridView - tách ra từ constructor
            dgvKetQua.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvKetQua.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvKetQua.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dgvKetQua.EnableHeadersVisualStyles = false;
            dgvKetQua.DefaultCellStyle.ForeColor = Color.Black;
            dgvKetQua.DefaultCellStyle.BackColor = Color.White;
            dgvKetQua.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvKetQua.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvKetQua.RowTemplate.Height = 30;
            dgvKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKetQua.ScrollBars = ScrollBars.Vertical;
            txtSearch.Multiline = false;
        }

        private void InitGrid()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.Columns.Clear();
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.AllowUserToAddRows = false;

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên học sinh",
                DataPropertyName = "StudentName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Width = 200
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Bài kiểm tra",
                DataPropertyName = "QuizTitle",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Width = 200
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm",
                DataPropertyName = "Score",
                Width = 100
            });

            dgvKetQua.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày làm bài",
                DataPropertyName = "DateTaken",
                Width = 150
            });
        }

        public void LoadKetQua()
        {
            List<KetQuaDTO> danhSach;
            danhSach = ketQuaBLL.LayTatCaKetQua();
            dgvKetQua.DataSource = danhSach;

            // Chỉ thực hiện ResizeDataGridViewHeight khi load lần đầu
            if (isInitialLoad)
            {
                ResizeDataGridViewHeight();
                isInitialLoad = false;
            }
        }

        private void ResizeDataGridViewHeight()
        {
            if (dgvKetQua.Rows.Count == 0) return;

            int rowHeight = dgvKetQua.RowTemplate.Height;
            int rowCount = dgvKetQua.Rows.Count;
            int headerHeight = dgvKetQua.ColumnHeadersHeight;
            int totalHeight = headerHeight + (rowHeight * rowCount);

            // Thêm padding nhỏ để tránh bị cắt
            totalHeight += 5;

            // Giới hạn chiều cao tối đa là 400 pixels
            if (totalHeight > 450) totalHeight = 450;

            // Đảm bảo chiều cao tối thiểu là 100 pixels
            if (totalHeight < 100) totalHeight = 100;

            dgvKetQua.Height = totalHeight;

            // Điều chỉnh vị trí của DataGridView - chỉ thực hiện lần đầu tiên
            dgvKetQua.Top = titleLabel.Bottom + 40;

            // Cập nhật lại vị trí của các control khác nếu cần
            this.Refresh();
        }

        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            List<KetQuaDTO> danhSach = ketQuaBLL.LayTatCaKetQua();

            if (danhSach == null || danhSach.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = "KetQuaBaiKiemTra.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");
                        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontContent = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                        doc.Add(new Paragraph("KẾT QUẢ BÀI KIỂM TRA", fontTitle));
                        doc.Add(new Paragraph("Ngày in: " + DateTime.Now.ToShortDateString(), fontContent));
                        doc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(4) { WidthPercentage = 100 };
                        string[] headers = { "Tên học sinh", "Bài kiểm tra", "Điểm", "Ngày làm bài" };

                        foreach (var header in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, fontContent))
                            {
                                BackgroundColor = BaseColor.LIGHT_GRAY
                            };
                            table.AddCell(cell);
                        }

                        foreach (var item in danhSach)
                        {
                            table.AddCell(new Phrase(item.StudentName, fontContent));
                            table.AddCell(new Phrase(item.QuizTitle, fontContent));
                            table.AddCell(new Phrase(item.Score.ToString("0.00"), fontContent));
                            table.AddCell(new Phrase(item.DateTaken.ToShortDateString(), fontContent));
                        }

                        doc.Add(table);
                        doc.Close();
                    }

                    MessageBox.Show("Xuất file PDF thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xuất file PDF: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            // Lấy dữ liệu gốc
            var danhSachGoc = ketQuaBLL.LayTatCaKetQua();

            // Lọc theo từ khóa
            var danhSachLoc = danhSachGoc.FindAll(kq =>
                kq.StudentName.ToLower().Contains(keyword) ||
                kq.QuizTitle.ToLower().Contains(keyword) ||
                kq.Score.ToString().Contains(keyword) ||
                kq.DateTaken.ToString("dd/MM/yyyy").Contains(keyword)
            );

            // Cập nhật lại DataGridView mà không điều chỉnh vị trí
            dgvKetQua.DataSource = danhSachLoc;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                
                List<KetQuaDTO> danhSach = ketQuaBLL.LayTatCaKetQua();
                dgvKetQua.DataSource = danhSach;
            }
        }
    }
}