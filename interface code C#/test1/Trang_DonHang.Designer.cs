namespace test1
{
    partial class Trang_DonHang
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
            this.txtDonhang = new System.Windows.Forms.Button();
            this.txtbanghienthi1 = new System.Windows.Forms.DataGridView();
            this.txtNhandonhang = new System.Windows.Forms.Button();
            this.txtMadonhang = new System.Windows.Forms.TextBox();
            this.txtThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btSuadonhang = new System.Windows.Forms.Button();
            this.btHuydonhang = new System.Windows.Forms.Button();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.lbSoluong = new System.Windows.Forms.Label();
            this.txtHinhthucthanhtoan = new System.Windows.Forms.TextBox();
            this.lbHinhthucthanhtoan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmadonhang_update = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDonhang
            // 
            this.txtDonhang.Location = new System.Drawing.Point(331, 260);
            this.txtDonhang.Name = "txtDonhang";
            this.txtDonhang.Size = new System.Drawing.Size(157, 39);
            this.txtDonhang.TabIndex = 1;
            this.txtDonhang.Text = "Hiển Thị Đơn Hàng";
            this.txtDonhang.UseVisualStyleBackColor = true;
            this.txtDonhang.Click += new System.EventHandler(this.txtDonhang_Click);
            // 
            // txtbanghienthi1
            // 
            this.txtbanghienthi1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.txtbanghienthi1.Location = new System.Drawing.Point(110, 305);
            this.txtbanghienthi1.Name = "txtbanghienthi1";
            this.txtbanghienthi1.RowHeadersWidth = 51;
            this.txtbanghienthi1.RowTemplate.Height = 24;
            this.txtbanghienthi1.Size = new System.Drawing.Size(589, 150);
            this.txtbanghienthi1.TabIndex = 2;
            // 
            // txtNhandonhang
            // 
            this.txtNhandonhang.Location = new System.Drawing.Point(298, 92);
            this.txtNhandonhang.Name = "txtNhandonhang";
            this.txtNhandonhang.Size = new System.Drawing.Size(133, 39);
            this.txtNhandonhang.TabIndex = 3;
            this.txtNhandonhang.Text = "Nhận Đơn Hàng";
            this.txtNhandonhang.UseVisualStyleBackColor = true;
            this.txtNhandonhang.Click += new System.EventHandler(this.txtNhandonhang_Click);
            // 
            // txtMadonhang
            // 
            this.txtMadonhang.Location = new System.Drawing.Point(395, 12);
            this.txtMadonhang.Multiline = true;
            this.txtMadonhang.Name = "txtMadonhang";
            this.txtMadonhang.Size = new System.Drawing.Size(133, 38);
            this.txtMadonhang.TabIndex = 4;
            // 
            // txtThoat
            // 
            this.txtThoat.Location = new System.Drawing.Point(687, 23);
            this.txtThoat.Name = "txtThoat";
            this.txtThoat.Size = new System.Drawing.Size(101, 36);
            this.txtThoat.TabIndex = 5;
            this.txtThoat.Text = "Thoát";
            this.txtThoat.UseVisualStyleBackColor = true;
            this.txtThoat.Click += new System.EventHandler(this.txtThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã đơn hàng";
            // 
            // btSuadonhang
            // 
            this.btSuadonhang.Location = new System.Drawing.Point(110, 198);
            this.btSuadonhang.Name = "btSuadonhang";
            this.btSuadonhang.Size = new System.Drawing.Size(133, 39);
            this.btSuadonhang.TabIndex = 7;
            this.btSuadonhang.Text = "Sửa Đơn Hàng";
            this.btSuadonhang.UseVisualStyleBackColor = true;
            this.btSuadonhang.Click += new System.EventHandler(this.btSuadonhang_Click);
            // 
            // btHuydonhang
            // 
            this.btHuydonhang.Location = new System.Drawing.Point(479, 92);
            this.btHuydonhang.Name = "btHuydonhang";
            this.btHuydonhang.Size = new System.Drawing.Size(133, 39);
            this.btHuydonhang.TabIndex = 8;
            this.btHuydonhang.Text = "Hủy Đơn Hàng";
            this.btHuydonhang.UseVisualStyleBackColor = true;
            this.btHuydonhang.Click += new System.EventHandler(this.btHuydonhang_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(110, 81);
            this.txtSoluong.Multiline = true;
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(133, 38);
            this.txtSoluong.TabIndex = 4;
            // 
            // lbSoluong
            // 
            this.lbSoluong.AutoSize = true;
            this.lbSoluong.Location = new System.Drawing.Point(13, 84);
            this.lbSoluong.Name = "lbSoluong";
            this.lbSoluong.Size = new System.Drawing.Size(69, 17);
            this.lbSoluong.TabIndex = 6;
            this.lbSoluong.Text = "Số Lượng";
            // 
            // txtHinhthucthanhtoan
            // 
            this.txtHinhthucthanhtoan.Location = new System.Drawing.Point(110, 141);
            this.txtHinhthucthanhtoan.Multiline = true;
            this.txtHinhthucthanhtoan.Name = "txtHinhthucthanhtoan";
            this.txtHinhthucthanhtoan.Size = new System.Drawing.Size(133, 38);
            this.txtHinhthucthanhtoan.TabIndex = 4;
            // 
            // lbHinhthucthanhtoan
            // 
            this.lbHinhthucthanhtoan.AutoSize = true;
            this.lbHinhthucthanhtoan.Location = new System.Drawing.Point(5, 153);
            this.lbHinhthucthanhtoan.Name = "lbHinhthucthanhtoan";
            this.lbHinhthucthanhtoan.Size = new System.Drawing.Size(99, 17);
            this.lbHinhthucthanhtoan.TabIndex = 6;
            this.lbHinhthucthanhtoan.Text = "Hình Thức Trả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã đơn hàng";
            // 
            // txtmadonhang_update
            // 
            this.txtmadonhang_update.Location = new System.Drawing.Point(110, 12);
            this.txtmadonhang_update.Multiline = true;
            this.txtmadonhang_update.Name = "txtmadonhang_update";
            this.txtmadonhang_update.Size = new System.Drawing.Size(133, 38);
            this.txtmadonhang_update.TabIndex = 9;
            // 
            // Trang_DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmadonhang_update);
            this.Controls.Add(this.btHuydonhang);
            this.Controls.Add(this.btSuadonhang);
            this.Controls.Add(this.lbHinhthucthanhtoan);
            this.Controls.Add(this.lbSoluong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThoat);
            this.Controls.Add(this.txtHinhthucthanhtoan);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.txtMadonhang);
            this.Controls.Add(this.txtNhandonhang);
            this.Controls.Add(this.txtbanghienthi1);
            this.Controls.Add(this.txtDonhang);
            this.Name = "Trang_DonHang";
            this.Text = "Trang_DonHang";
            this.Load += new System.EventHandler(this.Trang_DonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button txtDonhang;
        private System.Windows.Forms.DataGridView txtbanghienthi1;
        private System.Windows.Forms.Button txtNhandonhang;
        private System.Windows.Forms.TextBox txtMadonhang;
        private System.Windows.Forms.Button txtThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSuadonhang;
        private System.Windows.Forms.Button btHuydonhang;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label lbSoluong;
        private System.Windows.Forms.TextBox txtHinhthucthanhtoan;
        private System.Windows.Forms.Label lbHinhthucthanhtoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmadonhang_update;
    }
}