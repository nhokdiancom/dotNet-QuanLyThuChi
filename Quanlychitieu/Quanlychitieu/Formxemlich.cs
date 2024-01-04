using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Quanlychitieu
{
    public partial class Formxemlich : Form
    {
        string tk = "";
        public Formxemlich(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formxemlich_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
                string sql = "select Distinct ndl.MaNDLich,ndl.Tenlich from Noidunglich ndl,Lichchitieu lich,Nguoidung nd where ndl.MaNDLich=lich.MaNDLich and nd.Username='"+tk+"' and lich.MaND=nd.MaND";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbtenlich.DisplayMember = "Tenlich";
                cbtenlich.ValueMember = "MaNDLich";
                cbtenlich.DataSource = dt;
                lbtongchi.Visible = false;
                lbthongbaotien.Visible = false;
          
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu ql = new Formquanlychitieu(tk, true);
            this.Hide();
            ql.Show();
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string mandlich = cbtenlich.SelectedValue.ToString();
                string sql = "select Distinct ndlich.MaNDLich[Mã lịch],ndlich.Tenlich[Tên lịch],ndlich.NgayBD[Ngày bắt đầu],ndlich.NgayKT[Ngày kết thúc],lich.Tenkhoanchi[Tên khoản chi],lich.Sotien[Số tiền] from Lichchitieu lich,Noidunglich ndlich where lich.MaNDLich='" + mandlich + "' and ndlich.MaNDLich=lich.MaNDLich";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvthongtinlich.DataSource = dt;
                lbtongchi.Visible = true;
                lbtongchi.Text = "";
                lbthongbaotien.Text = "";
                string sql4 = "select sum(lich.Sotien)[TT] from Lichchitieu lich,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=lich.MaND and lich.MaNDLich='" + mandlich + "'";
                SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);
                lbtongchi.Text = "Tổng số tiền chi: " + dt4.Rows[0]["TT"].ToString();
                int tongchi = int.Parse(dt4.Rows[0]["TT"].ToString());

                string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and month(tn.Ngay)='" + DateTime.Now.Month + "'";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                int TTTN = int.Parse(dt3.Rows[0]["TT"].ToString());
                lbthongbaotien.Visible = true;
                lbthongbaotien.Text = "Tổng số tiền còn lại: " + " " + (TTTN - tongchi);
            }
            catch
            {
                MessageBox.Show("Bạn chưa tạo lịch chi tiêu nào. Hãy tạo lịch chi tiêu!");
            }
        }
    }
}
