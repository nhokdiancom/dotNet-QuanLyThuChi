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
    public partial class Formthaydoimatkhau : Form
    {
        string tk="";
        public Formthaydoimatkhau(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formthaydoimatkhau_Load(object sender, EventArgs e)
        {
            txtmatkhaumoi.Text = "";
            txtnhaplaimk.Text = "";
            txtmatkhaumoi.Focus();
        }

        private void btthaydoimk_Click(object sender, EventArgs e)
        {
            if (txtmatkhaumoi.Text == "")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống");
                txtmatkhaumoi.Focus();
            }
            else
            {
                if (txtmatkhaumoi.Text != txtnhaplaimk.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng");
                    txtnhaplaimk.Focus();
                }
                else
                {
                    xuly thaydoimk = new xuly();
                    if (thaydoimk.thaydoimk(tk, txtmatkhaumoi.Text, txtnhaplaimk.Text))
                    {
                        MessageBox.Show("Thay đổi thành công!");
                        Formquanlychitieu ql = new Formquanlychitieu(tk, true);
                        this.Close();
                        ql.Show();
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi không thành công!");
                    }
                }
            }
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formquanlychitieu ql = new Formquanlychitieu(tk, true);
            this.Hide();
            ql.Show();
        }
    }
}
