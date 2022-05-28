using GUI.SpaceTeam;
using SpaceTeam_Oracle.SpaceTeam;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.UI
{
    public partial class DangNhap : Form
    {
        ContextNhat db = new ContextNhat();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
        #region SHA1
        public static string HashSHA1(string passwordInput)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] passwordHashData = sha1.ComputeHash(Encoding.ASCII.GetBytes(passwordInput));
            string hashPassword = Convert.ToBase64String(passwordHashData);

            return hashPassword;
        }
        public static byte[] GetHashSHA1(string inputString)
        {
            using (HashAlgorithm algorithm = SHA1.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        #endregion

        #region button DangNhap
        private void btnDangNhap_Click(object sender, EventArgs e)
        {            
            ContextNhat db = new ContextNhat();
            if (txtDangNhap.Text != string.Empty && txtMatKhau.Text != string.Empty)
            {
                var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN.Equals(txtDangNhap.Text));
                if (user != null)
                {
                    string password = txtMatKhau.Text.Trim();
                    byte[] matKhauHash = GetHashSHA1(password);
                    if (Encoding.Default.GetString(user.MATKHAU) == Encoding.Default.GetString(matKhauHash))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Have a great day! :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (user.MACHUCVU == Convert.ToDecimal(1))
                        {
                            using (DanhMucAdmin dmAdmin = new DanhMucAdmin(txtDangNhap.Text))
                                if (dmAdmin.ShowDialog() == DialogResult.OK)
                                {
                                    this.Hide();
                                    Application.Run(new DanhMucAdmin(txtDangNhap.Text));
                                    this.Show();
                                }
                            return;
                        }
                        if (user.MACHUCVU == Convert.ToDecimal(21))
                        {
                            using (DanhMucNV dmNV = new DanhMucNV(txtDangNhap.Text))
                                if (dmNV.ShowDialog() == DialogResult.OK)
                                {
                                    this.Hide();
                                    Application.Run(new DanhMucNV(txtDangNhap.Text));
                                    this.Show();
                                }
                            return;
                        }
                        if (user.MACHUCVU == Convert.ToDecimal(20))
                        {
                            using (DanhMucQuanLy dmQL = new DanhMucQuanLy(txtDangNhap.Text))
                                if (dmQL.ShowDialog() == DialogResult.OK)
                                {
                                    this.Hide();
                                    Application.Run(new DanhMucQuanLy(txtDangNhap.Text));
                                    this.Show();
                                }
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(" Mật khẩu không đúng ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(" Tên đăng nhập không đúng ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(" Lỗi kết nối ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region Thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion

        private void txtDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtMatKhau.Focus();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnDangNhap.PerformClick();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
