using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Quanlychitieu
{
    public partial class Formxoalich : Form
    {
        string tk;
        public Formxoalich(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formxoalich_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndl.MaNDLich,ndl.Tenlich from Noidunglich ndl,Lichchitieu lich,Nguoidung nd where ndl.MaNDLich=lich.MaNDLich and nd.Username='" + tk + "' and lich.MaND=nd.MaND";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbtenlich.DisplayMember = "Tenlich";
            cbtenlich.ValueMember = "MaNDLich";
            cbtenlich.DataSource = dt;
        }

        private void cbtenlich_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mandlich = cbtenlich.SelectedValue.ToString();
            string strcon = ConfigurationManager.ConnectionStrings["strcon"].ToString();
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "select Distinct ndl.MaNDLich[Ma] from Noidunglich ndl,Lichchitieu lich,Nguoidung nd where ndl.MaNDLich=lich.MaNDLich and nd.Username='" + tk + "'and ndl.MaNDLich='"+mandlich+"' and lich.MaND=nd.MaND";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbmalich.DisplayMember = "Ma";
            cbmalich.ValueMember = "Ma";
            cbmalich.DataSource = dt;
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu ql = new Formquanlychitieu(tk, true);
            this.Hide();
            ql.Show();
        }

        private void btxoakhoanthu_Click(object sender, EventArgs e)
        {
            xuly xoa = new xuly();
            if (xoa.xoalich(cbmalich.Text))
            {
                MessageBox.Show("Xóa lịch thành công");
                Formxoalich_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa bị lỗi");
            }
        }
    }
}
