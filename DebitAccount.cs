using System;

namespace Lab5
{
    public class DebitAccount : Account
    {
        private double Bonus { get; set; }
        public DebitAccount(Bank bank, double money, double percent) : base(bank, money)
        {
            Percent = percent;
        }

        public override void Replenishment(double money)
        {
            Money += money;
        }
        
        public override double Withdrawal(double money)
        {
            if (!(Money - money > 0)) return 0; // Exception: Not enough money on account!
            Money -= money;
            return money;
        }

        public override void Transfer(int id, double money)
        {
            if (!(Money - money > 0)) return;
            Money -= money;
            AccountBank.FindAccountInSystem(id).Replenishment(money);
            return ;
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