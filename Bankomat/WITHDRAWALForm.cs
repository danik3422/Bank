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
    public partial class WITHDRAWALForm : Form
    {
        private readonly CreditCard card;
        private readonly IBankDB db;

        public WITHDRAWALForm(CreditCard card)
        {
            InitializeComponent();
            this.card = card;
            db = new BankDB();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            NumberForm pinForm = new NumberForm("Enter value", "Enter value", 9, false, (form, value) =>
              {
                  decimal amount = -1;
                  decimal.TryParse(value, out amount);
                  payMoney(amount);
              });
            pinForm.Show();
            Hide();
        }

        private void payMoney(decimal amount)
        {
            if (db.payMoney(card, amount))
            {
                DialogResult iExit;

                iExit = MessageBox.Show("Nie zapomnij odebrać karty!", "ATM System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (iExit == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payMoney(20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            payMoney(50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            payMoney(100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            payMoney(200);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            payMoney(1000);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            var formMenu = new MenuForm(card);
            formMenu.Show();
            Hide();
        }
    }
}

