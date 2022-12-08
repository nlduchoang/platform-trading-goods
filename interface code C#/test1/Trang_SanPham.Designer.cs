namespace test1
{
    partial class Trang_SanPham
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
            this.btHienthisanpham = new System.Windows.Forms.Button();
            this.dgvbanghienthi5 = new System.Windows.Forms.DataGridView();
            this.btTimkiem = new System.Windows.Forms.Button();
            this.btMuasanpham = new System.Windows.Forms.Button();
            this.txtMasanpham = new System.Windows.Forms.TextBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.lbMamathang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoluongmua = new System.Windows.Forms.TextBox();
            this.btQuayVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbanghienthi5)).BeginInit();
            this.SuspendLayout();
            // 
            // btHienthisanpham
            // 
            this.btHienthisanpham.Location = new System.Drawing.Point(324, 233);
            this.btHienthisanpham.Name = "btHienthisanpham";
            this.btHienthisanpham.Size = new System.Drawing.Size(143, 43);
            this.btHienthisanpham.TabIndex = 0;
            this.btHienthisanpham.Text = "Hiển Thị Sản Phẩm";
            this.btHienthisanpham.UseVisualStyleBackColor = true;
            this.btHienthisanpham.Click += new System.EventHandler(this.btHienthisanpham_Click);
            // 
            // dgvbanghienthi5
            // 
            this.dgvbanghienthi5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbanghienthi5.Location = new System.Drawing.Point(44, 299);
            this.dgvbanghienthi5.Name = "dgvbanghienthi5";
            this.dgvbanghienthi5.RowHeadersWidth = 51;
            this.dgvbanghienthi5.RowTemplate.Height = 24;
            this.dgvbanghienthi5.Size = new System.Drawing.Size(686, 150);
            this.dgvbanghienthi5.TabIndex = 1;
            // 
            // btTimkiem
            // 
            this.btTimkiem.Location = new System.Drawing.Point(379, 139);
            this.btTimkiem.Name = "btTimkiem";
            this.btTimkiem.Size = new System.Drawing.Size(143, 43);
            this.btTimkiem.TabIndex = 2;
            this.btTimkiem.Text = "Tìm Kiếm Mặt Hàng ";
            this.btTimkiem.UseVisualStyleBackColor = true;
            this.btTimkiem.Click += new System.EventHandler(this.btTimkiem_Click);
            // 
            // btMuasanpham
            // 
            this.btMuasanpham.Location = new System.Drawing.Point(149, 139);
            this.btMuasanpham.Name = "btMuasanpham";
            this.btMuasanpham.Size = new System.Drawing.Size(143, 43);
            this.btMuasanpham.TabIndex = 3;
            this.btMuasanpham.Text = "Mua Sản Phẩm ";
            this.btMuasanpham.UseVisualStyleBackColor = true;
            this.btMuasanpham.Click += new System.EventHandler(this.btMuasanpham_Click);
            // 
            // txtMasanpham
            // 
            this.txtMasanpham.Location = new System.Drawing.Point(174, 12);
            this.txtMasanpham.Multiline = true;
            this.txtMasanpham.Name = "txtMasanpham";
            this.txtMasanpham.Size = new System.Drawing.Size(118, 28);
            this.txtMasanpham.TabIndex = 4;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(395, 73);
            this.txtTimkiem.Multiline = true;
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(117, 28);
            this.txtTimkiem.TabIndex = 5;
            // 
            // lbMamathang
            // 
            this.lbMamathang.AutoSize = true;
            this.lbMamathang.Location = new System.Drawing.Point(376, 15);
            this.lbMamathang.Name = "lbMamathang";
            this.lbMamathang.Size = new System.Drawing.Size(155, 17);
            this.lbMamathang.TabIndex = 6;
            this.lbMamathang.Text = "Nhập vào mã mặt hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập mã sản phẩm ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nhập số lượng mua ";
            // 
            // txtSoluongmua
            // 
            this.txtSoluongmua.Location = new System.Drawing.Point(174, 73);
            this.txtSoluongmua.Multiline = true;
            this.txtSoluongmua.Name = "txtSoluongmua";
            this.txtSoluongmua.Size = new System.Drawing.Size(118, 28);
            this.txtSoluongmua.TabIndex = 8;
            // 
            // btQuayVe
            // 
            this.btQuayVe.Location = new System.Drawing.Point(713, 15);
            this.btQuayVe.Name = "btQuayVe";
            this.btQuayVe.Size = new System.Drawing.Size(75, 31);
            this.btQuayVe.TabIndex = 10;
            this.btQuayVe.Text = "Quay Về";
            this.btQuayVe.UseVisualStyleBackColor = true;
            this.btQuayVe.Click += new System.EventHandler(this.btQuayVe_Click);
            // 
            // Trang_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btQuayVe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoluongmua);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMamathang);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.txtMasanpham);
            this.Controls.Add(this.btMuasanpham);
            this.Controls.Add(this.btTimkiem);
            this.Controls.Add(this.dgvbanghienthi5);
            this.Controls.Add(this.btHienthisanpham);
            this.Name = "Trang_SanPham";
            this.Text = "Trang_SanPham";
            ((System.ComponentModel.ISupportInitialize)(this.dgvbanghienthi5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btHienthisanpham;
        private System.Windows.Forms.DataGridView dgvbanghienthi5;
        private System.Windows.Forms.Button btTimkiem;
        private System.Windows.Forms.Button btMuasanpham;
        private System.Windows.Forms.TextBox txtMasanpham;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Label lbMamathang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoluongmua;
        private System.Windows.Forms.Button btQuayVe;
    }
}