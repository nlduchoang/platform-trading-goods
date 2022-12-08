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
    public partial class Trang_Shipper : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
   
        public Trang_Shipper()
        {
            InitializeComponent();
        }
        
        private void txtThoat_Trangshipper_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select *from dangnhap where taikhoan = '" + taikhoan.Trim() + "' and matkhau = '" + matkhau.Trim() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            FormDemo f = new FormDemo(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
            f.ShowDialog();
        }

        private void Trang_Shipper_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
        }

        public Trang_Shipper(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }
        private void txtXemthongtin_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_THONGTIN_CUASHIPPER", conn);
            cmd.CommandType = CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@loainguoidung", loainguoidung);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            txtbanghienthi.DataSource = dt;
            conn.Close();
        }
    }
}
