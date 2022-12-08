namespace test1
{
    partial class Trang_QuanLy
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
            this.btxemdoanhthu = new System.Windows.Forms.Button();
            this.dgvbanghienthi0 = new System.Windows.Forms.DataGridView();
            this.txtMashop_xem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btxemrating = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbanghienthi0)).BeginInit();
            this.SuspendLayout();
            // 
            // btxemdoanhthu
            // 
            this.btxemdoanhthu.Location = new System.Drawing.Point(202, 222);
            this.btxemdoanhthu.Name = "btxemdoanhthu";
            this.btxemdoanhthu.Size = new System.Drawing.Size(144, 34);
            this.btxemdoanhthu.TabIndex = 0;
            this.btxemdoanhthu.Text = "Xem Doanh Thu";
            this.btxemdoanhthu.UseVisualStyleBackColor = true;
            this.btxemdoanhthu.Click += new System.EventHandler(this.btxemdoanhthu_Click);
            // 
            // dgvbanghienthi0
            // 
            this.dgvbanghienthi0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbanghienthi0.Location = new System.Drawing.Point(75, 299);
            this.dgvbanghienthi0.Name = "dgvbanghienthi0";
            this.dgvbanghienthi0.RowHeadersWidth = 51;
            this.dgvbanghienthi0.RowTemplate.Height = 24;
            this.dgvbanghienthi0.Size = new System.Drawing.Size(656, 150);
            this.dgvbanghienthi0.TabIndex = 1;
            // 
            // txtMashop_xem
            // 
            this.txtMashop_xem.Location = new System.Drawing.Point(95, 21);
            this.txtMashop_xem.Name = "txtMashop_xem";
            this.txtMashop_xem.Size = new System.Drawing.Size(100, 22);
            this.txtMashop_xem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã Shop";
            // 
            // btxemrating
            // 
            this.btxemrating.Location = new System.Drawing.Point(480, 222);
            this.btxemrating.Name = "btxemrating";
            this.btxemrating.Size = new System.Drawing.Size(144, 34);
            this.btxemrating.TabIndex = 4;
            this.btxemrating.Text = "Xem Rating";
            this.btxemrating.UseVisualStyleBackColor = true;
            this.btxemrating.Click += new System.EventHandler(this.btxemrating_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(689, 48);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 34);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // Trang_QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btxemrating);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMashop_xem);
            this.Controls.Add(this.dgvbanghienthi0);
            this.Controls.Add(this.btxemdoanhthu);
            this.Name = "Trang_QuanLy";
            this.Text = "Trang_QuanLy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvbanghienthi0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btxemdoanhthu;
        private System.Windows.Forms.DataGridView dgvbanghienthi0;
        private System.Windows.Forms.TextBox txtMashop_xem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btxemrating;
        private System.Windows.Forms.Button btThoat;
    }
}