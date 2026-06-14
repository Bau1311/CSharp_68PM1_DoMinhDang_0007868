namespace WinFormsApp
{
    public partial class UCQLLopHoc : UserControl
    {
        // ── Dữ liệu ────────────────────────────────────────────────────────
        private readonly QLSinhVienDB db = new QLSinhVienDB();
        private List<LopHoc> ketQuaTimKiem = new List<LopHoc>();
        private int currentPage = 1;
        private const int pageSize = 10;

        public UCQLLopHoc()
        {
            InitializeComponent();
            TaoCotDataGridView();
            LoadDanhSachLop();
        }

        // ── Load danh sách lớp từ DB ────────────────────────────────────────
        private void LoadDanhSachLop()
        {
            try
            {
                ketQuaTimKiem = db.LayDanhSachLop();
                currentPage = 1;
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Tạo cột DataGridView ───────────────────────────────────────────
        private void TaoCotDataGridView()
        {
            dgvLopHoc.Columns.Clear();
            dgvLopHoc.Columns.Add("MaID", "Mã ID");
            dgvLopHoc.Columns.Add("MaLop", "Mã lớp");
            dgvLopHoc.Columns.Add("TenLop", "Tên lớp");
            dgvLopHoc.Columns.Add("GhiChu", "Ghi chú");

            dgvLopHoc.Columns["MaID"]!.Width = 70;
            dgvLopHoc.Columns["MaLop"]!.Width = 120;
            dgvLopHoc.Columns["TenLop"]!.Width = 250;
            dgvLopHoc.Columns["GhiChu"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        // ── THÊM → DB ─────────────────────────────────────────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            if (db.TonTaiMaLop(txtMaLop.Text.Trim()))
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lop = new LopHoc
            {
                MaLop  = txtMaLop.Text.Trim(),
                TenLop = txtTenLop.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            try
            {
                db.ThemLopHoc(lop);
                LoadDanhSachLop();
                int totalPages = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
                currentPage = totalPages;
                HienThiDanhSach();
                LamMoi();
                MessageBox.Show("Thêm lớp học thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm lớp:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── SỬA → DB ──────────────────────────────────────────────────────
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

            if (db.TonTaiMaLop(txtMaLop.Text.Trim(), maID))
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lop = new LopHoc
            {
                MaID   = maID,
                MaLop  = txtMaLop.Text.Trim(),
                TenLop = txtTenLop.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            try
            {
                db.SuaLopHoc(lop);
                LoadDanhSachLop();
                MessageBox.Show("Sửa lớp học thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa lớp:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA → DB ──────────────────────────────────────────────────────
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
                try
                {
                    db.XoaLopHoc(maID);
                    LoadDanhSachLop();
                    LamMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa lớp:\n{ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        // ── TÌM KIẾM → DB ──────────────────────────────────────────────────
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    ketQuaTimKiem = db.LayDanhSachLop();
                else
                    ketQuaTimKiem = db.TimLopHoc(keyword);
                currentPage = 1;
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Click vào hàng → đổ dữ liệu vào form ──────────────────────────
        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLopHoc.Rows[e.RowIndex];
            txtMaID.Text  = row.Cells["MaID"].Value?.ToString() ?? "";
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString() ?? "";
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString() ?? "";
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
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
            string maLop = dgvLopHoc.SelectedRows[0].Cells["MaLop"].Value?.ToString() ?? "";
            try
            {
                using var dbCtx = new QLSinhVienDB();
                var dsSV = dbCtx.SinhViens
                    .Where(sv => sv.Lop == maLop)
                    .OrderBy(sv => sv.HoTen)
                    .ToList();

                if (dsSV.Count == 0)
                {
                    MessageBox.Show($"Lớp {maLop} chưa có sinh viên nào.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string danhSach = string.Join("\n", dsSV.Select(
                    sv => $"  {sv.MaSV}  –  {sv.HoTen}  ({sv.GioiTinh})"));
                MessageBox.Show($"Danh sách sinh viên lớp {maLop} ({dsSV.Count} SV):\n\n{danhSach}",
                    "Danh sách sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách SV:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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