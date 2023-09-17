using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

// Casey Fuh-Cham
// 2232479
namespace ProjectCaseyFuhCham
{
    public partial class Calculator : Form
    {
        double firstNumber;
        string operation;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(textBox1.Text);
            operation = "+";
            textBox1.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(textBox1.Text);
            operation = "-";
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(textBox1.Text);
            operation = "*";
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(textBox1.Text);
            operation = "/";
            textBox1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string txtfile = @"Calculator.txt";
            double secondNumber;
            double result;

            secondNumber = Convert.ToDouble(textBox1.Text);

            if (operation == "+")
            {
                result = (firstNumber + secondNumber);
                textBox1.Text = Convert.ToString(result);
            }
            if (operation == "-")
            {
                result = (firstNumber - secondNumber);
                textBox1.Text = Convert.ToString(result);
            }
            if (operation == "*")
            {
                result = (firstNumber * secondNumber);
                textBox1.Text = Convert.ToString(result);
            }
            if (operation == "/")
            {
                if (secondNumber == 0)
                {
                    textBox1.Text = "Cannot divide by zero";

                }
                else
                {
                    result = (firstNumber / secondNumber);
                    textBox1.Text = Convert.ToString(result);
                }
            }

            FileStream fileStream = null;

            try
            {
                using (fileStream = new FileStream(txtfile, FileMode.Append, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine($"{firstNumber}  {operation}  {secondNumber} = {textBox1.Text}");
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show(" Error \n" + ex.Message);
            }
            finally { if (fileStream != null) fileStream.Close(); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quit the calculator?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
