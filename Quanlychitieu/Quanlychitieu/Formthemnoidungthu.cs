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
    public partial class Formthemnoidungthu : Form
    {
        string tk,manoidung = "";
        public Formthemnoidungthu(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formthemnoidungthu_Load(object sender, EventArgs e)
        {
            txttennoidung.Text = "";
            txttennoidung.Focus();
        }

        private void btthemnoidungthu_Click(object sender, EventArgs e)
        {
            xuly themndt = new xuly();
            manoidung = themndt.catchuoi(txttennoidung.Text);

            if (themndt.themndthu(manoidung.ToUpper(), txttennoidung.Text))
            {
                MessageBox.Show("Thêm thành công!");
                Formthemnoidungthu_Load(sender, e);
            }
            else
                MessageBox.Show("Thêm không thành công!");
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formthemkhoanthu them = new Formthemkhoanthu(tk);
            this.Hide();
            them.Show();
        }
    }
}
