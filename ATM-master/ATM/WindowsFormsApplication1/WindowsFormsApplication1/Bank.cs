using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    public class Bank
    {
        //List of bank accounts
        List<Account> ac;

        public Bank()
        {
            ac = new List<Account>();
            newAccount(500, 1111, 111111);
            newAccount(1000, 2222, 222222);

        }

        /**
        * <summary>
        * Returns the list of accounts
        * </summary>
        *
        * <returns>
        * List of accounts
        * </returns>
        */
        public List<Account> getAccounts()
        {
            return ac;
        }

        /**
        * <summary>
        * Looks for an account with the given account number
        * </summary>
        *
        * <param name="accountNum">
        * The account number to be searched
        * </param>
        * <returns>
        * The account if it was found, null otherwise
        * </returns>
        */
        public Account findAccount(int accountNum)
        {
            foreach (var account in ac)
            {
                if (account.getAccountNum() == accountNum)
                {
             
                    return account;
                }
            }

            return null;
        }

        /**
        * <summary>
        * Creates a new account and adds it to the list of accounts
        * </summary>
        *
        * <param name="startingBalance">
        * The balance the account should be set up with
        * </param>
        * <param name="pin">
        * The pin number for the new account
        * </param>
        * <param name="accountNum">
        * The account number for the new account
        * </param>
        */
        public void newAccount(int startingBalance, int pin, int accountNum)
        {
            ac.Add(new Account(startingBalance, pin, accountNum));
        }

        /**
        * <summary>
        * Deletes a specifed account from the list of accounts
        * </summary>
        *
        * <param name="accountNum">
        * The account number for the account to be removed
        * </param>
        */
        public void deleteAccount(int accountNum)
        {
            ac.RemoveAll(x => x.getAccountNum() == accountNum);
        }
    }
}
