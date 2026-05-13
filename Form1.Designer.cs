namespace WinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();

            // label1 - Tên đăng nhập
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(60, 100);
            label1.Name = "label1";
            label1.Text = "Tên đăng nhập";

            // label2 - Mật khẩu
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(60, 150);
            label2.Name = "label2";
            label2.Text = "Mật khẩu";

            // txtUsername
            txtUsername.Location = new Point(220, 97);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 28);
            txtUsername.Font = new Font("Segoe UI", 11F);

            // txtPassword
            txtPassword.Location = new Point(220, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 28);
            txtPassword.Font = new Font("Segoe UI", 11F);

            // btnLogin
            btnLogin.Location = new Point(170, 210);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 45);
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(33, 150, 243);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += btnLogin_Click;

            // Label tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(150, 40);

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 58, 95);
            ClientSize = new Size(550, 300);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập Hệ Thống";
            Controls.Add(lblTitle);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}