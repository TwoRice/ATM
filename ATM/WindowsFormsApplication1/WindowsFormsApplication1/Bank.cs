using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Bank
    {
         List<Account> ac = new List<Account>();

        public Bank()
        {
            newAccount(500, 1111, 111111);
            newAccount(1000, 2222, 222222);

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
