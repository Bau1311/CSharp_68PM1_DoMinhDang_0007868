namespace WinFormsApp
{
    partial class UCDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblSubtitle = new Label();
            panel1 = new Panel();

            panel1.SuspendLayout();
            SuspendLayout();

            // lblWelcome
            lblWelcome.Text = "🎓  Chào mừng đến hệ thống";
            lblWelcome.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 58, 95);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(40, 55);

            // lblSubtitle
            lblSubtitle.Text = "Quản Lý Sinh Viên – Lớp 68PM1";
            lblSubtitle.Font = new Font("Segoe UI", 14F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(110, 120);

            // panel1
            panel1.BackColor = Color.White;
            panel1.Size = new Size(620, 200);
            panel1.Controls.AddRange(new Control[] { lblWelcome, lblSubtitle });

            // UserControl
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            Dock = DockStyle.Fill;
            Controls.Add(panel1);

            void CentratePanel(object s, EventArgs e)
            {
                panel1.Location = new Point(
                    Math.Max(0, (Width - panel1.Width) / 2),
                    Math.Max(0, (Height - panel1.Height) / 2) - 20
                );
            }
            Resize += CentratePanel;
            Load += CentratePanel;

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblWelcome;
        private Label lblSubtitle;
        private Panel panel1;
    }
}