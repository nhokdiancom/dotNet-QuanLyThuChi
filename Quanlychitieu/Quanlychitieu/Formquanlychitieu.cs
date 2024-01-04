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
using System.Drawing.Imaging;

namespace Quanlychitieu
{
    public partial class Formquanlychitieu : Form
    {
        bool ktdn = false;
        string tk,matn,mact,tam2,tam1= "";
        SqlConnection conn;
        int tam;
        public Formquanlychitieu(string tk,bool ketnoi)
        {
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            conn = new SqlConnection(strcon);
            conn.Open();
            this.ktdn = ketnoi;
            this.tk = tk;
            InitializeComponent();
        }

        private void Formquanlychitieu_Load(object sender, EventArgs e)
        {
            if (ktdn)
            {
                this.Text = "Chào " + tk+ "!";
                lbchao.Visible = false;
                lbthongtin.Visible = true;
                menudangxuat.Enabled = true;
                menulichchitieu.Enabled = true;
                menuquanlyct.Enabled = true;
                menuthongtin.Enabled = true;
                menuthaydoimk.Enabled = true;
                dgvthongtin.Visible = true;
                lbchon.Visible = false;
                cbthongtin.Visible = false;
                btxem.Visible = false;
                lbthang.Visible = false;
                cbthang.Visible = false;
                lbtongtienthu.Visible = false;
                lbtongtienchi.Visible = false;
                string month = DateTime.Now.Month.ToString();
                lbthongtin.Text = lbthongtin.Text + " " + month + " :";
                btquaylai.Visible = false;
                lbthongbao.Visible = true;
                lbtien.Visible = true;
                lbngay.Visible = false;
                cbngay.Visible = false;
                lbconlai.Visible = false;
                lbtongchi.Visible = false;
                lbtongthu.Visible = false;
                lbthongbaotatca.Visible = false;
                cbthang1.Visible = false;
                menudangnhap.Visible = false;
                try
                {
                    string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and MONTH(tn.Ngay)=month(GETDATE()) and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows[0]["TT"].ToString() == "")
                    {
                        tam2 = "0";
                    }
                    else
                        tam2= dt3.Rows[0]["TT"].ToString();
                }
                catch
                {
                    tam2 = "0";
                }

                try
                {
                    string sql2 = "select sum(ttct.Sotien)[TT] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and MONTH(ttct.Ngay)=month(GETDATE()) and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    if (dt2.Rows[0]["TT"].ToString() == "")
                    {
                        tam1 = "0";
                    }
                    else
                        tam1 = dt2.Rows[0]["TT"].ToString();
                }
                catch
                {
                    tam1 = "0";
                }

                string sql = "select nd.Username[Tài khoản],nd.MaND[Mã người dùng],nd.Hoten[Họ tên],sum(tttn.Sotien)[Tổng số tiền thu(VNĐ)],sum(ttct.Sotien)[Tổng số tiền chi(VNĐ)] from Nguoidung nd,Thongtinchitieu ttct,Thunhap tttn where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and nd.MaND =tttn.MaND group by nd.Username,nd.MaND,nd.Hoten";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    row["Tổng số tiền thu(VNĐ)"] = tam2;
                    row["Tổng số tiền chi(VNĐ)"] = tam1;
                }
                dgvthongtin.DataSource = dt;
                if (int.Parse(tam2) != 0 && int.Parse(tam1) != 0)
                {
                    if ((int.Parse(tam2) - int.Parse(tam1)) < 0)
                    {
                        lbtien.Text = "Số tiền vượt: " + ((int.Parse(tam1) - int.Parse(tam2)).ToString()) + " VNĐ";
                        lbthongbao.Text = "Tháng này bạn đã chi vượt quá thu nhập hiện tại!";
                    }
                    else
                    {
                        if ((int.Parse(tam2) - int.Parse(tam1)) == 0)
                        {
                            lbthongbao.Text = "Tháng này bạn đã chi hết tiền";
                            lbtien.Text = "Số tiền còn lại: 0 VNĐ";
                        }
                        else
                        {
                            lbthongbao.Text = "Tháng này bạn chi tiêu hợp lý và còn dư!";
                            lbtien.Text = "Số tiền còn dư: " + (int.Parse(tam2) - int.Parse(tam1)).ToString() + " VNĐ";
                        }
                    }
                }
                else
                {
                    if (int.Parse(tam2) == 0 && int.Parse(tam1) == 0)
                    {
                        lbthongbao.Text = "Chào " + tk + "! Bạn còn chờ gì nữa hãy thêm khoản thu chi của mình đi nào.";
                        lbtien.Visible = false;
                    }
                    else
                    {
                        lbthongbao.Visible = false;
                        lbtien.Visible = false;
                    }
                }
            }
            else
            {
                lbthang.Visible = false;
                cbthang.Visible = false;
                lbthongtin.Visible = false;
                menudangxuat.Enabled = false;
                menulichchitieu.Enabled = false;
                menuquanlyct.Enabled = false;
                menuthongtin.Enabled = false;
                dgvthongtin.Visible = false;
                lbchon.Visible = false;
                cbthongtin.Visible = false;
                btxem.Visible = false;
                menuthaydoimk.Enabled = false;
                lbtongtienthu.Visible = false;
                lbtongtienchi.Visible = false;
                lbchao.Visible = true;
                btquaylai.Visible = false;
                lbthongbao.Visible = false;
                lbtien.Visible = false;
                lbngay.Visible = false;
                cbngay.Visible = false;
                lbconlai.Visible = false;
                lbtongchi.Visible = false;
                lbtongthu.Visible = false;
                lbthongbaotatca.Visible = false;
                cbthang1.Visible = false;
            }
        }

        private void menudangnhap_Click(object sender, EventArgs e)
        {
            Formdangnhap dn = new Formdangnhap();
            this.Hide();
            dn.Show();
        }

        private void menuthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menudangxuat_Click(object sender, EventArgs e)
        {
            ktdn = false;
            Formquanlychitieu_Load(sender, e);
            menudangnhap.Visible = true;
        }

        private void menuthaydoimk_Click(object sender, EventArgs e)
        {
            Formthaydoimatkhau thaydoi = new Formthaydoimatkhau(tk);
            this.Hide();
            thaydoi.Show();   
        }

        private void menuthemkhoanthu_Click(object sender, EventArgs e)
        {
            Formthemkhoanthu them = new Formthemkhoanthu(tk);
            this.Hide();
            them.Show();
        }

        private void menuthemkhoanchi_Click(object sender, EventArgs e)
        {
            Formthemkhoanchi them1 = new Formthemkhoanchi(tk);
            this.Hide();
            them1.Show();
        }

        private void menusuakhoanthu_Click(object sender, EventArgs e)
        {
            Formsuathunhap sua = new Formsuathunhap(tk);
            this.Hide();
            sua.Show();
        }

        private void menuxoakhoanthu_Click(object sender, EventArgs e)
        {
            Formxoathunhap xoa = new Formxoathunhap(tk);
            this.Hide();
            xoa.Show();
        }

        private void menuxoakhoanchi_Click(object sender, EventArgs e)
        {
            Formxoachitieu xoa = new Formxoachitieu(tk);
            this.Hide();
            xoa.Show();
        }

        private void menuttkhoanthu_Click(object sender, EventArgs e)
        {
            lbthongbao.Visible = false;
            lbtien.Visible = false;
            btquaylai.Visible = true;
            tam = 1;
            lbthongtin.Visible = false;
            lbchon.Visible = true;
            lbchon.Text = "Chọn khoản thu:";
            cbthongtin.Visible = true;
            btxem.Visible = true;
            lbthang.Visible = true;
            cbthang.Visible = true;
            lbtongtienthu.Visible = true;
            lbtongtienthu.Text = "Tổng thu nhập: ";
            lbtongtienchi.Visible = false;
            lbngay.Visible = true;
            cbngay.Visible = true;
            cbthang1.Visible = false;
            xuly mand = new xuly();
            string mand1 = mand.manguoidung(tk);

            string sql1 = "select Distinct month(Ngay)[Thang] from Thunhap where MaND='"+mand1+"'";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();  
            adapter1.Fill(dt1);
            cbthang.DisplayMember = "Thang";
            cbthang.ValueMember = "Thang";
            cbthang.DataSource = dt1;
            cbthang.Text = "Tháng";

            string sql2 = "select Distinct day(Ngay)[Ngay] from Thunhap where MaND='" + mand1 + "'";
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            cbngay.DisplayMember = "Ngay";
            cbngay.ValueMember = "Ngay";
            cbngay.DataSource = dt2;
            cbngay.Text = "Ngày";

            string sql4 = "select Distinct ndtn.MaNDTN[Ma],ndtn.TenNDTN from Noidungthunhap ndtn,Nguoidung nd,Thunhap tn where nd.Username='" + tk + "'and month(tn.Ngay)=month(GETDATE()) and ndtn.MaNDTN=tn.MaNDTN and tn.MaND=nd.MaND and tn.MaTN!=nd.MaND order by ndtn.TenNDTN ASC";
            SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
            DataTable dt4 = new DataTable();
            DataRow dr4 = dt4.NewRow();
            adapter4.Fill(dt4);
            dr4["Ma"] = "TC";
            dr4["TenNDTN"] = "Tất cả";
            dt4.Rows.Add(dr4);
            cbthongtin.DisplayMember = "TenNDTN";
            cbthongtin.ValueMember = "Ma";
            cbthongtin.DataSource = dt4;


            string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "'and month(tn.Ngay)=month(GETDATE()) and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and tn.MaTN!=nd.MaND group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvthongtin.DataSource = dt;

            string sql3 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn where nd.Username='" + tk + "' and month(tttn.Ngay)=month(GETDATE())and nd.MaND=tttn.MaND";
            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);

            lbtongtienthu.Text = lbtongtienthu.Text + dt3.Rows[0]["TT"].ToString() + " VNĐ";
        }

        private void menuttkhoanchi_Click(object sender, EventArgs e)
        {
            lbthongbao.Visible = false;
            lbtien.Visible = false;
            btquaylai.Visible = true;
            tam = 0;
            lbthongtin.Visible = false;
            lbchon.Visible = true;
            lbchon.Text = "Chọn khoản chi:";
            cbthongtin.Visible = true;
            btxem.Visible = true;
            lbthang.Visible = true;
            cbthang.Visible = true;
            lbtongtienchi.Visible = true;
            lbtongtienchi.Text = "Tổng chi tiêu: ";
            lbtongtienthu.Visible = false;
            dgvthongtin.Visible = true;
            lbngay.Visible = true;
            cbngay.Visible = true;
            cbthang1.Visible = false;
            

            string sql1 = "select Distinct month(Ngay)[Thang] from Thongtinchitieu";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            cbthang.DisplayMember = "Thang";
            cbthang.ValueMember = "Thang";
            cbthang.DataSource = dt1;
            cbthang.Text = "Tháng";


            string sql4 = "select Distinct day(Ngay)[Ngay] from Thongtinchitieu";
            SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
            DataTable dt4 = new DataTable();
            adapter4.Fill(dt4);
            cbngay.DisplayMember = "Ngay";
            cbngay.ValueMember = "Ngay";
            cbngay.DataSource = dt4;
            cbngay.Text = "Ngày";


            string sql2 = "select Distinct ndct.MaNDCT[Ma],ndct.TenNDCT from Noidungchitieu ndct,Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE()) and ndct.MaNDCT=ttct.MaNDCT and ttct.MaND=nd.MaND and ttct.MaTTCT!=nd.MaND order by ndct.TenNDCT ASC";
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            DataRow dr = dt2.NewRow();
            adapter2.Fill(dt2);
            dr["Ma"] = "TC";
            dr["TenNDCT"] = "Tất cả";
            dt2.Rows.Add(dr);
            cbthongtin.DisplayMember = "TenNDCT";
            cbthongtin.ValueMember = "Ma";
            cbthongtin.DataSource = dt2;


            string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE())  and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT and ttct.MaTTCT!=nd.MaND group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvthongtin.DataSource = dt;

            string sql3 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE())  and nd.MaND=ttct.MaND";
            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);
            lbtongtienchi.Text = lbtongtienchi.Text + dt3.Rows[0]["TT"].ToString() + " VNĐ";
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tam == 1)
                {
                    if (cbthongtin.Text == "Tất cả")
                    {
                        if (cbthang.Text != "Tháng")
                        {
                            string sql3 = "select Distinct ndtn.MaNDTN[Ma],ndtn.TenNDTN from Noidungthunhap ndtn,Nguoidung nd,Thunhap tn where nd.Username='" + tk + "'and ndtn.MaNDTN=tn.MaNDTN and tn.MaND=nd.MaND and tn.MaTN!=nd.MaND order by ndtn.TenNDTN ASC";
                            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                            DataTable dt3 = new DataTable();
                            DataRow dr = dt3.NewRow();
                            adapter3.Fill(dt3);
                            dr["Ma"] = "TC";
                            dr["TenNDTN"] = "Tất cả";
                            dt3.Rows.Add(dr);
                            cbthongtin.DisplayMember = "TenNDTN";
                            cbthongtin.ValueMember = "Ma";
                            cbthongtin.DataSource = dt3;

                            string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and month(tn.Ngay)='" + cbthang.Text + "'and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and tn.MaTN!=nd.MaND group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvthongtin.DataSource = dt;

                            string sql2 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn where nd.Username='" + tk + "' and month(tn.Ngay)='" + cbthang.Text + "' and nd.MaND=tttn.MaND";
                            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                            DataTable dt2 = new DataTable();
                            adapter2.Fill(dt2);
                            lbtongtienthu.Text = "Tổng thu nhập: ";
                            lbtongtienthu.Text = lbtongtienthu.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                        }
                        else
                        {
                            string sql3 = "select Distinct ndtn.MaNDTN[Ma],ndtn.TenNDTN from Noidungthunhap ndtn,Nguoidung nd,Thunhap tn where nd.Username='" + tk + "'and month(tn.Ngay)=month(GETDATE()) and ndtn.MaNDTN=tn.MaNDTN and tn.MaND=nd.MaND and tn.MaTN!=nd.MaND order by ndtn.TenNDTN ASC";
                            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                            DataTable dt3 = new DataTable();
                            DataRow dr = dt3.NewRow();
                            adapter3.Fill(dt3);
                            dr["Ma"] = "TC";
                            dr["TenNDTN"] = "Tất cả";
                            dt3.Rows.Add(dr);
                            cbthongtin.DisplayMember = "TenNDTN";
                            cbthongtin.ValueMember = "Ma";
                            cbthongtin.DataSource = dt3;

                            string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "'and month(tn.Ngay)=month(GETDATE())  and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and tn.MaTN!=nd.MaND group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvthongtin.DataSource = dt;

                            string sql2 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn where nd.Username='" + tk + "'and month(tttn.Ngay)=month(GETDATE())  and nd.MaND=tttn.MaND";
                            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                            DataTable dt2 = new DataTable();
                            adapter2.Fill(dt2);
                            lbtongtienthu.Text = "Tổng thu nhập: ";
                            lbtongtienthu.Text = lbtongtienthu.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                        }
                    }
                    else
                    {
                        if (cbthang.Text != "Tháng")
                        {
                            if (cbngay.Text != "Ngày")
                            {
                                matn = cbthongtin.SelectedValue.ToString();
                                string ma = cbthongtin.SelectedValue.ToString();
                                string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and ndtn.MaNDTN='" + ma + "' and month(tn.Ngay)='" + cbthang.Text + "'and day(tn.Ngay)='" + cbngay.Text + "' group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvthongtin.DataSource = dt;
                                string sql2 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn,Noidungthunhap ndtn where nd.Username='" + tk + "' and nd.MaND=tttn.MaND and ndtn.MaNDTN='" + matn + "' and month(tttn.Ngay)='" + cbthang.Text + "'and day(tttn.Ngay)='" + cbngay.Text + "' and tttn.MaNDTN=ndtn.MaNDTN";
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                                DataTable dt2 = new DataTable();
                                adapter2.Fill(dt2);
                                lbtongtienthu.Text = "Tổng thu nhập: ";
                                lbtongtienthu.Text = lbtongtienthu.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                                cbngay.Text = "Ngày";
                                cbthang.Text = "Tháng";
                            }
                            else
                            {
                                matn = cbthongtin.SelectedValue.ToString();
                                string ma = cbthongtin.SelectedValue.ToString();
                                string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and ndtn.MaNDTN='" + ma + "' and month(tn.Ngay)='" + cbthang.Text + "' group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvthongtin.DataSource = dt;
                                string sql2 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn,Noidungthunhap ndtn where nd.Username='" + tk + "' and nd.MaND=tttn.MaND and ndtn.MaNDTN='" + matn + "' and month(tttn.Ngay)='" + cbthang.Text + "' and tttn.MaNDTN=ndtn.MaNDTN";
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                                DataTable dt2 = new DataTable();
                                adapter2.Fill(dt2);
                                lbtongtienthu.Text = "Tổng thu nhập: ";
                                lbtongtienthu.Text = lbtongtienthu.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                                cbthang.Text = "Tháng";
                            }
                        }
                        else
                        {
                            matn = cbthongtin.SelectedValue.ToString();
                            string ma = cbthongtin.SelectedValue.ToString();
                            string sql = "select tn.MaTN[Mã thu nhập],ndtn.TenNDTN[Tên thu nhập],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and ndtn.MaNDTN='" + ma + "' group by nd.Username,nd.MaND,tn.MaTN,ndtn.TenNDTN,tn.Sotien,tn.Ngay,tn.Ghichu";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvthongtin.DataSource = dt;
                            string sql2 = "select sum(tttn.Sotien)[TT] from Nguoidung nd,Thunhap tttn,Noidungthunhap ndtn where nd.Username='" + tk + "' and nd.MaND=tttn.MaND and ndtn.MaNDTN='" + matn + "' and tttn.MaNDTN=ndtn.MaNDTN";
                            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                            DataTable dt2 = new DataTable();
                            adapter2.Fill(dt2);
                            lbtongtienthu.Text = "Tổng thu nhập: ";
                            lbtongtienthu.Text = lbtongtienthu.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                            cbngay.Text = "Ngày";
                            cbthang.Text = "Tháng";
                        }
                    }
                }
                else
                {
                    if (tam == 0)
                    {
                        if (cbthongtin.Text == "Tất cả")
                        {
                            if (cbthang.Text != "Tháng")
                            {
                                string sql3 = "select Distinct ndct.MaNDCT[Ma],ndct.TenNDCT from Noidungchitieu ndct,Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and ndct.MaNDCT=ttct.MaNDCT and ttct.MaND=nd.MaND and ttct.MaTTCT!=nd.MaND order by ndct.TenNDCT ASC";
                                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                                DataTable dt3 = new DataTable();
                                DataRow dr = dt3.NewRow();
                                adapter3.Fill(dt3);
                                dr["Ma"] = "TC";
                                dr["TenNDCT"] = "Tất cả";
                                dt3.Rows.Add(dr);
                                cbthongtin.DisplayMember = "TenNDCT";
                                cbthongtin.ValueMember = "Ma";
                                cbthongtin.DataSource = dt3;

                                string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and month(ttct.Ngay)='" + cbthang.Text + "'and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT and ttct.MaTTCT!=nd.MaND group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvthongtin.DataSource = dt;

                                string sql2 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and month(ttct.Ngay)='" + cbthang.Text + "' and nd.MaND=ttct.MaND";
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                                DataTable dt2 = new DataTable();
                                adapter2.Fill(dt2);
                                lbtongtienchi.Text = "Tổng chi tiêu: ";
                                lbtongtienchi.Text = lbtongtienchi.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                                cbthang.Text = "Tháng";
                                cbngay.Text = "Ngày";
                            }
                            else
                            {
                                string sql3 = "select Distinct ndct.MaNDCT[Ma],ndct.TenNDCT from Noidungchitieu ndct,Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE()) and ndct.MaNDCT=ttct.MaNDCT and ttct.MaND=nd.MaND and ttct.MaTTCT!=nd.MaND order by ndct.TenNDCT ASC";
                                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                                DataTable dt3 = new DataTable();
                                DataRow dr = dt3.NewRow();
                                adapter3.Fill(dt3);
                                dr["Ma"] = "TC";
                                dr["TenNDCT"] = "Tất cả";
                                dt3.Rows.Add(dr);
                                cbthongtin.DisplayMember = "TenNDCT";
                                cbthongtin.ValueMember = "Ma";
                                cbthongtin.DataSource = dt3;

                                string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE())  and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT and ttct.MaTTCT!=nd.MaND group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvthongtin.DataSource = dt;

                                string sql2 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE())  and nd.MaND=ttct.MaND";
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                                DataTable dt2 = new DataTable();
                                adapter2.Fill(dt2);
                                lbtongtienchi.Text = "Tổng chi tiêu: ";
                                lbtongtienchi.Text = lbtongtienchi.Text + dt2.Rows[0]["TT"].ToString() + " VNĐ";
                                cbthang.Text = "Tháng";
                                cbngay.Text = "Ngày";
                            }
                        }
                        else
                        {
                            if (cbthang.Text != "Tháng")
                            {
                                if (cbngay.Text != "Ngày")
                                {
                                    mact = cbthongtin.SelectedValue.ToString();
                                    string ma = cbthongtin.SelectedValue.ToString();
                                    string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ttct.MaNDCT=ndct.MaNDCT and ndct.MaNDCT='" + mact + "' and month(ttct.Ngay)='" + cbthang.Text + "'and day(ttct.Ngay)='" + cbngay.Text + "'group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
                                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);
                                    dgvthongtin.DataSource = dt;

                                    string sql3 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct,Noidungchitieu ndct where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ndct.MaNDCT='" + mact + "' and month(ttct.Ngay)='" + cbthang.Text + "' and day(ttct.Ngay)='" + cbngay.Text + "'and ttct.MaNDCT=ndct.MaNDCT";
                                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                                    DataTable dt3 = new DataTable();
                                    adapter3.Fill(dt3);
                                    lbtongtienchi.Text = "Tổng chi tiêu: ";
                                    lbtongtienchi.Text = lbtongtienchi.Text + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                                    cbthang.Text = "Tháng";
                                    cbngay.Text = "Ngày";
                                }
                                else
                                {
                                    mact = cbthongtin.SelectedValue.ToString();
                                    string ma = cbthongtin.SelectedValue.ToString();
                                    string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ttct.MaNDCT=ndct.MaNDCT and ndct.MaNDCT='" + mact + "' and month(ttct.Ngay)='" + cbthang.Text + "'group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
                                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);
                                    dgvthongtin.DataSource = dt;

                                    string sql3 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct,Noidungchitieu ndct where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ndct.MaNDCT='" + mact + "' and month(ttct.Ngay)='" + cbthang.Text + "' and ttct.MaNDCT=ndct.MaNDCT";
                                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                                    DataTable dt3 = new DataTable();
                                    adapter3.Fill(dt3);
                                    lbtongtienchi.Text = "Tổng chi tiêu: ";
                                    lbtongtienchi.Text = lbtongtienchi.Text + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                                    cbthang.Text = "Tháng";
                                    cbngay.Text = "Ngày";
                                }
                            }
                            else
                            {
                                mact = cbthongtin.SelectedValue.ToString();
                                string ma = cbthongtin.SelectedValue.ToString();
                                string sql = "select ttct.MaTTCT[Mã chi tiêu],ndct.TenNDCT[Tên chi tiêu],ttct.Sotien[Số tiền],ttct.Ngay[Ngày],ttct.Ghichu[Ghi chú] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ttct.MaNDCT=ndct.MaNDCT and ndct.MaNDCT='" + mact + "'group by nd.Username,nd.MaND,ttct.MaTTCT,ndct.TenNDCT,ttct.Sotien,ttct.Ngay,ttct.Ghichu";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dgvthongtin.DataSource = dt;

                                string sql3 = "select sum(ttct.Sotien)[TT] from Nguoidung nd,Thongtinchitieu ttct,Noidungchitieu ndct where nd.Username='" + tk + "' and nd.MaND=ttct.MaND and ndct.MaNDCT='" + mact + "' and  ttct.MaNDCT=ndct.MaNDCT";
                                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                                DataTable dt3 = new DataTable();
                                adapter3.Fill(dt3);
                                lbtongtienchi.Text = "Tổng chi tiêu: ";
                                lbtongtienchi.Text = lbtongtienchi.Text + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                                cbthang.Text = "Tháng";
                                cbngay.Text = "Ngày";
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu");
            }
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            lbthongtin.Text ="Thông tin của bạn trong tháng ";
            Formquanlychitieu_Load(sender, e);
        }

        private void menusuakhoanchi_Click(object sender, EventArgs e)
        {
            Formsuachitieu sua1 = new Formsuachitieu(tk);
            this.Hide();
            sua1.Show();
        }

        private void menutttatca_Click(object sender, EventArgs e)
        {
            lbngay.Visible = false;
            cbngay.Visible = false;
            lbchao.Visible = false;
            lbchon.Visible = false;
            lbthang.Visible = false;
            lbthongbao.Visible = false;
            lbtien.Visible = false;
            lbtongtienthu.Visible = false;
            lbtongtienchi.Visible = false;
            cbthongtin.Visible = false;
            cbthang.Visible = false;
            btxem.Visible = false;
            btquaylai.Visible = true;
            lbthongtin.Visible = true;
            lbtongchi.Visible = true;
            lbtongthu.Visible = true;
            int tam,tam1;
            cbthang1.Visible = true;
            lbthang.Visible = true;
            string sql2 = "select Distinct month(Ngay)[Thang] from Thongtinchitieu";
            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            cbthang1.DisplayMember = "Thang";
            cbthang1.ValueMember = "Thang";
            cbthang1.DataSource = dt2;
            cbthang1.Text = "Tháng";
            lbconlai.Text = "";
            lbtongchi.Text = "";
            lbtongthu.Text = "";
           
                lbthongtin.Text = "Tất cả thông tin chi tiêu tháng "+DateTime.Now.Month.ToString()+" :";
                string sql1 = "select Distinct tn.MaTN[Mã],ndtn.TenNDTN[Tên nội dung],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and month(tn.Ngay)=month(GETDATE()) and ndtn.MaNDTN=tn.MaNDTN and tn.MaTN!=nd.MaND and ndtn.MaNDTN!=ndtn.TenNDTN UNION ALL select Distinct ct.MaTTCT,ndct.TenNDCT,ct.Sotien,ct.Ngay,ct.Ghichu from Nguoidung nd,Thongtinchitieu ct,Noidungchitieu ndct where nd.Username='" + tk + "'and month(ct.Ngay)=month(GETDATE()) and ndct.MaNDCT=ct.MaNDCT and ct.MaTTCT!=nd.MaND and ndct.MaNDCT!=ndct.TenNDCT";
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvthongtin.DataSource = dt;
                try
                {
                    string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and month(tn.Ngay)=month(GETDATE()) and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows[0]["TT"].ToString() == "")
                    {
                        lbtongthu.Text = "Tổng thu: " + "0" + " VNĐ";
                        tam = 0;
                    }
                    else
                    {
                        lbtongthu.Text = "Tổng thu: " + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                        tam = int.Parse(dt3.Rows[0]["TT"].ToString());
                    }
                }
                catch
                {
                    lbtongthu.Text = "Tổng thu: " + "0" + " VNĐ";
                    tam = 0;
                }

                try
                {
                    string sql3 = "select sum(ttct.Sotien)[TT] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "'and month(ttct.Ngay)=month(GETDATE())  and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows[0]["TT"].ToString() == "")
                    {
                        lbtongchi.Text = "Tổng chi: " + "0" + " VNĐ";
                        tam1 = 0;
                    }
                    else
                    {
                        lbtongchi.Text = "Tổng chi: " + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                        tam1 = int.Parse(dt3.Rows[0]["TT"].ToString());
                    }
                }
                catch
                {
                    lbtongchi.Text = "Tổng chi: " + "0" + " VNĐ";
                    tam1 = 0;
                }

                lbconlai.Visible = true;
                if ((tam - tam1) < 0)
                {
                    lbconlai.Text = "Số tiền vượt: " + ((tam1 - tam)).ToString() + " VNĐ";
                    lbthongbaotatca.Visible = true;
                    lbthongbaotatca.Text = "Trong tháng này bạn chi vượt số tiền thu nhập!";
                }
                else
                {
                    if ((tam - tam1) == 0)
                    {
                        lbconlai.Text = "Số tiền còn lai: " + ((tam - tam1)).ToString()+" VNĐ";
                        lbthongbaotatca.Visible = true;
                        lbthongbaotatca.Text = "Trong tháng này bạn đã chi hết tiền!";
                    }
                    else
                    {
                        lbconlai.Text = "Số tiền còn dư: " + ((tam - tam1)).ToString() + " VNĐ";
                        lbthongbaotatca.Visible = true;
                        lbthongbaotatca.Text = "Trong tháng này bạn chi hợp lý và còn dư!";
                    }
            }
        }

        private void cbthang1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tam, tam1;
            if (cbthang1.Text != "Tháng")
            {
                lbconlai.Text = "";
                lbtongchi.Text = "";
                lbtongthu.Text = "";
                lbthongtin.Text = "Tất cả thông tin tháng " + cbthang1.Text + " :";
                string sql1 = "select Distinct tn.MaTN[Mã],ndtn.TenNDTN[Tên nội dung],tn.Sotien[Số tiền],tn.Ngay[Ngày],tn.Ghichu[Ghi chú] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and MONTH(tn.Ngay)='" + cbthang1.Text + "' and ndtn.MaNDTN=tn.MaNDTN and tn.MaTN!=nd.MaND and ndtn.MaNDTN!=ndtn.TenNDTN UNION ALL select Distinct ct.MaTTCT,ndct.TenNDCT,ct.Sotien,ct.Ngay,ct.Ghichu from Nguoidung nd,Thongtinchitieu ct,Noidungchitieu ndct where nd.Username='" + tk + "' and MONTH(ct.Ngay)='" + cbthang1.Text + "' and ndct.MaNDCT=ct.MaNDCT and ct.MaTTCT!=nd.MaND and ndct.MaNDCT!=ndct.TenNDCT";
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvthongtin.DataSource = dt;
                try
                {
                    string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and MONTH(tn.Ngay)='" + cbthang1.Text + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows[0]["TT"].ToString() == "")
                    {
                        lbtongthu.Text ="Tổng thu: " + "0" + " VNĐ";
                        tam = 0;
                    }
                    else
                    {
                        lbtongthu.Text = "Tổng thu: " + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                        tam = int.Parse(dt3.Rows[0]["TT"].ToString());
                    }
                }
                catch
                {
                    lbtongthu.Text = "Tổng thu: " + "0" + " VNĐ";
                    tam = 0;
                }

                try
                {
                    string sql3 = "select sum(ttct.Sotien)[TT] from Thongtinchitieu ttct,Noidungchitieu ndct,Nguoidung nd where nd.Username='" + tk + "' and MONTH(ttct.Ngay)='" + cbthang1.Text + "' and nd.MaND=ttct.MaND and ttct.MaNDCT =ndct.MaNDCT";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows[0]["TT"].ToString() == "")
                    {
                        lbtongchi.Text = "Tổng chi: "+ "0" + " VNĐ";
                        tam1 = 0;
                    }
                    else
                    {
                        lbtongchi.Text = "Tổng chi: " + dt3.Rows[0]["TT"].ToString() + " VNĐ";
                        tam1 = int.Parse(dt3.Rows[0]["TT"].ToString());
                    }
                }
                catch
                {
                    lbtongchi.Text = "Tổng chi: " + "0" + " VNĐ";
                    tam1 = 0;
                }

                lbconlai.Visible = true;
                if ((tam - tam1) < 0)
                {
                    lbconlai.Text = "Số tiền vượt: " + ((tam1 - tam)).ToString();
                    lbthongbaotatca.Visible = true;
                    lbthongbaotatca.Text = "Trong tháng này bạn chi vượt số tiền thu nhập!";
                }
                else
                {
                    if ((tam - tam1) == 0)
                    {
                        lbconlai.Text = "Số tiền còn lai: " + ((tam - tam1)).ToString();
                        lbthongbaotatca.Visible = true;
                        lbthongbaotatca.Text = "Trong tháng này bạn đã chi hết tiền!";
                    }
                    else
                    {
                        lbconlai.Text = "Số tiền còn dư: " + ((tam - tam1)).ToString();
                        lbthongbaotatca.Visible = true;
                        lbthongbaotatca.Text = "Trong tháng này bạn chi hợp lý và còn dư!";
                    }

                }
            }
        }

        private void xemLịchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formxemlich xem = new Formxemlich(tk);
            this.Hide();
            xem.Show();
        }

        private void menututaolich_Click(object sender, EventArgs e)
        {
            Formnhaptenlich lich = new Formnhaptenlich(tk);
            this.Hide();
            lich.Show();
        }

        private void xóaLịchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formxoalich xoa = new Formxoalich(tk);
            this.Hide();
            xoa.Show();
        }
    }
}
