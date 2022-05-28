using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.SpaceTeam.DanhMucNV
{
    public partial class DoanhThu : Form
    {
        private ContextNhat db = new ContextNhat();

        public DoanhThu()
        {
            InitializeComponent();
        }

        private string tongtienNgayBan;
        private string tongtienCN;
        private string tongtienNV;
        private string tongtienTheoNam;
        private string tongtienTheoThang;

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            LoadComboboxCN();
            LoadComboboxNhanVien();
            GetDataGridViewNgay(pageNumber, numberRecord);
            GetDataGridViewThang(pageNumber, numberRecord);
            GetDataGridViewNam(pageNumber, numberRecord);
            GetDataGridView(pageNumber,numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNhanVien.Text = "";
            txtTongTienNV.Text = "0";
            txtTongTienCN.Text = "0";
            txtTongTien.Text = "0";
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

        #endregion Load Combobox CN

        #region Load Combobox NhanVien

        public void LoadComboboxNhanVien()
        {
            try
            {
                List<NHANVIEN> listNhanVien = db.NHANVIENs.ToList();
                cmbTenNhanVien.DataSource = listNhanVien;
                cmbTenNhanVien.ValueMember = "MANV";
                cmbTenNhanVien.DisplayMember = "HOTEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Load Combobox NhanVien

        #region TK cmb Chi Nhanh

        private void TKcmbCN()
        {
            DateTime TKNgayBanTuNgay = dateTimeTuNgay.Value;
            DateTime TKNgayBanDenNgay = dateTimeDenNgay.Value;
            var employeeData = from h in db.HOADONs
                               join c in db.CHINHANHs
                               on h.MACHINHANH equals c.MACHINHANH
                               join k in db.KHACHHANGs
                               on h.MAKH equals k.MAKH
                               join nv in db.NHANVIENs
                               on h.MANV equals nv.MANV
                               where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                               && TKNgayBanTuNgay <= h.NGAYTAO
                               && h.NGAYTAO <= TKNgayBanDenNgay
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               };
            var ListEmployee = employeeData.ToList();
            dataGridView.DataSource = ListEmployee;
            dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện Thoại";
            dataGridView.Columns[4].HeaderText = "Ghi chú";
            dataGridView.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridView.Columns[6].HeaderText = "Mã nhân viên";
            dataGridView.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridView.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridView.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 130;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 120;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 140;
            dataGridView.Columns[8].Width = 120;
            dataGridView.Columns[9].Width = 90;
            var employt = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienCN = employt.ToString();
            var employt1 = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNgayBan = employt.ToString();
        }

        #endregion TK cmb Chi Nhanh

        #region TK cmb Nhan Vien

        private void TKcmbNV()
        {
            DateTime TKNgayBanTuNgay = dateTimeTuNgay.Value;
            DateTime TKNgayBanDenNgay = dateTimeDenNgay.Value;
            var employeeData = from h in db.HOADONs
                               join c in db.CHINHANHs
                               on h.MACHINHANH equals c.MACHINHANH
                               join k in db.KHACHHANGs
                               on h.MAKH equals k.MAKH
                               join nv in db.NHANVIENs
                               on h.MANV equals nv.MANV
                               where nv.HOTEN == cmbTenNhanVien.Text
                               && TKNgayBanTuNgay <= h.NGAYTAO
                               && h.NGAYTAO <= TKNgayBanDenNgay
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               };

            var ListEmployee = employeeData.ToList();
            dataGridView.DataSource = ListEmployee;
            dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện Thoại";
            dataGridView.Columns[4].HeaderText = "Ghi chú";
            dataGridView.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridView.Columns[6].HeaderText = "Mã nhân viên";
            dataGridView.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridView.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridView.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 130;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 120;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 140;
            dataGridView.Columns[8].Width = 120;
            dataGridView.Columns[9].Width = 90;
            var employt = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNV = employt.ToString();
            var employt1 = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNgayBan = employt.ToString();
        }

        #endregion TK cmb Nhan Vien

        #region TK cmb Chi Nhanh vs NhanVien

        private void TKcmbCN_cmbNV()
        {
            DateTime TKNgayBanTuNgay = dateTimeTuNgay.Value;
            DateTime TKNgayBanDenNgay = dateTimeDenNgay.Value;
            var employeeData = from h in db.HOADONs
                               join c in db.CHINHANHs
                               on h.MACHINHANH equals c.MACHINHANH
                               join k in db.KHACHHANGs
                               on h.MAKH equals k.MAKH
                               join nv in db.NHANVIENs
                               on h.MANV equals nv.MANV
                               where c.TENCHINHANH.Equals(cmbChiNhanh.Text)
                               && nv.HOTEN.Equals(cmbTenNhanVien.Text)
                               && TKNgayBanTuNgay <= h.NGAYTAO
                               && h.NGAYTAO <= TKNgayBanDenNgay
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               };
            var employt = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNV = employt.ToString();
            var employt1 = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNgayBan = employt.ToString();
            var employt2 = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienCN = employt.ToString();
            var ListEmployee = employeeData.ToList();
            dataGridView.DataSource = ListEmployee;
            dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện Thoại";
            dataGridView.Columns[4].HeaderText = "Ghi chú";
            dataGridView.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridView.Columns[6].HeaderText = "Mã nhân viên";
            dataGridView.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridView.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridView.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 130;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 120;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 140;
            dataGridView.Columns[8].Width = 120;
            dataGridView.Columns[9].Width = 90;
        }

        #endregion TK cmb Chi Nhanh vs NhanVien

        #region TK cmb Chi Nhanh vs NhanVien Null
        private void TKcmbCN_cmbNV_null()
        {
            DateTime TKNgayBanTuNgay = dateTimeTuNgay.Value;
            DateTime TKNgayBanDenNgay = dateTimeDenNgay.Value;
            var employeeData = from h in db.HOADONs
                               join c in db.CHINHANHs
                               on h.MACHINHANH equals c.MACHINHANH
                               join k in db.KHACHHANGs
                               on h.MAKH equals k.MAKH
                               join nv in db.NHANVIENs
                               on h.MANV equals nv.MANV
                               where TKNgayBanTuNgay <= h.NGAYTAO
                               && h.NGAYTAO <= TKNgayBanDenNgay
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               };
            var ListEmployee = employeeData.ToList();
            dataGridView.DataSource = ListEmployee;
            dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện Thoại";
            dataGridView.Columns[4].HeaderText = "Ghi chú";
            dataGridView.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridView.Columns[6].HeaderText = "Mã nhân viên";
            dataGridView.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridView.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridView.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridView.Columns[0].Width = 30;
            dataGridView.Columns[1].Width = 130;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 120;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 140;
            dataGridView.Columns[8].Width = 120;
            dataGridView.Columns[9].Width = 90;
        }

        #endregion TK cmb Chi Nhanh vs NhanVien Null

        #region button Tim Kiem Theo NB
        public void btnTimKiemNB_Click()
        {
            DateTime TKNgayBanTheoNgay = dateTimePickerTheoNgay.Value;
            var employeeData = from h in db.HOADONs
                               join c in db.CHINHANHs
                               on h.MACHINHANH equals c.MACHINHANH
                               join k in db.KHACHHANGs
                               on h.MAKH equals k.MAKH
                               join nv in db.NHANVIENs
                               on h.MANV equals nv.MANV
                               where h.NGAYTAO.Day == TKNgayBanTheoNgay.Day
                               && h.NGAYTAO.Month == TKNgayBanTheoNgay.Month
                               && h.NGAYTAO.Year == TKNgayBanTheoNgay.Year
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               };
            var employt = employeeData.Sum(h => h.TONGTHUCTHU);
            tongtienNgayBan = employt.ToString();
            var ListEmployee = employeeData.ToList();
            dataGridViewTheoNgay.DataSource = ListEmployee;
            dataGridViewTheoNgay.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoNgay.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoNgay.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoNgay.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoNgay.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoNgay.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoNgay.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoNgay.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoNgay.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoNgay.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoNgay.Columns[0].Width = 50;
            dataGridViewTheoNgay.Columns[1].Width = 130;
            dataGridViewTheoNgay.Columns[2].Width = 120;
            dataGridViewTheoNgay.Columns[3].Width = 90;
            dataGridViewTheoNgay.Columns[4].Width = 120;
            dataGridViewTheoNgay.Columns[5].Width = 100;
            dataGridViewTheoNgay.Columns[6].Width = 40;
            dataGridViewTheoNgay.Columns[7].Width = 140;
            dataGridViewTheoNgay.Columns[8].Width = 120;
            dataGridViewTheoNgay.Columns[9].Width = 90;
        }

        #endregion button Tim Kiem Theo NB

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (cmbChiNhanh.Text == "")
            {
                TKcmbNV();
                txtTongTienNV.Text = tongtienNV;
                txtTongTienCN.Text = "0";
            }
            if (cmbTenNhanVien.Text == "")
            {
                TKcmbCN();
                txtTongTienCN.Text = tongtienCN;
                txtTongTienNV.Text = "0";
            }
            if (cmbChiNhanh.Text != "" && cmbTenNhanVien.Text != "")
            {
                TKcmbCN_cmbNV();
                txtTongTienCN.Text = tongtienCN;
                txtTongTienNV.Text = tongtienNV;
            }
            if (cmbChiNhanh.Text == "" && cmbTenNhanVien.Text == "")
            {
                TKcmbCN_cmbNV_null();
                txtTongTienNV.Text = "0";
                txtTongTienCN.Text = "0";
            }
        }
        private void TienTeNB(object sender, EventArgs e)
        {
            txtTongTien.Text = string.Format("{0:0,0}", decimal.Parse(txtTongTien.Text));
            txtTongTien.SelectionStart = txtTongTien.Text.Length;
        }

        private void txtTongTienCN_TextChanged(object sender, EventArgs e)
        {
            txtTongTienCN.Text = string.Format("{0:0,0}", decimal.Parse(txtTongTienCN.Text));
            txtTongTienCN.SelectionStart = txtTongTienCN.Text.Length;
        }

        private void txtTongTienNV_TextChanged(object sender, EventArgs e)
        {
            txtTongTienNV.Text = string.Format("{0:0,0}", decimal.Parse(txtTongTienNV.Text));
            txtTongTienNV.SelectionStart = txtTongTienNV.Text.Length;
        }

        #region Xem Theo Thang

        public void XemTheoThang()
        {
            var TKThangData = from h in db.HOADONs
                              join c in db.CHINHANHs
                              on h.MACHINHANH equals c.MACHINHANH
                              join k in db.KHACHHANGs
                              on h.MAKH equals k.MAKH
                              join nv in db.NHANVIENs
                              on h.MANV equals nv.MANV
                              where h.NGAYTAO.Month.Equals((int)numericThang.Value)
                              && h.NGAYTAO.Year.Equals((int)numericNam.Value)
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
                                  c.TENCHINHANH,
                                  h.TONGTHUCTHU
                              };
            var employt = TKThangData.Sum(h => h.TONGTHUCTHU);
            tongtienTheoThang = employt.ToString();
            var ListTimKiemThang = TKThangData.ToList();
            dataGridViewTheoThang.DataSource = ListTimKiemThang;
            dataGridViewTheoThang.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoThang.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoThang.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoThang.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoThang.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoThang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoThang.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoThang.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoThang.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoThang.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoThang.Columns[0].Width = 30;
            dataGridViewTheoThang.Columns[1].Width = 130;
            dataGridViewTheoThang.Columns[2].Width = 120;
            dataGridViewTheoThang.Columns[3].Width = 90;
            dataGridViewTheoThang.Columns[4].Width = 120;
            dataGridViewTheoThang.Columns[5].Width = 100;
            dataGridViewTheoThang.Columns[6].Width = 40;
            dataGridViewTheoThang.Columns[7].Width = 140;
            dataGridViewTheoThang.Columns[8].Width = 120;
            dataGridViewTheoThang.Columns[9].Width = 90;
        }

        #endregion Xem Theo Thang

        #region Xem Theo Nam

        public void XemTheoNam()
        {
            var TKNamData = from h in db.HOADONs
                            join c in db.CHINHANHs
                            on h.MACHINHANH equals c.MACHINHANH
                            join k in db.KHACHHANGs
                            on h.MAKH equals k.MAKH
                            join nv in db.NHANVIENs
                            on h.MANV equals nv.MANV
                            where h.NGAYTAO.Year.Equals((int)numericNam1.Value)
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
                                c.TENCHINHANH,
                                h.TONGTHUCTHU
                            };
            var employt = TKNamData.Sum(h => h.TONGTHUCTHU);
            tongtienTheoNam = employt.ToString();
            var ListTimKiemNam = TKNamData.ToList();
            dataGridViewTheoNam.DataSource = ListTimKiemNam;
            dataGridViewTheoNam.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoNam.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoNam.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoNam.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoNam.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoNam.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoNam.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoNam.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoNam.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoNam.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoNam.Columns[0].Width = 30;
            dataGridViewTheoNam.Columns[1].Width = 130;
            dataGridViewTheoNam.Columns[2].Width = 120;
            dataGridViewTheoNam.Columns[3].Width = 90;
            dataGridViewTheoNam.Columns[4].Width = 120;
            dataGridViewTheoNam.Columns[5].Width = 100;
            dataGridViewTheoNam.Columns[6].Width = 40;
            dataGridViewTheoNam.Columns[7].Width = 140;
            dataGridViewTheoNam.Columns[8].Width = 120;
            dataGridViewTheoNam.Columns[9].Width = 90;
        }

        #endregion Xem Theo Nam

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
            var employeeData = (from h in db.HOADONs
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            var ListEmployee = employeeData.ToList();
            dataGridView.DataSource = ListEmployee;
            dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện Thoại";
            dataGridView.Columns[4].HeaderText = "Ghi chú";
            dataGridView.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridView.Columns[6].HeaderText = "Mã nhân viên";
            dataGridView.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridView.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridView.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 130;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 90;
            dataGridView.Columns[4].Width = 120;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 40;
            dataGridView.Columns[7].Width = 140;
            dataGridView.Columns[8].Width = 120;
            dataGridView.Columns[9].Width = 90;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            GetDataGridView(pageNumber, numberRecord);
            cmbChiNhanh.Text = "";
            cmbTenNhanVien.Text = "";
            txtTongTien.Text = "";
            txtTongTienCN.Text = "";
            txtTongTienNV.Text = "";
        }

        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            btnTimKiemNB_Click();
            txtTongTien.Text = tongtienNgayBan;
        }

        private void btnTaiLaiNgay_Click(object sender, EventArgs e)
        {
            GetDataGridViewNgay(pageNumber, numberRecord);
            txtTongTien.Text = "";
        }

        private void btnXemThang_Click(object sender, EventArgs e)
        {
            XemTheoThang();
            txtTongTienThang.Text = tongtienTheoThang;
        }

        private void btnTaiLaiThang_Click(object sender, EventArgs e)
        {
            GetDataGridViewThang(pageNumber, numberRecord);
            txtTongTienThang.Text = "";
        }

        private void btnXemNam_Click(object sender, EventArgs e)
        {
            XemTheoNam();
            txtTongTienNam.Text = tongtienTheoNam;
        }

        private void btnTaiLaiNam_Click(object sender, EventArgs e)
        {
            GetDataGridViewNam(pageNumber, numberRecord);
            txtTongTienNam.Text = "";
        }

        private void btnFirstsDay_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            GetDataGridViewNgay(pageNumber, numberRecord);
            txbPageBillDay.Text = pageNumber.ToString();
        }

        private void btnFirstsMonth_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            GetDataGridViewThang(pageNumber, numberRecord);
            txbPageBillMonth.Text = pageNumber.ToString();
        }

        private void btnFirstsYear_Click(object sender, EventArgs e)
        {
            pageNumber = 1;
            GetDataGridViewNam(pageNumber, numberRecord);
            txbPageBillYear.Text = pageNumber.ToString();
        }

        private void btnPrevioursDay_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                GetDataGridViewNgay(pageNumber, numberRecord);
                txbPageBillDay.Text = pageNumber.ToString();
            }
        }

        private void btnPrevioursMonth_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                GetDataGridViewThang(pageNumber, numberRecord);
                txbPageBillMonth.Text = pageNumber.ToString();
            }
        }

        private void btnPrevioursYear_Click(object sender, EventArgs e)
        {
            if (pageNumber - 1 > 0)
            {
                pageNumber--;
                GetDataGridViewNam(pageNumber, numberRecord);
                txbPageBillYear.Text = pageNumber.ToString();
            }
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            int totalRecord = db.CHITIETHDs.Count();
            if (pageNumber - 1 < (totalRecord / numberRecord))
            {
                pageNumber++;
                GetDataGridViewNgay(pageNumber, numberRecord);
                txbPageBillDay.Text = pageNumber.ToString();
            }
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            int totalRecord = db.CHITIETHDs.Count();
            if (pageNumber - 1 < (totalRecord / numberRecord))
            {
                pageNumber++;
                GetDataGridViewThang(pageNumber, numberRecord);
                txbPageBillMonth.Text = pageNumber.ToString();
            }
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            int totalRecord = db.CHITIETHDs.Count();
            if (pageNumber - 1 < (totalRecord / numberRecord))
            {
                pageNumber++;
                GetDataGridViewNam(pageNumber, numberRecord);
                txbPageBillYear.Text = pageNumber.ToString();
            }
        }

        private void btnLastDay_Click(object sender, EventArgs e)
        {
            int sumRecord = db.CHITIETHDs.Count();

            int pageNumber = sumRecord / 10;

            if (sumRecord % 10 != 0)
                pageNumber++;
            GetDataGridViewNgay(pageNumber, numberRecord);
            txbPageBillDay.Text = pageNumber.ToString();
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            int sumRecord = db.CHITIETHDs.Count();

            int pageNumber = sumRecord / 10;

            if (sumRecord % 10 != 0)
                pageNumber++;
            GetDataGridViewThang(pageNumber, numberRecord);
            txbPageBillMonth.Text = pageNumber.ToString();
        }

        private void btnLastYear_Click(object sender, EventArgs e)
        {
            int sumRecord = db.CHITIETHDs.Count();

            int pageNumber = sumRecord / 10;

            if (sumRecord % 10 != 0)
                pageNumber++;
            GetDataGridViewNam(pageNumber, numberRecord);
            txbPageBillYear.Text = pageNumber.ToString();
        }
        #region Load DataGridView Danh Sach Đơn Hàng Theo Ngay
        public void GetDataGridViewNgay(int page, int recordNum)
        {
            var employeeData = (from h in db.HOADONs
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
                                    c.TENCHINHANH,
                                    h.TONGTHUCTHU
                                }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();

            var ListEmployee = employeeData.ToList();
            dataGridViewTheoNgay.DataSource = ListEmployee;
            dataGridViewTheoNgay.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoNgay.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoNgay.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoNgay.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoNgay.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoNgay.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoNgay.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoNgay.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoNgay.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoNgay.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoNgay.Columns[0].Width = 50;
            dataGridViewTheoNgay.Columns[1].Width = 130;
            dataGridViewTheoNgay.Columns[2].Width = 120;
            dataGridViewTheoNgay.Columns[3].Width = 90;
            dataGridViewTheoNgay.Columns[4].Width = 120;
            dataGridViewTheoNgay.Columns[5].Width = 100;
            dataGridViewTheoNgay.Columns[6].Width = 40;
            dataGridViewTheoNgay.Columns[7].Width = 140;
            dataGridViewTheoNgay.Columns[8].Width = 120;
            dataGridViewTheoNgay.Columns[9].Width = 90;
            txbPageBill.Text = pageNumber.ToString();
        }

        #endregion Load DataGridView Danh Sach Đơn Hàng Theo Ngày

        #region Load DataGridView Danh Sach Đơn Hàng Theo Thang

        public void GetDataGridViewThang(int page, int recordNum)
        {
            var employeeData = (from h in db.HOADONs
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
                                   c.TENCHINHANH,
                                   h.TONGTHUCTHU
                               }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();

            var ListEmployee = employeeData.ToList();
            dataGridViewTheoThang.DataSource = ListEmployee;
            dataGridViewTheoThang.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoThang.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoThang.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoThang.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoThang.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoThang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoThang.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoThang.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoThang.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoThang.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoThang.Columns[0].Width = 50;
            dataGridViewTheoThang.Columns[1].Width = 130;
            dataGridViewTheoThang.Columns[2].Width = 120;
            dataGridViewTheoThang.Columns[3].Width = 90;
            dataGridViewTheoThang.Columns[4].Width = 120;
            dataGridViewTheoThang.Columns[5].Width = 100;
            dataGridViewTheoThang.Columns[6].Width = 40;
            dataGridViewTheoThang.Columns[7].Width = 140;
            dataGridViewTheoThang.Columns[8].Width = 120;
            dataGridViewTheoThang.Columns[9].Width = 90;
            txbPageBill.Text = pageNumber.ToString();
        }

        #endregion Load DataGridView Danh Sach Đơn Hàng Theo Thang

        #region Load DataGridView Danh Sach Đơn Hàng Theo Nam

        public void GetDataGridViewNam(int page, int recordNum)
        {
            var TKNamData = (from h in db.HOADONs
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
                                c.TENCHINHANH,
                                h.TONGTHUCTHU
                            }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            var ListTimKiemNam = TKNamData.ToList();
            dataGridViewTheoNam.DataSource = ListTimKiemNam;
            dataGridViewTheoNam.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewTheoNam.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridViewTheoNam.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewTheoNam.Columns[3].HeaderText = "Điện Thoại";
            dataGridViewTheoNam.Columns[4].HeaderText = "Ghi chú";
            dataGridViewTheoNam.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridViewTheoNam.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewTheoNam.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridViewTheoNam.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridViewTheoNam.Columns[9].HeaderText = "Tổng Thu Thực";
            dataGridViewTheoNam.Columns[0].Width = 30;
            dataGridViewTheoNam.Columns[1].Width = 130;
            dataGridViewTheoNam.Columns[2].Width = 120;
            dataGridViewTheoNam.Columns[3].Width = 90;
            dataGridViewTheoNam.Columns[4].Width = 120;
            dataGridViewTheoNam.Columns[5].Width = 100;
            dataGridViewTheoNam.Columns[6].Width = 40;
            dataGridViewTheoNam.Columns[7].Width = 140;
            dataGridViewTheoNam.Columns[8].Width = 120;
            dataGridViewTheoNam.Columns[9].Width = 90;
            txbPageBill.Text = pageNumber.ToString();
        }

        #endregion Load DataGridView Danh Sach Đơn Hàng Theo Nam
    }
}