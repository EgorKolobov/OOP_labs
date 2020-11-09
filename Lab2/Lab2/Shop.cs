using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public class Shop
    {
        private readonly Dictionary<int, Product> _store;

        public int Code { get; private set; }
        private string Name { get; set; }
        private string Address { get; set; }

        public Shop(int code, string name = "Default Shop Name", string address = "Default Shop Address")
        {
            Code = code;
            Name = name;
            Address = address;
            _store = new Dictionary<int, Product>();
        }

        public void DeliverProducts(int productCode, string productName, double productPrice, int productQuantity)
        {
            Product addProduct = new Product(productName,productPrice, productQuantity);
            if (_store.Keys.Contains(productCode))
                throw new UserException("There is already a Product with Code " + productCode + " in the Shop №" + this.Code);
            else
                _store.Add(productCode, addProduct);
        }

        public bool HasEnoughProducts(int productCode, int productQuantity)
        { 
            return(_store.Keys.Contains(productCode) && _store[productCode].Quantity>=productQuantity);
        }
        
        public string GetProductName(int productCode)
        {
            if (_store.Keys.Contains(productCode))
                return _store[productCode].Name;
            throw new UserException("No Product in the Shop №" + this.Code + " with Code " + productCode + '!');
        }
        
        public double GetProductPrice(int productCode)
        {
            if(_store.Keys.Contains(productCode))
                return _store[productCode].Price;
            throw new UserException("No Product in the Shop №" + this.Code + " with Code " + productCode + '!');
        }

        public int GetProductQuantity(int productCode)
        {
            if (_store.Keys.Contains(productCode))
                return _store[productCode].Quantity;
            throw new UserException("No Product in the Shop №" + this.Code + " with Code " + productCode + '!');
        }

        public List<int> GetProductCodes(string productName)
        {
            List<int> result = new List<int>();
            foreach (var pair in _store)
            {
                if(pair.Value.Name == productName)
                    result.Add(pair.Key);
            }
            return result;
        }

        // Возвращает лист пар: код продукта - колличество
        public Dictionary<int, int> CanBuy(double money)
        {
            var ans = new Dictionary<int, int>();
            foreach (var pair in _store)
                if (pair.Value.Price <= money)
                    ans.Add(pair.Key, (int) (money / pair.Value.Price));
            return ans;
        }

        public double SellPackage(Package productPack)
        {
            double totalPrice = 0.0;
            foreach (var pair in productPack.Pack)
            {
                if(!_store.ContainsKey(pair.Key))
                    throw new UserException("No Product in the Shop №" + this.Code + " with Code " + pair.Key + '!');
                var product = _store[pair.Key];
                if (product.Quantity < pair.Value)
                    throw new UserException("Shop №" + this.Code + " can't sell enough Product №" + pair.Key + " !");
                totalPrice += product.Price * pair.Value;
                _store[pair.Key] = new Product(product.Name, product.Price, product.Quantity-pair.Value);
            }
            return totalPrice;
        }
    }
}