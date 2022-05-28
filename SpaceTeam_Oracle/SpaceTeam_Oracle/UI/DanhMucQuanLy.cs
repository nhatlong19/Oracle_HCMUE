using SpaceTeam_Oracle.SpaceTeam.DanhMucNV;
using SpaceTeam_Oracle.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.SpaceTeam
{
    public partial class DanhMucQuanLy : Form
    {
        private string TenDN { get; set; }
        public DanhMucQuanLy(string tenDN)
        {
            InitializeComponent();
            TenDN = tenDN;
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            using (QLNhanVien qLNV = new QLNhanVien(TenDN))
                if (qLNV.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLNhanVien(TenDN));
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            using (DoanhThu dT = new DoanhThu())
                if (dT.ShowDialog() == DialogResult.OK)
                    Application.Run(new DoanhThu());
        }

        private void btnTTCaNhan_Click(object sender, EventArgs e)
        {
            using (ThongTinCaNhan ttCN = new ThongTinCaNhan(TenDN))
                if (ttCN.ShowDialog() == DialogResult.OK)
                    Application.Run(new ThongTinCaNhan(TenDN));
        }

        private void btnQLKhoHang_Click(object sender, EventArgs e)
        {
            using (NhapKho nK = new NhapKho())
                if (nK.ShowDialog() == DialogResult.OK)
                    Application.Run(new NhapKho());
        }

        private void btnDSHHDaBan_Click(object sender, EventArgs e)
        {
            using (DanhSachHangHoaDaBan dsHH = new DanhSachHangHoaDaBan())
                if (dsHH.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachHangHoaDaBan());
        }

        private void btnQLDSDonHang_Click(object sender, EventArgs e)
        {
            using (DanhSachDonHang dsDH = new DanhSachDonHang(TenDN))
                if (dsDH.ShowDialog() == DialogResult.OK)
                    Application.Run(new DanhSachDonHang(TenDN));
        }

        private void btnQLDSChucVu_Click(object sender, EventArgs e)
        {
            using (QLChucVu dsDH = new QLChucVu())
                if (dsDH.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLChucVu());
        }

        private void btnQLDSKhachHang_Click(object sender, EventArgs e)
        {
            using (QLKhachHang dsDH = new QLKhachHang())
                if (dsDH.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLKhachHang());
        }

        private void btnQLDSNhaCungCap_Click(object sender, EventArgs e)
        {
            using (QLNhaCungCap dsDH = new QLNhaCungCap())
                if (dsDH.ShowDialog() == DialogResult.OK)
                    Application.Run(new QLNhaCungCap());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }

        private void DanhMucQuanLy_Load(object sender, EventArgs e)
        {

        }
    }
}
