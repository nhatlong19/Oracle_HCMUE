using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SpaceTeam_Oracle
{
    public partial class NhapKho : Form
    {
        private ContextNhat db = new ContextNhat();

        public NhapKho()
        {
            InitializeComponent();
        }

        private void NhapKho_Load(object sender, EventArgs e)
        {
            LoadComboboxLoai();
            LoadComboboxNCC();
            GetDataGridView(pageNumber,numberRecord);
        }

        #region Load Combobox Ten Loai

        public void LoadComboboxLoai()
        {
            try
            {
                List<LOAI> listLoai = db.LOAIs.ToList();
                cmbMaLoai.DataSource = listLoai;
                cmbMaLoai.DisplayMember = "TENLOAI";
                cmbMaLoai.ValueMember = "MALOAI";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Load Combobox Ten Loai

        #region Load Combobox Nha Cung Cap

        public void LoadComboboxNCC()
        {
            try
            {
                List<NHACUNGCAP> listNhaCungCap = db.NHACUNGCAPs.ToList();
                cmbMaNCC.DataSource = listNhaCungCap;
                cmbMaNCC.DisplayMember = "TENCONGTY";
                cmbMaNCC.ValueMember = "MANCC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi  " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Load Combobox Nha Cung Cap

        #region Hàm Get Id 
        public int GetIdHH()
        {
            int dem = 1;
            while (true)
            {
                var c = db.HANGHOAs.Where(w => w.MAHH == dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }
        #endregion

        #region Hàm Insert HH

        public void InsertHH(int maHH, string tenHH, int maLoai, int soLuong, int donGia, decimal giamGia, string moTa, int maNCC)
        {
            HANGHOA add = new HANGHOA();
            add.MAHH = maHH;
            add.TENHH = tenHH;
            add.MALOAI = maLoai;
            add.SOLUONG = soLuong;
            add.DONGIA = donGia;
            add.GIAMGIA = giamGia;
            add.MOTA = moTa;
            add.MANCC = maNCC;
            db.HANGHOAs.Add(add);
            db.SaveChanges();
        }

        #endregion Hàm Insert HH

        #region Hàm Insert HH1

        public void UpdateHH1(string tenHH, int soLuong)
        {
            ContextNhat db = new ContextNhat();
            HANGHOA update = db.HANGHOAs.SingleOrDefault(hh => hh.TENHH == tenHH);
            update.TENHH = tenHH;
            update.SOLUONG = update.SOLUONG + soLuong;
            db.SaveChanges();
        }

        #endregion Hàm Insert HH1

        #region Hàm Update HH

        public void UpdateHH(int maHH, string tenHH, int maLoai, int soLuong, int donGia, decimal giamGia, string moTa, int maNCC)
        {
            ContextNhat db = new ContextNhat();
            HANGHOA update = db.HANGHOAs.SingleOrDefault(hh => hh.MAHH == maHH);
          
            update.TENHH = tenHH;
            update.MALOAI = maLoai;
            update.SOLUONG = soLuong;
            update.DONGIA = donGia;
            update.GIAMGIA = giamGia;
            update.MOTA = moTa;
            update.MANCC = maNCC;
            //update.TENCONGTY = tenNCC;
            //Nếu thêm tên ncc thì cái bảng hàng hóa t phải thêm cột tên công ty rồi:(( là 
            db.SaveChanges();
        }

        #endregion Hàm Update HH

        #region Hàm Delete HH

        public void DeleteHH(int maHH)
        {
            var hangHoa = db.HANGHOAs.Where(hh => hh.MAHH == maHH).SingleOrDefault();
            db.HANGHOAs.Remove(hangHoa);
            db.SaveChanges();
        }

        #endregion Hàm Delete HH

        

        #region Cell Click

        private void dataGridViewDSNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewDSHHNhap.Rows[e.RowIndex];
                txtMaHH.Text = row.Cells[0].Value.ToString();
                txtTenHH.Text = row.Cells[1].Value.ToString();
                cmbMaLoai.Text = row.Cells[2].Value.ToString();
                numUDSoLuong.Text = row.Cells[3].Value.ToString();
                txtDonGia.Text = row.Cells[4].Value.ToString();
                txtGiamGia.Text = row.Cells[5].Value.ToString();
                txtMoTa.Text = row.Cells[6].Value.ToString();
                cmbMaNCC.Text = row.Cells[8].Value.ToString();
            }
        }

        #endregion Cell Click

        #region button Add HH

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maHH = GetIdHH();
            string tenHH = txtTenHH.Text;
            int maLoai = int.Parse(cmbMaLoai.SelectedValue.ToString());
            int soLuong = (int)numUDSoLuong.Value;
            int donGia = int.Parse(txtDonGia.Text);
            decimal giamGia = decimal.Parse(txtGiamGia.Text);
            string moTa = txtMoTa.Text;
            int maNCC = int.Parse(cmbMaNCC.SelectedValue.ToString());

            try
            {
                string dem = db.HANGHOAs.Count(hh => hh.TENHH == tenHH).ToString();
                int dem1 = int.Parse(dem);
                if (dem1 == 1)
                {
                    UpdateHH1(tenHH, soLuong);
                    MessageBox.Show("Đã thêm "+ soLuong + " sản phẩm vào hàng hóa này!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetDataGridView(pageNumber, numberRecord);
                }
                if (dem1 == 0)
                {
                    InsertHH(maHH, tenHH, maLoai, soLuong, donGia, giamGia, moTa, maNCC);
                    MessageBox.Show("Thêm Hàng Hóa Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetDataGridView(pageNumber, numberRecord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Hàng Hóa Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion button Add HH

        #region btn Delete HH

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maHH = int.Parse(txtMaHH.Text);
            try
            {
                DeleteHH(maHH);
                MessageBox.Show("Xóa Hàng Hóa Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Hàng Hóa Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion btn Delete HH

        #region btn Update HH

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maHH = int.Parse(txtMaHH.Text);
            string tenHH = txtTenHH.Text;
            int maLoai = int.Parse(cmbMaLoai.SelectedValue.ToString());
            int soLuong = (int)numUDSoLuong.Value;
            int donGia = int.Parse(txtDonGia.Text);
            decimal giamGia = decimal.Parse(txtGiamGia.Text);
            string moTa = txtMoTa.Text;
            int maNCC = int.Parse(cmbMaNCC.SelectedValue.ToString());
            //string tenNCC = cmbMaNCC.Text;
            try
            {
                UpdateHH(maHH, tenHH, maLoai, soLuong, donGia, giamGia, moTa, maNCC);
                MessageBox.Show("Sửa Hàng Hóa Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa Hàng Hóa Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion btn Update HH

        #region button Refresh HH

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = " ";
            txtTenHH.Text = " ";
            cmbMaLoai.Text = " ";
            numUDSoLuong.TextAlign = 0;
            txtDonGia.Text = " ";
            txtGiamGia.Text = " ";
            txtMoTa.Text = " ";
            cmbMaNCC.Text = " ";
        }

        #endregion button Refresh HH

        #region button Exit HH

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }


        #endregion button Exit HH


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
            int totalRecord = db.HANGHOAs.Count();
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
            int sumRecord = db.HANGHOAs.Count();

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
            var hangHoa = (from h in db.HANGHOAs
                           join l in db.LOAIs
                           on h.MALOAI equals l.MALOAI
                           join ncc in db.NHACUNGCAPs
                           on h.MANCC equals ncc.MANCC
                           select new
                           {
                               h.MAHH,
                               h.TENHH,
                               l.TENLOAI,
                               h.SOLUONG,
                               h.DONGIA,
                               h.GIAMGIA,
                               h.MOTA,
                               ncc.MANCC,
                               ncc.TENCONGTY
                           }).OrderByDescending(i => i.MAHH).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            dataGridViewDSHHNhap.DataSource = hangHoa;
            dataGridViewDSHHNhap.Columns[0].HeaderText = "Mã Hàng Hóa";
            dataGridViewDSHHNhap.Columns[1].HeaderText = "Tên Hàng Hóa";
            dataGridViewDSHHNhap.Columns[2].HeaderText = "Mã Loại";
            dataGridViewDSHHNhap.Columns[3].HeaderText = "Số Lượng";
            dataGridViewDSHHNhap.Columns[4].HeaderText = "Đơn Giá";
            dataGridViewDSHHNhap.Columns[5].HeaderText = "Giảm Giá";
            dataGridViewDSHHNhap.Columns[6].HeaderText = "Mô Tả";
            dataGridViewDSHHNhap.Columns[7].HeaderText = "Mã Nhà Cung Cấp";
            dataGridViewDSHHNhap.Columns[8].HeaderText = "Tên Nhà Cung Cấp";
            dataGridViewDSHHNhap.Columns[0].Width = 100;
            dataGridViewDSHHNhap.Columns[1].Width = 250;
            dataGridViewDSHHNhap.Columns[2].Width = 100;
            dataGridViewDSHHNhap.Columns[3].Width = 70;
            dataGridViewDSHHNhap.Columns[4].Width = 150;
            dataGridViewDSHHNhap.Columns[5].Width = 70;
            dataGridViewDSHHNhap.Columns[6].Width = 300;
            dataGridViewDSHHNhap.Columns[7].Width = 100;
            dataGridViewDSHHNhap.Columns[8].Width = 400;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion
    }
}