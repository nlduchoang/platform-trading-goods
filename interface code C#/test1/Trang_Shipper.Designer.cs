namespace test1
{
    partial class Trang_Shipper
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
            this.txtXemthongtin = new System.Windows.Forms.Button();
            this.txtbanghienthi = new System.Windows.Forms.DataGridView();
            this.txtThoat_Trangshipper = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtXemthongtin
            // 
            this.txtXemthongtin.Location = new System.Drawing.Point(324, 226);
            this.txtXemthongtin.Name = "txtXemthongtin";
            this.txtXemthongtin.Size = new System.Drawing.Size(170, 37);
            this.txtXemthongtin.TabIndex = 0;
            this.txtXemthongtin.Text = "Xem thông tin";
            this.txtXemthongtin.UseVisualStyleBackColor = true;
            this.txtXemthongtin.Click += new System.EventHandler(this.txtXemthongtin_Click);
            // 
            // txtbanghienthi
            // 
            this.txtbanghienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.txtbanghienthi.Location = new System.Drawing.Point(104, 303);
            this.txtbanghienthi.Name = "txtbanghienthi";
            this.txtbanghienthi.RowHeadersWidth = 51;
            this.txtbanghienthi.RowTemplate.Height = 24;
            this.txtbanghienthi.Size = new System.Drawing.Size(618, 150);
            this.txtbanghienthi.TabIndex = 1;
            // 
            // txtThoat_Trangshipper
            // 
            this.txtThoat_Trangshipper.Location = new System.Drawing.Point(676, 25);
            this.txtThoat_Trangshipper.Name = "txtThoat_Trangshipper";
            this.txtThoat_Trangshipper.Size = new System.Drawing.Size(91, 39);
            this.txtThoat_Trangshipper.TabIndex = 2;
            this.txtThoat_Trangshipper.Text = "Thoát";
            this.txtThoat_Trangshipper.UseVisualStyleBackColor = true;
            this.txtThoat_Trangshipper.Click += new System.EventHandler(this.txtThoat_Trangshipper_Click);
            // 
            // Trang_Shipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtThoat_Trangshipper);
            this.Controls.Add(this.txtbanghienthi);
            this.Controls.Add(this.txtXemthongtin);
            this.Name = "Trang_Shipper";
            this.Text = "Trang_Shipper";
            this.Load += new System.EventHandler(this.Trang_Shipper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtXemthongtin;
        private System.Windows.Forms.DataGridView txtbanghienthi;
        private System.Windows.Forms.Button txtThoat_Trangshipper;
    }
}