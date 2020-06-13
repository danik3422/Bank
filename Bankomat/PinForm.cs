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
    public partial class PinForm : Form
    {
        private readonly string CardNo;
        private readonly IBankDB db;

        public PinForm(string cardNo)
        {
            this.CardNo = cardNo;
            db = new BankDB(OnError);
            InitializeComponent();
        }


        private void OnError(string message)
        {
        }


        private void pin_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
               pin_text.Text = pin_text.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            pin_text.Text = pin_text.Text + "0";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            pin_text.Text = "";
        }


        private void ok_Click(object sender, EventArgs e)
        {
            string pin = pin_text.Text;
            CreditCard card = db.getCreditCard(CardNo, pin);
            if (card != null)
            {
                MenuForm fr3 = new MenuForm(card);
                fr3.Show();
                Hide();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            iExit = MessageBox.Show("Nie zapomnij odebrać karty!", "ATM System" ,  MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(iExit == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
