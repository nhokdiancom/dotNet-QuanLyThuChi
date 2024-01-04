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
    public partial class Formlichchitieu : Form
    {
        string mandlich, tk,tam;
        int sotien;
        public Formlichchitieu(string mandlich,string tk)
        {
            this.mandlich = mandlich;
            this.tk = tk;
            InitializeComponent();
        }

        private void Formlichchitieu_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct * from Noidungchitieu where MaNDCT!=TenNDCT";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbnoidungchi.DisplayMember = "TenNDCT";
            cbnoidungchi.ValueMember = "MaNDCT";
            cbnoidungchi.DataSource = dt;
            txtsotien.Text = "";

            try
            {
                string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and MONTH(tn.Ngay)=month(GETDATE()) and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                if (dt3.Rows[0]["TT"].ToString() == "")
                {
                    tam = "0";
                }
                else
                    tam = dt3.Rows[0]["TT"].ToString();
            }
            catch
            {
                tam = "0";
            }
            lbthongbaotien.Text = lbthongbaotien.Text + " " + tam + " VNĐ";

            string strcon1 = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn1 = new SqlConnection(strcon1);
            conn1.Open();
            string sql1 = "select Distinct ndl.Tenlich[Tên lịch],ndl.NgayBD[Ngày bắt đầu],ndl.NgayKT[Ngày kết thúc],lct.Tenkhoanchi[Tên khoản chi],lct.Sotien[Số tiền] from Noidunglich ndl,Lichchitieu lct, Nguoidung nd where lct.MaNDLich='" + mandlich + "'and ndl.MaNDLich=lct.MaNDLich and nd.MaND=lct.MaND";
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
            DataTable dt1 = new DataTable();
            adapter.Fill(dt1);
            dgvlich.DataSource = dt1;
            sotien = int.Parse(tam);
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            if (int.Parse(tam) == 0)
            {
                MessageBox.Show("Bạn hãy thêm khoản thu nhập!");
            }
            else
            {
                xuly them = new xuly();
                string mand = them.manguoidung(tk);
                string malich = "LCT";
                int i = 1;
                if (them.ktmalich(malich))
                {
                    malich = malich + i;
                    while (them.ktmalich(malich))
                    {
                        string ma1 = malich;
                        string tam1 = ma1.Substring(ma1.Length - 1, 1);
                        string tam2 = ma1.Substring(ma1.Length - 2, 1);
                        xuly so = new xuly();
                        if (so.Isint(tam1) && so.Isint(tam2))
                        {
                            string tam3 = ma1.Substring(ma1.Length - 2, 2);
                            malich = ma1.Substring(0, ma1.Length - 2) + (i + (int.Parse(tam3)));
                        }
                        else
                        {
                            if (so.Isint(tam1))
                            {
                                malich = ma1.Substring(0, ma1.Length - 1) + (i + (int.Parse(tam1)));
                            }
                        }
                    }
                }
                try
                {
                    if ((sotien - int.Parse(txtsotien.Text)) < 0)
                    {
                        MessageBox.Show("Khoản chi có số tiền lớn hơn số tiền còn lại!");
                    }
                    else
                    {
                        if (them.themlich(malich, mand, mandlich, cbnoidungchi.Text, txtsotien.Text))
                        {
                            string strcon1 = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                            SqlConnection conn1 = new SqlConnection(strcon1);
                            conn1.Open();
                            string sql1 = "select Distinct ndl.Tenlich[Tên lịch],ndl.NgayBD[Ngày bắt đầu],ndl.NgayKT[Ngày kết thúc],lct.Tenkhoanchi[Tên khoản chi],lct.Sotien[Số tiền] from Noidunglich ndl,Lichchitieu lct, Nguoidung nd where lct.MaNDLich='" + mandlich + "'and ndl.MaNDLich=lct.MaNDLich and nd.MaND=lct.MaND";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn1);
                            DataTable dt1 = new DataTable();
                            adapter.Fill(dt1);
                            dgvlich.DataSource = dt1;
                            lbthongbaotien.Text = "";
                            sotien = sotien - int.Parse(txtsotien.Text);
                            lbthongbaotien.Text = "Số tiền còn lại: " + (sotien).ToString();
                            txtsotien.Text = "";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Số tiền nhập vào không đúng");
                }
            }
        }

        
        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu ql = new Formquanlychitieu(tk, true);
            this.Hide();
            ql.Show();
        }
    }
}
