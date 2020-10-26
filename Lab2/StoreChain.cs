using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Lab2
{
    public class StoreChain
    {
        public List<Shop> Shops { get; private set; }

        public StoreChain()
        {
            Shops = new List<Shop>();
        }
        
        public StoreChain(List<Shop> shops)
        {
            Shops = shops;
        }

        public void Add(Shop newShop)
        {
            Shops.Add(newShop);
        }
        
        public int FindCheapestSource(int productCode)
        {
            var lowestPrice = Double.MaxValue;
            var returnShopCode = 0;
            foreach (var shop in this.Shops)
            {
                var curPrice = shop.GetProductPrice(productCode);
                if (!(curPrice < lowestPrice)) continue;
                returnShopCode = shop.Code;
                lowestPrice = curPrice;
            }
            return returnShopCode;
        }
        
        // Возвращает словарь вида: код магазина - код товара
        public Dictionary<int, int> FindCheapestSource(string productName)
        {
            var productCodes = new List<int>();
            foreach (var shop in this.Shops)
                productCodes.AddRange(shop.GetProductCodes(productName));
            var noDupes = productCodes.Distinct().ToList();
            if(noDupes.Count == 0)
                throw new UserException("No Product with such Name: " + productName);
            
            var ans = new Dictionary<int, int>();
            foreach (var pCode in noDupes)
                ans.Add(this.FindCheapestSource(pCode), pCode);
            return ans;
        }
        
        public int FindCheapestSource(Package productPack)
        {
            var lowestPrice = Double.MaxValue;
            var returnShopCode = -1;
            foreach (var shop in this.Shops)
            {
                var currentPrice = 0.0;
                foreach (var pair in productPack.Pack)
                {
                    if (!shop.HasEnoughProducts(pair.Key, pair.Value))
                    {
                        currentPrice = -1.0;
                        break;
                    }
                    currentPrice += shop.GetProductPrice(pair.Key) * pair.Value;
                }
               
                if(currentPrice < 0)
                    continue;
                
                else if(currentPrice < lowestPrice)
                {
                    lowestPrice = currentPrice;
                    returnShopCode = shop.Code;
                }
            }
            
            if (returnShopCode == -1)
                throw new UserException("Can't buy all products in any shop.");
            return returnShopCode;
        }
        
    }
}