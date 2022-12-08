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
    public partial class Trang_HoaDon : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_HoaDon()
        {
            InitializeComponent();
        }

        private void btSuahoadon_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("UPDATE_HOADON_TINHTRANGXACNHAN_RATING_NHANXET", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            cmd.Parameters.AddWithValue("@mahoadon", txtMahoadon.Text);
            cmd.Parameters.AddWithValue("@tinhtranghoadon", txtTinhtrang.Text);
            cmd.Parameters.AddWithValue("@rating", txtRating.Text);
            cmd.Parameters.AddWithValue("@nhanxet", txtNhanXet.Text);
            if (txtMahoadon.Text != "" && txtTinhtrang.Text != "" && txtRating.Text != "" && txtNhanXet.Text != "")
            {
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                MessageBox.Show("Sửa thành công");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Không có hóa đơn này hoặc bạn chưa nhập đủ thông tin");
            }

        }

        private void txt_hoadon_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
        }

        public Trang_HoaDon(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        private void btHienthihoadon_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_HOADON_CUAKHACHHANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            if (loainguoidung.Trim() == "GIAOHANG")
            {
                MessageBox.Show("Không có quyền này");
            }
                
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            txtbanghienthi3.DataSource = dt;
            conn.Close();
        }
    }
}

