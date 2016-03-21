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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        class Program{
            private Account[] ac = new Account[3];
            private ATM atm;

            public Program(){
                ac[0] = new Account(300,1111,111111);
                ac[1] = new Account(750,2222,222222);
                ac[2] = new Account(3000,3333,333333);

                atm = new ATM(ac);
            }

            static void Main(string[] args)
            {
                new Program();
            }

        }
        public class Account 
        {
            //Attributes for account.
            private int balance;
            private int pin;
            private int accountNum;
            
            //constuctor that takes inital values for account attributes
            public Account(int balance, int pin, int accountNum)
            {
                this.balance = balance;
                this.pin = pin;
                this.accountNum = accountNum;
            }

            public int getBalance()
            {
                return balance;
            }

            public void setBalance(int newBalance)
            {
                this.balance = newBalance;
            }
       
             /*
         *   This funciton allows us to decrement the balance of an account
         *   it perfomes a simple check to ensure the balance is greater tha
         *   the amount being debeted
         *   
         *   reurns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        


        class ATM
        {
            //local referance to the array of accounts 
            private Account[] ac;

            //referance to the account being used
            private Account activeAccount = null;

            public ATM(Account[] ac)
            {
               this.ac = ac;
            }

           /* while(true)
            {
                activeAccount = this.findAccount();
                
                if (activeAccount != null)
                {
                    if(activeAccount.checkPin(this.promptForPin()))
                    {
                        DispOptions();
                    }
                }
                else
                {
                
                }   
            }
        }*/

        private Account findAccount()
        {
            lblDisplay.Text = "Enter your account number.."
            //userinput//



        }


        private void label1_Click(object sender, EventArgs e)
        {
        
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }
}
