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
    public partial class frmATM : Form
    {

        //Array of Buttons for the keypad
        Button[,] keyPad = new Button[4, 3];
        //string entered by user using the keypad
        string input;
        //variable used to determine which screen of the ATM the user is on
        enum stage
        {
            ACCOUNT,
            PIN,
            MENU,
            WITHDRAW,
            BALANCE
        };

        stage st;

        public frmATM()
        {
            InitializeComponent();
            populateKeyPad();
        }

        /*
        *Method to set/reset the ATM when opened/reopened
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            accountScreen();
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
        private void accountScreen()
        {
            st = stage.ACCOUNT;
            lblScreen.Text = "Enter Account No : \n";
        }

        /*
        *Method which sets the ATM to the PIN number entry screen
        */
        private void pinScreen()
        {
            st = stage.PIN;
            input = "";
            lblScreen.Text = "Enter Pin No : \n";
        }

         /*
        *Method which sets the ATM to account menu screen
        */
        private void menuScreen()
        {
            st = stage.MENU;
            lblScreen.Text = "1. Withdraw \n 2. Check Balance \n 3. Exit \n"; ;
        }

        /*
        *Method which sets the ATM to withdraw cash screen
        */
        private void withdrawScreen()
        {
            st = stage.WITHDRAW;
            input = "";
            lblScreen.Text = "Enter amount to Withdraw : /n £";
        }

        /*
        *Method which sets the ATM to account balance screen
        */
        private void balanceScreen()
        {
            st = stage.BALANCE;
            lblScreen.Text = "Balance : \n £";
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
            if (st == stage.MENU)
            {
                switch (btnSender.Text)
                {
                    case "1":
                        withdrawScreen();
                        break;

                    case "2":
                        balanceScreen();
                        break;

                    case "3":
                        accountScreen();
                        break;
                }
            }

            //Checks if the button pressed was the # key and advances to next screen if so
            else if (btnSender.Text == "#")
            {
                switch (st)
                {
                    case stage.ACCOUNT:
                        pinScreen();
                        break;

                    case stage.PIN:
                        menuScreen();
                        break;

                    case stage.BALANCE:
                        menuScreen();
                        break;

                    case stage.WITHDRAW:
                        menuScreen();
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
