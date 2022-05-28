using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SpaceTeam_Oracle
{
    public partial class QLChucVu : Form
    {
        ContextNhat db = new ContextNhat();
        public QLChucVu()
        {
            InitializeComponent();
        }
       
        private void QLChucVu_Load(object sender, EventArgs e)
        {
            GetDataGridView();
        }
        #region Hàm Get IdCV
        int GetIdCV()
        {
            int dem = 1;

            while (true)
            {
                var c = db.CHUCVUs.Where(w => w.MACHUCVU == dem).SingleOrDefault();
                if (c == null)
                {
                    return dem;
                }
                dem++;
            }
        }
        #endregion
        #region Hàm Insert CV
        public string InsertCV(int maCV, string tenCV)
        {
            int dem = db.CHUCVUs.Count(w => w.TENCHUCVU == tenCV);
            if (dem == 0)
            {
                CHUCVU add = new CHUCVU();
                add.MACHUCVU = maCV;
                add.TENCHUCVU = tenCV;
                db.CHUCVUs.Add(add);
                db.SaveChanges();
                return "1";
            }

            return "2";
        }
        #endregion
        #region Hàm Update CV
        public void UpdateCV(int maCV, string tenCV)
        {
            CHUCVU update = db.CHUCVUs.SingleOrDefault(cv => cv.MACHUCVU == maCV);
            update.MACHUCVU = maCV;
            update.TENCHUCVU = tenCV;
            db.SaveChanges();
        }
        #endregion
        #region Hàm Delete CV
        public void DeleteCV(int maCV)
        {
            var chucVu = db.CHUCVUs.Where(cv => cv.MACHUCVU== maCV).SingleOrDefault();
            db.CHUCVUs.Remove(chucVu);
            db.SaveChanges();
        }
        #endregion
        
        #region Load DataGridView
        public void GetDataGridView()
        {
            var employeeData = from cv in db.CHUCVUs
                               select new
                               {
                                   cv.MACHUCVU,
                                   cv.TENCHUCVU
                               };

            var ListEmployee = employeeData.ToList();
            dataGridViewDSCV.DataSource = ListEmployee;
            dataGridViewDSCV.Columns[0].HeaderText = "Mã Chức Vụ";
            dataGridViewDSCV.Columns[1].HeaderText = "Tên Chức Vụ";
            dataGridViewDSCV.Columns[0].Width = 150;
            dataGridViewDSCV.Columns[1].Width = 450;
        }
        #endregion
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int maCV = GetIdCV();
            string tenCV = txtTenCV.Text;
            string temp = InsertCV(maCV, tenCV);
            if (temp == "1")
            {
                MessageBox.Show("Thêm Chức Vụ Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView();
            }
            else
            {
                MessageBox.Show(" Chức Vụ Đã Tồn Tại ", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maCV = int.Parse(txtMaCV.Text);
            try
            {
                DeleteCV(maCV);
                MessageBox.Show("Xóa Chức Vụ Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa Chức vụ Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int maCV = int.Parse(txtMaCV.Text);
            string tenCV = txtTenCV.Text;

            try
            {
                UpdateCV(maCV, tenCV);
                MessageBox.Show("Sửa Chức vụ Thành Công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa Chức vụ Không Thành Công " + ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = " ";
            txtTenCV.Text = " ";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Close();
            }
        }

        private void dataGridViewDSCV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewDSCV.Rows[e.RowIndex];
                txtMaCV.Text = row.Cells[0].Value.ToString();
                txtTenCV.Text = row.Cells[1].Value.ToString();
            }
        }

       

    }
}
