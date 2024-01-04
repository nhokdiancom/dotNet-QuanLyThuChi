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
    public partial class Formthemkhoanchi : Form
    {
        string tk,mandchi,mact= "";
        public Formthemkhoanchi(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formthemkhoanchi_Load(object sender, EventArgs e)
        {
            txtsotien.Text = "";
            txtghichu.Text = "";
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndct.MaNDCT,ndct.TenNDCT from Noidungchitieu ndct where ndct.MaNDCT!=ndct.TenNDCT";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbkhoanchi.DisplayMember = "TenNDCT";
            cbkhoanchi.ValueMember = "MaNDCT";
            cbkhoanchi.DataSource = dt;
        }

        private void btthemchitieu_Click(object sender, EventArgs e)
        {
            mandchi = cbkhoanchi.SelectedValue.ToString();
            xuly mand = new xuly();
            string mand1 = mand.manguoidung(tk);
            xuly themkchi = new xuly();
            if (themkchi.themkchitieu(mandchi, mact, mand1, txtsotien.Text, dtpngay.Text, txtghichu.Text))
            {
                MessageBox.Show("Thêm thành công");
                Formthemkhoanchi_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void cbnoidungchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbkhoanchi.Text != mandchi)
            {
                xuly cat = new xuly();
                string ma = cat.catchuoi(cbkhoanchi.Text);
                xuly ktdl = new xuly();
                int i = 1;
                if (ktdl.ktdlmachitieu(ma))
                {
                    mact = ma + i;
                    while (ktdl.ktdlmachitieu(mact))
                    {
                        string ma1 = mact;
                        string tam1 = ma1.Substring(ma1.Length - 1, 1);
                        xuly so = new xuly();
                        if (so.Isint(tam1))
                        {
                            tam1 = mact.Substring(0, mact.Length - 1) + (i + (int.Parse(tam1)));
                            mact = tam1;
                        }
                    }
                }
                else
                {
                    mact = ma;
                }
            }
            else
            {
                mact = mandchi;
            }
        }


        private void btthemkhoanchi_Click(object sender, EventArgs e)
        {
            Formthemnoidungchi them = new Formthemnoidungchi(tk);
            this.Hide();
            them.Show();
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu them = new Formquanlychitieu(tk, true);
            this.Hide();
            them.Show();
        }
    }
}
