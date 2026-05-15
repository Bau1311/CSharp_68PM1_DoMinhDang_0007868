namespace WinFormsApp
{
    partial class FormQLSV
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuQLSV = new ToolStripMenuItem();
            mnuQLLopHoc = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            grpThongTin = new GroupBox();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();
            dgvSinhVien = new DataGridView();
            btnDau = new Button();
            btnTruoc = new Button();
            lblTrang = new Label();
            btnSau = new Button();
            btnCuoi = new Button();

            menuStrip1.SuspendLayout();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuQLSV, mnuQLLopHoc, mnuDangXuat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            mnuQLSV.Text = "Quản lý Sinh Viên";
            mnuQLLopHoc.Text = "Quản lý Lớp Học";
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.ForeColor = Color.Red;
            mnuDangXuat.Click += mnuDangXuat_Click;

            // grpThongTin - chứa form nhập liệu
            grpThongTin.Text = "Thông tin sinh viên";
            grpThongTin.Location = new Point(10, 35);
            grpThongTin.Size = new Size(420, 490);
            grpThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            lblMaSV.Text = "Mã sinh viên:";
            lblMaSV.Location = new Point(15, 30);
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new Font("Segoe UI", 10F);

            txtMaSV.Location = new Point(15, 55);
            txtMaSV.Size = new Size(380, 30);
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.BorderStyle = BorderStyle.FixedSingle;

            lblHoTen.Text = "Họ và tên:";
            lblHoTen.Location = new Point(15, 100);
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);

            txtHoTen.Location = new Point(15, 125);
            txtHoTen.Size = new Size(380, 30);
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;

            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new Point(15, 175);
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F);

            dtpNgaySinh.Location = new Point(15, 200);
            dtpNgaySinh.Size = new Size(380, 30);
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;

            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new Point(15, 250);
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 10F);

            cboGioiTinh.Location = new Point(15, 275);
            cboGioiTinh.Size = new Size(380, 30);
            cboGioiTinh.Font = new Font("Segoe UI", 10F);
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            lblLop.Text = "Lớp:";
            lblLop.Location = new Point(15, 325);
            lblLop.AutoSize = true;
            lblLop.Font = new Font("Segoe UI", 10F);

            cboLop.Location = new Point(15, 350);
            cboLop.Size = new Size(380, 30);
            cboLop.Font = new Font("Segoe UI", 10F);
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Items.AddRange(new object[] { "68PM1 – Lớp 68PM1", "68PM2 – Lớp 68PM2" });
            cboLop.SelectedIndex = 0;

            grpThongTin.Controls.AddRange(new Control[] {
                lblMaSV, txtMaSV, lblHoTen, txtHoTen,
                lblNgaySinh, dtpNgaySinh, lblGioiTinh,
                cboGioiTinh, lblLop, cboLop
            });

            // 4 nút bên dưới grpThongTin
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(10, 535);
            btnThem.Size = new Size(200, 50);
            btnThem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThem.BackColor = Color.FromArgb(33, 150, 243);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Cursor = Cursors.Hand;
            btnThem.Click += btnThem_Click;

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(220, 535);
            btnSua.Size = new Size(200, 50);
            btnSua.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSua.BackColor = Color.FromArgb(76, 175, 80);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.Cursor = Cursors.Hand;
            btnSua.Click += btnSua_Click;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(10, 595);
            btnXoa.Size = new Size(200, 50);
            btnXoa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXoa.BackColor = Color.FromArgb(244, 67, 54);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(220, 595);
            btnLamMoi.Size = new Size(200, 50);
            btnLamMoi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLamMoi.BackColor = Color.FromArgb(158, 158, 158);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Click += btnLamMoi_Click;

            // Tìm kiếm
            lblTimKiem.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTimKiem.Location = new Point(450, 40);
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F);

            txtTimKiem.Location = new Point(450, 65);
            txtTimKiem.Size = new Size(370, 30);
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;

            btnTim.Text = "Tìm";
            btnTim.Location = new Point(830, 62);
            btnTim.Size = new Size(80, 35);
            btnTim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTim.BackColor = Color.FromArgb(96, 125, 139);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.FlatAppearance.BorderSize = 0;
            btnTim.Cursor = Cursors.Hand;
            btnTim.Click += btnTim_Click;

            // DataGridView
            dgvSinhVien.Location = new Point(450, 110);
            dgvSinhVien.Size = new Size(880, 580);
            dgvSinhVien.Font = new Font("Segoe UI", 10F);
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.BorderStyle = BorderStyle.None;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dgvSinhVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;

            // Phân trang
            btnDau.Text = "<<";
            btnDau.Location = new Point(450, 700);
            btnDau.Size = new Size(55, 38);
            btnDau.FlatStyle = FlatStyle.Flat;
            btnDau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDau.Click += btnDau_Click;

            btnTruoc.Text = "<";
            btnTruoc.Location = new Point(515, 700);
            btnTruoc.Size = new Size(55, 38);
            btnTruoc.FlatStyle = FlatStyle.Flat;
            btnTruoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTruoc.Click += btnTruoc_Click;

            lblTrang.Text = "Trang 1/1  |  0 bản ghi";
            lblTrang.Location = new Point(585, 710);
            lblTrang.AutoSize = true;
            lblTrang.Font = new Font("Segoe UI", 10F);

            btnSau.Text = ">";
            btnSau.Location = new Point(800, 700);
            btnSau.Size = new Size(55, 38);
            btnSau.FlatStyle = FlatStyle.Flat;
            btnSau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSau.Click += btnSau_Click;

            btnCuoi.Text = ">>";
            btnCuoi.Location = new Point(865, 700);
            btnCuoi.Size = new Size(55, 38);
            btnCuoi.FlatStyle = FlatStyle.Flat;
            btnCuoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCuoi.Click += btnCuoi_Click;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 760);
            WindowState = FormWindowState.Maximized;
            MainMenuStrip = menuStrip1;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sinh Viên";
            Controls.AddRange(new Control[] {
                menuStrip1, grpThongTin,
                btnThem, btnSua, btnXoa, btnLamMoi,
                lblTimKiem, txtTimKiem, btnTim,
                dgvSinhVien,
                btnDau, btnTruoc, lblTrang, btnSau, btnCuoi
            });

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuQLSV, mnuQLLopHoc, mnuDangXuat;
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