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
    public partial class DanhSachHangHoaDaBan : Form
    {
        ContextNhat db = new ContextNhat();
        public DanhSachHangHoaDaBan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DanhSachHangHoaDaBan_Load(object sender, EventArgs e)
        {
            LoadComboboxCN();
            LoadComboboxNhanVien();
            LoadComboboxSP();
            GetDataGridView(pageNumber,numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNV.Text = "";
            cmbTenSP.Text = "";
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

        #region Load Combobox SP
        public void LoadComboboxSP()
        {
            try
            {
                List<HANGHOA> listHangHoa = db.HANGHOAs.ToList();
                cmbTenSP.DataSource = listHangHoa;
                cmbTenSP.ValueMember = "MAHH";
                cmbTenSP.DisplayMember = "TENHH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion 


        #region Ham Tim Kiem theo SP
        void TKcmbSP()
        {
            string tenHH = cmbTenSP.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenHH == hh.TENHH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen

                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo NV
        void TKcmbNV()
        {
            string tenNV = cmbTenNV.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenNV == nv.HOTEN
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo CN
        void TKcmbCN()
        {
            string tenCN = cmbChiNhanh.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenCN == cn.TENCHINHANH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH

                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo NB
        void TKtheoNB()
        {
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo SP vs NV
        void TKcmbSP_NV()
        {
            string tenHH = cmbTenSP.Text;
            string tenNV = cmbTenNV.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenNV == nv.HOTEN
                               && tenHH == hh.TENHH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo SP vs CN
        void TKcmbSP_CN()
        {
            string tenHH = cmbTenSP.Text;
            string tenCN = cmbChiNhanh.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenCN == cn.TENCHINHANH
                               && tenHH == hh.TENHH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo NV vs CN
        void TKcmbNV_CN()
        {
            string tenCN = cmbChiNhanh.Text;
            string tenNV = cmbTenNV.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenNV == nv.HOTEN
                               && tenCN == cn.TENCHINHANH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }
        #endregion

        #region Ham Tim Kiem theo Ca 3 SP vs NV vs CN
        void TKcmbCa3()
        {
            string tenCN = cmbChiNhanh.Text;
            string tenHH = cmbTenSP.Text;
            string tenNV = cmbTenNV.Text;
            DateTime TKNgayBanTu = dtTKNgayBanTu.Value;
            DateTime TKNgayBanDen = dtTKNgayBanDen.Value;
            var employeeData = from ct in db.CHITIETHDs
                               join hh in db.HANGHOAs
                               on ct.MAHH equals hh.MAHH
                               where ct.MAHH == hh.MAHH
                               join ncc in db.NHACUNGCAPs
                               on hh.MANCC equals ncc.MANCC
                               join l in db.LOAIs
                               on hh.MALOAI equals l.MALOAI
                               join hd in db.HOADONs
                               on ct.MAHD equals hd.MAHD
                               join cn in db.CHINHANHs
                               on hd.MACHINHANH equals cn.MACHINHANH
                               join nv in db.NHANVIENs
                               on hd.MANV equals nv.MANV
                               where tenNV == nv.HOTEN
                               && tenCN == cn.TENCHINHANH
                               && tenHH == hh.TENHH
                               && TKNgayBanTu < hd.NGAYTAO
                               && hd.NGAYTAO < TKNgayBanDen
                               select new
                               {
                                   ct.MAHH,
                                   hh.TENHH,
                                   ct.SOLUONG,
                                   l.TENLOAI,
                                   hh.DONGIA,
                                   hh.GIAMGIA,
                                   hh.MOTA,
                                   ncc.TENCONGTY,
                                   nv.HOTEN,
                                   cn.TENCHINHANH
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewHHDB.DataSource = ListEmployee;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
        }

        #endregion
        #region btn Tim Kiem
        private void btnTK_Click(object sender, EventArgs e)
        {
            if (cmbChiNhanh.Text == "")
            {
                TKcmbSP_NV();
            }
            if (cmbTenNV.Text == "")
            {
                TKcmbSP_CN();

            }
            if (cmbTenSP.Text == "")
            {
                TKcmbNV_CN();
            }
            if (cmbChiNhanh.Text == "" && cmbTenNV.Text == "")
            {
                TKcmbSP();
            }
            if (cmbChiNhanh.Text == "" && cmbTenSP.Text == "")
            {
                TKcmbNV();
            }
            if (cmbTenNV.Text == "" && cmbTenSP.Text == "")
            {
                TKcmbCN();
            }
            if (cmbChiNhanh.Text == "" && cmbTenSP.Text == "" && cmbTenNV.Text == "")
            {
                TKtheoNB();
            }
            if (cmbChiNhanh.Text != "" && cmbTenSP.Text != "" && cmbTenNV.Text != "")
            {
                TKcmbCa3();
            }
        }

        #endregion

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            GetDataGridView(pageNumber,numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNV.Text = "";
            cmbTenSP.Text = "";
            dtTKNgayBanTu.Value = new DateTime(2018, 1, 1);
            dtTKNgayBanDen.Value = new DateTime(2020, 9, 1);
        }

        int pageNumber = 1;
        int numberRecord = 10;

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
            int totalRecord = db.CHITIETHDs.Count();
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
            int sumRecord = db.CHITIETHDs.Count();

            int pageNumber = sumRecord / 10;

            if (sumRecord % 10 != 0)
                pageNumber++;
            GetDataGridView(pageNumber, numberRecord);
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion

        #region GetDataGridView
        void GetDataGridView(int page, int recordNum)
        {
            var hangHoa = (from ct in db.CHITIETHDs
                           join hh in db.HANGHOAs
                           on ct.MAHH equals hh.MAHH
                           where ct.MAHH == hh.MAHH
                           join ncc in db.NHACUNGCAPs
                           on hh.MANCC equals ncc.MANCC
                           join l in db.LOAIs
                           on hh.MALOAI equals l.MALOAI
                           join hd in db.HOADONs
                           on ct.MAHD equals hd.MAHD
                           join cn in db.CHINHANHs
                           on hd.MACHINHANH equals cn.MACHINHANH
                           join nv in db.NHANVIENs
                           on hd.MANV equals nv.MANV
                           select new
                           {
                               ct.MAHH,
                               hh.TENHH,
                               ct.SOLUONG,
                               l.TENLOAI,
                               hh.DONGIA,
                               hh.GIAMGIA,
                               hh.MOTA,
                               ncc.TENCONGTY,
                               nv.HOTEN,
                               cn.TENCHINHANH
                           }).OrderByDescending(i => i.MAHH).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            dataGridViewHHDB.DataSource = hangHoa;
            dataGridViewHHDB.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewHHDB.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewHHDB.Columns[2].HeaderText = "Số Lượng";
            dataGridViewHHDB.Columns[3].HeaderText = "Tên Loại";
            dataGridViewHHDB.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewHHDB.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewHHDB.Columns[6].HeaderText = "Mô Tả";
            dataGridViewHHDB.Columns[7].HeaderText = "Tên Công Ty";
            dataGridViewHHDB.Columns[8].HeaderText = "Tên Nhân Viên";
            dataGridViewHHDB.Columns[9].HeaderText = "Tên Chi Nhánh";
            dataGridViewHHDB.Columns[0].Width = 50;
            dataGridViewHHDB.Columns[1].Width = 130;
            dataGridViewHHDB.Columns[2].Width = 50;
            dataGridViewHHDB.Columns[3].Width = 150;
            dataGridViewHHDB.Columns[4].Width = 80;
            dataGridViewHHDB.Columns[5].Width = 50;
            dataGridViewHHDB.Columns[6].Width = 150;
            dataGridViewHHDB.Columns[7].Width = 140;
            dataGridViewHHDB.Columns[8].Width = 150;
            dataGridViewHHDB.Columns[9].Width = 140;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion
    }
}
