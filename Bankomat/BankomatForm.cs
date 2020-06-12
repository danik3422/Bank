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

        private void OnError(string message)
        {
        }

        public Bankomat()
        {
            db = new BankDB(OnError);
            CenterToScreen();
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            string cardNo = numberOfCard.Text;
            if (db.verifyCardNumber(cardNo))
            {
                PinForm pinForm = new PinForm(cardNo);
                pinForm.Show();
                Hide();
            }
        }
    }
}
