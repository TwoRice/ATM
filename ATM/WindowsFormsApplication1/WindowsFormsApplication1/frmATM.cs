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

        Button[,] keyPad = new Button[4, 3];
        string input;
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
            setup();
        }

        public void reset()
        {
            st = stage.ACCOUNT;
            input = "";
            lblScreen.Text = "Enter Account No : \n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void setup()
        {

            int k = 0;
            lblScreen.Text = "Enter Account No : \n";

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

        private void accountScreen()
        {
            st = stage.ACCOUNT;
            lblScreen.Text = "Enter Account No : \n";
        }

        private void pinScreen()
        {
            st = stage.PIN;
            input = "";
            lblScreen.Text = "Enter Pin No : \n";
        }

        private void menuScreen()
        {
            st = stage.MENU;
            lblScreen.Text = "1. Withdraw \n 2. Check Balance \n 3. Exit \n"; ;
        }

        private void withdrawScreen()
        {
            st = stage.WITHDRAW;
            input = "";
            lblScreen.Text = "Enter amount to Withdraw : /n £";
        }

        private void balanceScreen()
        {
            st = stage.BALANCE;
            lblScreen.Text = "Balance : \n £";
        }

        private void keyPadEvent_Click(object sender, EventArgs e)
        {

            Button btnSender = ((Button)sender);

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

            else if (btnSender.Text == "*")
            {
                if (input.Length != 0)
                {
                    input = input.Remove(input.Length - 1);
                    lblScreen.Text = lblScreen.Text.Remove(lblScreen.Text.Length - 1);
                }
            }

            else
            {
                input += btnSender.Text;
                lblScreen.Text += btnSender.Text;
            }

        }

    }



}
