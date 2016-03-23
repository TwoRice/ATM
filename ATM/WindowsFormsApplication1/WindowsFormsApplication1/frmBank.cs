using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmBank : Form
    {

        public Bank bank = new Bank();

        public frmBank()
        {
            InitializeComponent();
        }

        /**
        * <summary>
        * Opens a new ATM in a seprate thread
        * </summary>
        */
        private void btnBank_Click(object sender, EventArgs e)
        {
            //Sets up the new thread
            Thread atmThread = new Thread(new ThreadStart(ThreadBegin));
            //Starts the thread
            atmThread.Start();
        }

        /**
        * <summary>
        * Creates a new ATM form and opens it, to be run as the thread start
        * </summary>
        */
        private void ThreadBegin()
        {
            frmATM atm = new frmATM(bank);
            atm.ShowDialog();

        }

        private void frmBank_Load(object sender, EventArgs e)
        {

        }
    }
}
