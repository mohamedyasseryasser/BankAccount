using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class CurrentAccount
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                     if (value < -OverdraftLimit)
                        throw new InvalidOperationException($"Balance cannot go below overdraft limit ({-OverdraftLimit})");
                }
                _balance = value;
            }
        }

        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(int accountNumber, string ownerName, decimal overdraftLimit)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = 0;
            OverdraftLimit = overdraftLimit;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero");

            Balance += amount;
            Console.WriteLine($"Your balance becomes {Balance} after deposit {amount}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be greater than zero");

            if (Balance - amount < -OverdraftLimit)
                throw new InvalidOperationException($"Cannot withdraw more than balance + overdraft limit ({OverdraftLimit})");

            Balance -= amount;
            Console.WriteLine($"Your balance becomes {Balance} after withdraw {amount}");
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Owner Name     : {OwnerName}");
            Console.WriteLine($"Balance        : {Balance}");
            Console.WriteLine($"Account Type   : Current (Standalone)");
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }
    }
}