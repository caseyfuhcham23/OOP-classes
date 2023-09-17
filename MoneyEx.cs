using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

// Casey Fuh-Cham
// 2232479
namespace ProjectCaseyFuhCham
{
    public partial class MoneyEx : Form
    {
        public MoneyEx()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quit the application\nMoney Exchange?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textToPrint = "";
            FileStream stream = null;
            byte counter = 0;
            try
            {
                using (stream = new FileStream(@"MoneyConv.txt", FileMode.OpenOrCreate, FileAccess.Read))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        textToPrint += line + "\n";
                        counter++;
                        if (counter == 0)
                        {
                            MessageBox.Show(textToPrint);
                            textToPrint = "";
                        }
                    }
                    if (counter > 0) { MessageBox.Show(textToPrint); }
                    reader.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while reading the file: {ex.Message}");
            }
            finally { if (stream != null) stream.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value = 0;
            double result = 0;
            value = Convert.ToDouble(textBox1.Text);
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd  h:mm:ss tt");
            string textfile = @"MoneyConv.txt";
            string name = "";
            string name2 = "";

            if (radioButton1.Checked == true)
            {
                name = "CAD";
                if (radioButton7.Checked == true) // CAD to USD
                {
                    name2 = "USD";
                    result = value * 0.74; // 1 CAD = 0.74 USD
                    textBox2.Text = result.ToString();
                }

                else if (radioButton8.Checked == true) // CAD tu EUR
                {
                    name2 = "EUR";
                    result = value * 0.68; // 1 CAD = 0.68 USD
                    textBox2.Text = result.ToString();
                }

                else if (radioButton9.Checked == true) // CAD to GBP
                {
                    name2 = "GBP";
                    result = value * 0.59; // 1 CAD = 0.59 GBP
                    textBox2.Text = result.ToString();
                }

                else if (radioButton6.Checked == true) // CAD TO XAF
                {
                    name2 = "XAF";
                    result = value * 439.91; // 1 CAD = 439.91 XAF
                    textBox2.Text = result.ToString();
                }

                else
                {
                    name2 = name;
                    textBox2.Text = textBox1.Text;
                }
            }

            if (radioButton2.Checked == true)
            {

                name = "USD";
                if (radioButton10.Checked == true) // USD to CAD
                {
                    name2 = "CAD";
                    result = value * 1.36;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton8.Checked == true) // USD tu EUR
                {
                    name2 = "EUR";
                    result = value * 0.91;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton9.Checked == true) // USD to GBP
                {
                    name2 = "GBP";
                    result = value * 0.81;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton6.Checked == true) // USD TO XAF
                {
                    name2 = "XAF";
                    result = value * 596.50;
                    textBox2.Text = result.ToString();
                }

                else
                {
                    name2 = name;
                    textBox2.Text = textBox1.Text;
                }
            }

            if (radioButton3.Checked == true)
            {
                name = "EUR";
                if (radioButton10.Checked == true) // EUR to CAD
                {
                    name2 = "CAD";
                    result = value * 1.47;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton7.Checked == true) // EUR to USD
                {
                    name2 = "USD";
                    result = value * 1.10;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton9.Checked == true) // EUR to GBP
                {
                    name2 = "GBP";
                    result = value * 0.89;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton6.Checked == true) // EUR TO XAF
                {
                    name2 = "XAF";
                    result = value * 655.82;
                    textBox2.Text = result.ToString();
                }

                else
                {
                    name2 = name;
                    textBox2.Text = textBox1.Text;
                }
            }

            if (radioButton4.Checked == true)
            {
                name = "GBP";
                if (radioButton10.Checked == true) // GBP to CAD
                {
                    name2 = "CAD";
                    result = value * 1.68;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton7.Checked == true) // GBP to USD
                {
                    name2 = "USD";
                    result = value * 1.24;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton8.Checked == true) // GBP to EUR
                {
                    name2 = "EUR";
                    result = value * 1.13;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton6.Checked == true) // GBP TO XAF
                {
                    name2 = "XAF";
                    result = value * 740.91;
                    textBox2.Text = result.ToString();
                }

                else
                {
                    name2 = name;
                    textBox2.Text = textBox1.Text;
                }
            }

            if (radioButton5.Checked == true)
            {
                name = "XAF";
                if (radioButton10.Checked == true) // XAF to CAD
                {
                    name2 = "CAD";
                    result = value * 0.0023;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton7.Checked == true) // XAF to USD
                {
                    name2 = "USD";
                    result = value * 0.0017;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton8.Checked == true) // XAF to EUR
                {
                    name2 = "EUR";
                    result = value * 0.0015;
                    textBox2.Text = result.ToString();
                }

                else if (radioButton9.Checked == true) // XAF TO GBP
                {
                    name2 = "GBP";
                    result = value * 0.0013;
                    textBox2.Text = result.ToString();
                }

                else
                {
                    name2 = name;
                    textBox2.Text = textBox1.Text;
                }
            }

            FileStream fileStream = null;
            try
            {
            using (fileStream = new FileStream(textfile, FileMode.Append, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"{value + " " + name} = {result + " " + name2}, {dateTime}");
            }
            }
            catch (IOException ex)
            {
                MessageBox.Show(" Error \n" + ex.Message);
            }
            finally { if (fileStream != null) fileStream.Close(); }

        }

        private void MoneyEx_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@".\Files\"))
            {
                Directory.CreateDirectory(@".\Files.\");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
