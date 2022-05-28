using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceTeam_Oracle.UI
{
    public partial class QLKhachHang : Form
    {
        ContextNhat db = new ContextNhat();
        public QLKhachHang()
        {
            InitializeComponent();
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            GetDataGridView(pageNumber,numberRecord);
        }
        #region Hàm GetIDNV
        int GetIdKH()
        {
            int dem = 1;
            while (true)
            {
                var c = db.KHACHHANGs.Where(w => w.MAKH== dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }
        #endregion
        #region Hàm Insert NhanVien
        public void InsertKH(int maKH,string hoTen, bool gioiTinh, DateTime ngaySinh, string SDT, string diaChi,string email)
        {
            KHACHHANG add = new KHACHHANG();
            add.MAKH = maKH;
            add.HOTEN = hoTen;
            add.GIOITINH = gioiTinh;
            add.NGAYSINH = ngaySinh;
            add.DIENTHOAI = SDT;
            add.DIACHI = diaChi;
            add.EMAIL = email;
            db.KHACHHANGs.Add(add);
            db.SaveChanges();
        }
        #endregion

        #region Hàm Update Khách Hàng
        public void UpdateKH(int maKH, string hoTen, bool gioiTinh, DateTime ngaySinh, string SDT, string diaChi,string email)
        {
            KHACHHANG update = db.KHACHHANGs.SingleOrDefault(kh => kh.MAKH == maKH);
            update.HOTEN = hoTen;
            update.GIOITINH = gioiTinh;
            update.NGAYSINH = ngaySinh;
            update.DIENTHOAI = SDT;
            update.DIACHI = diaChi;
            update.EMAIL = email;
            db.SaveChanges();
        }
        #endregion

        #region Hàm Delete KH
        public void DeleteKH(int maKH)
        {
            ContextNhat db = new ContextNhat();
            var khachHang = db.KHACHHANGs.Where(kh => kh.MAKH == maKH).SingleOrDefault();

            db.KHACHHANGs.Remove(khachHang);
            db.SaveChanges();
        }
        #endregion

        #region Cell CLick

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "True")
                    radioMen.Checked = true;
                if (row.Cells[2].Value.ToString() == "False")
                    radioFemale.Checked = true;
                dtpkBD.Value = Convert.ToDateTime(row.Cells[3].Value);
                txtEmail.Text = row.Cells[4].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();
                txtDiaChi.Text = row.Cells[6].Value.ToString();
            }
        }

        #endregion DONE 

        #region btn Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maKH = GetIdKH();
            DateTime dateBD = dtpkBD.Value;
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
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;

            try
            {
                InsertKH(maKH, hoTen, gioiTinh, dateBD, sDT, diaChi, email);

                MessageBox.Show("Thêm Khách Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Khách Hàng Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Delete Khach Hang
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maKH = int.Parse(txtMaKH.Text);
            try
            {
                DeleteKH(maKH);

                MessageBox.Show("Xóa Khách Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Khách Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Update KH
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maKH = int.Parse(txtMaKH.Text);
            DateTime dateBD = dtpkBD.Value;
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
            string sDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;

            try
            {
                UpdateKH(maKH, hoTen, gioiTinh, dateBD, sDT, diaChi, email);

                MessageBox.Show("Update Khách Hàng Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Khách Hàng Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region button Fresh NCC
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = " ";
            txtHoTen.Text = " ";
            //dtpkBD.Text = "TO_TIMESTAMP ('2018-11-30 17:53:28.673','YYYY-MM-DD HH24:MI:SS.FF3')";
            radioMen.Checked = true;
            txtEmail.Text = " ";
            txtSDT.Text = " ";
            txtDiaChi.Text = " ";
        }
        #endregion

        #region button Exit NCC
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion

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
            int totalRecord = db.KHACHHANGs.Count();
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
            int sumRecord = db.KHACHHANGs.Count();

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
            var hangHoa = (from kh in db.KHACHHANGs
                           select new
                           {
                               kh.MAKH,
                               kh.HOTEN,
                               kh.GIOITINH,
                               kh.NGAYSINH,
                               kh.EMAIL,
                               kh.DIENTHOAI,
                               kh.DIACHI,

                           }).OrderByDescending(i => i.MAKH).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            dataGridViewKhachHang.DataSource = hangHoa;
            dataGridViewKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dataGridViewKhachHang.Columns[1].HeaderText = "Họ tên Khách Hàng";
            dataGridViewKhachHang.Columns[2].HeaderText = "Giới Tính";
            dataGridViewKhachHang.Columns[3].HeaderText = "Ngày sinh";
            dataGridViewKhachHang.Columns[4].HeaderText = "Email";
            dataGridViewKhachHang.Columns[5].HeaderText = "Số Điện Thoại";
            dataGridViewKhachHang.Columns[6].HeaderText = "Địa Chỉ";

            dataGridViewKhachHang.Columns[0].Width = 100;
            dataGridViewKhachHang.Columns[1].Width = 150;
            dataGridViewKhachHang.Columns[2].Width = 80;
            dataGridViewKhachHang.Columns[3].Width = 120;
            dataGridViewKhachHang.Columns[4].Width = 150;
            dataGridViewKhachHang.Columns[5].Width = 100;
            dataGridViewKhachHang.Columns[6].Width = 500;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion
    }
}
