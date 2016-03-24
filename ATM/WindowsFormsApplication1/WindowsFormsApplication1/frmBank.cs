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
        Boolean lag, fix = false;

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
            frmATM atm = new frmATM(bank, lag, fix);
            atm.ShowDialog();

        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("Accounts.txt"))
            {
                System.IO.File.AppendAllText("Accounts.txt", "111111,1111,500" + Environment.NewLine);
                System.IO.File.AppendAllText("Accounts.txt", "222222,2222,1000" + Environment.NewLine);
            }
            else
            {
                string[] fileText = System.IO.File.ReadAllLines("Accounts.txt");

                int[] temp = new int[3];
                foreach (string line in fileText)
                {
                    temp = Array.ConvertAll(line.Split(','), int.Parse);
                    bank.newAccount(temp[2], temp[1], temp[0]);
                }
            }
        }

        private void frmBank_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Account> ac= bank.getAccounts();

            System.IO.File.WriteAllText("Accounts.txt", string.Empty);
            foreach (var account in ac)
            {
                System.IO.File.AppendAllText("Accounts.txt", account.getAccountNum() + "," + account.getPinNum() + "," + account.getBalance() + Environment.NewLine);
            }

        }

        private void lagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toggle = ((ToolStripMenuItem)sender);

            if (toggle.Text == "Enable Lag")
            {
                lag = true;
                toggle.Text = "Disable Lag";
            }
            else
            {
                lag = false;
                toggle.Text = "Enable Lag";
            }
        }

        private void fixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toggle = ((ToolStripMenuItem)sender);

            if (toggle.Text == "Enable Fix")
            {
                fix = true;
                toggle.Text = "Disable Fix";
            }
            else
            {
                fix = false;
                toggle.Text = "Enable Fix";
            }
        }
    }
}
