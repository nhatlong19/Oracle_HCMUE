
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace SpaceTeam_Oracle.SpaceTeam.DanhMucNV
{
    public partial class TaoDonHang : Form
    {
        ContextNhat db = new ContextNhat();

        public TaoDonHang()
        {
            InitializeComponent();
        }

        int pageNumber = 1;
        int numberRecord = 10;
        #region Load Form
        private void TaoDonHang_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.WindowState = FormWindowState.Normal;
            LoadComboboxLoai();
            LoadComboboxKhachHang();
            LoadComboboxNhanVien();
            LoadComboboxCN();
            GetDataGridView(pageNumber, numberRecord);
        }
        #endregion

        #region Load Combobox KhachHang 

        public void LoadComboboxKhachHang()
        {
            try
            {
                List<KHACHHANG> listKhachHang = db.KHACHHANGs.ToList();
                cmbMaKhachHang.DataSource = listKhachHang;
                cmbMaKhachHang.DisplayMember = "MAKH";
                cmbMaKhachHang.ValueMember = "MAKH";
                cmbTenKhachHang.DataSource = listKhachHang;
                cmbTenKhachHang.DisplayMember = "HOTEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load Combobox Loai

        public void LoadComboboxLoai()
        {
            try
            {
                List<LOAI> listLoai = db.LOAIs.ToList();
                cmbLoai.DataSource = listLoai;
                cmbLoai.DisplayMember = "TENLOAI";
                cmbLoai.ValueMember = "MALOAI";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

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
                cmbMaNV.DataSource = listNhanVien;
                cmbMaNV.DisplayMember = "MANV";
                cmbMaNV.ValueMember = "MANV";
                cmbTenNV.DataSource = listNhanVien;
                cmbTenNV.DisplayMember = "HOTEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Load Combobox HANGHOA

        public void LoadComboboxHangHoa(int maLoai)
        {
            try
            {
                List<HANGHOA> listHangHoa = db.HANGHOAs.Where(hh => hh.MALOAI == maLoai).ToList();
                cmbMaHang.DataSource = listHangHoa;
                cmbMaHang.ValueMember = "MAHH";
                cmbMaHang.DisplayMember = "TENHH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Hàm chuyển số thành chữ
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp break; 
                    switch ((mLen - i) % 9)
                    {
                        case 0:
                            mTemp = mTemp + " tỷ";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 6:
                            mTemp = mTemp + " triệu";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 3:
                            mTemp = mTemp + " nghìn";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        default:
                            switch ((mLen - i) % 3)
                            {
                                case 2:
                                    mTemp = mTemp + " trăm";
                                    break;
                                case 1:
                                    mTemp = mTemp + " mươi";
                                    break;
                            }
                            break;
                    }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", ""); //Loại bỏ trường hợp 00x 
            mTemp = mTemp.Replace("không mươi ", "linh "); //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }


        #endregion

        #region Hàm Get Id Hóa Đơn
        public int GetIdBill()
        {
            int dem = 1;
            while (true)
            {
                var c = db.HOADONs.Where(w => w.MAHD == dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }
        #endregion

        #region Selection Loai ra Hàng Hóa
        private void cmbLoai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int loai = int.Parse(cmbLoai.SelectedValue.ToString());
            LoadComboboxHangHoa(loai);
        }
        #endregion

        #region Selection MaHang ra thông tin hàng hóa
        private void cmbMaHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maHH = int.Parse(cmbMaHang.SelectedValue.ToString());
            GetHangHoa(maHH);
        }
        #endregion

        #region Hàm lấy thông tin hàng hóa
        public void GetHangHoa(int maHH)
        {
            var hh = db.HANGHOAs.Where(h => h.MAHH == maHH).SingleOrDefault();
            txtDonGia.Text = hh.DONGIA.ToString();
            txtGiamGia.Text = hh.GIAMGIA.ToString();
            txtTenHang.Text = hh.TENHH.ToString();
            
        }
        #endregion

        #region Hàm check ID Hóa đơn
        public int CheckIdHD(int idHD)
        {
            var hd = db.HOADONs.Where(h => h.MAHD == idHD).SingleOrDefault();
            if (hd != null)
                return hd.MAHD;
            return -1;
        }
        #endregion

        #region Cell Content Click
        private void dataGridDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridDonHang.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells[0].Value.ToString();

                cmbTenKhachHang.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtSoDienThoai.Text = row.Cells[3].Value.ToString();
                //txtGhiChu.Text = row.Cells[4].Value.ToString();
                dtNgayBan.Value = Convert.ToDateTime(row.Cells[5].Value.ToString());

                cmbMaNV.Text = row.Cells[6].Value.ToString();
                cmbTenNV.Text = row.Cells[7].Value.ToString();
                cmbChiNhanh.Text = row.Cells[8].Value.ToString();
                GetDataGridViewCTDH(int.Parse(row.Cells[0].Value.ToString()));
            }

        }
        #endregion

        

        #region Load DataGridView CT Hóa Đơn
        public void GetDataGridViewCTDH(int maHD)
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
            txtTongTien.Text = employt.ToString();
            var ListEmployee = employeeData.ToList();
            dataGridBillDetail.DataSource = ListEmployee;
            dataGridBillDetail.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridBillDetail.Columns[1].HeaderText = "Mã hàng hóa";
            dataGridBillDetail.Columns[2].HeaderText = "Tên hàng hóa";
            dataGridBillDetail.Columns[3].HeaderText = "Số Lượng ";
            dataGridBillDetail.Columns[4].HeaderText = "Đơn Giá";
            dataGridBillDetail.Columns[5].HeaderText = "Giảm Giá";
            dataGridBillDetail.Columns[6].HeaderText = "Thành Tiền";
            dataGridBillDetail.Columns[0].Width = 60;
            dataGridBillDetail.Columns[1].Width = 60;
            dataGridBillDetail.Columns[2].Width = 200;
            dataGridBillDetail.Columns[3].Width = 40;
            dataGridBillDetail.Columns[4].Width = 80;
            dataGridBillDetail.Columns[5].Width = 80;
            dataGridBillDetail.Columns[6].Width = 100;
        }
        #endregion

        #region Hàm Insert Bill
        public void InsertBill(int maHD, int maCN, int maKH, string hoTen, string diaChi, string SDT, string ghiChu, int maNV, DateTime ngayTao, int tongTien)
        {
            HOADON add = new HOADON();
            add.MACHINHANH = maCN;
            add.MAHD = maHD;
            if (radioKhachVangLai.Checked == true)
            {
                add.MAKH = 1;
            }
            else
            {
                add.MAKH = maKH;
            }
            add.HOTEN = "Khach Vang Lai";
            add.DIACHI = CheckValidation(diaChi);
            add.SDT = CheckValidation(SDT);
            add.GHICHU = CheckValidation(ghiChu);
            add.MANV = maNV;
            add.NGAYTAO = ngayTao;
            //add.TONGTIENHANG = tongTien;
            db.HOADONs.Add(add);
            db.SaveChanges();
        }
        #endregion

        #region check validation
        public string CheckValidation(string input)
        {
            if (input == "")
                return "Không";
            else
                return input;
        }
        #endregion

        #region Hàm Insert CTHD
        public void InsertBillDetail(int maHoaDon, int maHangHoa, int donGia, decimal giamgia, int soLuong)
        {
            CHITIETHD add = new CHITIETHD();
            add.MAHD = maHoaDon;
            add.MAHH = maHangHoa;
            //add.DONGIA = donGia;
            //add.GIAMGIA = giamgia;
            add.SOLUONG = soLuong;
            db.CHITIETHDs.Add(add);
            db.SaveChanges();
        }
        #endregion

        #region Hàm Update Bill
        public void UpdateBill (int maHD, int maCN, int maKH, string hoTen, string diaChi, string SDT, string ghiChu, int maNV, int tongTien)
        {
            //SpaceTeam_Oracle_03 db = new SpaceTeam_Oracle_03();
            HOADON update = db.HOADONs.SingleOrDefault(hd => hd.MAHD == maHD);
            update.MACHINHANH = maCN;
            update.MAKH = maKH;
            update.HOTEN = hoTen;
            update.DIACHI = diaChi;
            update.SDT = SDT;
            update.GHICHU = ghiChu;
            update.MANV = maNV;
            //update.TONGTIENHANG = tongTien;
            db.SaveChanges();
        }
        #endregion

        #region Hàm Delete Bill
        public void DeleteBill(int maHD)
        {
            var hoaDon = db.HOADONs.Where(nv => nv.MAHD == maHD).SingleOrDefault();
            var ctDonHang = db.CHITIETHDs.Where(ct => ct.MAHD == maHD).ToList();
            ctDonHang.RemoveAll(ct => ct.MAHD == maHD);
            db.HOADONs.Remove(hoaDon);
            db.SaveChanges();
        }
        #endregion

        #region btn Add Đơn Hàng
        private void btnAddDH_Click(object sender, EventArgs e)
        {
            int maHD = GetIdBill();
            int maKH = int.Parse(cmbMaKhachHang.SelectedValue.ToString());
            int maCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
            string hoTen = cmbTenKhachHang.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string ghiChu = txtGhiChu.Text;
            DateTime ngayTao = dtNgayBan.Value;
            int maNV = int.Parse(cmbMaNV.SelectedValue.ToString());
            int tongTien = 0;
            if (txtTongTien.Text == "")
                tongTien = 0;


            try
            {
                InsertBill(maHD, maCN, maKH, hoTen, diaChi, soDienThoai, ghiChu, maNV, ngayTao, tongTien);
                txtMaHD.Text = maHD.ToString();
                MessageBox.Show("Thêm Đơn Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Đơn Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #region button Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(cmbMaNV.SelectedValue.ToString());
            int maKH = int.Parse(cmbMaKhachHang.SelectedValue.ToString());
            int maCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
            string hoTen = cmbTenKhachHang.Text;
            string diaChi = txtDiaChi.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string ghiChu = txtGhiChu.Text;
            DateTime ngayTao = dtNgayBan.Value;
            int maNV = int.Parse(cmbMaNV.SelectedValue.ToString());
            int tongTien = int.Parse(txtTongTien.Text);

            try
            {
                UpdateBill(maHD, maCN, maKH, hoTen, diaChi, soDienThoai, ghiChu, maNV, tongTien);
                MessageBox.Show("Sửa Đơn Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
                GetDataGridViewCTDH(maHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa Đơn Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region button Huy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);
            try
            {
                DeleteBill(maHD);
                MessageBox.Show("Xóa Đơn Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Đơn Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region button Refesh
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = " ";
            txtGhiChu.Text = " ";
            txtSoDienThoai.Text = " ";
            txtDonGia.Text = " ";
            txtGiamGia.Text = " ";
            txtThanhTien.Text = " ";
            txtTenHang.Text = " ";
            txtTongTien.Text = " ";
            if (radioKhachVangLai.Checked == true)
            {
                radioKhachVangLai.Checked = false;
            }
        }
        #endregion

        #region Update Tổng Tiền
        public void UpdateTongTien(int maHD, int tongTien)
        {
            //SpaceTeam_Oracle_03 db = new SpaceTeam_Oracle_03();
            HOADON update = db.HOADONs.SingleOrDefault(hd => hd.MAHD == maHD);
            //update.TONGTIENHANG = tongTien;
            db.SaveChanges();
        }
        #endregion

        public void UpdateSoLuongConLai(int maHH, int soLuong)
        {
            HANGHOA resultUpdate = db.HANGHOAs.SingleOrDefault(hh => hh.MAHH == maHH);
            resultUpdate.SOLUONG = resultUpdate.SOLUONG - soLuong;
            db.SaveChanges();
        }

        public int CheckSoLuong(int maHH)
        {
            int soLuong;
            var resultObject = db.HANGHOAs.First(hh => hh.MAHH == maHH);
            soLuong = (int)(resultObject.SOLUONG.GetValueOrDefault());
            return soLuong;
        }

        #region button Thêm Món cho đơn hàng
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                int maHoaDon = 0;
                if(txtMaHD.Text == "")
                {
                    maHoaDon = GetIdBill();
                }
                else
                {
                    maHoaDon = int.Parse(txtMaHD.Text);
                }    
                int maCN = int.Parse(cmbChiNhanh.SelectedValue.ToString());
                int maHangHoa = int.Parse(cmbMaHang.SelectedValue.ToString());
                int soLuong = (int)nupSL.Value;
                int tienGiamGia = Convert.ToInt32(decimal.Parse(txtThanhTien.Text));
                int donGia = int.Parse(txtDonGia.Text);
                int tongTien = 0;
                if (txtTongTien.Text == "")
                    tongTien = 0;
                int maKH = int.Parse(cmbMaKhachHang.SelectedValue.ToString());
                string hoTen = cmbTenKhachHang.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string ghiChu = txtGhiChu.Text;
                int maNV = int.Parse(cmbMaNV.SelectedValue.ToString());
                DateTime ngayTao = dtNgayBan.Value;

                int check = CheckIdHD(maHoaDon);
                if (check == -1)
                {
                    if (soLuong > CheckSoLuong(maHangHoa))
                    {
                        MessageBox.Show("Hàng Hóa Trong Kho Không Đủ Yêu Cầu ! Chỉ còn lại " + CheckSoLuong(maHangHoa), "Không đủ hàng hóa !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpdateSoLuongConLai(maHangHoa, soLuong);
                        InsertBill(maHoaDon, maCN, maKH, hoTen, diaChi, soDienThoai, ghiChu, maNV, ngayTao, tongTien);
                        InsertBillDetail(maHoaDon, maHangHoa, donGia, tienGiamGia, soLuong);
                        GetDataGridView(pageNumber, numberRecord);
                        GetDataGridViewCTDH(maHoaDon);
                        MessageBox.Show("Thêm Vào Đơn Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var check2 = db.CHITIETHDs.SingleOrDefault(dh => dh.MAHD == maHoaDon && dh.MAHH == maHangHoa);
                    if (check2 != null)
                    {
                        if (soLuong > CheckSoLuong(maHangHoa))
                        {
                            MessageBox.Show("Hàng Hóa Trong Kho Không Đủ Yêu Cầu ! Chỉ còn lại " + CheckSoLuong(maHangHoa), "Không đủ hàng hóa !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateSoLuongConLai(maHangHoa, soLuong);
                            UpdateBillDetail(maHoaDon, maHangHoa, soLuong);
                            GetDataGridViewCTDH(maHoaDon);
                            int tongT = int.Parse(txtTongTien.Text);
                            UpdateTongTien(maHoaDon, tongT);
                            
                            MessageBox.Show("Thay đổi số lượng vào đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (soLuong > CheckSoLuong(maHangHoa))
                        {
                            MessageBox.Show("Hàng Hóa Trong Kho Không Đủ Yêu Cầu !", "Không đủ hàng hóa !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateSoLuongConLai(maHangHoa, soLuong);
                            InsertBillDetail(maHoaDon, maHangHoa, donGia, tienGiamGia, soLuong);
                            GetDataGridViewCTDH(maHoaDon);
                            int tongT = int.Parse(txtTongTien.Text);
                            UpdateTongTien(maHoaDon, tongT);
                            MessageBox.Show("Thay đổi số lượng vào đơn hàng thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Đơn Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        public void UpdateBillDetail(int maHD, int maHH, int quatity)
        {
            CHITIETHD update = db.CHITIETHDs.SingleOrDefault(hd => hd.MAHD == maHD && hd.MAHH == maHH);
            update.SOLUONG = update.SOLUONG + quatity;
            db.SaveChanges();
        }

        private void dataGridBillDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridBillDetail.Rows[e.RowIndex];
                int maHH = int.Parse(row.Cells[1].Value.ToString());
                var hangHoa = from ct in db.CHITIETHDs
                              join hh in db.HANGHOAs
                              on ct.MAHH equals hh.MAHH
                              where ct.MAHH == maHH
                              select new
                              {
                                  hh.MAHH,
                                  hh.TENHH
                              };

                var listHangHoa = hangHoa.ToList();
                cmbMaHang.DataSource = listHangHoa;
                cmbMaHang.ValueMember = "MAHH";
                cmbMaHang.DisplayMember = "TENHH";


                txtTenHang.Text = row.Cells[2].Value.ToString();
                var cc = Convert.ToDecimal(row.Cells[5].Value.ToString());
                txtGiamGia.Text = cc.ToString();
                txtDonGia.Text = row.Cells[4].Value.ToString();
                nupSL.Value = int.Parse(row.Cells[3].Value.ToString());
            }
        }

        private void nupSL_ValueChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = ((int.Parse(txtDonGia.Text) * nupSL.Value) - (int.Parse(txtDonGia.Text) * decimal.Parse(txtGiamGia.Text))).ToString();
        }

        public void DeleteProductInBill(int productId, int billId)
        {
            var productInBill = db.CHITIETHDs.Where(nv => nv.MAHD == billId && nv.MAHH == productId).SingleOrDefault();
            db.CHITIETHDs.Remove(productInBill);
            db.SaveChanges();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);
            int maHH = int.Parse(cmbMaHang.SelectedValue.ToString());
            try
            {
                UpdateHangHoaKhiXoa(maHD, maHH);
                DeleteProductInBill(maHH,maHD);
                MessageBox.Show("Xóa Sản Phẩm Khỏi Đơn Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
                GetDataGridViewCTDH(maHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Sản Phẩm Khỏi Đơn Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateHangHoaKhiXoa(int maHD, int maHH)
        {
            int sl = 0;
            var soLuongTraLai = db.CHITIETHDs.SingleOrDefault(ct => ct.MAHD == maHD && ct.MAHH == maHH);
            sl = soLuongTraLai.SOLUONG.Value;   
            
            HANGHOA resultUpdate = db.HANGHOAs.SingleOrDefault(hh => hh.MAHH == maHH);
            resultUpdate.SOLUONG = resultUpdate.SOLUONG + sl;
            db.SaveChanges();
        }
        #region Firsts
        private void btnFirsts_Click(object sender, EventArgs e)
        {
                pageNumber = 1 ;
            GetDataGridView(pageNumber, numberRecord);
                txbPageBill.Text = pageNumber.ToString();
        }
        #endregion

        #region Previours
        private void btnPreviours_Click(object sender, EventArgs e)
        {
            if (pageNumber -  1 > 0)
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
            if(pageNumber - 1 < (totalRecord/numberRecord))
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
            var hangHoa = (from h in db.HOADONs
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
                           h.DIACHI,
                           h.SDT,
                           h.GHICHU,
                           h.NGAYTAO,
                           nv.MANV,
                           TENNV = nv.HOTEN,
                           c.TENCHINHANH
                       }).OrderByDescending(i => i.MAHD).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            dataGridDonHang.DataSource = hangHoa;
            dataGridDonHang.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridDonHang.Columns[1].HeaderText = "Họ tên khách hàng";
            dataGridDonHang.Columns[2].HeaderText = "Địa chỉ";
            dataGridDonHang.Columns[3].HeaderText = "Điện Thoại";
            dataGridDonHang.Columns[4].HeaderText = "Ghi chú";
            dataGridDonHang.Columns[5].HeaderText = "Ngày tạo đơn hàng";
            dataGridDonHang.Columns[6].HeaderText = "Mã nhân viên";
            dataGridDonHang.Columns[7].HeaderText = "Nhân viên bán hàng";
            dataGridDonHang.Columns[8].HeaderText = "Tên Chi Nhánh";
            dataGridDonHang.Columns[0].Width = 30;
            dataGridDonHang.Columns[1].Width = 130;
            dataGridDonHang.Columns[2].Width = 120;
            dataGridDonHang.Columns[3].Width = 90;
            dataGridDonHang.Columns[4].Width = 120;
            dataGridDonHang.Columns[5].Width = 100;
            dataGridDonHang.Columns[6].Width = 40;
            dataGridDonHang.Columns[7].Width = 140;
            dataGridDonHang.Columns[8].Width = 120;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion
    }
}
