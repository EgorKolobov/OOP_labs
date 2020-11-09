using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public class Package
    {
        // Словарь: код продукта - колличество
        public Dictionary<int, int> Pack { get;  private set; }
        
        public Package()
        {
            Pack = new Dictionary<int, int>();
        }

        public void Info()
        {
            Console.WriteLine("To buy list:");
            foreach (var pair in Pack)
                Console.WriteLine("    Product Code: " + pair.Key + "   Product Quantity" + pair.Value);
            Console.WriteLine();
        }

        public void Add(int productCode, int productQuantity)
        {
            if (Pack.ContainsKey(productCode))
                Pack[productCode] += productQuantity;
            else
                Pack.Add(productCode, productQuantity);
        }
    }
}