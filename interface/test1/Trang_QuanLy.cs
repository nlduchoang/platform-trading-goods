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
    public partial class Trang_QuanLy : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_QuanLy()
        {
            InitializeComponent();
        }
        public Trang_QuanLy(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }

        private void btxemrating_Click(object sender, EventArgs e)
        {           
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("LAYRATINGTHAP_ADMIN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi0.DataSource = dt;
            conn.Close();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
        }

        private void btxemdoanhthu_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("XEMDOANHTHU_ADMIN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi0.DataSource = dt;
            conn.Close();
        }
    }
}
