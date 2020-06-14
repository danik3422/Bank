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
    public partial class MenuForm : Form
    {
        private readonly CreditCard card;
        private readonly IBankDB db;

        public MenuForm(CreditCard card)
        {
            InitializeComponent();
            this.card = card;
            db = new BankDB();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            
            DialogResult iExit;

            iExit = MessageBox.Show("Nie zapomnij odebrać karty!", "ATM System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (iExit == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void change_pin_Click(object sender, EventArgs e)
        {
            NumberForm pinForm = new NumberForm("Enter current PIN", "Enter current PIN", DBUtils.PIN_LENGTH, true, (form, currentPin) =>
             {
                 if (db.IsCorrectPin(card.CardNo, currentPin))
                 {
                     NumberForm newPinForm = new NumberForm("Enter new PIN", "Enter new PIN", DBUtils.PIN_LENGTH, true, (newForm, newPin) =>
                     {
                         if (db.changePin(card, currentPin, newPin))
                         {
                             var menuForm = new MenuForm(card);
                             menuForm.Show();
                             newForm.Hide();
                         }
                     });
                     newPinForm.Show();
                     form.Hide();
                 }

             });
            pinForm.Show();
            Hide();
        }

        private void balance_button_Click(object sender, EventArgs e)
        {

            BalanceForm blf = new BalanceForm(card);
            blf.Show();
            Hide();
            
        }

        private void cash_button_Click(object sender, EventArgs e)
        {
            var form = new WITHDRAWALForm(card);
            form.Show();
            Hide();
        }

        private void transfer_button_Click(object sender, EventArgs e)
        {
            NumberForm form = new NumberForm("Enter konto", "Enter konto", DBUtils.CARD_NUMER_LENGTH, false, (kontoForm, konto) =>
            {
                if (DBUtils.IsCardNumberValid(konto))
                {
                    NumberForm form2 = new NumberForm("Enter amount", "Enter amount",9, false, (amountForm, amount) =>
                     {
                         decimal decimalAmount = -1;
                         decimal.TryParse(amount, out decimalAmount);
                         if (db.payMoney(card, decimalAmount))
                         {
                             DialogResult iExit;

                             iExit = MessageBox.Show("Na konto: " + konto + "\nSuma: " + amount, "ATM System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                             if (iExit == DialogResult.OK)
                             {
                                 Application.Exit();
                             }
                         }
                     });
                    form2.Show();
                    kontoForm.Hide();
                }
                else
                {
                    MessageBox.Show("Nie poprawny!", "ATM System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            form.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
