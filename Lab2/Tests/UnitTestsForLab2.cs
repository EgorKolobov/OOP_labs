using System;
using System.Collections.Generic;
using Lab2;
using NUnit.Framework;
namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestDeliverProducts()
        {
            var shop1 = new Shop( 1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(100, "Black Monster Energy Ultra", 90, 20);
            
            Assert.AreEqual("Black Monster Energy Ultra", shop1.GetProductName(100));
            Assert.AreEqual(90, shop1.GetProductPrice(100));
            Assert.AreEqual(20, shop1.GetProductQuantity(100));
            try {
                shop1.DeliverProducts(100, "Water", 10, 20);
                Assert.Fail();
            } catch (UserException e) {
                Assert.AreEqual("There is already a Product with Code 100 in the Shop №1", e.Message);
            }
            try {
                shop1.DeliverProducts(100, "Water2", 0, 20);
                Assert.Fail();
            } catch (UserException e) {
                Assert.AreEqual("Product's Price can't be 0!", e.Message);
            }
        }

        [Test]
        public void TestFindCheapestSource1()
        {
            var shop1 = new Shop(1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(100, "Black Monster Energy Ultra", 75, 20);
            shop1.DeliverProducts(101, "Pepsi", 36.5, 100);
            shop1.DeliverProducts(102, "Pepsi", 70, 90);
            shop1.DeliverProducts(103, "Snickers", 50, 45);
            shop1.DeliverProducts(104, "M&M's", 120, 30);
            shop1.DeliverProducts(105, "Dr. Pepper", 57, 40);
            shop1.DeliverProducts(106, "AriZona", 129, 15);
            shop1.DeliverProducts(107, "Mars", 37, 50);
            shop1.DeliverProducts(108, "Pringles", 90, 25);
            shop1.DeliverProducts(109, "M1911", 15500, 10);
            
            
            
            var shop2 = new Shop(2,"Дикси", "Саблинская ул., 13/15");
            shop2.DeliverProducts(100, "Black Monster Energy Ultra", 75.9, 22);
            shop2.DeliverProducts(101, "Pepsi", 36, 100);
            shop2.DeliverProducts(102, "Pepsi", 70, 90);
            shop2.DeliverProducts(103, "Snickers", 50, 45);
            shop2.DeliverProducts(104, "M&M's", 128.9, 30);
            shop2.DeliverProducts(105, "Dr. Pepper", 56.9, 40);
            shop2.DeliverProducts(106, "AriZona", 128.5, 15);
            shop2.DeliverProducts(107, "Mars", 37, 50);
            shop2.DeliverProducts(108, "Pringles", 90, 30);
            shop2.DeliverProducts(109, "M1911", 15490, 12);
            
            var shop3 = new Shop(3,"Реалъ", "Кирочная ул., 18");
            shop3.DeliverProducts(100, "Black Monster Energy Ultra", 90, 60);
            shop3.DeliverProducts(101, "Pepsi", 38, 111);
            shop3.DeliverProducts(102, "Pepsi", 69.9, 90);
            shop3.DeliverProducts(103, "Snickers", 50, 45);
            shop3.DeliverProducts(104, "M&M's", 123, 30);
            shop3.DeliverProducts(105, "Dr. Pepper", 60, 70);
            shop3.DeliverProducts(106, "AriZona", 128, 25);
            shop3.DeliverProducts(107, "Mars", 37, 60);
            shop3.DeliverProducts(108, "Pringles", 100, 40);
            shop3.DeliverProducts(109, "M1911", 55490, 2);

            var shop4 = new Shop(4,"SPAR", "Фурштатская ул., 2/12, лит.А");
            shop4.DeliverProducts(100, "Black Monster Energy Ultra", 100, 55);
            shop4.DeliverProducts(101, "Pepsi", 37, 35);
            shop4.DeliverProducts(102, "Pepsi", 69.9, 75);
            shop4.DeliverProducts(103, "Snickers", 49.9, 45);
            shop4.DeliverProducts(104, "M&M's", 130, 100);
            shop4.DeliverProducts(105, "Dr. Pepper", 65, 70);
            shop4.DeliverProducts(106, "AriZona", 128, 25);
            shop4.DeliverProducts(107, "Mars", 36, 80);
            shop4.DeliverProducts(108, "Pringles", 97, 60);
            shop4.DeliverProducts(109, "M1911", 45500, 1);
            
            var myShops = new StoreChain(new List<Shop>(){shop1, shop2, shop3, shop4});
            
            Assert.AreEqual(1, myShops.FindCheapestSource(100));
            Assert.AreEqual(2, myShops.FindCheapestSource(101));
            Assert.AreEqual(3, myShops.FindCheapestSource(102));
            Assert.AreEqual(4, myShops.FindCheapestSource(103));
            Assert.AreEqual(1, myShops.FindCheapestSource(104));
            Assert.AreEqual(2, myShops.FindCheapestSource(105));
            Assert.AreEqual(3, myShops.FindCheapestSource(106));
            Assert.AreEqual(4, myShops.FindCheapestSource(107));
            Assert.AreEqual(1, myShops.FindCheapestSource(108));
            Assert.AreEqual(2, myShops.FindCheapestSource(109));
            try
            {
                myShops.FindCheapestSource(200);
                Assert.Fail();
            } catch (UserException e) {
                Assert.AreEqual("No Product in the Shop №1 with Code 200!", e.Message);
            }
            
        }

        [Test]
        public void TestFindCheapestSource2()
        {
            var shop1 = new Shop(1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(101, "Pepsi", 36.5, 100);
            shop1.DeliverProducts(102, "Pepsi", 70, 90);
            
            var shop2 = new Shop(2,"Дикси", "Саблинская ул., 13/15");
            shop2.DeliverProducts(100, "Black Monster Energy Ultra", 75.9, 22);
            shop2.DeliverProducts(101, "Pepsi", 36, 100);
            shop2.DeliverProducts(102, "Pepsi", 70, 90);
            shop2.DeliverProducts(103, "Snickers", 50, 45);
            
            var shop3 = new Shop(3,"Реалъ", "Кирочная ул., 18");
            shop3.DeliverProducts(100, "Black Monster Energy Ultra", 90, 60);
            shop3.DeliverProducts(101, "Pepsi", 38, 111);
            shop3.DeliverProducts(102, "Pepsi", 69.9, 90);
            
            var shop4 = new Shop(4,"SPAR", "Фурштатская ул., 2/12, лит.А");
            shop4.DeliverProducts(100, "Black Monster Energy Ultra", 100, 55);
            shop4.DeliverProducts(101, "Pepsi", 37, 35);
            shop4.DeliverProducts(102, "Pepsi", 69.9, 75);
            shop4.DeliverProducts(103, "Snickers", 49.9, 45);
            shop4.DeliverProducts(104, "M&M's", 130, 100);
            
            var myShops = new StoreChain(new List<Shop>(){shop1, shop2, shop3, shop4});
            
            var expected = new Dictionary<int,int>();
            expected.Add(2, 101);
            expected.Add(3, 102);
            
            Assert.AreEqual(expected, myShops.FindCheapestSource("Pepsi"));
        }

        [Test]
        public void TestCanBuy()
        {
            var shop1 = new Shop(1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(100, "Black Monster Energy Ultra", 75, 20);
            shop1.DeliverProducts(101, "Pepsi", 36.5, 100);
            shop1.DeliverProducts(102, "Pepsi", 70, 90);
            shop1.DeliverProducts(103, "Snickers", 50, 45);
            shop1.DeliverProducts(104, "M&M's", 120, 30);
            shop1.DeliverProducts(105, "Dr. Pepper", 57, 40);
            shop1.DeliverProducts(106, "AriZona", 129, 15);
            shop1.DeliverProducts(107, "Mars", 37, 50);
            shop1.DeliverProducts(108, "Pringles", 90, 25);
            shop1.DeliverProducts(109, "M1911", 15500, 10);
            
            var expected = new Dictionary<int,int>();
            expected.Add(100, 13);
            expected.Add(101, 27);
            expected.Add(102, 14);
            expected.Add(103, 20);
            expected.Add(104, 8);
            expected.Add(105, 17);
            expected.Add(106, 7);
            expected.Add(107, 27);
            expected.Add(108, 11);
            
            Assert.AreEqual(expected, shop1.CanBuy(1000));
        }

        [Test]
        public void TestSellPackage()
        {
            var shop1 = new Shop(1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(100, "Black Monster Energy Ultra", 75, 20);
            shop1.DeliverProducts(101, "Pepsi", 36.5, 100);
            shop1.DeliverProducts(102, "Pepsi", 70, 90);
            shop1.DeliverProducts(103, "Snickers", 50, 45);
            shop1.DeliverProducts(104, "M&M's", 120, 30);
            shop1.DeliverProducts(105, "Dr. Pepper", 57, 40);
            shop1.DeliverProducts(106, "AriZona", 129, 15);
            shop1.DeliverProducts(107, "Mars", 37, 50);
            shop1.DeliverProducts(108, "Pringles", 90, 25);
            shop1.DeliverProducts(109, "M1911", 15500, 10);

            Package pack1 = new Package();
            pack1.Add(100, 10);
            pack1.Add(100, 5);
            pack1.Add(106, 10);
            pack1.Add(109, 2);
            
            Assert.AreEqual(33415, shop1.SellPackage(pack1));
            
            var shop2 = new Shop(2,"Дикси", "Саблинская ул., 13/15");
            try
            {
                shop2.SellPackage(pack1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("No Product in the Shop №2 with Code 100!",e.Message);
            }
            shop2.DeliverProducts(100, "Black Monster Energy Ultra", 75, 5);
            try
            {
                shop2.SellPackage(pack1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Shop №2 can't sell enough Product №100 !",e.Message);
            }
        }

        [Test]
        public void TestFindCheapestSource3()
        {
            var shop1 = new Shop(1,"Дикси", "Сытнинская ул., 4");
            shop1.DeliverProducts(100, "Black Monster Energy Ultra", 75, 20);
            shop1.DeliverProducts(101, "Pepsi", 36.5, 100);
            shop1.DeliverProducts(102, "Pepsi", 70, 90);
            shop1.DeliverProducts(103, "Snickers", 50, 45);
            shop1.DeliverProducts(104, "M&M's", 120, 30);
            shop1.DeliverProducts(105, "Dr. Pepper", 57, 40);
            shop1.DeliverProducts(106, "AriZona", 129, 15);
            shop1.DeliverProducts(107, "Mars", 37, 50);
            shop1.DeliverProducts(108, "Pringles", 90, 25);
            shop1.DeliverProducts(109, "M1911", 15500, 10);
            
            
            
            var shop2 = new Shop(2,"Дикси", "Саблинская ул., 13/15");
            shop2.DeliverProducts(100, "Black Monster Energy Ultra", 75.9, 22);
            shop2.DeliverProducts(101, "Pepsi", 36, 100);
            shop2.DeliverProducts(102, "Pepsi", 70, 90);
            shop2.DeliverProducts(103, "Snickers", 50, 45);
            shop2.DeliverProducts(104, "M&M's", 128.9, 30);
            shop2.DeliverProducts(105, "Dr. Pepper", 56.9, 40);
            shop2.DeliverProducts(106, "AriZona", 128.5, 15);
            shop2.DeliverProducts(107, "Mars", 37, 50);
            shop2.DeliverProducts(108, "Pringles", 90, 30);
            shop2.DeliverProducts(109, "M1911", 15490, 12);
            
            var shop3 = new Shop(3,"Реалъ", "Кирочная ул., 18");
            shop3.DeliverProducts(100, "Black Monster Energy Ultra", 90, 60);
            shop3.DeliverProducts(101, "Pepsi", 38, 111);
            shop3.DeliverProducts(102, "Pepsi", 69.9, 90);
            shop3.DeliverProducts(103, "Snickers", 50, 45);
            shop3.DeliverProducts(104, "M&M's", 123, 30);
            shop3.DeliverProducts(105, "Dr. Pepper", 60, 70);
            shop3.DeliverProducts(106, "AriZona", 128, 25);
            shop3.DeliverProducts(107, "Mars", 37, 60);
            shop3.DeliverProducts(108, "Pringles", 100, 40);
            shop3.DeliverProducts(109, "M1911", 55490, 2);

            var shop4 = new Shop(4,"SPAR", "Фурштатская ул., 2/12, лит.А");
            shop4.DeliverProducts(100, "Black Monster Energy Ultra", 100, 55);
            shop4.DeliverProducts(101, "Pepsi", 37, 35);
            shop4.DeliverProducts(102, "Pepsi", 69.9, 75);
            shop4.DeliverProducts(103, "Snickers", 49.9, 45);
            shop4.DeliverProducts(104, "M&M's", 130, 100);
            shop4.DeliverProducts(105, "Dr. Pepper", 65, 70);
            shop4.DeliverProducts(106, "AriZona", 128, 25);
            shop4.DeliverProducts(107, "Mars", 36, 80);
            shop4.DeliverProducts(108, "Pringles", 97, 60);
            shop4.DeliverProducts(109, "M1911", 45500, 1);
            
            var myShops = new StoreChain(new List<Shop>(){shop1, shop2, shop3, shop4});
            
            Package pack1 = new Package();
            pack1.Add(100, 10);
            pack1.Add(100, 5);
            pack1.Add(106, 10);
            pack1.Add(109, 2);
            
            Package pack2 = new Package();
            pack2.Add(100, 10);
            pack2.Add(100, 5);
            pack2.Add(106, 1000);
            pack2.Add(109, 2);
            try
            {
                myShops.FindCheapestSource(pack2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can't buy all products in any shop.", e.Message);
            }
        }
    }
}