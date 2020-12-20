using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Lab5
{
    public abstract class Account
    {
        //public int Id { get; set; }
        protected double Money { get; set; }
        public double Percent{ get; protected set; }
        protected Bank AccountBank { get; private set; }
        public int LastTransactionId { get; set; }

        protected Account(Bank bank, double money)
        {
            AccountBank = bank;
            Money = money;
        }

        public double Info()
        {
            return Money;
        }
        
        public void ForcedWithdrawal(double money)
        {
            Money -= money;
        }
        
        public abstract double Withdrawal(double money); // Transaction
        public abstract void Replenishment(double money); // Transaction
        public abstract void Transfer(int id, double money); // Transaction
        public abstract void UpdateBonus(double bonusMoney);
        public abstract void PayBonus();
    }
}