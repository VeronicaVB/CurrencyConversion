using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyConversion;

namespace Currency
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertCur currency = new ConvertCur();
                string result = currency.convert(txtCurrencyCode.Text, txtAmount.Text);
                lblConvertedAmount.Text = "In Australian Dollars: " + result;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            catch (ArithmeticException ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }
    }
}
