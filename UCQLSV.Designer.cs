namespace WinFormsApp
{
    partial class UCQLSV
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpThongTin  = new GroupBox();
            lblMaSV      = new Label();
            txtMaSV      = new TextBox();
            lblHoTen     = new Label();
            txtHoTen     = new TextBox();
            lblNgaySinh  = new Label();
            dtpNgaySinh  = new DateTimePicker();
            lblGioiTinh  = new Label();
            cboGioiTinh  = new ComboBox();
            lblLop       = new Label();
            cboLop       = new ComboBox();
            btnThem      = new Button();
            btnSua       = new Button();
            btnXoa       = new Button();
            btnLamMoi    = new Button();
            lblTimKiem   = new Label();
            txtTimKiem   = new TextBox();
            btnTim       = new Button();
            dgvSinhVien  = new DataGridView();
            btnDau       = new Button();
            btnTruoc     = new Button();
            lblTrang     = new Label();
            btnSau       = new Button();
            btnCuoi      = new Button();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();

            // ── grpThongTin ──────────────────────────────────────────────
            grpThongTin.Text     = "Thông tin sinh viên";
            grpThongTin.Location = new Point(10, 10);
            grpThongTin.Size     = new Size(420, 420);
            grpThongTin.Font     = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblMaSV.Text = "Mã sinh viên:"; lblMaSV.Location = new Point(15, 30);  lblMaSV.AutoSize = true; lblMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(15, 55);  txtMaSV.Size = new Size(380, 28); txtMaSV.Font = new Font("Segoe UI", 10F); txtMaSV.BorderStyle = BorderStyle.FixedSingle;

            lblHoTen.Text = "Họ và tên:";   lblHoTen.Location = new Point(15, 95);  lblHoTen.AutoSize = true; lblHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(15, 120); txtHoTen.Size = new Size(380, 28); txtHoTen.Font = new Font("Segoe UI", 10F); txtHoTen.BorderStyle = BorderStyle.FixedSingle;

            lblNgaySinh.Text = "Ngày sinh:"; lblNgaySinh.Location = new Point(15, 160); lblNgaySinh.AutoSize = true; lblNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Location = new Point(15, 185); dtpNgaySinh.Size = new Size(380, 28); dtpNgaySinh.Font = new Font("Segoe UI", 10F); dtpNgaySinh.Format = DateTimePickerFormat.Short;

            lblGioiTinh.Text = "Giới tính:"; lblGioiTinh.Location = new Point(15, 225); lblGioiTinh.AutoSize = true; lblGioiTinh.Font = new Font("Segoe UI", 10F);
            cboGioiTinh.Location = new Point(15, 250); cboGioiTinh.Size = new Size(380, 28); cboGioiTinh.Font = new Font("Segoe UI", 10F);
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            lblLop.Text = "Lớp:"; lblLop.Location = new Point(15, 295); lblLop.AutoSize = true; lblLop.Font = new Font("Segoe UI", 10F);
            cboLop.Location = new Point(15, 320); cboLop.Size = new Size(380, 28); cboLop.Font = new Font("Segoe UI", 10F);
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Items.AddRange(new object[] { "68PM1 – Lớp 68PM1", "68PM2 – Lớp 68PM2" });
            cboLop.SelectedIndex = 0;

            grpThongTin.Controls.AddRange(new Control[] {
                lblMaSV, txtMaSV, lblHoTen, txtHoTen,
                lblNgaySinh, dtpNgaySinh, lblGioiTinh,
                cboGioiTinh, lblLop, cboLop
            });

            // ── Buttons CRUD ──────────────────────────────────────────────
            MakeBtn(btnThem,   "Thêm",    new Point(10, 440),  Color.FromArgb(33, 150, 243));  btnThem.Click  += btnThem_Click;
            MakeBtn(btnSua,    "Sửa",     new Point(220, 440), Color.FromArgb(76, 175, 80));   btnSua.Click   += btnSua_Click;
            MakeBtn(btnXoa,    "Xóa",     new Point(10, 500),  Color.FromArgb(244, 67, 54));   btnXoa.Click   += btnXoa_Click;
            MakeBtn(btnLamMoi, "Làm mới", new Point(220, 500), Color.FromArgb(158, 158, 158)); btnLamMoi.Click += btnLamMoi_Click;

            // ── Tìm kiếm ─────────────────────────────────────────────────
            lblTimKiem.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTimKiem.Location = new Point(450, 10); lblTimKiem.AutoSize = true; lblTimKiem.Font = new Font("Segoe UI", 10F);

            txtTimKiem.Location = new Point(450, 35); txtTimKiem.Size = new Size(370, 28);
            txtTimKiem.Font = new Font("Segoe UI", 10F); txtTimKiem.BorderStyle = BorderStyle.FixedSingle;

            btnTim.Text = "Tìm"; btnTim.Location = new Point(830, 33); btnTim.Size = new Size(75, 32);
            btnTim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTim.BackColor = Color.FromArgb(96, 125, 139); btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat; btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Cursor = Cursors.Hand; btnTim.Click += btnTim_Click;

            // ── DataGridView ──────────────────────────────────────────────
            dgvSinhVien.Location = new Point(450, 75);
            dgvSinhVien.Size     = new Size(880, 530);
            dgvSinhVien.Font     = new Font("Segoe UI", 10F);
            dgvSinhVien.AllowUserToAddRows  = false;
            dgvSinhVien.ReadOnly            = true;
            dgvSinhVien.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor     = Color.White;
            dgvSinhVien.BorderStyle         = BorderStyle.None;
            dgvSinhVien.RowHeadersVisible   = false;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Font     = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgvSinhVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            // ── Phân trang ────────────────────────────────────────────────
            MakePagBtn(btnDau,   "<<", new Point(450, 615)); btnDau.Click   += btnDau_Click;
            MakePagBtn(btnTruoc, "<",  new Point(515, 615)); btnTruoc.Click += btnTruoc_Click;
            MakePagBtn(btnSau,   ">",  new Point(800, 615)); btnSau.Click   += btnSau_Click;
            MakePagBtn(btnCuoi,  ">>", new Point(865, 615)); btnCuoi.Click  += btnCuoi_Click;

            lblTrang.Text = "Trang 1/1  |  0 bản ghi";
            lblTrang.Location = new Point(585, 623); lblTrang.AutoSize = true; lblTrang.Font = new Font("Segoe UI", 10F);

            // ── UserControl ───────────────────────────────────────────────
            AutoScaleMode = AutoScaleMode.Font;
            Size = new Size(1350, 660);
            Controls.AddRange(new Control[] {
                grpThongTin, btnThem, btnSua, btnXoa, btnLamMoi,
                lblTimKiem, txtTimKiem, btnTim,
                dgvSinhVien, btnDau, btnTruoc, lblTrang, btnSau, btnCuoi
            });

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // ── helpers ───────────────────────────────────────────────────────
        private void MakeBtn(Button btn, string text, Point loc, Color color)
        {
            btn.Text = text; btn.Location = loc; btn.Size = new Size(200, 45);
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }
        private void MakePagBtn(Button btn, string text, Point loc)
        {
            btn.Text = text; btn.Location = loc; btn.Size = new Size(55, 35);
            btn.FlatStyle = FlatStyle.Flat; btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private GroupBox grpThongTin;
        private Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblLop;
        private TextBox txtMaSV, txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboGioiTinh, cboLop;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private Label lblTimKiem, lblTrang;
        private TextBox txtTimKiem;
        private Button btnTim, btnDau, btnTruoc, btnSau, btnCuoi;
        private DataGridView dgvSinhVien;
    }
}
