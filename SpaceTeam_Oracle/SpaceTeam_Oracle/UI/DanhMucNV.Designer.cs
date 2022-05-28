namespace GUI.SpaceTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMucNV));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQLKhachHang = new System.Windows.Forms.Button();
            this.btnThoát = new System.Windows.Forms.Button();
            this.btnTTCaNhan = new System.Windows.Forms.Button();
            this.btnTaoDonHang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnQLKhachHang);
            this.panel1.Controls.Add(this.btnThoát);
            this.panel1.Controls.Add(this.btnTTCaNhan);
            this.panel1.Controls.Add(this.btnTaoDonHang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(65, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 468);
            this.panel1.TabIndex = 8;
            // 
            // btnQLKhachHang
            // 
            this.btnQLKhachHang.BackColor = System.Drawing.Color.Ivory;
            this.btnQLKhachHang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnQLKhachHang.Location = new System.Drawing.Point(669, 146);
            this.btnQLKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLKhachHang.Name = "btnQLKhachHang";
            this.btnQLKhachHang.Size = new System.Drawing.Size(212, 86);
            this.btnQLKhachHang.TabIndex = 7;
            this.btnQLKhachHang.Text = "Quản Lý Khách Hàng";
            this.btnQLKhachHang.UseVisualStyleBackColor = false;
            this.btnQLKhachHang.Click += new System.EventHandler(this.btnQLKhachHang_Click);
            // 
            // btnThoát
            // 
            this.btnThoát.BackColor = System.Drawing.Color.Ivory;
            this.btnThoát.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoát.Location = new System.Drawing.Point(364, 309);
            this.btnThoát.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoát.Name = "btnThoát";
            this.btnThoát.Size = new System.Drawing.Size(212, 86);
            this.btnThoát.TabIndex = 6;
            this.btnThoát.Text = "Thoát";
            this.btnThoát.UseVisualStyleBackColor = false;
            this.btnThoát.Click += new System.EventHandler(this.btnThoát_Click);
            // 
            // btnTTCaNhan
            // 
            this.btnTTCaNhan.BackColor = System.Drawing.Color.Ivory;
            this.btnTTCaNhan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnTTCaNhan.Location = new System.Drawing.Point(364, 146);
            this.btnTTCaNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTTCaNhan.Name = "btnTTCaNhan";
            this.btnTTCaNhan.Size = new System.Drawing.Size(212, 86);
            this.btnTTCaNhan.TabIndex = 3;
            this.btnTTCaNhan.Text = "Thông tin cá nhân";
            this.btnTTCaNhan.UseVisualStyleBackColor = false;
            this.btnTTCaNhan.Click += new System.EventHandler(this.btnTTCaNhan_Click);
            // 
            // btnTaoDonHang
            // 
            this.btnTaoDonHang.BackColor = System.Drawing.Color.Ivory;
            this.btnTaoDonHang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnTaoDonHang.Location = new System.Drawing.Point(59, 146);
            this.btnTaoDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTaoDonHang.Name = "btnTaoDonHang";
            this.btnTaoDonHang.Size = new System.Drawing.Size(212, 86);
            this.btnTaoDonHang.TabIndex = 1;
            this.btnTaoDonHang.Text = "Tạo Đơn Hàng";
            this.btnTaoDonHang.UseVisualStyleBackColor = false;
            this.btnTaoDonHang.Click += new System.EventHandler(this.btnTaoDonHang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(376, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân Viên";
            // 
            // DanhMucNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1067, 485);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DanhMucNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Nhân Viên";
            this.Load += new System.EventHandler(this.DanhMucNV_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQLKhachHang;
        private System.Windows.Forms.Button btnThoát;
        private System.Windows.Forms.Button btnTTCaNhan;
        private System.Windows.Forms.Button btnTaoDonHang;
        private System.Windows.Forms.Label label1;
    }
}