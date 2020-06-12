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
            db = new BankDB(OnError);
        }

        private void OnError(string message)
        {
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            var bank = new Bankomat();
            bank.Show();
            Hide();
        }

        private void change_pin_Click(object sender, EventArgs e)
        {

        }

        private void balance_button_Click(object sender, EventArgs e)
        {

        }

        private void cash_button_Click(object sender, EventArgs e)
        {
           
        }

        private void transfer_button_Click(object sender, EventArgs e)
        {

        }
    }
}
