namespace WinFormsApp
{
    public partial class UCQLSV : UserControl
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();
        private int currentPage = 1;
        private int pageSize = 10;
        private List<SinhVien> ketQuaTimKiem = new List<SinhVien>();

        public UCQLSV()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            TaoCoTDanhSachSV();
            HienThiDanhSach();
        }

        private void KhoiTaoDuLieu()
        {
            danhSachSV.Add(new SinhVien { MaSV = "1", HoTen = "Nguyễn Văn An",   GioiTinh = "Nam", NgaySinh = new DateTime(2005, 1, 15),  Lop = "68PM1" });
            danhSachSV.Add(new SinhVien { MaSV = "2", HoTen = "Trần Thị Bích",   GioiTinh = "Nữ",  NgaySinh = new DateTime(2005, 3, 22),  Lop = "68PM1" });
            danhSachSV.Add(new SinhVien { MaSV = "3", HoTen = "Lê Hoàng Nam",    GioiTinh = "Nam", NgaySinh = new DateTime(2005, 7, 10),  Lop = "68PM2" });
            danhSachSV.Add(new SinhVien { MaSV = "4", HoTen = "Phạm Thị Lan",    GioiTinh = "Nữ",  NgaySinh = new DateTime(2005, 9, 5),   Lop = "68PM2" });
            danhSachSV.Add(new SinhVien { MaSV = "5", HoTen = "Võ Minh Tuấn",    GioiTinh = "Nam", NgaySinh = new DateTime(2005, 11, 30), Lop = "68PM1" });
            ketQuaTimKiem = new List<SinhVien>(danhSachSV);
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
                dgvSinhVien.Rows.Add(sv.MaSV, sv.HoTen, sv.GioiTinh, sv.NgaySinh.ToString("dd/MM/yyyy"), sv.Lop);

            lblTrang.Text = $"Trang {currentPage}/{totalPages}  |  {total} bản ghi";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sv = new SinhVien
            {
                MaSV     = txtMaSV.Text.Trim(),
                HoTen    = txtHoTen.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                Lop      = cboLop.SelectedItem.ToString().Split('–')[0].Trim()
            };
            danhSachSV.Add(sv);
            ketQuaTimKiem = new List<SinhVien>(danhSachSV);
            HienThiDanhSach();
            LamMoi();
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count == 0) return;
            string maSV = dgvSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();
            var sv = danhSachSV.FirstOrDefault(s => s.MaSV == maSV);
            if (sv != null)
            {
                sv.HoTen    = txtHoTen.Text.Trim();
                sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.Lop      = cboLop.SelectedItem.ToString().Split('–')[0].Trim();
                ketQuaTimKiem = new List<SinhVien>(danhSachSV);
                HienThiDanhSach();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count == 0) return;
            string maSV = dgvSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                danhSachSV.RemoveAll(s => s.MaSV == maSV);
                ketQuaTimKiem = new List<SinhVien>(danhSachSV);
                HienThiDanhSach();
                LamMoi();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void LamMoi()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            ketQuaTimKiem = danhSachSV.Where(s =>
                s.HoTen.ToLower().Contains(keyword) ||
                s.MaSV.ToLower().Contains(keyword)  ||
                s.Lop.ToLower().Contains(keyword)).ToList();
            currentPage = 1;
            HienThiDanhSach();
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
            HienThiDanhSach();
        }
    }
}
