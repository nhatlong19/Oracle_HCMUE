using SpaceTeam_Oracle.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.SpaceTeam.DanhMucNV
{
    public partial class ThongTinCaNhan : Form
    {
        ContextNhat db = new ContextNhat();
        private string TenDN { get; set; }
        public ThongTinCaNhan(string tenNV)
        {
            InitializeComponent();
            TenDN = tenNV;
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadComboboxChiNhanh();
            LoadComboboxChucVu();
            LoadDL();
        }
        #region Load Combobox Chi Nhanh

        public void LoadComboboxChiNhanh()
        {
            try
            {
                List<CHINHANH> listChiNhanh = db.CHINHANHs.ToList();
                cmbChiNhanh.DataSource = listChiNhanh;
                cmbChiNhanh.DisplayMember = "TENCHINHANH";
                cmbChiNhanh.ValueMember = "MACHINHANH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Load Combobox Chuc Vu

        public void LoadComboboxChucVu()
        {
            try
            {
                List<CHUCVU> listChucVu = db.CHUCVUs.ToList();
                cmbChucVu.DataSource = listChucVu;
                cmbChucVu.DisplayMember = "TENCHUCVU";
                cmbChucVu.ValueMember = "MACHUCVU";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Hàm GetIDNV
        int GetIdNV()
        {
            int dem = 1;
            while (true)
            {
                var c = db.NHANVIENs.Where(w => w.MANV == dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }
        #endregion
        #region Mã Hóa AES 256
        public string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherText;
        }
        #endregion
        #region Giải Mã AES
        public string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();
            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;

            try
            {
                // Convert the ciphertext string into a byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                byte[] plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainText;
        }
        #endregion
        #region Hàm mã hóa SHA1
        public static byte[] GetHashSHA1(string inputString)
        {
            using (HashAlgorithm algorithm = SHA1.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        #endregion

        #region Hàm Insert NhanVien
        public void InsertNV(string hoTen, bool gioiTinh, DateTime ngaySinh, string SDT, string diaChi, string luong, string tenDN, byte[] matKhau, string Email, int maChiNhanh, int maChucVu)
        {
            NHANVIEN add = new NHANVIEN();
            add.MANV = GetIdNV();
            add.HOTEN = hoTen;
            add.GIOITINH = gioiTinh;
            add.NGAYSINH = ngaySinh;
            add.SDT = SDT;
            add.DIACHI = diaChi;
            add.TENDN = tenDN;
            add.LUONG = luong;
            add.MATKHAU = matKhau;
            add.MACHINHANH = maChiNhanh;
            add.MACHUCVU =maChucVu;
            db.NHANVIENs.Add(add);
            db.SaveChanges();
        }
        #endregion

        #region Hàm Update Nhân Viên
        public void UpdateNhanVien(int maNV, string hoTen, bool gioiTinh, DateTime ngaySinh, string SDT, string diaChi, string luong, string tenDN, byte[] matKhau, string eMail, int maChiNhanh, int maChucVu)
        {
            ContextNhat db = new ContextNhat();
            NHANVIEN update = db.NHANVIENs.SingleOrDefault(nv => nv.MANV == maNV);
            update.HOTEN = hoTen;
            update.GIOITINH = gioiTinh;
            update.NGAYSINH = ngaySinh;
            update.SDT = SDT;
            update.LUONG = luong;
            update.DIACHI = diaChi;
            update.TENDN = tenDN;
            update.MATKHAU = matKhau;
            update.EMAIL = eMail;
            update.MACHINHANH = maChiNhanh;
            update.MACHUCVU = maChucVu;
            db.SaveChanges();
        }
        #endregion

        #region Hàm Delete Bill
        public void Delete(int maNV)
        {
            ContextNhat db = new ContextNhat();
            var nhanVien = db.NHANVIENs.Where(nv => nv.MANV == maNV).SingleOrDefault();

            db.NHANVIENs.Remove(nhanVien);
            db.SaveChanges();
        }
        #endregion

        private void LoadDL()
        {
            decimal maNV = db.NHANVIENs.Where(nv => nv.TENDN.Equals(TenDN)).Select(nv => nv.MANV).FirstOrDefault();
            var nhanVien = db.NHANVIENs.Where(nv => nv.MANV.Equals((int)maNV));
            txtMaNV.Text = Convert.ToString(nhanVien.Select(nv => nv.MANV).FirstOrDefault());
            txtHoTen.Text = nhanVien.Select(nv => nv.HOTEN).FirstOrDefault();
            bool gioiTinh = nhanVien.Select(nv => nv.GIOITINH).FirstOrDefault();
            if (gioiTinh == true)
                radioMen.Checked = true;
            if (gioiTinh == false)
                radioFemale.Checked = true;
            txtEmail.Text = nhanVien.Select(nv => nv.EMAIL).FirstOrDefault();
            #region Giải Mã Lương
            string luong = nhanVien.Select(nv => nv.LUONG).FirstOrDefault();
            string password = "spaceTeam";

            // Create sha256 hash
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            txtLuong.Text = this.DecryptString(luong, key, iv);

            #endregion
            txtMatKhau.Text = Encoding.Default.GetString(nhanVien.Select(nv => nv.MATKHAU).FirstOrDefault());
            dtpkBD.Value = Convert.ToDateTime(nhanVien.Select(nv => nv.NGAYSINH).SingleOrDefault());
            txtSDT.Text = nhanVien.Select(nv => nv.SDT).FirstOrDefault();
            txtDiaChi.Text = nhanVien.Select(nv => nv.DIACHI).FirstOrDefault();
            txtTenDN.Text = TenDN;
            int maCN = Convert.ToInt32(nhanVien.Select(nv => nv.MACHINHANH).FirstOrDefault());
            cmbChiNhanh.Text = db.CHINHANHs.Where(cn => cn.MACHINHANH.Equals(maCN)).Select(cn => cn.TENCHINHANH).FirstOrDefault().ToString();
            var maCV = nhanVien.Select(nv => nv.MACHUCVU).FirstOrDefault();
            cmbChucVu.Text = db.CHUCVUs.Where(cv => cv.MACHUCVU.Equals(maCV)).Select(nv => nv.TENCHUCVU).FirstOrDefault().ToString();
            txtLuong.Enabled = false;
            txtTenDN.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(txtMaNV.Text);
            DateTime dateBD = dtpkBD.Value;

            string matKhau = txtMatKhau.Text.Trim();
            byte[] matKhauHash;
            var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN.Equals(TenDN));
            if (Encoding.Default.GetString(user.MATKHAU) == txtMatKhau.Text)
            {
                matKhauHash = user.MATKHAU;
            }
            else
            {
                matKhauHash = GetHashSHA1(matKhau);
            }
            //matKhauHash = GetHashSHA1(matKhau);
            string hoTen = txtHoTen.Text;

            bool gioiTinh = true;
            if (radioMen.Checked == true)
            {
                gioiTinh = true;
            }
            if (radioFemale.Checked == true)
            {
                gioiTinh = false;
            }
            string eMail = txtEmail.Text;
            #region Mã Hóa Lương
            string password = "spaceTeam";

            // Create sha256 hash
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            string luong = this.EncryptString(txtLuong.Text, key, iv);
            #endregion
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string tenDN = txtTenDN.Text;
            int chiNhanh = int.Parse(cmbChiNhanh.SelectedValue.ToString());
            int chucVu = int.Parse(cmbChucVu.SelectedValue.ToString());

            try
            {
                UpdateNhanVien(maNV, hoTen, gioiTinh, dateBD, sDT, diaChi, luong, tenDN, matKhauHash, eMail, chiNhanh, chucVu);

                MessageBox.Show("Update Nhân Viên Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //GetDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Nhân Viên Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }

      
    }
}
