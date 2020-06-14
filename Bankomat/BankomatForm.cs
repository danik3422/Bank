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
    public partial class Bankomat : Form
    {
        private readonly IBankDB db;

        public Bankomat()
        {
            db = new BankDB();
            CenterToScreen();
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            string cardNo = numberOfCard.Text;
            if (db.verifyCardNumber(cardNo))
            {
                NumberForm pinForm = new NumberForm("Enter PIN", "Enter PIN", DBUtils.PIN_LENGTH, true, (form, pin) =>
                   {
                       CreditCard card = db.getCreditCard(cardNo, pin);
                       if (card != null)
                       {
                           MenuForm fr3 = new MenuForm(card);
                           fr3.Show();
                           form.Hide();
                       }
                   });
                pinForm.Show();
                Hide();
            }
        }

        private void Bankomat_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numberOfCard_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
