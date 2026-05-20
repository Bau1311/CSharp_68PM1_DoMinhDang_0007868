namespace WinFormsApp
{
    /// <summary>
    /// Form chính sau khi đăng nhập.
    /// Chứa MenuStrip để điều hướng và một Panel để hiển thị các UserControl.
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            // Mặc định hiển thị Dashboard
            HienThiUC(new UCDashboard());
        }

        // ── Điều hướng qua MenuStrip ──────────────────────────────────────

        private void mnuQLSV_Click(object sender, EventArgs e)
        {
            HienThiUC(new UCQLSV());
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            HienThiUC(new UCDashboard());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Hiện lại Form1 (Login) rồi đóng form này
                Application.OpenForms[0]?.Show();
                this.Close();
            }
        }

        // ── Helper: swap UserControl vào panel ───────────────────────────

        private void HienThiUC(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        private void mnuQLLopHoc_Click(object sender, EventArgs e)
        {
            HienThiUC(new UCQLLopHoc());
        }
    }
}
