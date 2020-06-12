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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {

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
            Application.Exit();
        }
    }
}
