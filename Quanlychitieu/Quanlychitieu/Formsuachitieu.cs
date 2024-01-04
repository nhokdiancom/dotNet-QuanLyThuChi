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
    public partial class Formsuachitieu : Form
    {
        string tk,mand1,mandct = "";
        public Formsuachitieu(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formsuachitieu_Load(object sender, EventArgs e)
        {
            txtsotien.Text = "";
            txtghichu.Text = "";
            xuly mand = new xuly();
            mand1 = mand.manguoidung(tk);
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndct.TenNDCT,ndct.MaNDCT from Noidungchitieu ndct,Thongtinchitieu ttct where ttct.MaND='" + mand1 + "' and ttct.MaND!=ndct.MaNDCT and ndct.MaNDCT=ttct.MaNDCT order by ndct.TenNDCT ASC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbnoidungchi.DisplayMember = "TenNDCT";
            cbnoidungchi.ValueMember = "MaNDCT";
            cbnoidungchi.DataSource = dt;
        }

        private void btsuachitieu_Click(object sender, EventArgs e)
        {
            xuly sua = new xuly();
            if (sua.suakhoanchi(mand1, cbmact.Text, mandct, txtsotien.Text, dtpngay.Text, txtghichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                Formsuachitieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void cbnoidungchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            mandct = cbnoidungchi.SelectedValue.ToString();
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql1 = "select Distinct MaTTCT from Thongtinchitieu where MaND='" + mand1 + "'and MaNDCT='" + mandct + "'  order by MaTTCT ASC";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbmact.DisplayMember = "MaTTCT";
            cbmact.ValueMember = "MaTTCT";
            cbmact.DataSource = dt1;
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu quanly = new Formquanlychitieu(tk, true);
            this.Hide();
            quanly.Show();
        }
    }
}
