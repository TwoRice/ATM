using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmATM : Form
    {

        Boolean lag, fix;
        static Semaphore s;
        //Object holding record of all the accounts on the system
        Bank bank;
        //The account being accessed on the ATM
        Account currentAccount;
        //Array of Buttons for the keypad
        Button[,] keyPad = new Button[4, 3];
        //string entered by user using the keypad
        string input;
        //variable used to determine which screen of the ATM the user is on
        enum Stage
        {
            ACCOUNT,
            PIN,
            MENU,
            WITHDRAW,
            BALANCE
        };

        Stage st;

        public frmATM(Bank bank, Boolean lag, Boolean fix)
        {
            this.lag = lag;
            this.fix = fix;
            if(fix == true) { s = new Semaphore(1, 1); }
            this.bank = bank;
            InitializeComponent();
            populateKeyPad();
        }

        /*
        *Method to set/reset the ATM when opened/reopened
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            accountScreen("Enter Account No : \n");
        }


        /**
        *Method to populate the key pad array with the buttons for the key pad
        */
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

         /*
        *Method which sets the ATM to account menu screen
        */
        private void menuScreen()
        {
            st = Stage.MENU;
            lblScreen.Text = "1. Withdraw \n 2. Check Balance \n 3. Exit \n"; ;
        }

        /*
        *Method which sets the ATM to withdraw cash screen
        */
        private void withdrawScreen(string screenText)
        {
            st = Stage.WITHDRAW;
            input = "";
            lblScreen.Text = screenText;
        }

        /*
        *Method which sets the ATM to account balance screen
        */
        private void balanceScreen()
        {
            st = Stage.BALANCE;
            int balance = currentAccount.getBalance();
            lblScreen.Text = "Balance : \n £" + balance;
        }


        /**
        * <summary>
        * Method which takes the account number from the user and checks if it is a valid account then moves on
        * </summary>
        */
        private void processAccountNo()
        {
            try
            {
                int accountNum = Convert.ToInt32(input);
                //Retrieves account information from the bank object
                Account ac = bank.findAccount(accountNum);

                //Checks is account exists
                if (ac == null)
                {
                    accountScreen("Invalid Account No, Please Try Again : \n");
                }
                else
                {
                    currentAccount = ac;
                    pinScreen("Enter Pin No : \n");
                }
            }
            catch
            {
                accountScreen("Invalid Account No, Please Try Again : \n");
            }
        }

        /**
        * <summary>
        * Method which takes the pin number for the account from the user checks if it is correct then moves on
        * </summary>
        */
        private void processPinNo()
        {
            try
            {
                int pinNo = Convert.ToInt16(input);
                //Checks if pin number is correct
                if (currentAccount.checkPin(pinNo))
                {
                    menuScreen();
                }
                else
                {
                    pinScreen("Invalid Pin No, Please Try Again : \n");
                }
            }
            catch
            {
                pinScreen("Invalid Pin No, Please Try Again : \n");
            }
        }

        /**
        * <summary>
        * Method which takes amount to be withdrawn from the user and removes that value from the account balance
        * </summary>
        */
        private void processWithdrawl()
        {
            int amount = Convert.ToInt32(input);
            //Checks if the user has enough in there account to remove the amount specified
            if (currentAccount.getBalance() < amount)
            {
                withdrawScreen("Insufficient Funds, Please Try Again : \n £");
            }
            else
            {
                if (fix == true) { s.WaitOne(); }
                currentAccount.decrementBalance(amount, lag);
                if (fix == true) { s.Release(); }
                menuScreen();
            }

        }

        /**
        * <summary>
        * Method which handles what happens when a key on the key pad is pressed
        * </summary>
        *
        * <param name="sender">
        * The button on the key pad that was pressed
        * </param>
        */
        private void keyPadEvent_Click(object sender, EventArgs e)
        {

            Button btnSender = ((Button)sender);

            //Checks if the ATM is on the menu screen and uses 1,2 and 3 as option selection keys if so
            if (st == Stage.MENU)
            {
                switch (btnSender.Text)
                {
                    case "1":
                        withdrawScreen("Enter amount to withdraw : \n £");
                        break;

                    case "2":
                        balanceScreen();
                        break;

                    case "3":
                        accountScreen("Enter Account No : \n");
                        break;
                }
            }

            //Checks if the button pressed was the # key and advances to next screen if so
            else if (btnSender.Text == "#")
            {
                switch (st)
                {
                    case Stage.ACCOUNT:
                        processAccountNo();
                        break;

                    case Stage.PIN:
                        processPinNo();
                        break;

                    case Stage.BALANCE:
                        menuScreen();
                        break;

                    case Stage.WITHDRAW:
                        processWithdrawl();
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
