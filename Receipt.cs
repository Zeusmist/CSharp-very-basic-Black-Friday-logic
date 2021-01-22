using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class Receipt
    {
        /* Receipt is used to display all CartItems and final total */

        public double finalTotal = 0;
        public Receipt(List<CartItem> items)
        {
            /* 
             * Foreach item in items,
             * increment finalTotal by item total.
            */
            foreach (var item in items)
            {
                finalTotal += item.total;
            }
        }

        public void displayReceipt(List<CartItem> items)
        {
            Console.Clear();
            Console.WriteLine("\n\nThank you for shopping with us!\nHere is your receipt.\n");

            Console.WriteLine("Product name\t|\tProduct price\t|\tProduct quantity\t|\tProduct total");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            /* 
             * Foreach  item in items,
             * display item name, item price, item quantity, item total.
            */

            foreach (var item in items)
            {
                double itemPercentageOff = item.categoryPercentageOff;
                Console.WriteLine($"{item.name}\t\t|\t{item.price}\t\t|\t{item.quantity}\t\t\t|\t${item.total} {(itemPercentageOff > 0 ? $"({itemPercentageOff}% OFF)" : null)}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine($"\t\t\t\tYour total to pay is ${finalTotal}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

        }
    }
}
