using SpaceTeam_Oracle.SpaceTeam.DanhMucNV;
using SpaceTeam_Oracle.UI;
using System;
using System.Windows.Forms;

namespace GUI.SpaceTeam
{
    public partial class DanhMucNV : Form
    {
        private string TenDN { get; set; }
        public DanhMucNV(string tenDN)
        {
            InitializeComponent();
            TenDN = tenDN;
        }

        private void DanhMucNV_Load(object sender, EventArgs e)
        {

        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            using (TaoDonHang lophoc = new TaoDonHang())
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new TaoDonHang());
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            using (DoanhThu lophoc = new DoanhThu())
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new DoanhThu());
        }

        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            using (ThongTinCaNhan lophoc = new ThongTinCaNhan(TenDN))
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new ThongTinCaNhan(TenDN));
        }

        private void btnDSDonHang_Click(object sender, EventArgs e)
        {
            using (DanhSachDonHang lophoc = new DanhSachDonHang(TenDN))
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachDonHang(TenDN));
        }

        private void btnDSHHDaBan_Click(object sender, EventArgs e)
        {
            using (DanhSachHangHoaDaBan lophoc = new DanhSachHangHoaDaBan())
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachHangHoaDaBan());
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            using (QLKhachHang lophoc = new QLKhachHang())
                if (lophoc.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLKhachHang());
        }

        private void btnThoát_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }
    }
}
