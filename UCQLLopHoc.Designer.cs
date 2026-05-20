namespace WinFormsApp
{
    partial class UCQLLopHoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Controls khai báo ────────────────────────────────────────
            grpThongTin = new GroupBox();
            lblMaID = new Label();
            txtMaID = new TextBox();
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXemSV = new Button();

            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTim = new Button();

            dgvLopHoc = new DataGridView();
            pnlPhanTrang = new Panel();
            btnDau = new Button();
            btnTruoc = new Button();
            lblTrang = new Label();
            btnSau = new Button();
            btnCuoi = new Button();

            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            pnlPhanTrang.SuspendLayout();
            SuspendLayout();

            // ════════════════════════════════════════════════════════════════
            // grpThongTin  (bên trái)
            // ════════════════════════════════════════════════════════════════
            grpThongTin.Text = "Thông tin lớp học";
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Size = new Size(430, 540);
            grpThongTin.Font = new Font("Segoe UI", 10F);

            // Mã ID
            lblMaID.Text = "Mã ID:";
            lblMaID.Location = new Point(15, 30);
            lblMaID.AutoSize = true;

            txtMaID.Location = new Point(15, 50);
            txtMaID.Size = new Size(390, 30);
            txtMaID.ReadOnly = true;
            txtMaID.BackColor = Color.WhiteSmoke;

            // Mã lớp
            lblMaLop.Text = "Mã lớp:";
            lblMaLop.Location = new Point(15, 95);
            lblMaLop.AutoSize = true;

            txtMaLop.Location = new Point(15, 115);
            txtMaLop.Size = new Size(390, 30);

            // Tên lớp
            lblTenLop.Text = "Tên lớp:";
            lblTenLop.Location = new Point(15, 160);
            lblTenLop.AutoSize = true;

            txtTenLop.Location = new Point(15, 180);
            txtTenLop.Size = new Size(390, 30);

            // Ghi chú
            lblGhiChu.Text = "Ghi chú:";
            lblGhiChu.Location = new Point(15, 225);
            lblGhiChu.AutoSize = true;

            txtGhiChu.Location = new Point(15, 245);
            txtGhiChu.Size = new Size(390, 30);

            grpThongTin.Controls.AddRange(new Control[]
            {
                lblMaID, txtMaID, lblMaLop, txtMaLop,
                lblTenLop, txtTenLop, lblGhiChu, txtGhiChu
            });

            // ════════════════════════════════════════════════════════════════
            // Buttons hành động (dưới grpThongTin)
            // ════════════════════════════════════════════════════════════════
            int btnY = 565;

            btnThem.Text = "Thêm";
            btnThem.Location = new Point(12, btnY);
            btnThem.Size = new Size(200, 45);
            btnThem.BackColor = Color.FromArgb(0, 123, 255);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.Click += btnThem_Click;

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(222, btnY);
            btnSua.Size = new Size(200, 45);
            btnSua.BackColor = Color.FromArgb(40, 167, 69);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.Click += btnSua_Click;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(12, btnY + 55);
            btnXoa.Size = new Size(200, 45);
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(222, btnY + 55);
            btnLamMoi.Size = new Size(200, 45);
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.Click += btnLamMoi_Click;

            btnXemSV.Text = "Xem danh sách sinh viên";
            btnXemSV.Location = new Point(12, btnY + 110);
            btnXemSV.Size = new Size(410, 45);
            btnXemSV.BackColor = Color.FromArgb(23, 162, 184);
            btnXemSV.ForeColor = Color.White;
            btnXemSV.FlatStyle = FlatStyle.Flat;
            btnXemSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemSV.Click += btnXemSV_Click;

            // ════════════════════════════════════════════════════════════════
            // Tìm kiếm (bên phải – trên cùng)
            // ════════════════════════════════════════════════════════════════
            int rightX = 460;

            lblTimKiem.Text = "Tìm kiếm (Mã ID / Mã lớp / Tên lớp):";
            lblTimKiem.Location = new Point(rightX, 12);
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F);

            txtTimKiem.Location = new Point(rightX, 35);
            txtTimKiem.Size = new Size(350, 30);
            txtTimKiem.Font = new Font("Segoe UI", 10F);

            btnTim.Text = "Tìm";
            btnTim.Location = new Point(rightX + 360, 33);
            btnTim.Size = new Size(90, 34);
            btnTim.BackColor = Color.FromArgb(52, 58, 64);
            btnTim.ForeColor = Color.White;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 10F);
            btnTim.Click += btnTim_Click;

            // ════════════════════════════════════════════════════════════════
            // DataGridView
            // ════════════════════════════════════════════════════════════════
            dgvLopHoc.Location = new Point(rightX, 75);
            dgvLopHoc.Size = new Size(820, 650);
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.MultiSelect = false;
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Font = new Font("Segoe UI", 10F);
            dgvLopHoc.CellClick += dgvLopHoc_CellClick;

            // ════════════════════════════════════════════════════════════════
            // Panel phân trang
            // ════════════════════════════════════════════════════════════════
            pnlPhanTrang.Location = new Point(rightX, 735);
            pnlPhanTrang.Size = new Size(820, 50);

            btnDau.Text = "<<";
            btnDau.Size = new Size(55, 36);
            btnDau.Location = new Point(0, 7);
            btnDau.FlatStyle = FlatStyle.Flat;
            btnDau.Click += btnDau_Click;

            btnTruoc.Text = "<";
            btnTruoc.Size = new Size(55, 36);
            btnTruoc.Location = new Point(60, 7);
            btnTruoc.FlatStyle = FlatStyle.Flat;
            btnTruoc.Click += btnTruoc_Click;

            lblTrang.Text = "Trang 1/1  |  0 bản ghi";
            lblTrang.Location = new Point(125, 14);
            lblTrang.Size = new Size(500, 22);
            lblTrang.TextAlign = ContentAlignment.MiddleCenter;
            lblTrang.Font = new Font("Segoe UI", 10F);

            btnSau.Text = ">";
            btnSau.Size = new Size(55, 36);
            btnSau.Location = new Point(635, 7);
            btnSau.FlatStyle = FlatStyle.Flat;
            btnSau.Click += btnSau_Click;

            btnCuoi.Text = ">>";
            btnCuoi.Size = new Size(55, 36);
            btnCuoi.Location = new Point(695, 7);
            btnCuoi.FlatStyle = FlatStyle.Flat;
            btnCuoi.Click += btnCuoi_Click;

            pnlPhanTrang.Controls.AddRange(new Control[]
            {
                btnDau, btnTruoc, lblTrang, btnSau, btnCuoi
            });

            // ════════════════════════════════════════════════════════════════
            // UserControl
            // ════════════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Size = new Size(1300, 800);
            Font = new Font("Segoe UI", 10F);

            Controls.AddRange(new Control[]
            {
                grpThongTin,
                btnThem, btnSua, btnXoa, btnLamMoi, btnXemSV,
                lblTimKiem, txtTimKiem, btnTim,
                dgvLopHoc,
                pnlPhanTrang
            });

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            pnlPhanTrang.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        // ── Field declarations ───────────────────────────────────────────
        private GroupBox grpThongTin;
        private Label lblMaID, lblMaLop, lblTenLop, lblGhiChu;
        private TextBox txtMaID, txtMaLop, txtTenLop, txtGhiChu;
        private Button btnThem, btnSua, btnXoa, btnLamMoi, btnXemSV;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgvLopHoc;
        private Panel pnlPhanTrang;
        private Button btnDau, btnTruoc, btnSau, btnCuoi;
        private Label lblTrang;
    }
}