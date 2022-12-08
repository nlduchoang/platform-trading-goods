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
    public partial class Trang_KhachHang : Form
    {
        string taikhoan = "", matkhau = "", loainguoidung = "";
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlConnection conn;
        public Trang_KhachHang()
        {
            InitializeComponent();
        }

        private void btxemthongtin_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("VIEW_TABLE_InfoKH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim());
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dgvbanghienthi6.DataSource = dt;
            conn.Close();
        }

        private void btSuathongtin_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("UPDATE_TABLE_InfoKH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
            cmd.Parameters.AddWithValue("@hotenmoi", txthoten.Text);
            cmd.Parameters.AddWithValue("@sodienthoaimoi", txtSĐT.Text);
            cmd.Parameters.AddWithValue("@emailmoi", txtEmail.Text);
            cmd.Parameters.AddWithValue("@diachimoi", txtDiachi.Text);
            cmd.Parameters.AddWithValue("@matkhaumoi", txtMatkhau.Text);
            if (txthoten.Text != "" && txtSĐT.Text != "" && txtEmail.Text != "" && txtDiachi.Text != "" && txtMatkhau.Text != "" )
            {
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần sửa");
            }
        }

        private void bttaoshop_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-BABQJU6\SQLEXPRESS;Initial Catalog=HETHONGBANHANG_test;Integrated Security=True");
            conn.Open();
            string sql = "select *from SHOP where MACHUSHOP = (select makhachhang from KHACHHANG where TAIKHOAN = '" + taikhoan + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int temp = dt.Rows.Count;
            if(temp == 0)
            {
                conn.Close();
                conn.Open();
                cmd = new SqlCommand("ADD_SHOP_KH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan.Trim()); //lệnh trim() để xóa khoảng trắng đầu và cuối chuỗi
                cmd.Parameters.AddWithValue("@tenshop", txtTenshop.Text);
                cmd.Parameters.AddWithValue("@sodienthoaishop", txtSĐT_tao.Text);
                cmd.Parameters.AddWithValue("@diachishop", txtDiachi_tao.Text);
                if(txtTenshop.Text != "" && txtSĐT_tao.Text != "" && txtDiachi_tao.Text != "" && loainguoidung == "KHACHHANG"){
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    MessageBox.Show("Tạo shop thành công");
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập thông tin shop cần tạo");
                }                
            }
            else
            {
                MessageBox.Show("Mỗi tài khoản chỉ được tạo một shop");
            }                
            

            //try
            //{
             
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
            //conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
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

        public Trang_KhachHang(string taikhoan, string matkhau, string loainguoidung)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.loainguoidung = loainguoidung;
        }
        
    }
}
