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
using System.Xml.Linq;

namespace ProjectCaseyFuhCham
{
    public partial class TempApp : Form
    {
        public TempApp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtfile = @"TempConv.txt";
            double tempC = 0;
            double tempF = 0;
            string message = "";
            string name = "";
            string name2 = "";
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd  h:mm:ss tt");

            if (radioButton1.Checked == true)
            {
                label2.Text = "C";
                label3.Text = "F";
                name = "C";
                name2 = "F";
                tempC = Convert.ToDouble(textBox1.Text);
                tempF = (tempC * 9 / 5) + 32;
                textBox2.Text = tempF.ToString();
            }

            else
            {
                name = "F";
                name2 = "C";
                label2.Text = "F";
                label3.Text = "C";
                tempF = Convert.ToDouble(textBox1.Text);
                tempC = (tempF - 32) * 5 / 9;
                textBox2.Text = tempC.ToString();
            }

            if (tempC >= 100)
            {
                message = "Water boils";
            }
            else if (tempC >= 40 && tempC < 100)
            {
                message = "Hot Bath";
            }
            else if (tempC >= 37 && tempC < 40)
            {
                message = "Body temperature";
            }

            else if (tempC >= 30 && tempC < 37)
            {
                message = "Beach weather";
            }

            else if (tempC >= 21 && tempC < 30)
            {
                message = "Room temperature";
            }

            else if (tempC >= 10 && tempC < 21)
            {
                message = "Cool day";
            }

            else if (tempC >= 0 && tempC < 10)
            {
                message = "Freezing point of water";
            }

            else if (tempC >= -18 && tempC < 0)
            {
                message = "Very Cold Day";
            }

            else
            {
                message = "Extremely Cold Day";
            }

            textBox3.Text = message;

            FileStream fileStream = null;

            try
            {
                using (fileStream = new FileStream(txtfile, FileMode.Append, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine($"{textBox1.Text + " " + name} = {textBox2.Text + " " + name2}, {dateTime + " " + message} ");
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show(" Error \n" + ex.Message);
            }
            finally { if (fileStream != null) fileStream.Close(); }
        }

        private void TempApp_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textToPrint = "";
            FileStream stream = null;
            byte counter = 0;
            try
            {
                using (stream = new FileStream(@"TempConv.txt", FileMode.OpenOrCreate, FileAccess.Read))
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quit the application\nTemperature Conversions?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
