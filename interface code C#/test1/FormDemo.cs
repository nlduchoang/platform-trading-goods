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
    
    public partial class FormDemo : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
      
        private void button_kenhnguoiban_Click(object sender, EventArgs e)
        {
        //   if (loainguoidung == "NGUOIBAN")
        //    {
        //        MessageBox.Show("quyen nguoi ban");
        //    }
        //    else
        //    {
        //        MessageBox.Show("khong dc lam");
        //    }
        }
        public FormDemo()
        {
            InitializeComponent();
        }
        public FormDemo(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        SqlConnection conn;

        private void txtTrangshipper_Click(object sender, EventArgs e)
        {
            Trang_Shipper f = new Trang_Shipper(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.ShowDialog();           
        }

        private void txtTrangdonhang_Click(object sender, EventArgs e)
        {
            Trang_DonHang f = new Trang_DonHang(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.ShowDialog();
        }

        private void txtTranggiaohang_Click(object sender, EventArgs e)
        {
            Trang_GiaoHang f = new Trang_GiaoHang(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.ShowDialog();
        }

        private void btMathang_Click(object sender, EventArgs e)
        {
            Trang_MatHang f = new Trang_MatHang(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }

        private void btHoadon_Click(object sender, EventArgs e)
        {
            Trang_HoaDon f = new Trang_HoaDon(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }

        private void btTrangsanpham_Click(object sender, EventArgs e)
        {
            Trang_SanPham f = new Trang_SanPham(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }

        private void btTrangshop_Click(object sender, EventArgs e)
        {
            Trang_Shop f = new Trang_Shop(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }

        private void btTrangkhachhang_Click(object sender, EventArgs e)
        {
            Trang_KhachHang f = new Trang_KhachHang(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }


        private void btQuayVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1 f = new Form1();
            f.ShowDialog();
           
        }

        private void btTrangquanly_Click(object sender, EventArgs e)
        {
            Trang_QuanLy f = new Trang_QuanLy(taikhoan, matkhau, loainguoidung);
            this.Hide();
            f.Show();
        }
        private void FormDemo_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            //Hienthi();
            if (loainguoidung.Trim() == "GIAOHANG")
            {
                //trang shippper, đơn hàng, giao hàng
                btTrangkhachhang.Visible = false;
                btTrangquanly.Visible = false;
                btTrangsanpham.Visible = false;
                btTrangshop.Visible = false;
                btMathang.Visible = false;
                btHoadon.Visible = false;
            }
            else if(loainguoidung.Trim() == "KHACHHANG")
            {
                //KHACHHANG, Shop, sanpham, mathang, donhang, giaohang, hoadon
                txtTrangshipper.Visible = false;
                btTrangquanly.Visible = false;
            }
            else if (loainguoidung.Trim() == "QUANLY")
            {
                btTrangkhachhang.Visible = false;
                btTrangsanpham.Visible = false;
                btTrangshop.Visible = false;
                btMathang.Visible = false;
                btHoadon.Visible = false;
                txtTrangshipper.Visible = false;
                txtTrangdonhang.Visible = false;
                txtTranggiaohang.Visible = false;
            }

        }
    }
}
