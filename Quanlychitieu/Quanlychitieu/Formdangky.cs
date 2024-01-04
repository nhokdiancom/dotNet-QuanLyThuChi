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
    public partial class Formdangky : Form
    {
        public Formdangky()
        {
            InitializeComponent();
        }

        private void Formdangky_Load(object sender, EventArgs e)
        {
            txthoten.Text = "";
            txtgioitinh.Text = "";
            txttaikhoan.Text = "";
            txtmatkhau.Text = "";
            txtnhaplaimatkhau.Text = "";
            txthoten.Focus();
        }

        private void btdk_Click(object sender, EventArgs e)
        {
            xuly themtk = new xuly();
            xuly ktdl = new xuly();
            xuly cat = new xuly();
            string mand = "";
            int i=1;
            mand = cat.catchuoi(txthoten.Text);

            if (ktdl.ktdl(mand))
            {
                mand = mand + i;
                while(ktdl.ktdl(mand))
                {
                    string ma1 = mand;
                    string tam1 = ma1.Substring(ma1.Length - 1, 1);
                    string tam2 = ma1.Substring(ma1.Length - 2, 1);
                    xuly so = new xuly();
                    if (so.Isint(tam1) && so.Isint(tam2))
                    {
                        string tam3 = ma1.Substring(ma1.Length - 2, 2);
                        tam3 = mand.Substring(0, mand.Length - 2) + (i + (int.Parse(tam3)));
                        mand = tam3;
                    }
                    else
                    {
                        if (so.Isint(tam1))
                        {
                            tam1 = mand.Substring(0, mand.Length - 1) + (i + (int.Parse(tam1)));
                            mand = tam1;
                        }
                    }
                }
              }

            if (themtk.themtk(txttaikhoan.Text, txtmatkhau.Text, txtnhaplaimatkhau.Text))
            {
                if (themtk.themnguoidung(mand, txttaikhoan.Text, txthoten.Text, dtpnamsinh.Text, txtgioitinh.Text))
                {
                    if (themtk.themndthu(mand, mand))
                    {
                        if (themtk.themkhoanthu(mand, mand, mand, "0", DateTime.Today.ToString(), ""))
                        {
                            if (themtk.themndchi(mand,mand))
                            {
                                if (themtk.themkchitieu(mand, mand, mand, "0", DateTime.Today.ToString(), ""))
                                {
                                    MessageBox.Show("Đăng ký thành công!");
                                    Formdangnhap ql = new Formdangnhap();
                                    this.Hide();
                                    ql.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Đăng ký không thành công!");
                                    themtk.xoakhoanchi(mand, mand, mand);
                                    themtk.xoandchi(mand);
                                    themtk.xoakhoanthu(mand, mand, mand);
                                    themtk.xoandthu(mand);
                                    themtk.xoand(mand);
                                    themtk.xoatk(txttaikhoan.Text);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Đăng ký không thành công!");
                                themtk.xoandchi(mand);
                                themtk.xoakhoanthu(mand, mand, mand);
                                themtk.xoandthu(mand);
                                themtk.xoand(mand);
                                themtk.xoatk(txttaikhoan.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký không thành công!");
                            themtk.xoakhoanthu(mand, mand, mand);
                            themtk.xoandthu(mand);
                            themtk.xoand(mand);
                            themtk.xoatk(txttaikhoan.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký không thành công!");
                        themtk.xoandthu(mand);
                        themtk.xoand(mand);
                        themtk.xoatk(txttaikhoan.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công!");
                    themtk.xoand(mand);
                    themtk.xoatk(txttaikhoan.Text);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại hoặc mật khẩu nhập lại không đúng!");
            }
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            Formdangnhap dn = new Formdangnhap();
            this.Hide();
            dn.Show();
        }
    }
}
