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
    public partial class Bankomat : Form
    {
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
    }
}
