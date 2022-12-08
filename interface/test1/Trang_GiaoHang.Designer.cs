namespace test1
{
    partial class Trang_GiaoHang
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
            this.txtGiaohang = new System.Windows.Forms.Button();
            this.txtbanghienthi2 = new System.Windows.Forms.DataGridView();
            this.txtThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGiaohang
            // 
            this.txtGiaohang.Location = new System.Drawing.Point(328, 220);
            this.txtGiaohang.Name = "txtGiaohang";
            this.txtGiaohang.Size = new System.Drawing.Size(145, 40);
            this.txtGiaohang.TabIndex = 0;
            this.txtGiaohang.Text = "Hiển Thị Giao Hàng";
            this.txtGiaohang.UseVisualStyleBackColor = true;
            this.txtGiaohang.Click += new System.EventHandler(this.txtGiaohang_Click);
            // 
            // txtbanghienthi2
            // 
            this.txtbanghienthi2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.txtbanghienthi2.Location = new System.Drawing.Point(12, 299);
            this.txtbanghienthi2.Name = "txtbanghienthi2";
            this.txtbanghienthi2.RowHeadersWidth = 51;
            this.txtbanghienthi2.RowTemplate.Height = 24;
            this.txtbanghienthi2.Size = new System.Drawing.Size(776, 150);
            this.txtbanghienthi2.TabIndex = 1;
            // 
            // txtThoat
            // 
            this.txtThoat.Location = new System.Drawing.Point(666, 12);
            this.txtThoat.Name = "txtThoat";
            this.txtThoat.Size = new System.Drawing.Size(113, 38);
            this.txtThoat.TabIndex = 2;
            this.txtThoat.Text = "Thoát";
            this.txtThoat.UseVisualStyleBackColor = true;
            this.txtThoat.Click += new System.EventHandler(this.txtThoat_Click);
            // 
            // Trang_GiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtThoat);
            this.Controls.Add(this.txtbanghienthi2);
            this.Controls.Add(this.txtGiaohang);
            this.Name = "Trang_GiaoHang";
            this.Text = "Trang_GiaoHang";
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtGiaohang;
        private System.Windows.Forms.DataGridView txtbanghienthi2;
        private System.Windows.Forms.Button txtThoat;
    }
}