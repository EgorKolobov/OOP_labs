using System;
using Microsoft.VisualBasic;

namespace Lab5
{
    public class Transaction
    {
        public string Type { get; private set; }
        public int FromId { get; private set; }
        public int ToId { get; private set; }
        public double Money { get; private set; }

        public Transaction(int fromId, int toId, double money, string type)
        {
            Type = type;
            FromId = fromId;
            ToId = toId;
            Money = money;
        }
        
        public Transaction(int account, double money, string type)
        {
            Type = type;
            FromId = account;
            ToId = -1;
            Money = money;
        }
    }
}