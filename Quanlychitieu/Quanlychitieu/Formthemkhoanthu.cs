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
    public partial class Formthemkhoanthu : Form
    {
        string tk, mandtn,matn="";
        public Formthemkhoanthu(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formthemkhoanthu_Load(object sender, EventArgs e)
        {
            cbkhoanthunhap.Text = "";
            txtsotien.Text = "";
            txtghichu.Text = "";
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct MaNDTN,TenNDTN from Noidungthunhap ndtn where ndtn.MaNDTN!=ndtn.TenNDTN";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbkhoanthunhap.DisplayMember = "TenNDTN";
            cbkhoanthunhap.ValueMember = "MaNDTN";
            cbkhoanthunhap.DataSource = dt;
        }

        private void cbkhoanthunhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mandthu = cbkhoanthunhap.SelectedValue.ToString();
            if (cbkhoanthunhap.Text != mandthu)
            {
                xuly cat = new xuly();
                string ma = cat.catchuoi(cbkhoanthunhap.Text);
                xuly ktdl = new xuly();
                int i = 1;
                if (ktdl.ktdlmatn(ma))
                {
                    matn = ma + i;
                    while (ktdl.ktdlmatn(matn))
                    {
                        string ma1 = matn;
                        string tam1 = ma1.Substring(ma1.Length - 1, 1);
                        string tam2 = ma1.Substring(ma1.Length - 2, 1);
                        xuly so = new xuly();
                        if (so.Isint(tam1) && so.Isint(tam2))
                        {
                            string tam3 = ma1.Substring(ma1.Length - 2, 2);
                            tam3 = matn.Substring(0, matn.Length - 2) + (i + (int.Parse(tam3)));
                            matn = tam3;
                        }
                        else
                        {
                            if (so.Isint(tam1))
                            {
                                tam1 = matn.Substring(0, matn.Length - 1) + (i + (int.Parse(tam1)));
                                matn = tam1;
                            }
                        }
                    }
                }
                else
                {
                    matn = ma;
                }
            }
            else
            {
                matn= mandthu;
            }
        }

        private void btthemkhoanthu_Click(object sender, EventArgs e)
        {
            mandtn = cbkhoanthunhap.SelectedValue.ToString();
            xuly mand = new xuly();
            string mand1 = mand.manguoidung(tk);
            xuly themkt = new xuly();
            if (themkt.themkhoanthu(mandtn, matn, mand1, txtsotien.Text, dtpngay.Text, txtghichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                Formthemkhoanthu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            Formthemnoidungthu ndt = new Formthemnoidungthu(tk);
            this.Hide();
            ndt.Show();
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu quanly = new Formquanlychitieu(tk, true);
            this.Hide();
            quanly.Show();
        }
    }
}
