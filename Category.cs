using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class Category
    {
        /* A category has a name and a list of products */
        public string name { get; set; }
        public List<Product> Products = new List<Product>();

        public Category(string name)
        {
            this.name = name;
        }

        public void addProduct(string name, int price, int discount)
        {
            Products.Add(new Product(name, price, discount));
        }
    }

    class Product
    {
        public string name;
        public int price;
        public int discount;
        public Product(string name, int price, int discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }
    }
}
