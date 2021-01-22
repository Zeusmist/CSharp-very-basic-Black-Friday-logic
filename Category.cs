using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class Category
    {
        /* A category has a name and a list of products */
        public int code;
        public string name;
        public List<Product> Products = new List<Product>();
        public int percentageOff = 0;

        public Category(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public void addProduct(int code, string name, int price)
        {
            Products.Add(new Product(code , name, price));
        }


    }
}
