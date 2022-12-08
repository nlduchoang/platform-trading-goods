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
    public partial class Trang_DonHang : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_DonHang()
        {
            InitializeComponent();
        }
        public Trang_DonHang(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        private void txtNhandonhang_Click(object sender, EventArgs e)
        {
            if(loainguoidung == "KHACHHANG")
            {
                txtNhandonhang.Visible = false;
            }
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            string sql = "select *from giaohang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int temp = dt.Rows.Count;
            conn.Close();
            conn.Open();

            cmd = new SqlCommand("NHANDONHANG_INSERT_ROW_TABLE_GIAOHANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung.Trim());
            cmd.Parameters.AddWithValue("@madonhang", txtMadonhang.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();

            dt.Load(dr);
            string sql1 = "select *from giaohang";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);

            int temp1 = dt1.Rows.Count;
            if (temp1 > temp)
            {
                MessageBox.Show("Nhận đơn thành công");
            }
            else if (temp1 > temp || txtMadonhang.Text == "")
            {
                MessageBox.Show("Đơn hàng này không tồn tại hoặc bạn chưa điền đủ thông tin");
            }
            conn.Close();
        }


        private void txtThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '"+matkhau.Trim()+"'",conn);
            //SqlDataAdapter da1 = new SqlDataAdapter("select *from taikhoan where loainguoidung = 'sinhvien'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
            //DialogResult f = MessageBox.Show("Bạn có chắc chắn muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (f == DialogResult.Yes)
            //{
            //    this.Close();
            //    //Application.Exit();
            //    Application.Restart();
            //}
            //conn.Close();
        }

        private void btSuadonhang_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
                conn.Open();
                cmd = new SqlCommand("UPDATE_DONHANG_CHUACOSHIPPERNHAN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
                cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
                cmd.Parameters.AddWithValue("@madonhang", txtmadonhang_update.Text);
                cmd.Parameters.AddWithValue("@soluong", txtSoluong.Text);
                cmd.Parameters.AddWithValue("@hinhthucthanhtoan", txtHinhthucthanhtoan.Text);
                if (txtmadonhang_update.Text != "" && txtSoluong.Text != "" && txtHinhthucthanhtoan.Text != "")
                {
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    MessageBox.Show("Sửa thành công");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Không có đơn hàng này hoặc bạn chưa nhập đủ thông tin sản phẩm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Trang_DonHang_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            if(loainguoidung.Trim() == "GIAOHANG")
            {
                btSuadonhang.Visible = false;
                btHuydonhang.Visible = false;
                txtSoluong.Visible = false;
                txtHinhthucthanhtoan.Visible = false;
                txtmadonhang_update.Visible = false;
                lbSoluong.Visible = false;
                lbHinhthucthanhtoan.Visible = false;
                label2.Visible = false; 
            }
        }

        private void btHuydonhang_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            string sql = "select *from donhang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int temp = dt.Rows.Count;
            conn.Close();
            conn.Open();

            cmd = new SqlCommand("DELETE_DONHANG_CHUACOSHIPPERNHAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            cmd.Parameters.AddWithValue("@madonhang", txtMadonhang.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();

            dt.Load(dr);
            string sql1 = "select *from donhang";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);

            int temp1 = dt1.Rows.Count;
            if (temp1 < temp)
            {
                MessageBox.Show("Xóa đơn thành công");
            }
            else if (temp1 < temp || txtMadonhang.Text == "")
            {
                MessageBox.Show("Đơn hàng này không tồn tại hoặc bạn chưa điền đủ thông tin");
            }
            conn.Close();
        }

        private void txtDonhang_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_DONHANG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            txtbanghienthi1.DataSource = dt;
            conn.Close();
        }
    }
}
