using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();          
        }
        
        private void login_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + txtTaikhoan.Text + "' and matkhau = '" + txtMatkhau.Text + "'", conn);
            //SqlDataAdapter da1 = new SqlDataAdapter("select *from taikhoan where loainguoidung = 'sinhvien'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //string loainguoidung = dt.Rows[0][2].ToString();
            
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công");
                FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //string taikhoan = "", matkhau = "", loainguoidung = "";

        //public Trang_KhachHang(string taikhoan, string matkhau, string loainguoidung)
        //{
        //    InitializeComponent();
        //    this.taikhoan = taikhoan;
        //    this.matkhau = matkhau;
        //    this.loainguoidung = loainguoidung;
        //}
        //this.Hide();
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
        //SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //    FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
        //f.ShowDialog();
    }
}
