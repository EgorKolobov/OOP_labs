using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Lab5
{
    public class Bank
    {
        private BankSystem System { get; set; }
        
        public string Name { get; private set; }
        private double DebitPercent { get; set; } // [0 ; 1]
        private int DepositLifespan { get; set; } // Number of days
        private double CreditTakeoff { get; set; } // [0 ; 1]
        private double MoneyLimit { get; set; } // Money limit for unverified clents
        private int TransactionId { get; set; }
        
        private Dictionary<int, Transaction> Transactions { get; set; }
        public Dictionary<int, Account> Accounts { get; private set; }

        public Bank(string name, double debitPr, int depositLs, double creditTakeoff, double moneyLimit)
        {
            Name = name;
            DebitPercent = debitPr;
            DepositLifespan = depositLs;
            CreditTakeoff = creditTakeoff;
            MoneyLimit = moneyLimit;
            
            TransactionId = 0;
            Accounts = new Dictionary<int, Account>();
            Transactions = new Dictionary<int, Transaction>();
        }

        public void SetSystem(BankSystem system)
        {
            System = system;
        }

        public Dictionary<int, Account> GetAccountsCopy()
        {
            return new Dictionary<int, Account>(Accounts);
        }
        
        public Account FindAccountInSystem(int id)
        {
            if (!BankSystem.Data.ContainsKey(id))
                throw new UserException("Ошибка! Счёт с номером: " + id + " не был найден в глобальной банковской системе.");
            else
                return BankSystem.Data[id];
        }

        public void AddAccount(Client client, string accountType, double startMoney)
        {
            var id = BankSystem.BaseId;
            switch (accountType)
            {
                case "debit":
                    var newDebitAccount = new DebitAccount(this, startMoney, DebitPercent);
                    Accounts.Add(id, newDebitAccount);
                    BankSystem.Data.Add(id, newDebitAccount);
                    client.AccountId.Add(id);
                    System.IncBaseId();
                    break;
                case "deposit":
                    var newDepositAccount = new DepositAccount(this, startMoney, DepositLifespan);
                    Accounts.Add(id, newDepositAccount);
                    BankSystem.Data.Add(id, newDepositAccount);
                    client.AccountId.Add(id);
                    System.IncBaseId();
                    break;
                case "credit":
                    var newCreditAccount = new CreditAccount(this, startMoney, CreditTakeoff);
                    Accounts.Add(id, newCreditAccount);
                    BankSystem.Data.Add(id, newCreditAccount);
                    client.AccountId.Add(id);
                    System.IncBaseId();
                    break;
                default:
                    throw new UserException("Ошибка! Неизвестный тип счёта.");
            }
        }
        
        /*-------------------------- Transactions --------------------------*/
        public void Replenishment(int id, double money, bool unverifiedClient)
        {
            if(!Accounts.ContainsKey(id))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + id);
            if (unverifiedClient && money > MoneyLimit)
                money = MoneyLimit;
            Transactions.Add(TransactionId, new Transaction(id, money, "Replenishment"));
            Accounts[id].LastTransactionId = TransactionId;
            TransactionId++;
            Accounts[id].Replenishment(money);
        }
        
        public void Withdrawal(int id, double money, bool unverifiedClient)
        {
            if(!Accounts.ContainsKey(id))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + id);
            if (unverifiedClient && money > MoneyLimit)
                money = MoneyLimit;
            Transactions.Add(TransactionId, new Transaction(id, money, "Withdrawal"));
            Accounts[id].LastTransactionId = TransactionId;
            TransactionId++;
            Accounts[id].Withdrawal(money);
        }
        
        public void Transfer(int fromId, int toId, double money, bool unverifiedClient)
        {
            if(!Accounts.ContainsKey(fromId))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + fromId);
            if (unverifiedClient && money > MoneyLimit)
                money = MoneyLimit;
            Transactions.Add(TransactionId, new Transaction(fromId, toId, money, "Transfer"));
            Accounts[fromId].LastTransactionId = TransactionId;
            TransactionId++;
            Accounts[fromId].Transfer(toId, money);
        }
        /*------------------------------------------------------------------*/

        public double AccountInfo(int id)
        {
            if (!Accounts.ContainsKey(id))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + id);
            return Accounts[id].Info();
        }

        public void UndoLastTransaction(int accountId)
        {
            if(!Accounts.ContainsKey(accountId))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + accountId);
            var transactionId = Accounts[accountId].LastTransactionId;
            if(!Transactions.ContainsKey(transactionId))
                throw new UserException("В Банке " + Name + " не совершалась операция с номером " + transactionId);
            var badTransaction = Transactions[transactionId];
            Transactions.Remove(transactionId);
            switch (badTransaction.Type)
            {
                case "Replenishment":
                    Accounts[badTransaction.FromId].Withdrawal(badTransaction.Money);
                    break;
                case "Withdrawal":
                    Accounts[badTransaction.FromId].Replenishment(badTransaction.Money);
                    break;
                case "Transfer":
                    Accounts[badTransaction.FromId].Replenishment(badTransaction.Money);
                    var toAccount = FindAccountInSystem(badTransaction.ToId);
                    toAccount.ForcedWithdrawal(badTransaction.Money);
                    break;
                default:
                    throw new UserException("Ошибка! Неизвестный тип операции.");
            }
        }

        public double Forecast(int id, int numberOfMonths)
        {
            if(!Accounts.ContainsKey(id))
                throw new UserException("В Банке " + Name + " нет счёта с номером " + id);
            if(Accounts[id].GetType() == typeof(CreditAccount))
                throw new UserException("У кредитного счёта нет начисления по процентам!");
            var money = Accounts[id].Info();
            return Math.Round(money *(1 + Accounts[id].Percent * (numberOfMonths / 12.0)), 2);
        }
        
    }
}