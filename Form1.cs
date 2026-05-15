namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = "0007868@st.huce.edu.vn"; 
            string mssv = "0007868";

            if (txtUsername.Text.Trim() == email && txtPassword.Text.Trim() == mssv)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormQLSV form = new FormQLSV();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}