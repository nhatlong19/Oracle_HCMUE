namespace SpaceTeam_Oracle.SpaceTeam
{
    partial class DanhMucNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.btnTTCaNhan = new System.Windows.Forms.Button();
            this.btnDSDonHang = new System.Windows.Forms.Button();
            this.btnDSHHDaBan = new System.Windows.Forms.Button();
            this.btnDiemDanh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(346, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân Viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTaoDonHang.Location = new System.Drawing.Point(107, 132);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Size = new System.Drawing.Size(159, 70);
            this.btnTaoDonHang.TabIndex = 1;
            this.btnTaoDonHang.Text = "Tạo Đơn Hàng";
            this.btnTaoDonHang.UseVisualStyleBackColor = true;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDoanhThu.Location = new System.Drawing.Point(323, 132);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(159, 70);
            this.btnDoanhThu.TabIndex = 2;
            this.btnDoanhThu.Text = "Doanh Thu";
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            // 
            // btnTTCaNhan
            // 
            this.btnTTCaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTTCaNhan.Location = new System.Drawing.Point(540, 132);
            this.btnTTCaNhan.Name = "btnTTCaNhan";
            this.btnTTCaNhan.Size = new System.Drawing.Size(159, 70);
            this.btnTTCaNhan.TabIndex = 3;
            this.btnTTCaNhan.Text = "Thông tin cá nhân";
            this.btnTTCaNhan.UseVisualStyleBackColor = true;
            // 
            // btnDSDonHang
            // 
            this.btnDSDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDSDonHang.Location = new System.Drawing.Point(107, 247);
            this.btnDSDonHang.Name = "btnDSDonHang";
            this.btnDSDonHang.Size = new System.Drawing.Size(159, 70);
            this.btnDSDonHang.TabIndex = 4;
            this.btnDSDonHang.Text = "Danh Sách Đơn Hàng";
            this.btnDSDonHang.UseVisualStyleBackColor = true;
            // 
            // btnDSHHDaBan
            // 
            this.btnDSHHDaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDSHHDaBan.Location = new System.Drawing.Point(323, 247);
            this.btnDSHHDaBan.Name = "btnDSHHDaBan";
            this.btnDSHHDaBan.Size = new System.Drawing.Size(159, 70);
            this.btnDSHHDaBan.TabIndex = 5;
            this.btnDSHHDaBan.Text = "Danh Sách Hàng Hóa Đã Bán";
            this.btnDSHHDaBan.UseVisualStyleBackColor = true;
            // 
            // btnDiemDanh
            // 
            this.btnDiemDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDiemDanh.Location = new System.Drawing.Point(540, 247);
            this.btnDiemDanh.Name = "btnDiemDanh";
            this.btnDiemDanh.Size = new System.Drawing.Size(159, 70);
            this.btnDiemDanh.TabIndex = 6;
            this.btnDiemDanh.Text = "Điểm Danh";
            this.btnDiemDanh.UseVisualStyleBackColor = true;
            // 
            // DanhMucNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 402);
            this.Controls.Add(this.btnDiemDanh);
            this.Controls.Add(this.btnDSHHDaBan);
            this.Controls.Add(this.btnDSDonHang);
            this.Controls.Add(this.btnTTCaNhan);
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.btnTaoDonHang);
            this.Controls.Add(this.label1);
            this.Name = "DanhMucNV";
            this.Text = "Danh mục Nhân Viên";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.Button btnTTCaNhan;
        private System.Windows.Forms.Button btnDSDonHang;
        private System.Windows.Forms.Button btnDSHHDaBan;
        private System.Windows.Forms.Button btnDiemDanh;
    }
}