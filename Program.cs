using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BlackFriday
{

    class Program
    {
        //static DateTime today = DateTime.Today;
        static DateTime today = new DateTime(2021, 1, 22);

        static Discount discountForToday;
        static List<Category> categories = new List<Category>();
        static List<DateTime> allFridaysInMonth = new List<DateTime>();
        static bool todayIsFriday = today.DayOfWeek == DayOfWeek.Friday;
        static bool userIsOrdering = true;
        static Cart userCart = new Cart();


        static void Main(string[] args)
        {
            /*
             * Shop program to display products and accept user order.
             * Discounts on all Fridays.
            */

            /* Initialize fridays for current month */
            setFridays(DateTime.Now.Year, DateTime.Now.Month);

            /* Initialize categories */
            createCategories();

            /* create discount if today is friday */
            if (todayIsFriday) createDiscount();

            Console.WriteLine($"\tWELCOME TO {DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture).ToUpper()} FRIDAYs\n");
            Console.WriteLine("** Enter category code, then enter product code to make purchase **");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Category code: Category name: {(todayIsFriday ? "- Percentage off" : null)}");
            Console.WriteLine($"Product code - Product name - Product price {(todayIsFriday ? "- Discount Price" : null)}");
            Console.WriteLine("--------------------------------------------------------------------\n");

            while (userIsOrdering)
            {
                /* display products and accept user order till user stops ordering */
                displayProducts();
            }

            /* Display receipt from Cart*/
            userCart.generateReceipt();
        }

        static void setFridays(int year, int month)
        {
            /* 
             * Check for the fridays in the month by looping through all days in the month.
             * If Day is friday, add day to allFridaysInMonth List.
            */
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                var dayToCheck = new DateTime(year, month, day);
                if (dayToCheck.DayOfWeek == DayOfWeek.Friday)
                {
                    allFridaysInMonth.Add(dayToCheck);
                }
            }

            /* Uncomment below to confirm fridays */

            //foreach(DateTime d in allFridaysInMonth)
            //{
            //    Console.WriteLine($"Date is {d.Date}");
            //}
        }

        static void createCategories()
        {
            /*
             * create different Category objects using static values, 
             * then add them all to categories property
            */

            var category1 = new Category(1, "Food & Nutrition");
            category1.addProduct(100, "Rice", 1000);
            category1.addProduct(101, "Beans", 1500);
            var category2 = new Category(2, "Clothings & Acc");
            category2.addProduct(100, "Clothe1", 1000);
            category2.addProduct(101, "Clothe2", 1500);
            var category3 = new Category(3, "Electronics");
            category3.addProduct(100, "Elect1", 1000);
            category3.addProduct(101, "Elect2", 1500);
            var category4 = new Category(4, "Home & Office");
            category4.addProduct(100, "Home1", 1000);
            category4.addProduct(101, "Home2", 1500);

            categories.AddRange(new List<Category> { category1, category2, category3, category4 });
            //categories.AddRange(new List<Category> { category1, category2 });
        }

        static void createDiscount()
        {
            /*
             * Foreach friday in allFridays,
             * increment percentageOff by 5, starting at 5.
             * 
             * if friday is today,
             * pick a category at random and set discountForToday.
             * 
             * add discount for each product in selected category
            */

            int percentage = 5;
            for (int i = 0; i < allFridaysInMonth.Count; i++)
            {
                int percentageOff = percentage * (i + 1);

                if (allFridaysInMonth[i] == today)
                {
                    Random rnd = new Random();
                    var discountCategory = categories[rnd.Next(0, categories.Count - 1)];
                    discountCategory.percentageOff = percentageOff;
                    discountForToday = new Discount(allFridaysInMonth[i], discountCategory, percentageOff);
                    foreach (var product in discountCategory.Products)
                    {
                        product.addDiscount(percentageOff);
                    }
                }
            }
        }

        static void displayProducts()
        {
            foreach (var category in categories)
            {
                /* 
                 * List all the categories and their products 
                 * Accept user response
                 * Return user response
                */
                int categoryPercentageOff = category.percentageOff;
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"{category.code}: {category.name}: {(categoryPercentageOff > 0 ? $"{categoryPercentageOff}% OFF" : null)}\n");
                foreach (var product in category.Products)
                {
                    double prouctDiscount = product.discount;
                    Console.WriteLine($"{product.code} - {product.name} - ${product.price} {(prouctDiscount > 0 ? $"- {prouctDiscount}" : null)}");
                }
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("\n");
            }

            Console.Write("Category code: ");
            int categoryCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product code: ");
            int productCode = Convert.ToInt32(Console.ReadLine());

            /* Add user order to cart */
            var selectedCategory = categories.Find((category) => category.code == categoryCode);
            var selectedProduct = selectedCategory.Products.Find(product => product.code == productCode);
            userCart.addOrder(categoryCode, selectedCategory.percentageOff, selectedProduct);
            Console.Write("\n\nWould you like to order another item?\nEnter 1 for YES, 2 for NO: ");
            int isStillOrdering = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            if (isStillOrdering == 2)
                userIsOrdering = false;
        }
    }
}
