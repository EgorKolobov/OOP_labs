using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Client
    {
        private string _name;
        private string _surname;
        private string _address;
        private long _passportId;
        private bool Unverified { get; set; }
        public List<int> AccountId { get; private set; }
        
        public void SetName(string name)
        {
            _name = name;
        }
        
        public void SetSurname(string surname)
        {
            _surname = surname;
        }
        public void SetAddress(string address)
        {
            _address = address;
            Unverified = false;
        }
        
        public void SetPassportId(long passportId)
        {
            _passportId = passportId;
            Unverified = false;
        }

        public Client()
        {
            AccountId = new List<int>();
            Unverified = true;
        }
        /*public Client(Client template)
        {
            SetName(template.Name);
            SetSurname(template.Surname);
            SetAddress(template.Address);
            SetPassportId(template.PassportId);
        }*/
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