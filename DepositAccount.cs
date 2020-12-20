using System;

namespace Lab5
{
    public class DepositAccount : Account
    {
        private int Lifespan { get; set; }
        private double Bonus { get; set; }
        public DepositAccount(Bank bank, double money, int lifespan) : base(bank, money)
        {
            Lifespan = lifespan;
            UpdatePercent();
        }
        
        public override void Replenishment(double money)
        {
            Money += money;
            UpdatePercent();
        }

        public override double Withdrawal(double money)
        {
            if (Lifespan != 0)
                return 0; // Exception: Can't withdraw money from deposit account before it's expiration!
            if (Money - money < 0)
                return 0; // Exception: Not enough money on account!
            Money -= money;
            return money;
        }

        public override void Transfer(int id, double money)
        {
            if (Lifespan != 0) 
                return; // Exception: Can't withdraw money from deposit account before it's expiration!
            if (Money - money < 0) // Exception: Not enough money on account!
                return;
            Money -= money;
            AccountBank.FindAccountInSystem(id).Replenishment(money);
        }

        private void UpdatePercent()
        {
            if (Money < 50000)
                Percent = 0.03;
            else if (Money < 100000)
                Percent = 0.035;
            else
                Percent = 0.04;
        }

        public override void UpdateBonus(double bonusMoney)
        {
            Bonus += bonusMoney;
        }
        
        public override void PayBonus()
        {
            Money += Bonus;
            Bonus = 0;
        }
    }
}