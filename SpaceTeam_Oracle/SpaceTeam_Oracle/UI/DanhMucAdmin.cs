using SpaceTeam_Oracle.SpaceTeam.DanhMucNV;
using System;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.UI
{
    public partial class DanhMucAdmin : Form
    {
        private string TenDN { get; set; }
        public DanhMucAdmin(string tenDN)
        {
            InitializeComponent();
            TenDN = tenDN;
        }
        #region btn Man hinh Nhan Vien
        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            using (QLNhanVien qLNV = new QLNhanVien(TenDN))
                if (qLNV.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLNhanVien(TenDN));
        }
        #endregion

        #region btn Man hinh Doanh Thu
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            using (DoanhThu dT = new DoanhThu())
                if (dT.ShowDialog() == DialogResult.OK)
                    Application.Run(new DoanhThu());
        }
        #endregion

        #region btn Man hinh Thong Tin Ca Nhan
        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            using (ThongTinCaNhan tTCN = new ThongTinCaNhan(TenDN))
                if (tTCN.ShowDialog() == DialogResult.OK)
                    Application.Run(new ThongTinCaNhan(TenDN));
        }
        #endregion

        #region btn Man hinh Kho Hang
        private void btnQLKhoHang_Click(object sender, EventArgs e)
        {
            using (NhapKho nK = new NhapKho())
                if (nK.ShowDialog() == DialogResult.OK)
                    Application.Run(new NhapKho());
        }
        #endregion

        #region btn Man hinh Danh Sach Hang Hoa Da Ban
        private void btnDSHHDaBan_Click(object sender, EventArgs e)
        {
            using (DanhSachHangHoaDaBan dSHHDB = new DanhSachHangHoaDaBan())
                if (dSHHDB.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachHangHoaDaBan());
        }
        #endregion

        #region btn Man hinh Quan ly Chi Nhanh
        private void btnQLDSChiNhanh_Click(object sender, EventArgs e)
        {
            using (QLChiNhanh qLCN = new QLChiNhanh())
                if (qLCN.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLChiNhanh());
        }
        #endregion

        #region btn Man hinh Quan Ly Chuc Vu
        private void btnQLDSChucVu_Click(object sender, EventArgs e)
        {
            using (QLChucVu qLCV = new QLChucVu())
                if (qLCV.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLChucVu());
        }
        #endregion

        #region btn Man hinh Quan Ly Khach Hang
        private void btnQLDSKhachHang_Click(object sender, EventArgs e)
        {
            using (QLKhachHang qLKH = new QLKhachHang())
                if (qLKH.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLKhachHang());
        }
        #endregion

        #region btn Man hinh Quan Ly Nha Cung Cap
        private void btnQLDSNhaCungCap_Click(object sender, EventArgs e)
        {
            using (QLNhaCungCap qLNCC = new QLNhaCungCap())
                if (qLNCC.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLNhaCungCap());
        }
        #endregion

        #region btn Quan Ly Danh Sach Don Hang
        private void btnQLDSDonHang_Click(object sender, EventArgs e)
        {
            using (DanhSachDonHang dSDH = new DanhSachDonHang(TenDN))
                if (dSDH.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachDonHang(TenDN));
        }
        #endregion

        #region btn Thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion

        private void DanhMucAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
