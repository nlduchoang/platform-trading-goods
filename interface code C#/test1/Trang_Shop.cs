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
    public partial class Trang_Shop : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";

        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_Shop()
        {
            InitializeComponent();
        }
        public Trang_Shop(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        private void btSuasanpham_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("UPDATE_SP_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@masp", txtmasanpham_update.Text);
            cmd.Parameters.AddWithValue("@giatienmoi", txtgiatien_update.Text);
            cmd.Parameters.AddWithValue("@soluongconlaimoi", txtsoluong_update.Text);
            if(txtmasanpham_update.Text != "" && txtgiatien_update.Text != "" && txtsoluong_update.Text != "")
            {
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                MessageBox.Show("Sửa thành công");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin sản phẩm");
            }
        }

        private void btXoasanpham_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            string sql = "select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = '" + taikhoan + "'))";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int temp = dt.Rows.Count;
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("DELETE_SP_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@masp", txtmasanpham_delete.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            string sql1 = "select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = '" + taikhoan + "'))";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            int temp1 = dt1.Rows.Count;
            if (temp1 < temp)
            {
                MessageBox.Show("Xóa sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại");
            }
            conn.Close();
        }

        private void bthienthisanpham_Click(object sender, EventArgs e)
        {           
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_SP_CUASHOP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi2.DataSource = dt;
            conn.Close();
        }

        private void btQuayve_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '"+matkhau.Trim()+"'", conn);
            //SqlDataAdapter da1 = new SqlDataAdapter("select *from taikhoan where loainguoidung = 'sinhvien'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
        }

        private void btdangsanpham_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            string sql = "select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = '" + taikhoan + "'))";         
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int temp = dt.Rows.Count;
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("SELL_SP_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@tensp", txttensanpham.Text);
            cmd.Parameters.AddWithValue("@mamathangsp", txtmamathang.Text);
            cmd.Parameters.AddWithValue("@giatiensp", txtgiatien.Text);
            cmd.Parameters.AddWithValue("@soluongban", txtsoluong.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();

            dt.Load(dr);
            string sql1 = "select *from SANPHAM where MASHOP = (select mashop from shop where machushop = (select makhachhang from KHACHHANG where TAIKHOAN = '" + taikhoan + "'))";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);

            int temp1 = dt1.Rows.Count;
            if (temp1 > temp)
            {
                MessageBox.Show("Đăng bán thành công");
            }
            else
            {
                MessageBox.Show("Đăng bán thất bại");
            }
            conn.Close();
        }
    }
}
