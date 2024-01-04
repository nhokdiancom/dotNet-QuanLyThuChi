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
    public partial class Formlichchitieumau : Form
    {
        int luu, TTTN = 0;
        string tk, MaNDLich, Malich, manguoidung = "";
        public Formlichchitieumau(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formlichchitieumau_Load(object sender, EventArgs e)
        {
            cbnoio.Text = "Nhà";
            cbnoio.Items.Add("Nhà");
            cbnoio.Items.Add("Nhà trọ");
            dgvthongtinlich.Visible = false;
            lbtien.Visible = false;
            txttiennhatro.Visible = false;
            lbthongbaotien.Visible = false;
            lbtongchi.Visible = false;
            btluu.Visible = false;
          
            btkhongluu.Visible = false;
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql3 = "select sum(tn.Sotien)[TT] from Thunhap tn,Noidungthunhap ndtn,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=tn.MaND and tn.MaNDTN =ndtn.MaNDTN and month(tn.Ngay)='" + DateTime.Now.Month + "'";
            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataTable dt3 = new DataTable();
            adapter3.Fill(dt3);
            TTTN = int.Parse(dt3.Rows[0]["TT"].ToString());

        }

        private void bttaolich_Click(object sender, EventArgs e)
        {
            if (cbnoio.Text == "Nhà")
            {
                xuly lich = new xuly();
                MaNDLich = lich.catchuoi(cbnoio.Text);
                Malich = MaNDLich;
                int i = 1;
                if (lich.ktmandlich(MaNDLich))
                {
                    MaNDLich = MaNDLich + i;
                    while (lich.ktmandlich(MaNDLich))
                    {
                        string ma1 = MaNDLich;
                        string tam1 = ma1.Substring(ma1.Length - 1, 1);
                        xuly so = new xuly();
                        if (so.Isint(tam1))
                        {
                            tam1 = MaNDLich.Substring(0, MaNDLich.Length - 1) + (i + (int.Parse(tam1)));
                            MaNDLich = tam1;
                        }
                    }
                }

                manguoidung = lich.manguoidung(tk);
                lich.themndlichmau(MaNDLich, dngaybd.Text, dngaykt.Text);
                if (TTTN > 0)
                {
                    if (txttiendien.Text != "" && TTTN - int.Parse(txttiendien.Text) >= 0)
                    {
                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền điện", txttiendien.Text))
                        {
                            TTTN = TTTN - int.Parse(txttiendien.Text);
                        }
                    }
                    if (txttiennuoc.Text != "" && TTTN - int.Parse(txttiennuoc.Text) >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }
                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền nước", txttiennuoc.Text))
                        {
                            TTTN = TTTN - int.Parse(txttiennuoc.Text);
                        }
                    }
                    if (TTTN - 600000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Ăn uống", "600000"))
                        {
                            TTTN = TTTN - int.Parse("600000");
                        }
                    }
                    if (TTTN - 400000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }
                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền xe", "400000"))
                        {
                            TTTN = TTTN - int.Parse("400000");
                        }
                    }
                    if (TTTN - 1000000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Chi tiêu khác", "1000000"))
                        {
                            TTTN = TTTN - int.Parse("1000000");
                        }
                    }

                    MessageBox.Show("Tạo lịch thành công");
                    string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                    SqlConnection conn = new SqlConnection(strcon);
                    conn.Open();
                    string sql = "select ndlich.TenLich[Tên lịch],ndlich.NgayBD[Ngày bắt đầu],ndlich.NgayKT[Ngày kết thúc],lich.Tenkhoanchi[Nội dung chi],lich.Sotien[Số tiền] from Noidunglich ndlich,Lichchitieu lich,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=lich.MaND and ndlich.MaNDLich='" + MaNDLich + "' and ndlich.MaNDLich=lich.MaNDLich";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvthongtinlich.Visible = true;
                    dgvthongtinlich.DataSource = dt;
                    lbthongbaotien.Visible = true;
                    lbthongbaotien.Text = "Số tiền còn lại là: " + TTTN.ToString();
                    lbnoio.Visible = false;
                    lbngaybd.Visible = false;
                    lbngaykt.Visible = false;
                    lbtien.Visible = false;
                    lbtiennuoc.Visible = false;
                    lbtiendien.Visible = false;
                    cbnoio.Visible = false;
                    txttiennhatro.Visible = false;
                    txttiendien.Visible = false;
                    txttiennuoc.Visible = false;
                    dngaybd.Visible = false;
                    dngaykt.Visible = false;
                    bttaolich.Visible = false;
                    lbtongchi.Visible = true;
                    btluu.Visible = true;
                   
                    btkhongluu.Visible = true;
                    string sql4 = "select sum(lich.Sotien)[TT] from Lichchitieu lich,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=lich.MaND and lich.MaNDLich='" + MaNDLich + "'";
                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
                    DataTable dt4 = new DataTable();
                    adapter4.Fill(dt4);
                    lbtongchi.Text = lbtongchi.Text + dt4.Rows[0]["TT"].ToString();
                }
                else
                {
                    MessageBox.Show("Thu nhập không có! Không thể tạo lịch");
                }
            }
            else
            {
                xuly lich = new xuly();
                MaNDLich = lich.catchuoi(cbnoio.Text);
                Malich = MaNDLich;
                int i = 1;
                while (lich.ktmandlich(MaNDLich))
                {
                    string ma1 = MaNDLich;
                    string tam1 = ma1.Substring(ma1.Length - 1, 1);
                    xuly so = new xuly();
                    if (so.Isint(tam1))
                    {
                        tam1 = MaNDLich.Substring(0, MaNDLich.Length - 1) + (i + (int.Parse(tam1)));
                        MaNDLich = tam1;
                    }
                    MaNDLich = MaNDLich + i;
                }

                lich.themndlichmau(MaNDLich, dngaybd.Text, dngaykt.Text);
                manguoidung = lich.manguoidung(tk);
                if (TTTN > 0)
                {
                    if (txttiendien.Text != "" && (TTTN - int.Parse(txttiendien.Text)) >= 0)
                    {
                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền điện", txttiendien.Text))
                        {
                            TTTN = TTTN - int.Parse(txttiendien.Text);
                        }
                    }
                    if (txttiennuoc.Text != "" && TTTN - int.Parse(txttiennuoc.Text) >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }
                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền nước", txttiennuoc.Text))
                        {
                            TTTN = TTTN - int.Parse(txttiennuoc.Text);
                        }
                    }


                    if (txttiennhatro.Text != "" && TTTN - int.Parse(txttiennhatro.Text) >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }
                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền nhà trọ", txttiennhatro.Text))
                        {
                            TTTN = TTTN - int.Parse(txttiennhatro.Text);
                        }
                    }

                    if (TTTN - 800000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Ăn uống", "800000"))
                        {
                            TTTN = TTTN - int.Parse("800000");
                        }
                    }
                    if (TTTN - 400000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }
                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Tiền xe", "400000"))
                        {
                            TTTN = TTTN - int.Parse("400000");
                        }
                    }
                    if (TTTN - 1000000 >= 0)
                    {

                        int j = 1;

                        while (lich.ktmalichchitieu(Malich))
                        {
                            string ma1 = Malich;
                            if (ma1.Length > 1)
                            {
                                string tam1 = ma1.Substring(ma1.Length - 1, 1);
                                xuly so = new xuly();
                                if (so.Isint(tam1))
                                {
                                    tam1 = Malich.Substring(0, Malich.Length - 1) + (j + (int.Parse(tam1)));
                                    Malich = tam1;
                                }
                                else
                                    Malich = Malich + j;
                            }
                            else
                            {
                                Malich = Malich + j;
                            }
                        }

                        if (lich.themlichmau(Malich, manguoidung, MaNDLich, "Chi tiêu khác", "1000000"))
                        {
                            TTTN = TTTN - int.Parse("1000000");
                        }
                    }

                    MessageBox.Show("Tạo lịch thành công");
                    string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                    SqlConnection conn = new SqlConnection(strcon);
                    conn.Open();
                    string sql = "select ndlich.TenLich[Tên lịch],ndlich.NgayBD[Ngày bắt đầu],ndlich.NgayKT[Ngày kết thúc],lich.Tenkhoanchi[Nội dung chi],lich.Sotien[Số tiền] from Noidunglich ndlich,Lichchitieu lich,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=lich.MaND and ndlich.MaNDLich='" + MaNDLich + "' and ndlich.MaNDLich=lich.MaNDLich";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvthongtinlich.Visible = true;
                    dgvthongtinlich.DataSource = dt;
                    lbthongbaotien.Visible = true;
                    lbthongbaotien.Text = "Số tiền còn lại là: " + TTTN.ToString();
                    lbnoio.Visible = false;
                    lbngaybd.Visible = false;
                    lbngaykt.Visible = false;
                    lbtien.Visible = false;
                    lbtiennuoc.Visible = false;
                    lbtiendien.Visible = false;
                    cbnoio.Visible = false;
                    txttiennhatro.Visible = false;
                    txttiendien.Visible = false;
                    txttiennuoc.Visible = false;
                    dngaybd.Visible = false;
                    dngaykt.Visible = false;
                    bttaolich.Visible = false;
                    lbtongchi.Visible = true;
                    btluu.Visible = true;
                    btkhongluu.Visible = true;

                    string sql4 = "select sum(lich.Sotien)[TT] from Lichchitieu lich,Nguoidung nd where nd.Username='" + tk + "' and nd.MaND=lich.MaND and lich.MaNDLich='" + MaNDLich + "'";
                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
                    DataTable dt4 = new DataTable();
                    adapter4.Fill(dt4);
                    lbtongchi.Text = lbtongchi.Text + dt4.Rows[0]["TT"].ToString();
                }
                else
                {
                    MessageBox.Show("Thu nhập không có! Không thể tạo lịch");
                }
            }
        }

        private void cbnoio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnoio.Text == "Nhà trọ")
            {
                lbtien.Visible = true;
                txttiennhatro.Visible = true;
            }
            else
            {
                lbtien.Visible = false;
                txttiennhatro.Visible = false;
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu lịch chi tiêu");
            luu = 1;
        }

        private void btkhongluu_Click(object sender, EventArgs e)
        {
            luu = 0;
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql1 = "Delete Lichchitieu where MaNDLich='" + MaNDLich + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            int read1 = (int)cmd1.ExecuteNonQuery();

            string sql = "Delete Noidunglich where MaNDLich='" + MaNDLich + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int read = (int)cmd.ExecuteNonQuery();
            MessageBox.Show("Lịch chi tiêu đã được xóa");
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            if (luu == 1)
            {
                Formquanlychitieu ql = new Formquanlychitieu(tk, true);
                this.Hide();
                ql.Show();
            }
            else
            {
                string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string sql1 = "Delete Lichchitieu where MaNDLich='" + MaNDLich + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                int read1 = (int)cmd1.ExecuteNonQuery();

                string sql = "Delete Noidunglich where MaNDLich='" + MaNDLich + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int read = (int)cmd.ExecuteNonQuery();
                Formquanlychitieu ql = new Formquanlychitieu(tk, true);
                this.Hide();
                ql.Show();
            }
        }
    }
}
