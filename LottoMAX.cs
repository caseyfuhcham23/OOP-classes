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
using System.IO.Pipes;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;

// Casey Fuh-Cham
// 2232479
namespace ProjectCaseyFuhCham
{
    public partial class LottoMAX : Form
    {
        public LottoMAX()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtfile = @"LottoNbrs.txt";
            Random random = new Random();
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd  h:mm:ss tt");
            string name = "Max";
            string tempString = "";
            int randomNumber = 0;
            int bonusNumber = 0;

            for (int i = 0; i < 7; i++)
            {
                randomNumber = random.Next(0, 9);
                tempString += randomNumber.ToString();
            }
            label2.Text = tempString;
            tempString = "";

            for (int i = 0; i < 8; i++)
            {
                randomNumber = random.Next(1, 50);
                bonusNumber = random.Next(1, 50);
                tempString += randomNumber.ToString() + "\t";
            }
            textBox1.Text = tempString;

            FileStream fileStream = null;

            try { 
            using (fileStream = new FileStream(txtfile, FileMode.Append, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"{name}, {dateTime}, {tempString.Replace("\t", ",")} Bonus: {bonusNumber}");
            }
            tempString = "";

            }
            catch (IOException ex)
            {
                MessageBox.Show(" Error \n" + ex.Message);
            }
            finally { if (fileStream != null) fileStream.Close(); }
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application?", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes")
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
                    using (stream = new FileStream(@"LottoNbrs.txt", FileMode.OpenOrCreate, FileAccess.Read))
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LottoMAX_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@".\Files\"))
            {
                Directory.CreateDirectory(@".\Files.\");
            }

        }
    }
}
