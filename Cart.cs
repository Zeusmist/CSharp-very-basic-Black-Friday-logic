using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
    class Cart
    {
        /* Cart is used to generate CartItems from user orders */

        static List<CartItem> items = new List<CartItem>();
        static Receipt receipt;

        public void addOrder(int categoryCode, int categoryPercentageOff, Product product)
        {
            double productDiscount = product.discount;
            Console.Clear();
            Console.WriteLine("** You added the following item to your cart **");
            Console.WriteLine($"** {product.code} - {product.name} - ${product.price} {(productDiscount > 0 ? $"- Discount price(${productDiscount})":null)} **");

            /*
             * If product is already in cart, increment the quantity.
             * Else, add the product to cart.
            */

            int indexOfItemInCart = items.FindIndex(item => item.categoryCode == categoryCode && item.productCode == product.code);

            if (indexOfItemInCart != -1)
            {
                var itemInCart = items[indexOfItemInCart];
                itemInCart.quantity += 1;
                itemInCart.total += itemInCart.price;
                Console.WriteLine($"You now have {itemInCart.quantity} of this product");
            }
            else items.Add(new CartItem(categoryCode, categoryPercentageOff, product.code, product.name, product.price));
        }

        public void generateReceipt()
        {
            receipt = new Receipt(items);
            receipt.displayReceipt(items);
        }
    }
}
