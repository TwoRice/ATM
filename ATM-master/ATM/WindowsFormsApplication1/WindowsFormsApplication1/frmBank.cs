using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

        /**
        * <summary>
        * Runs when Bank form is opened and takes account information from a text file and loads it into the bank
        * </summary>
        */
        private void frmBank_Load(object sender, EventArgs e)
        {
            //Checks to see if the file for Account information exists, if not it creates the file with the default bank account information in it
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


        /**
        * <summary>
        * Runs when the bank form is closing and saves all account information to a text file
        * </summary>
        */
        private void frmBank_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Account> ac= bank.getAccounts();

            //Clears the contents of the text file
            System.IO.File.WriteAllText("Accounts.txt", string.Empty);
            foreach (var account in ac)
            {
                System.IO.File.AppendAllText("Accounts.txt", account.getAccountNum() + "," + account.getPinNum() + "," + account.getBalance() + Environment.NewLine);
            }

        }

        /**
        * <summary>
        * Enables the lag for the decrement balance method for when its called to help demonstrate the data race condition
        * </summary>
        */
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

        /**
        * <summary>
        * Enables the fix for the data race condition by enabling the semaphore code
        * </summary>
        */
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
       
        /**
        *Method  that allows for accounts to be created
        */ 
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boolean varible for input validation
            bool accountCheck = false;
            do
            {
                //input box that allows user to enter a new account number
                string acNo = Interaction.InputBox("Please enter a new 6 digit Account Number", "Account Creation", "", -1, -1);
                //validation to check length of the account number entered
                if (acNo.Length == 6)
                {

                    //converts user input to integer
                    int newAccount = Convert.ToInt32(acNo);
                    accountCheck = true;



                    //Checks is account exists
                    Account ac = bank.findAccount(newAccount);
                    if (ac == null)
                    {

                        bool pinCheck = false;
                        do
                        {
                            //input box that allows user to enter a new pin number
                            string pinNo = Interaction.InputBox("Please enter a new 4 digit Pin Number", "Account Creation", "", -1, -1);
                            //checks pin length is correct
                            if (pinNo.Length == 4)
                            {
                                //converts user input to integer
                                int newPin = Convert.ToInt32(pinNo);
                                pinCheck = true;


                                //input box that allows user to enter a deposit amount
                                string deposit = Interaction.InputBox("Please enter a deposit amount", "Account Creation", "", -1, -1);
                                //converts user input to integer
                                int newDeposit = Convert.ToInt32(deposit);
                                //inputs all user data and creates the account
                                bank.newAccount(newDeposit, newPin, newAccount);

                            }
                            else
                            {
                                //error message for pin validation
                                MessageBox.Show("Pin must be 4 digits long");
                            }
                        } while (pinCheck == false);

                    }
                    else
                    {
                        //error message for account validation
                        MessageBox.Show("Account Number Taken, Please Try Again : \n");
                    }

                }
                else
                {
                    //error message for account validation
                    MessageBox.Show("Account number must be 6 digits long.\n");
                }
            } while (accountCheck == false);
           
            

        }

        /**
        *Method  that allows for accounts to be deleted
        */
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool delCheck = false;


            do
            {

                //input box that allows user to eneter the account to be deleted
                string delAcc = Interaction.InputBox("Please enter the account number you wish to delete", "Account Deletion", "", -1, -1);
                if (delAcc.Length == 6)
                {
                    int deleteNum = Convert.ToInt32(delAcc);
                    bank.deleteAccount(deleteNum);
                    delCheck = true;


                }
                else
                {
                    //error message for account validation
                    MessageBox.Show("The account you wish to delete must be 6 digits long");
                }
            } while (delCheck == false);
        }

        /**
        *Method  that allows user to seach for accounts
        */
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool findCheck = false;


            do
            {
                string finAcc = Interaction.InputBox("Please enter the account number you wish to view", "Find Account", "", -1, -1);
                if (finAcc.Length == 6)
                {
                       int findNum = Convert.ToInt32(finAcc);    
                    //Checks is account exists
                    Account ac = bank.findAccount(findNum);
                    if (ac == null)
                    {
                        //error message for account validation
                        MessageBox.Show("Account Number Not Found, Please Try Again : \n");

                    }
                    else
                    {
                        //calls method to retreive and print account details
                        
                        Account found = bank.findAccount(findNum);
                        string aN = Convert.ToString(found.getAccountNum());
                        string pN = Convert.ToString(found.getPinNum());
                        string dN = Convert.ToString(found.getBalance());
                        MessageBox.Show("Account No: " + aN + " Pin Number " + pN + " Balance £" + dN);
                        findCheck = true;
                    }

                }
                else
                {
                    //error message for account validation
                    MessageBox.Show("The account you wish to delete must be 6 digits long");
                }
            } while (findCheck == false);
        }
    }
}
