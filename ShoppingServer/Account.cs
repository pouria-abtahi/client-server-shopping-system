using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingServer
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string UserName { get; set; }

        public Account(int accountNumber, string userName)
        {
            AccountNumber = accountNumber;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, User: {UserName}";
        }
    }
}
