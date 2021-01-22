using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class CartItem
    {
        /* CartItem is used to display Product, quantity & total */
        public int categoryCode;
        public double categoryPercentageOff;
        public int productCode;
        public string name;
        public double price;
        public int quantity = 1;
        public double total;

        public CartItem(int categoryCode, double categoryPercentageOff, int productCode, string name, double price)
        {
            this.categoryCode = categoryCode;
            this.categoryPercentageOff = categoryPercentageOff;
            this.productCode = productCode;
            this.name = name;
            this.price = price;
            total = price;

            if (categoryPercentageOff > 0)
            {
                double discountedPrice = price - (price * (categoryPercentageOff / 100));
                this.price = discountedPrice;
                total = discountedPrice;
            }

        }
    }
}
