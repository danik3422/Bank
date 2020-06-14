using Bankomat.Database1DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bankomat.DB;
namespace Bankomat
{
    public partial class BalanceForm : Form
    {

        private readonly IBankDB db;
        private readonly CreditCard card;
        

        public BalanceForm(CreditCard card)
        {
            InitializeComponent();
            this.card = card;
            db = new BankDB();
        }

        

        private void BalanceForm_Load(object sender, EventArgs e)
        {
            label2.Text = db.getBalance(card).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formMenu = new MenuForm(card);
            formMenu.Show();
            Hide();
        }
    }
}
