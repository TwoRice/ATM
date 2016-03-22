using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmBank : Form
    {

        Bank bank = new Bank();
        frmATM atm = new frmATM();

        public frmBank()
        {
            InitializeComponent();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            atm.ShowDialog();
        }

        private void frmBank_Load(object sender, EventArgs e)
        {

        }
    }
}
