namespace WinFormsApp
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1    = new MenuStrip();
            mnuDashboard  = new ToolStripMenuItem();
            mnuQLSV       = new ToolStripMenuItem();
            mnuDangXuat   = new ToolStripMenuItem();
            pnlContent    = new Panel();

            menuStrip1.SuspendLayout();
            SuspendLayout();

            // ── MenuStrip ─────────────────────────────────────────────────
            menuStrip1.BackColor = Color.FromArgb(30, 58, 95);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuDashboard, mnuQLSV, mnuDangXuat });
            menuStrip1.Location  = new Point(0, 0);
            menuStrip1.Name      = "menuStrip1";
            menuStrip1.Padding   = new Padding(5, 3, 0, 3);

            mnuDashboard.Text      = "🏠 Trang chủ";
            mnuDashboard.ForeColor = Color.White;
            mnuDashboard.Click    += mnuDashboard_Click;

            mnuQLSV.Text      = "👨‍🎓 Quản lý Sinh Viên";
            mnuQLSV.ForeColor = Color.White;
            mnuQLSV.Click    += mnuQLSV_Click;

            mnuDangXuat.Text      = "🚪 Đăng xuất";
            mnuDangXuat.ForeColor = Color.FromArgb(255, 100, 100);
            mnuDangXuat.Click    += mnuDangXuat_Click;

            // ── pnlContent – nơi load UserControl ────────────────────────
            pnlContent.Dock      = DockStyle.Fill;
            pnlContent.Location  = new Point(0, 30);
            pnlContent.Name      = "pnlContent";
            pnlContent.BackColor = Color.FromArgb(240, 244, 248);

            // ── Form ──────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            ClientSize          = new Size(1350, 760);
            WindowState         = FormWindowState.Maximized;
            MainMenuStrip       = menuStrip1;
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "Quản Lý Sinh Viên";
            Controls.Add(pnlContent);
            Controls.Add(menuStrip1);

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuDashboard, mnuQLSV, mnuDangXuat;
        private Panel pnlContent;
    }
}
