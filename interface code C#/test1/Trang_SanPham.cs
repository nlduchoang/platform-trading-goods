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
    public partial class Trang_SanPham : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_SanPham()
        {
            InitializeComponent();
        }
        public Trang_SanPham(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("FIND_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            //cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            cmd.Parameters.AddWithValue("@mamathangsp", txtTimkiem.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi5.DataSource = dt;
            conn.Close();
        }

        private void btMuasanpham_Click(object sender, EventArgs e)
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
            cmd = new SqlCommand("ADD_ĐH_KH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@masanpham", txtMasanpham.Text);
            cmd.Parameters.AddWithValue("@soluong", txtSoluongmua.Text);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);

            string sql1 = "select *from donhang";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            
            int temp1 = dt1.Rows.Count;
            if(temp1 > temp)
            {
                MessageBox.Show("Mua thành công");
            }
            else
            {
                MessageBox.Show("Mua thất bại");
            }
            conn.Close();
        }

        private void btQuayVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
        }

        private void btHienthisanpham_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_SP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            //cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi5.DataSource = dt;
            conn.Close();
        }
    }
}
