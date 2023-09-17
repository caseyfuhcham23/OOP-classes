using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// Casey Fuh-Cham
// 2232479
namespace ProjectCaseyFuhCham
{
    public partial class IP4_Validator : Form
    {
        DateTime startTime;
        public IP4_Validator()
        {
            InitializeComponent();
            startTime = DateTime.Now;
            label2.Text = "Today: " + startTime.ToString("dd,MM,yy");
        }

        private void IP4_Validator_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipAddress = textBox1.Text.Trim();

            // validate the IP address using regular expressions
            if (!Regex.IsMatch(ipAddress, @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                MessageBox.Show(ipAddress + "\nThe IP must have 4 bytes \ninteger number between 0 to 255 \nseperated by a dot (255.255.255.255)", "Error");
                return;
            }

            // write the IP address and current date/time to a binary file
            try
            {
                using (FileStream fs = new FileStream("IPAddresses.bin", FileMode.Append))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(ipAddress);
                        writer.Write(DateTime.Now.ToString());
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message);
            }

            MessageBox.Show(ipAddress + "\nThe IP is correct.", "Valid IP");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void IP4_Validator_FormClosing(object sender, FormClosingEventArgs e)
        {

            TimeSpan totalTime = DateTime.Now - startTime; // calculate the time difference
            MessageBox.Show($"You used this form for {totalTime.TotalSeconds} seconds ({totalTime.TotalMinutes} minutes).");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quit the application\nIP validator?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
