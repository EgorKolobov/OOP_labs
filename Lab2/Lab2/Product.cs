using System;
namespace Lab2
{
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        
        public Product(string name = "defaultProductName", double price = 1, int quantity = 0)
        {
            if (price == 0.0)
                throw new UserException("Product's Price can't be 0!");
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product(Product originalProduct)
        {
            this.Name = originalProduct.Name;
            this.Price = originalProduct.Price;
            this.Quantity = originalProduct.Quantity;
        }
    }
}