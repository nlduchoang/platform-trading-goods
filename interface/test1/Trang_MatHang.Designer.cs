namespace test1
{
    partial class Trang_MatHang
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
            this.txtbanghienthi4 = new System.Windows.Forms.DataGridView();
            this.btHienthimathang = new System.Windows.Forms.Button();
            this.btQuayve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbanghienthi4
            // 
            this.txtbanghienthi4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.txtbanghienthi4.Location = new System.Drawing.Point(119, 298);
            this.txtbanghienthi4.Name = "txtbanghienthi4";
            this.txtbanghienthi4.RowHeadersWidth = 51;
            this.txtbanghienthi4.RowTemplate.Height = 24;
            this.txtbanghienthi4.Size = new System.Drawing.Size(573, 150);
            this.txtbanghienthi4.TabIndex = 5;
            // 
            // btHienthimathang
            // 
            this.btHienthimathang.Location = new System.Drawing.Point(321, 231);
            this.btHienthimathang.Name = "btHienthimathang";
            this.btHienthimathang.Size = new System.Drawing.Size(172, 39);
            this.btHienthimathang.TabIndex = 4;
            this.btHienthimathang.Text = "Hiển Thị Mặt Hàng";
            this.btHienthimathang.UseVisualStyleBackColor = true;
            this.btHienthimathang.Click += new System.EventHandler(this.btHienthimathang_Click);
            // 
            // btQuayve
            // 
            this.btQuayve.Location = new System.Drawing.Point(701, 30);
            this.btQuayve.Name = "btQuayve";
            this.btQuayve.Size = new System.Drawing.Size(75, 36);
            this.btQuayve.TabIndex = 12;
            this.btQuayve.Text = "Quay Về";
            this.btQuayve.UseVisualStyleBackColor = true;
            this.btQuayve.Click += new System.EventHandler(this.btQuayve_Click);
            // 
            // Trang_MatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btQuayve);
            this.Controls.Add(this.txtbanghienthi4);
            this.Controls.Add(this.btHienthimathang);
            this.Name = "Trang_MatHang";
            this.Text = "Trang_MatHang";
            ((System.ComponentModel.ISupportInitialize)(this.txtbanghienthi4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView txtbanghienthi4;
        private System.Windows.Forms.Button btHienthimathang;
        private System.Windows.Forms.Button btQuayve;
    }
}