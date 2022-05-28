using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SpaceTeam_Oracle
{
    public partial class QLChiNhanh : Form
    {
        ContextNhat db  = new ContextNhat();

        public QLChiNhanh()
        {
            InitializeComponent();
        }

        private void QLChiNhanh_Load(object sender, EventArgs e)
        {
            GetDataGridView(pageNumber, numberRecord);
        }

        #region Hàm Insert CN

        /// <summary>
        /// test thử lại đi. 
        /// còn lỗi gì ko. tối rồi t team view qua push
        /// </summary>
        /// <param name="maCN"></param>
        /// <param name="tenCN"></param>
        /// <returns></returns>
        public string InsertCN(int maCN, string tenCN)
        {
            int dem = db.CHINHANHs.Count(w => w.TENCHINHANH == tenCN);
            if (dem == 0)
            {
                CHINHANH add = new CHINHANH();
                add.MACHINHANH = maCN;
                add.TENCHINHANH = tenCN;

                db.CHINHANHs.Add(add);
                db.SaveChanges();
                return "1";
            }

            return "2";
        }

        #endregion Hàm Insert CN

        #region Hàm Update CN

        public void UpdateCN(int maCN, string tenCN)
        {
            CHINHANH update = db.CHINHANHs.SingleOrDefault(cn => cn.MACHINHANH == maCN);
            update.MACHINHANH = maCN;
            update.TENCHINHANH = tenCN;
            db.SaveChanges();
        }

        #endregion Hàm Update CN

        #region Hàm Delete CN

        public void DeleteCN(int maCN)
        {
            var chiNhanh = db.CHINHANHs.Where(cn => cn.MACHINHANH == maCN).SingleOrDefault();
            db.CHINHANHs.Remove(chiNhanh);
            db.SaveChanges();
        }

        #endregion Hàm Delete CN

        #region Hàm Get Id CN

        private int GetIdCN()
        {
            int dem = 1;
            while (true)
            {
                var c = db.CHINHANHs.Where(w => w.MACHINHANH == dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }

        #endregion Hàm Get Id CN

        #region Cell CLick

        private void dataGridViewDSCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewDSCN.Rows[e.RowIndex];
                txtMaCN.Text = row.Cells[0].Value.ToString();
                txtTenCN.Text = row.Cells[1].Value.ToString();
            }
        }

        #endregion Cell CLick

        #region btn Add Chi Nhanh

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maNCC = GetIdCN();
            string tenNCC = txtTenCN.Text;
            string temp = InsertCN(maNCC, tenNCC);
            if (temp == "1")
            {
                MessageBox.Show("Thêm Chi Nhánh Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            else
            {
                MessageBox.Show("Tên Chi Nhánh đã tồn tại ", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion btn Add Chi Nhanh

        #region button Xoa

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maCN = int.Parse(txtMaCN.Text);
            try
            {
                DeleteCN(maCN);
                MessageBox.Show("Xóa Chi Nhánh Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Chi Nhánh Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion button Xoa

        #region button Sua

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maCN = int.Parse(txtMaCN.Text);
            string tenCN = txtTenCN.Text;

            try
            {
                UpdateCN(maCN, tenCN);
                MessageBox.Show("Sửa Chi Nhánh Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView(pageNumber, numberRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa Chi Nhánh Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion button Sua

        #region button Refresh

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaCN.Text = " ";
            txtTenCN.Text = " ";
        }

        #endregion button Refresh

        #region Thoat

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }


        #endregion Thoat
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
            int totalRecord = db.CHINHANHs.Count();
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
            int sumRecord = db.CHINHANHs.Count();

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
            var hangHoa = (from cn in db.CHINHANHs
                           select new
                           {
                               cn.MACHINHANH,
                               cn.TENCHINHANH,
                           }).OrderByDescending(i => i.MACHINHANH).Skip((page - 1) * recordNum).Take(recordNum).ToList();
            dataGridViewDSCN.DataSource = hangHoa;
            dataGridViewDSCN.Columns[0].HeaderText = "Mã Chi Nhánh";
            dataGridViewDSCN.Columns[1].HeaderText = "Tên Chi Nhánh";
            dataGridViewDSCN.Columns[0].Width = 200;
            dataGridViewDSCN.Columns[1].Width = 600;
            txbPageBill.Text = pageNumber.ToString();
        }
        #endregion
    }
}