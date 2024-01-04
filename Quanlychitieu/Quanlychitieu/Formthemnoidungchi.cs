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
    public partial class Formthemnoidungchi : Form
    {
        string tk ,manoidungchi= "";
        public Formthemnoidungchi(string tk)
        {
            this.tk = tk;
            InitializeComponent();
        }

        private void Formthemnoidungchi_Load(object sender, EventArgs e)
        {
            txttennoidungchitieu.Text= "";
            txttennoidungchitieu.Focus();
        }

        private void btthemnoidungct_Click(object sender, EventArgs e)
        {
            xuly themndc = new xuly();
            manoidungchi = themndc.catchuoi(txttennoidungchitieu.Text);
            if (themndc.themndchi(manoidungchi.ToUpper(), txttennoidungchitieu.Text))
            {
                MessageBox.Show("Thêm thành công");
                Formthemnoidungchi_Load(sender, e);
            }
            else
                MessageBox.Show("Thêm không thành công");
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formthemkhoanchi them = new Formthemkhoanchi(tk);
            this.Hide();
            them.Show();
        }
    }
}
