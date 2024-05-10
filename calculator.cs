using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiayinYanpingA1
{
    public partial class calculator : Form
    {
        private double x;
        private string pendingOperation;
        private bool isNewNumber;

        public calculator()
        {
            InitializeComponent();
        }

        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            if (isNewNumber)
            {
                LabelDisplay.Text = "";
                isNewNumber = false;
                caTextBox.Clear();
            }
            var buttonText = ((Button)sender).Text;
            if (buttonText == "." && caTextBox.Text.Contains("."))
            {
                return;
            }

            caTextBox.Text += buttonText;
            LabelDisplay.Text += buttonText;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            caTextBox.Clear();
            pendingOperation = "";
            x = 0;
            LabelDisplay.Text = "";
            isNewNumber = true;
        }

        private void ButtonOpenration_Click(object sender, EventArgs e)
        {
            x = Double.Parse(caTextBox.Text);
            pendingOperation = ((Button)sender).Text;
            LabelDisplay.Text = x + pendingOperation;
            caTextBox.Clear();

        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            double y = double.Parse(caTextBox.Text);
            double result = 0;
            switch (pendingOperation)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    if (y != 0)
                    {
                        result = x / y;
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
            }
            caTextBox.Text = result.ToString();
            LabelDisplay.Text = x + pendingOperation + y + "=" + result.ToString();
            pendingOperation = "";
            isNewNumber = true;
        }
    }
}
