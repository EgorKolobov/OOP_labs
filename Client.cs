using System.Collections.Generic;

namespace Lab5
{
    public class Client
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Address { get; set; }
        private long PassportId { get; set; }
        private bool Unverified { get; set; }
        public List<int> AccountId { get; private set; }

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Unverified = true;
            AccountId = new List<int>();
        }
        
        public void SetAddress(string address)
        {
            Address = address;
            Unverified = false;
        }
        
        public void SetPassportId(int id)
        {
            PassportId = id;
            Unverified = false;
        }
        /*-------------------------- Transactions --------------------------*/
        public void Replenishment(string myBankName, int id, double money)
        {
            var myBank = BankSystem.BankData[myBankName];
            myBank.Replenishment(id, money, Unverified);
        }
        
        public void Withdrawal(string myBankName, int id, double money)
        {
            var myBank = BankSystem.BankData[myBankName];
            myBank.Withdrawal(id, money, Unverified);
        }

        public void Transfer(string myBankName, int fromId, int toId, double money)
        {
            var myBank = BankSystem.BankData[myBankName];
            myBank.Transfer(fromId, toId, money, Unverified);
        }
        /*------------------------------------------------------------------*/
        public double Info(string myBankName, int id)
        {
            var myBank = BankSystem.BankData[myBankName];
            return myBank.AccountInfo(id);
        }

        public void UndoLastTransaction(string myBankName, int accountId)
        {
            var myBank = BankSystem.BankData[myBankName];
            myBank.UndoLastTransaction(accountId);
        }

        public void AddAccount(string myBankName, string accountType, double startMoney)
        {
            var myBank = BankSystem.BankData[myBankName];
            myBank.AddAccount(this, accountType, startMoney);
        }

        public double Forecast(string myBankName, int id, int numberOfMonths)
        {
            var myBank = BankSystem.BankData[myBankName];
            return myBank.Forecast( id, numberOfMonths);
        }
        
    }
}