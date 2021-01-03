using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1660454_1660553_QuanLyNhaSach
{
    public partial class fDiscount : Form
    {
        public fDiscount()
        {
            InitializeComponent();
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            int number;
            if (int.TryParse(txtdiscount.Text, out number))
            {
                if (number <= 10)
                {
                    //in range
                }
                else
                {
                    txtdiscount.Text = "";
                }
            }
        }

        private void fDiscount_Load(object sender, EventArgs e)
        {
            txtdiscount.Text = Session.discount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.discount = Int32.Parse(txtdiscount.Text);
            this.Close();
        }
    }
}
