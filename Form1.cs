using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Casey Fuh-Cham
// 2232479
namespace ProjectCaseyFuhCham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LottoMAX obj = new LottoMAX();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lotto649 obj = new Lotto649();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoneyEx obj = new MoneyEx();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TempApp obj = new TempApp();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calculator obj = new Calculator();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IP4_Validator obj = new IP4_Validator();
            obj.ShowDialog();
        }
    }
}
