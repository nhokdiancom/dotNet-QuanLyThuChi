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
    public partial class Formsuathunhap : Form
    {
        string tk,mand1,mandtn = "";
        public Formsuathunhap(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formsuathunhap_Load(object sender, EventArgs e)
        {
            txtsotien.Text = "";
            txtghichu.Text = "";
            xuly mand = new xuly();
            mand1= mand.manguoidung(tk);
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndtn.TenNDTN,ndtn.MaNDTN from Noidungthunhap ndtn,Thunhap tn where tn.MaND='" + mand1 + "' and  tn.MaND!=ndtn.MaNDTN and tn.MaNDTN =ndtn.MaNDTN order by ndtn.TenNDTN ASC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbkhoanthunhap.DisplayMember = "TenNDTN";
            cbkhoanthunhap.ValueMember = "MaNDTN";
            cbkhoanthunhap.DataSource = dt;
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

        private void btsuakhoanthu_Click(object sender, EventArgs e)
        {
            xuly sua = new xuly();
            if (sua.suakhoanthu(mand1, cbmatn.Text, mandtn, txtsotien.Text, dtpngay.Text, txtghichu.Text))
            {
                MessageBox.Show("Sửa thành công");
                Formsuathunhap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
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
