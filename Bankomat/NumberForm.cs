using Bankomat.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bankomat
{
    public partial class NumberForm : Form
    {
        private readonly IBankDB db;
        private readonly Action<NumberForm, string> onOkClick;


        public NumberForm(string text, string title,int numCount, bool hideNumbers, Action<NumberForm, string> onOkClick)
        {
            db = new BankDB();
            this.onOkClick = onOkClick;
            InitializeComponent();
            label1.Text = text;
            this.Text = title;
            pin_text.PasswordChar = hideNumbers ? 'X' : char.MinValue;
            pin_text.MaxLength = numCount;
        }

        private void PrintNumber(int number)
        {
            if (pin_text.Text.Length < pin_text.MaxLength)
            {
                pin_text.Text += number;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintNumber(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintNumber(2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintNumber(3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintNumber(4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintNumber(5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintNumber(6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PrintNumber(7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            PrintNumber(8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            PrintNumber(9);

        }

        private void button0_Click(object sender, EventArgs e)
        {
            PrintNumber(0);

        }

        private void clear_Click(object sender, EventArgs e)
        {
            string text = pin_text.Text;
            if (text.Length > 0)
            {         
                text = text.Substring(0, text.Length - 1);
                pin_text.Text = text;
            }
                
        }


        private void ok_Click(object sender, EventArgs e)
        {
            onOkClick(this, pin_text.Text);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
