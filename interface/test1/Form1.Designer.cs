namespace test1
{
    partial class Form1
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
            this.login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(300, 266);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 29);
            this.login.TabIndex = 0;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản";
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.Location = new System.Drawing.Point(269, 154);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.Size = new System.Drawing.Size(324, 22);
            this.txtTaikhoan.TabIndex = 2;

            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(269, 219);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(324, 22);
            this.txtMatkhau.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật khẩu";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(497, 266);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 29);
            this.exit.TabIndex = 5;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTaikhoan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.Name = "Form1";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exit;
    }
}

