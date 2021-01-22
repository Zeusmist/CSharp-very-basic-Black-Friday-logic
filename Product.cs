using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class Product
    {
        public int code;
        public string name;
        public int price;
        public double discount = 0;
        public Product(int code, string name, int price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }

        public void addDiscount(double percentageOff)
        {
            discount = price - (price * (percentageOff / 100));
            //Console.WriteLine($"Doodod: {price} - {percentageOff} - {price * (percentageOff / 100)} - {discount} ");
        }

    }
}
