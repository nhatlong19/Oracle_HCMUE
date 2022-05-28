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

namespace SpaceTeam_Oracle.SpaceTeam.DanhMucNV
{
    public partial class DanhSachDonHang : Form
    {
        ContextNhat db = new ContextNhat();
        private string TenDN { get; set; }
        public DanhSachDonHang(string tenDN)
        {
            InitializeComponent();
            TenDN = tenDN;
        }

        int pageNumber = 1;
        int numberRecord = 10;
        private void DanhSachDonHang_Load(object sender, EventArgs e)
        {
            LoadComboboxCN();
            LoadComboboxNhanVien();
            GetDataGridView(pageNumber, numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNV.Text = "";
        }
        #region Load Combobox CN
        public void LoadComboboxCN()
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
        #region Load Combobox NhanVien 

        public void LoadComboboxNhanVien()
        {
            try
            {
                List<NHANVIEN> listNhanVien = db.NHANVIENs.ToList();
                cmbTenNV.DataSource = listNhanVien;
                cmbTenNV.ValueMember = "MANV";
                cmbTenNV.DisplayMember = "HOTEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region button Xem
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbChiNhanh.Text == "")
            {
                TKcmbNV();
            }
            if (cmbTenNV.Text == "")
            {
                TKcmbCN();
            }
            if(cmbChiNhanh.Text != "" && cmbTenNV.Text != "")
            {
                TKcmbCN_cmbNV();
            }
        }
        #endregion
        #region TK cmb Chi Nhanh
        void TKcmbCN()
        {
            var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN == TenDN);
            if (user.MACHUCVU == 1)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if(user.MACHUCVU == 20)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if(user.MACHUCVU == 21)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   && h.MANV == user.MANV
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
        }
        #endregion
        #region TK cmb Nhan Vien
        void TKcmbNV()
        {
            var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN == TenDN);
            if (user.MACHUCVU == 1)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where nv.HOTEN == cmbTenNV.Text
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if (user.MACHUCVU == 20)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where nv.HOTEN == cmbTenNV.Text
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if (user.MACHUCVU == 21)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where nv.HOTEN == cmbTenNV.Text
                                   && h.MANV == user.MANV
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
        }
        #endregion
        #region TK cmb Chi Nhanh vs NhanVien
        void TKcmbCN_cmbNV()
        {
            var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN == TenDN);
            if (user.MACHUCVU == 1)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   && nv.HOTEN.Equals(cmbTenNV.Text)
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if (user.MACHUCVU == 20)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   && nv.HOTEN.Equals(cmbTenNV.Text)
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
            if (user.MACHUCVU == 21)
            {
                var employeeData = from h in db.HOADONs
                                   join c in db.CHINHANHs
                                   on h.MACHINHANH equals c.MACHINHANH
                                   join k in db.KHACHHANGs
                                   on h.MAKH equals k.MAKH
                                   join nv in db.NHANVIENs
                                   on h.MANV equals nv.MANV
                                   where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                                   && nv.HOTEN.Equals(cmbTenNV.Text)
                                   && h.MANV == user.MANV
                                   && h.MACHINHANH == user.MACHINHANH
                                   select new
                                   {
                                       h.MAHD,
                                       k.HOTEN,
                                       k.DIACHI,
                                       k.DIENTHOAI,
                                       h.GHICHU,
                                       h.NGAYTAO,
                                       nv.MANV,
                                       TENNV = nv.HOTEN,
                                       c.TENCHINHANH
                                   };
                var ListEmployee = employeeData.ToList();
                dataGridViewDonHang.DataSource = ListEmployee;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
            }
        }
        #endregion
        #region button Tai Lai
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            GetDataGridView(pageNumber, numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNV.Text = "";
        }
        #endregion
        #region Load DataGridView CT Hóa Đơn
        private void GetdataGridView1(int maHD)
        {
            var employeeData = (from hd in db.HOADONs
                                join ct in db.CHITIETHDs
                                on hd.MAHD equals ct.MAHD
                                join hh in db.HANGHOAs
                                on ct.MAHH equals hh.MAHH
                                where ct.MAHD == maHD
                                select new
                                {
                                    ct.MAHD,
                                    ct.MAHH,
                                    hh.TENHH,
                                    ct.SOLUONG,
                                    hh.DONGIA,
                                    hh.GIAMGIA,
                                    TONGTIEN = hh.DONGIA * ct.SOLUONG
                                }).OrderBy(i => i.MAHH);
            var employt = employeeData.Sum(c => c.TONGTIEN);
            //txtTongTien.Text = employt.ToString();
            var ListEmployee = employeeData.ToList();
            dataGridView1.DataSource = ListEmployee;
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[3].HeaderText = "Số Lượng ";
            dataGridView1.Columns[4].HeaderText = "Đơn Giá";
            dataGridView1.Columns[5].HeaderText = "Giảm Giá";
            dataGridView1.Columns[6].HeaderText = "Thành Tiền";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 40;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 100;
        }
        #endregion


        private void dataGridViewDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewDonHang.Rows[e.RowIndex];
                GetdataGridView1(int.Parse(row.Cells[0].Value.ToString()));
            }
        }


        #region Firsts
        private void btnFirsts_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            GetDataGridView(pageNumber, numberRecord);
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion

        #region Previours
        private void btnPreviours_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                GetDataGridView(pageNumber, numberRecord);
                txbPageBill.Text = pageNumber.ToString();
            }
        }
        #endregion

        #region Next
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecord = db.HOADONs.Count();
            if (pageNumber - 1 < (totalRecord / numberRecord))
            {
                pageNumber++;
                GetDataGridView(pageNumber, numberRecord);
                txbPageBill.Text = pageNumber.ToString();
            }
        }
        #endregion

        #region btnLast
        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = db.HOADONs.Count();

            int pageNumber = sumRecord / numberRecord;

            if (sumRecord % 5 != 0)
                pageNumber++;
            GetDataGridView(pageNumber, numberRecord);
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion

        #region GetDataGridView
        void GetDataGridView(int page, int recordNum)
        {
            var user = db.NHANVIENs.FirstOrDefault(nv => nv.TENDN == TenDN);
            if (user.MACHUCVU == 1)
            {
                var listDH = (from h in db.HOADONs
                             join c in db.CHINHANHs
                             on h.MACHINHANH equals c.MACHINHANH
                             join k in db.KHACHHANGs
                             on h.MAKH equals k.MAKH
                             join nv in db.NHANVIENs
                             on h.MANV equals nv.MANV
                             select new
                             {
                                 h.MAHD,
                                 k.HOTEN,
                                 k.DIACHI,
                                 k.DIENTHOAI,
                                 h.GHICHU,
                                 h.NGAYTAO,
                                 nv.MANV,
                                 TENNV = nv.HOTEN,
                                 c.TENCHINHANH
                             }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                dataGridViewDonHang.DataSource = listDH;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
                txbPageBill.Text = pageNumber.ToString();
            }

            if (user.MACHUCVU == 20)
            {
                var listDH = (from h in db.HOADONs
                              join c in db.CHINHANHs
                              on h.MACHINHANH equals c.MACHINHANH
                              join k in db.KHACHHANGs
                              on h.MAKH equals k.MAKH
                              join nv in db.NHANVIENs
                              on h.MANV equals nv.MANV
                              where h.MACHINHANH == user.MACHINHANH
                              select new
                              {
                                  h.MAHD,
                                  k.HOTEN,
                                  k.DIACHI,
                                  k.DIENTHOAI,
                                  h.GHICHU,
                                  h.NGAYTAO,
                                  nv.MANV,
                                  TENNV = nv.HOTEN,
                                  c.TENCHINHANH
                              }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                dataGridViewDonHang.DataSource = listDH;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
                txbPageBill.Text = pageNumber.ToString();
            }

            if (user.MACHUCVU == 21)
            {
                var listDH = (from h in db.HOADONs
                              join c in db.CHINHANHs
                              on h.MACHINHANH equals c.MACHINHANH
                              join k in db.KHACHHANGs
                              on h.MAKH equals k.MAKH
                              join nv in db.NHANVIENs
                              on h.MANV equals nv.MANV
                              where h.MANV == user.MANV && h.MACHINHANH == user.MACHINHANH
                              select new
                              {
                                  h.MAHD,
                                  k.HOTEN,
                                  k.DIACHI,
                                  k.DIENTHOAI,
                                  h.GHICHU,
                                  h.NGAYTAO,
                                  nv.MANV,
                                  TENNV = nv.HOTEN,
                                  c.TENCHINHANH
                              }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                dataGridViewDonHang.DataSource = listDH;
                dataGridViewDonHang.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridViewDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
                dataGridViewDonHang.Columns[2].HeaderText = "Địa chỉ";
                dataGridViewDonHang.Columns[3].HeaderText = "Điện Thoại";
                dataGridViewDonHang.Columns[4].HeaderText = "Ghi chú";
                dataGridViewDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
                dataGridViewDonHang.Columns[6].HeaderText = "Mã nhân viên";
                dataGridViewDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
                dataGridViewDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
                dataGridViewDonHang.Columns[0].Width = 30;
                dataGridViewDonHang.Columns[1].Width = 130;
                dataGridViewDonHang.Columns[2].Width = 120;
                dataGridViewDonHang.Columns[3].Width = 90;
                dataGridViewDonHang.Columns[4].Width = 120;
                dataGridViewDonHang.Columns[5].Width = 100;
                dataGridViewDonHang.Columns[6].Width = 40;
                dataGridViewDonHang.Columns[7].Width = 140;
                dataGridViewDonHang.Columns[8].Width = 120;
                txbPageBill.Text = pageNumber.ToString();
            }


        }
        #endregion
        
    }
}
