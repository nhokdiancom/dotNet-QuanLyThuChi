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
    public partial class Formxoachitieu : Form
    {
        string tk,mand1,mandchi = "";
        public Formxoachitieu(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formxoachitieu_Load(object sender, EventArgs e)
        {
            xuly mand = new xuly();
            mand1 = mand.manguoidung(tk);
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndct.TenNDCT,ndct.MaNDCT from Noidungchitieu ndct,Thongtinchitieu ttct where ttct.MaND='" + mand1 + "' and ttct.MaND!=ndct.MaNDCT and  ndct.MaNDCT=ttct.MaNDCT order by ndct.TenNDCT ASC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbkhoanchi.DisplayMember = "TenNDCT";
            cbkhoanchi.ValueMember = "MaNDCT";
            cbkhoanchi.DataSource = dt;
        }

        private void cbkhoanchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            mandchi = cbkhoanchi.SelectedValue.ToString();
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql1 = "select Distinct MaTTCT from Thongtinchitieu where MaND='" + mand1 + "'and MaNDCT='" + mandchi + "'  order by MaTTCT ASC";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbmachi.DisplayMember = "MaTTCT";
            cbmachi.ValueMember = "MaTTCT";
            cbmachi.DataSource = dt1;
        }

        private void btxoakhoanthu_Click(object sender, EventArgs e)
        {
            xuly xoa = new xuly();
            if (xoa.xoakhoanchi(mand1, cbmachi.Text, mandchi))
            {
                MessageBox.Show("Xóa thành công");
                Formxoachitieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu quanly = new Formquanlychitieu(tk, true);
            this.Hide();
            quanly.Show();
        }
    }
}
