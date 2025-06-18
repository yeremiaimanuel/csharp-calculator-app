using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal num1;
        decimal num2;
        int operation;
        bool opr_done;

        private void AddDigit(string digit)
        {
            if (txtDisplay.Text == "0" || opr_done)
            {
                txtDisplay.Text = digit;
                opr_done = false;
            }
            else
            {
                txtDisplay.Text += digit;
            }
        }

        private void btn1_Click(object sender, EventArgs e) => AddDigit("1");
        private void btn2_Click(object sender, EventArgs e) => AddDigit("2");
        private void btn3_Click(object sender, EventArgs e) => AddDigit("3");
        private void btn4_Click(object sender, EventArgs e) => AddDigit("4");
        private void btn5_Click(object sender, EventArgs e) => AddDigit("5");
        private void btn6_Click(object sender, EventArgs e) => AddDigit("6");
        private void btn7_Click(object sender, EventArgs e) => AddDigit("7");
        private void btn8_Click(object sender, EventArgs e) => AddDigit("8");
        private void btn9_Click(object sender, EventArgs e) => AddDigit("9");
        private void btn0_Click(object sender, EventArgs e) => AddDigit("0");

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtDisplay2.Text = ""; 
            num1 = num2 = 0;
            operation = 0;
            opr_done = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDecimal(txtDisplay.Text);
            operation = 4;
            txtDisplay2.Text = $"{num1} +";
            opr_done = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDecimal(txtDisplay.Text);
            operation = 3;
            txtDisplay2.Text = $"{num1} -";
            opr_done = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDecimal(txtDisplay.Text);
            operation = 1;
            txtDisplay2.Text = $"{num1} ×";
            opr_done = true;
        }

        private void btnDivided_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDecimal(txtDisplay.Text);
            operation = 2;
            txtDisplay2.Text = $"{num1} ÷";
            opr_done = true;
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            try
            {
                num2 = Convert.ToDecimal(txtDisplay.Text);
                decimal result = 0;
                string opSymbol = "";

                switch (operation)
                {
                    case 1:
                        result = num1 * num2;
                        opSymbol = "×";
                        break;
                    case 2:
                        if (num2 == 0)
                        {
                            MessageBox.Show("Tidak dapat membagi dengan nol.");
                            return;
                        }
                        result = num1 / num2;
                        opSymbol = "÷";
                        break;
                    case 3:
                        result = num1 - num2;
                        opSymbol = "-";
                        break;
                    case 4:
                        result = num1 + num2;
                        opSymbol = "+";
                        break;
                }

                txtDisplay2.Text = $"{num1} {opSymbol} {num2}";
                txtDisplay.Text = result.ToString();
                opr_done = false;
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan input.");
            }
        }

        private void btnPositiveorNegative_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDisplay.Text, out decimal val))
            {
                txtDisplay.Text = (-val).ToString();
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDisplay.Text, out decimal val))
            {
                txtDisplay.Text = (val / 100).ToString();
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }
    }
}
