namespace WinFormsApp
{
    public partial class UCQLSV : UserControl
    {
        private readonly QLSinhVienDB db = new QLSinhVienDB();
        private List<SinhVien> ketQuaTimKiem = new List<SinhVien>();
        private int currentPage = 1;
        private int pageSize = 10;

        public UCQLSV()
        {
            InitializeComponent();
            TaoCoTDanhSachSV();
            LoadDanhSachLopVaoCBX();   // ← display ClassList cho ComboBox
            LoadDanhSachSinhVien();     // ← display StudentList
        }

        // ── Load danh sách lớp từ DB → ComboBox ──────────────────────────
        private void LoadDanhSachLopVaoCBX()
        {
            try
            {
                var dsLop = db.LayDanhSachLop();
                cboLop.Items.Clear();
                foreach (var lop in dsLop)
                    cboLop.Items.Add($"{lop.MaLop} – {lop.TenLop}");
                if (cboLop.Items.Count > 0)
                    cboLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL khi load lớp:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load danh sách sinh viên từ DB ────────────────────────────────
        private void LoadDanhSachSinhVien()
        {
            try
            {
                ketQuaTimKiem = db.LayDanhSachSinhVien();
                currentPage = 1;
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối CSDL khi load sinh viên:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoCoTDanhSachSV()
        {
            dgvSinhVien.Columns.Clear();
            dgvSinhVien.Columns.Add("MaSV",     "Mã SV");
            dgvSinhVien.Columns.Add("HoTen",    "Họ và Tên");
            dgvSinhVien.Columns.Add("GioiTinh", "Giới Tính");
            dgvSinhVien.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvSinhVien.Columns.Add("Lop",      "Lớp");
        }

        private void HienThiDanhSach()
        {
            dgvSinhVien.Rows.Clear();
            int total      = ketQuaTimKiem.Count;
            int totalPages = (int)Math.Ceiling((double)total / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            var trang = ketQuaTimKiem.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            foreach (var sv in trang)
                dgvSinhVien.Rows.Add(sv.MaSV, sv.HoTen, sv.GioiTinh,
                    sv.NgaySinh.ToString("dd/MM/yyyy"), sv.Lop);

            lblTrang.Text = $"Trang {currentPage}/{totalPages}  |  {total} bản ghi";
        }

        // ── THÊM sinh viên → DB ──────────────────────────────────────────
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sv = new SinhVien
            {
                MaSV     = txtMaSV.Text.Trim(),
                HoTen    = txtHoTen.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                NgaySinh = dtpNgaySinh.Value,
                Lop      = cboLop.SelectedItem?.ToString()?.Split('–')[0].Trim() ?? ""
            };

            try
            {
                db.ThemSinhVien(sv);
                LoadDanhSachSinhVien();
                LamMoi();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── SỬA sinh viên → DB ───────────────────────────────────────────
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = dgvSinhVien.SelectedRows[0].Cells["MaSV"].Value?.ToString() ?? "";
            var sv = new SinhVien
            {
                MaSV     = maSV,
                HoTen    = txtHoTen.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                NgaySinh = dtpNgaySinh.Value,
                Lop      = cboLop.SelectedItem?.ToString()?.Split('–')[0].Trim() ?? ""
            };

            try
            {
                db.SuaSinhVien(sv);
                LoadDanhSachSinhVien();
                MessageBox.Show("Sửa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sinh viên:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA sinh viên → DB ───────────────────────────────────────────
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = dgvSinhVien.SelectedRows[0].Cells["MaSV"].Value?.ToString() ?? "";
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.XoaSinhVien(maSV);
                    LoadDanhSachSinhVien();
                    LamMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sinh viên:\n{ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── LÀM MỚI ─────────────────────────────────────────────────────
        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void LamMoi()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 0;
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;
        }

        // ── TÌM KIẾM → DB ───────────────────────────────────────────────
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    ketQuaTimKiem = db.LayDanhSachSinhVien();
                else
                    ketQuaTimKiem = db.TimSinhVien(keyword);
                currentPage = 1;
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Click vào hàng → đổ dữ liệu vào form ───────────────────────
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSinhVien.Rows[e.RowIndex];
            txtMaSV.Text             = row.Cells["MaSV"].Value?.ToString() ?? "";
            txtHoTen.Text            = row.Cells["HoTen"].Value?.ToString() ?? "";
            cboGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value?.ToString();
            dtpNgaySinh.Value        = DateTime.ParseExact(
                row.Cells["NgaySinh"].Value?.ToString() ?? DateTime.Now.ToString("dd/MM/yyyy"),
                "dd/MM/yyyy", null);

            // Tìm lớp tương ứng trong cboLop
            string maLop = row.Cells["Lop"].Value?.ToString() ?? "";
            for (int i = 0; i < cboLop.Items.Count; i++)
            {
                if ((cboLop.Items[i]?.ToString() ?? "").StartsWith(maLop))
                {
                    cboLop.SelectedIndex = i;
                    break;
                }
            }
        }

        // ── Phân trang ───────────────────────────────────────────────────
        private void btnDau_Click(object sender, EventArgs e)  { currentPage = 1; HienThiDanhSach(); }
        private void btnTruoc_Click(object sender, EventArgs e) { if (currentPage > 1) { currentPage--; HienThiDanhSach(); } }
        private void btnSau_Click(object sender, EventArgs e)
        {
            int total = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
            if (currentPage < total) { currentPage++; HienThiDanhSach(); }
        }
        private void btnCuoi_Click(object sender, EventArgs e)
        {
            currentPage = (int)Math.Ceiling((double)ketQuaTimKiem.Count / pageSize);
            if (currentPage < 1) currentPage = 1;
            HienThiDanhSach();
        }
    }
}
