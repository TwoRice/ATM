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
    public partial class frmApplication : Form
    {
        //Object holding record of all the accounts on the system
        Bank bank;
        //The account being accessed on the ATM
        Account currentAccount;
        //Array of Buttons for the keypad
        Button[,] keyPad = new Button[4, 3];
        //string entered by user using the keypad
        string input;
        List<Account> ac;
        //variable used to determine which screen of the ATM the user is on
        enum Stage
        {
            ACCOUNT,
            PIN,
            DEPOSIT
        };

        Stage st;
        public frmApplication(Bank bank)
        {
            this.bank = bank;
            InitializeComponent();
            populateKeyPad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            accountScreen("Enter New Account No : \n");
        }
        
         int processAccountNo()
        {
            if (input.Length == 6) 
            {
                int accountNumb = Convert.ToInt32(input);
                //Retrieves account information from the bank object
                Account ac = bank.findAccount(accountNumb);

                //Checks is account exists
                if (ac == null)
                {
                    pinScreen("Enter Pin No : \n");
                }
                else
                {
                    accountScreen("Account Number Taken, Please Try Again : \n");                  
                }
                return accountNumb;
            }
            else
            {
                accountScreen("Account number must be 6 digits long.\n");
                return 0;
            }
                
        }

        int processPinNo()
        {

            if (input.Length == 4)
            {
                int pinNo = Convert.ToInt32(input);
                depositScreen("Select deposit amount \n");
                return pinNo;
            } 
            else
            {
                pinScreen("Pin must be 4 digits long, Please Try Again : \n");
                return 0;
            }
            
        }

        private void processDeposit()
        {
            int deposit = Convert.ToInt32(input);
            //newAccount();
            accountScreen("Account Created \n");
        }

        public void newAccount(ref int deposit,ref int pinNo)
        {
            //ac.Add(new Account(, , ));
        }
        private void populateKeyPad()
        {

            int k = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    keyPad[i, j] = new Button();
                    keyPad[i, j].Dock = DockStyle.Fill;
                    keyPad[i, j].Font = new Font("Consolas", 18, FontStyle.Bold);
                    keyPad[i, j].Text = Convert.ToString(++k);
                    keyPad[i, j].Margin = new Padding(0, 1, 1, 0);
                    keyPad[i, j].Click += new EventHandler(this.keyPadEvent_Click);
                    tblLayoutKeyPad.Controls.Add(keyPad[i, j]);
                }
            }

            keyPad[3, 0].Text = "*";
            keyPad[3, 1].Text = "0";
            keyPad[3, 2].Text = "#";

        }
        /*
 *Method which sets the ATM to the account number entry screen
 */
        private void accountScreen(string screenText)
        {
            st = Stage.ACCOUNT;
            input = "";
            lblScreen.Text = screenText;
        }

        /*
        *Method which sets the ATM to the PIN number entry screen
        */
        private void pinScreen(string screenText)
        {
            st = Stage.PIN;
            input = "";
            lblScreen.Text = screenText;
        }

        private void depositScreen(string screenText)
        {
            st = Stage.DEPOSIT;
            input = "";
            lblScreen.Text = screenText;
        }

        private void keyPadEvent_Click(object sender, EventArgs e)
        {

            Button btnSender = ((Button)sender);

           
            //Checks if the button pressed was the # key and advances to next screen if so
            if (btnSender.Text == "#")
            {
                switch (st)
                {
                    case Stage.ACCOUNT:
                        processAccountNo();
                        break;

                    case Stage.PIN:
                        processPinNo();
                        break;

                    case Stage.DEPOSIT:
                        processDeposit();
                        break;
                }
            }

            //Checks if the button pressed was the * key and removes a number from the entry if so
            else if (btnSender.Text == "*")
            {
                //Stops user deleting characters from pre-defined text
                if (input.Length != 0)
                {
                    input = input.Remove(input.Length - 1);
                    lblScreen.Text = lblScreen.Text.Remove(lblScreen.Text.Length - 1);
                }
            }

            else
            {
                //Adds users key input to screen
                input += btnSender.Text;
                lblScreen.Text += btnSender.Text;
            }

        }
    }
}
