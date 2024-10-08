using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genepool.src.OOP.Encapsulation
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            this.balance = initialBalance;
        }

        public decimal GetBalance()
        {
            Console.WriteLine($"Balance: {balance}");
            return balance;
        }

        public void Deposit(decimal amount)
        {
            if(amount <= 0) {
                throw new InvalidOperationException("");
            }
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                throw new InvalidOperationException("");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}