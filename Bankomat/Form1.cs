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
        BankDB db = null;
        public Bankomat()
        {
            CenterToScreen();
            InitializeComponent();
        }

        private void Bankomat_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numberOfCard_TextChanged(object sender, EventArgs e)
        {
            numberOfCard.MaxLength = 31; 
        } 

        private void btnstart_Click(object sender, EventArgs e)
        {
        }
    }
}
