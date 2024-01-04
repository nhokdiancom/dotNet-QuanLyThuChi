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
    public partial class Formxoathunhap : Form
    {
        string tk, mand1,mandtn = "";
        public Formxoathunhap(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formxoathunhap_Load(object sender, EventArgs e)
        {
            xuly mand = new xuly();
            mand1 = mand.manguoidung(tk);
            string sql = "select Distinct ndtn.MaNDTN,ndtn.TenNDTN from Noidungthunhap ndtn,Thunhap tn where MaND='" + mand1 + "' and tn.MaND!=ndtn.MaNDTN and ndtn.MaNDTN=tn.MaNDTN";
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbkhoanthunhap.DisplayMember = "TenNDTN";
            cbkhoanthunhap.ValueMember = "MaNDTN";
            cbkhoanthunhap.DataSource = dt;
        }

        private void btxoakhoanthu_Click(object sender, EventArgs e)
        {
            xuly xoa = new xuly();
            if (xoa.xoakhoanthu(mand1, cbmatn.Text, mandtn))
            {
                MessageBox.Show("Xóa thành công");
                Formxoathunhap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thành công");
            }
        }

        private void cbkhoanthunhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            mandtn = cbkhoanthunhap.SelectedValue.ToString();
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql1 = "select Distinct tn.MaTN from Thunhap tn where tn.MaND='" + mand1 + "' and tn.MaNDTN='" + mandtn + "'order by tn.MaTN ASC";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbmatn.DisplayMember = "MaTN";
            cbmatn.ValueMember = "MaTN";
            cbmatn.DataSource = dt1;
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu quanly = new Formquanlychitieu(tk, true);
            this.Hide();
            quanly.Show();
        }
    }
}
