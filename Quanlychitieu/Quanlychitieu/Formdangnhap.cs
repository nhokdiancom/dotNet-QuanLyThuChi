using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlychitieu
{
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }

        private void Formdangnhap_Load(object sender, EventArgs e)
        {
            txttaikhoan.Text = "";
            txtmatkhau.Text = "";
            txttaikhoan.Focus();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Formquanlychitieu ql = new Formquanlychitieu("",false);
            ql.Show();
            this.Close();
        }

        private void btdk_Click(object sender, EventArgs e)
        {
            Formdangky dk = new Formdangky();
            this.Hide();
            dk.Show();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            bool dn = false;
            string tk = "";
            xuly kn = new xuly();
            bool ktkn = kn.ketnoi();
            xuly ktdn = new xuly();
            bool ktdangnhap = kn.ktdangnhap(txttaikhoan.Text, txtmatkhau.Text);
            if (ktkn)
            {
                if (ktdangnhap)
                {
                    tk = txttaikhoan.Text;
                    dn = true;
                    MessageBox.Show("Đăng nhập thành công");
                    Formquanlychitieu TTCT = new Formquanlychitieu(tk,dn);
                    TTCT.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Đăng nhập không thành công");
            }
            else
                MessageBox.Show("Kết nối bị lỗi");
        }
    }
}
