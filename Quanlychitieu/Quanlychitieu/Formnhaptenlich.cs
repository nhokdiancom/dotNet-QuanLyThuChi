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
    public partial class Formnhaptenlich : Form
    {
        string tk,mandlich;
        public Formnhaptenlich(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formnhaptenlich_Load(object sender, EventArgs e)
        {
            txttenlich.Text = "";
            txttenlich.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xuly ma = new xuly();
            mandlich = "NDL";
            int i = 1;
            if (ma.ktmandlich(mandlich))
            {
                mandlich = mandlich + i;
                while (ma.ktmandlich(mandlich))
                {
                    string ma1 = mandlich;
                    string tam1 = ma1.Substring(ma1.Length - 1, 1);
                    string tam2 = ma1.Substring(ma1.Length - 2, 1);
                    xuly so = new xuly();
                    if (so.Isint(tam1) && so.Isint(tam2))
                    {
                        string tam3 = ma1.Substring(ma1.Length - 2, 2);
                        mandlich = ma1.Substring(0, ma1.Length - 2) + (i + (int.Parse(tam3)));
                    }
                }
            }
            if (ma.themnoidunglich(mandlich, txttenlich.Text, dtpNgayBD.Text, dtpNgayKT.Text))
            {
                MessageBox.Show("Bạn đã tạo lịch " + txttenlich.Text + " thành công!");
                Formlichchitieu lich = new Formlichchitieu(mandlich, tk);
                this.Hide();
                lich.Show();
            }
            else
            {
                MessageBox.Show("Lỗi không thể tạo");
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
