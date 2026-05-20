namespace WinFormsApp
{
    public partial class UCQLLopHoc : UserControl
    {
        // ── Dữ liệu ────────────────────────────────────────────────────────
        private List<LopHoc> danhSachLop = new List<LopHoc>();
        private List<LopHoc> ketQuaTimKiem = new List<LopHoc>();
        private int currentPage = 1;
        private const int pageSize = 10;
        private int nextId = 1;   // auto-increment

        public UCQLLopHoc()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            TaoCotDataGridView();
            HienThiDanhSach();
        }

        // ── Khởi tạo dữ liệu mẫu ──────────────────────────────────────────
        private void KhoiTaoDuLieu()
        {
            danhSachLop.Add(new LopHoc { MaID = nextId++, MaLop = "68PM1", TenLop = "Lớp 68PM1", GhiChu = "abc" });
            danhSachLop.Add(new LopHoc { MaID = nextId++, MaLop = "68PM2", TenLop = "Lớp 68PM2", GhiChu = "xyz" });
            ketQuaTimKiem = new List<LopHoc>(danhSachLop);
        }

        // ── Tạo cột DataGridView ───────────────────────────────────────────
        private void TaoCotDataGridView()
        {
            dgvLopHoc.Columns.Clear();
            dgvLopHoc.Columns.Add("MaID", "Mã ID");
            dgvLopHoc.Columns.Add("MaLop", "Mã lớp");
            dgvLopHoc.Columns.Add("TenLop", "Tên lớp");
            dgvLopHoc.Columns.Add("GhiChu", "Ghi chú");

            // Căn chỉnh độ rộng cột
            dgvLopHoc.Columns["MaID"].Width = 70;
            dgvLopHoc.Columns["MaLop"].Width = 120;
            dgvLopHoc.Columns["TenLop"].Width = 250;
            dgvLopHoc.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // ── Hiển thị danh sách (có phân trang) ────────────────────────────
        private void HienThiDanhSach()
        {
            dgvLopHoc.Rows.Clear();

            int total = ketQuaTimKiem.Count;
            int totalPages = (int)Math.Ceiling((double)total / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            var trang = ketQuaTimKiem
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var lop in trang)
                dgvLopHoc.Rows.Add(lop.MaID, lop.MaLop, lop.TenLop, lop.GhiChu);

            lblTrang.Text = $"Trang {currentPage}/{totalPages}  |  {total} bản ghi";
        }

        // ── Validate form ──────────────────────────────────────────────────
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        // ── THÊM ───────────────────────────────────────────────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            // Kiểm tra trùng mã lớp
            if (danhSachLop.Any(l => l.MaLop.Equals(txtMaLop.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lop = new LopHoc
            {
                MaID = nextId++,
                MaLop = txtMaLop.Text.Trim(),
                TenLop = txtTenLop.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            danhSachLop.Add(lop);
            ketQuaTimKiem = new List<LopHoc>(danhSachLop);
            currentPage = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
            HienThiDanhSach();
            LamMoi();
            MessageBox.Show("Thêm lớp học thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── SỬA ────────────────────────────────────────────────────────────
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraDuLieu()) return;

            int maID = Convert.ToInt32(dgvLopHoc.SelectedRows[0].Cells["MaID"].Value);
            var lop = danhSachLop.FirstOrDefault(l => l.MaID == maID);
            if (lop == null) return;

            // Kiểm tra trùng mã lớp với bản ghi khác
            bool trung = danhSachLop.Any(l =>
                l.MaID != maID &&
                l.MaLop.Equals(txtMaLop.Text.Trim(), StringComparison.OrdinalIgnoreCase));
            if (trung)
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lop.MaLop = txtMaLop.Text.Trim();
            lop.TenLop = txtTenLop.Text.Trim();
            lop.GhiChu = txtGhiChu.Text.Trim();

            ketQuaTimKiem = new List<LopHoc>(danhSachLop);
            HienThiDanhSach();
            MessageBox.Show("Sửa lớp học thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── XÓA ────────────────────────────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maID = Convert.ToInt32(dgvLopHoc.SelectedRows[0].Cells["MaID"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                danhSachLop.RemoveAll(l => l.MaID == maID);
                ketQuaTimKiem = new List<LopHoc>(danhSachLop);
                HienThiDanhSach();
                LamMoi();
            }
        }

        // ── LÀM MỚI ────────────────────────────────────────────────────────
        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void LamMoi()
        {
            txtMaID.Text = string.Empty;
            txtMaLop.Text = string.Empty;
            txtTenLop.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dgvLopHoc.ClearSelection();
        }

        // ── TÌM KIẾM ───────────────────────────────────────────────────────
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            ketQuaTimKiem = danhSachLop.Where(l =>
                l.MaID.ToString().Contains(keyword) ||
                l.MaLop.ToLower().Contains(keyword) ||
                l.TenLop.ToLower().Contains(keyword)).ToList();
            currentPage = 1;
            HienThiDanhSach();
        }

        // ── Click vào hàng → đổ dữ liệu vào form ──────────────────────────
        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLopHoc.Rows[e.RowIndex];
            txtMaID.Text = row.Cells["MaID"].Value.ToString();
            txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
        }

        // ── Xem danh sách sinh viên của lớp đang chọn ─────────────────────
        private void btnXemSV_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maLop = dgvLopHoc.SelectedRows[0].Cells["MaLop"].Value.ToString();
            MessageBox.Show($"Xem danh sách sinh viên lớp: {maLop}\n(Tích hợp sau khi có UC quản lý SV)",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Khi tích hợp với FormMain, thay bằng:
            // var parent = this.ParentForm as FormMain;
            // parent?.HienThiUC(new UCQLSV(maLop));
        }

        // ── Phân trang ─────────────────────────────────────────────────────
        private void btnDau_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            HienThiDanhSach();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; HienThiDanhSach(); }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
            if (currentPage < totalPages) { currentPage++; HienThiDanhSach(); }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentPage = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
            if (currentPage < 1) currentPage = 1;
            HienThiDanhSach();
        }
    }
}