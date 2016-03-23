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

        public List<Account> getAccounts()
        {
            return ac;
        }

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

        public void newAccount(int startingBalance, int pin, int accountNum)
        {
            ac.Add(new Account(startingBalance, pin, accountNum));
        }

        public void deleteAccount(int accountNum)
        {

            ac.RemoveAll(x => x.getAccountNum() == accountNum);

        }
    }
}
