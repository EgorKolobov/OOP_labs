using System;

namespace Lab5
{
    public class CreditAccount : Account
    {
        private double Takeoff { get; set; }
        
        public CreditAccount(Bank bank, double money, double takeoff) : base(bank, money)
        {
            Takeoff = takeoff;
        }
        
        public override void Replenishment(double money)
        {
            Money += money;
            if (Money < 0)
                Money -= money * Takeoff;
        }
        
        public override double Withdrawal(double money)
        {
            Money -= money;
            if (Money < 0)
                Money -= money * Takeoff;
            return money;
        }

        public override void Transfer(int id, double money)
        {
            Money -= money;
            if (Money < 0)
                Money -= money * Takeoff;
            AccountBank.FindAccountInSystem(id).Replenishment(money);
        }

        public override void UpdateBonus(double bonusMoney) {}
        
        public override void PayBonus() {}
    }
}