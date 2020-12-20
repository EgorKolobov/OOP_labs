using NUnit.Framework;
using Lab5;
namespace Lab5Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [Test]
        public void Test1()
        {
            var masterCard = BankSystem.Status();
            
            var tinkoff = new Bank("Тинькофф", 0.0365, 365, 0.1, 5000);
            
            masterCard.AddBank(tinkoff);
            
            var me = new Client("Егор","Колобов" );
            me.SetAddress("Санкт-Петербург");
            me.SetPassportId(228666420);

            me.AddAccount("Тинькофф", "debit", 100000);// 100 000, Bonus = 0
            masterCard.DailyUpdate(); // Bonus += 10
            
            me.Replenishment("Тинькофф",me.AccountId[0], 100000); // + 100 000 = 200 00
            masterCard.DailyUpdate(); // Bonus += 20
            
            me.Withdrawal("Тинькофф",me.AccountId[0], 150000); // - 150 000 = 50 000
            masterCard.DailyUpdate(); // Bonus += 5
            
            masterCard.MonthUpdate(); // 50 000 + Bonus = 50 000 + 35 = 50 035
            
            Assert.AreEqual(50035, me.Info("Тинькофф", me.AccountId[0]));
        }

        [Test]
        public void Test2()
        {
            var masterCard = BankSystem.Status();
            
            var tinkoff = new Bank("Тинькофф", 0.0365, 365, 0.1, 5000);

            masterCard.AddBank(tinkoff);
            
            var me = new Client("Егор","Колобов" );
            me.SetAddress("Санкт-Петербург");
            me.SetPassportId(228666420);
            
            me.AddAccount("Тинькофф", "deposit", 1000000);
            
            var myForecast = me.Forecast("Тинькофф", me.AccountId[0], 18);
            
            Assert.AreEqual(1060000, myForecast);
        }
        
        [Test]
        public void Test3()
        {
            var masterCard = BankSystem.Status();
            
            var tinkoff = new Bank("Тинькофф", 0.0365, 365, 0.1, 5000);
            var sber = new Bank("Сбер", 0.03, 730, 0.15, 6000);

            masterCard.AddBank(tinkoff);
            masterCard.AddBank(sber);
            
            var me = new Client("Егор","Колобов" );
            me.SetAddress("Санкт-Петербург");
            me.SetPassportId(228666420);

            var friend = new Client("Друг","Хороший" );
            friend.SetAddress("Санкт-Петербург");
            friend.SetPassportId(1488691337);
            
            me.AddAccount("Тинькофф", "deposit", 100000); 
            friend.AddAccount("Сбер", "debit", 500000);
            
            friend.Transfer("Сбер", friend.AccountId[0], me.AccountId[0], 250000);
            
            Assert.AreEqual(350000, me.Info("Тинькофф", me.AccountId[0]));
            Assert.AreEqual(250000, friend.Info("Сбер", friend.AccountId[0]));
        }

        [Test]
        public void Test4()
        {
            var masterCard = BankSystem.Status();
            
            var tinkoff = new Bank("Тинькофф", 0.0365, 365, 0.1, 5000);

            masterCard.AddBank(tinkoff);
            
            var me = new Client("Егор","Колобов" );
            
            me.AddAccount("Тинькофф", "debit", 100000);
            me.Withdrawal("Тинькофф", me.AccountId[0], 90000);
            Assert.AreEqual(95000, me.Info("Тинькофф", me.AccountId[0]));
        }

        [Test]
        public void Test5()
        {
            var masterCard = BankSystem.Status();
            
            var tinkoff = new Bank("Тинькофф", 0.0365, 365, 0.1, 5000);
            var sber = new Bank("Сбер", 0.03, 730, 0.15, 6000);

            masterCard.AddBank(tinkoff);
            masterCard.AddBank(sber);
            
            var me = new Client("Егор","Колобов" );
            me.SetAddress("Санкт-Петербург");
            me.SetPassportId(228666420);

            var friend = new Client("Друг","Хороший" );
            friend.SetAddress("Санкт-Петербург");
            friend.SetPassportId(1488691337);
            
            me.AddAccount("Тинькофф", "deposit", 100); 
            friend.AddAccount("Сбер", "debit", 500); 
            
            friend.Transfer("Сбер", friend.AccountId[0], me.AccountId[0], 250);
            
            friend.UndoLastTransaction("Сбер", friend.AccountId[0]);
            
            Assert.AreEqual(100, me.Info("Тинькофф", me.AccountId[0]));
            Assert.AreEqual(500,  friend.Info("Сбер", friend.AccountId[0]));
        }
    }
}