using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public class BankSystem
    {
        public static int BaseId {get; private set;}
        private static BankSystem _globalBankSystem;
        public static Dictionary<int, Account> Data {get; private set;}
        public static Dictionary<string, Bank> BankData {get; private set;}

        private BankSystem()
        {
            BaseId = 1000;
            Data = new Dictionary<int, Account>();
            BankData = new Dictionary<string, Bank>();
        }

        public static BankSystem Status()
        {
            return BankSystem._globalBankSystem ?? (BankSystem._globalBankSystem = new BankSystem());
        }
        
        public void AddBank(Bank newBank)
        {
            newBank.SetSystem(this);
            BankData.Add(newBank.Name, newBank);
            foreach (var (key, value) in newBank.Accounts)
                Data.Add(key, value);
        }

        public void IncBaseId()
        {
            BaseId++;
        }

        public void DailyUpdate()
        {
            foreach (var account in BankData.Values.SelectMany(bank => bank.Accounts.Values))
                account.UpdateBonus((account.Percent / 365) * account.Info());
        }
        
        public void MonthUpdate()
        {
            foreach (var account in BankData.Values.SelectMany(bank => bank.Accounts.Values))
                account.PayBonus();
        }
        
    }
}