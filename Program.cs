using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackFriday
{
    class Program
    {
        static DateTime today = DateTime.Today;
        static List<Deal> deals = new List<Deal>();
        static List<Category> categories = new List<Category>();
        static List<int> fridays = new List<int> { 04, 11, 18, 25 };

        static void Main(string[] args)
        {
            /*
             * Black friday program to display discounted products on specific black fridays.
             * If day is not a black friday. No sale can be made.
            */


            /* Initialize categories */
            createCategories();

            /* Initialize deals */
            createDeals();

            Console.WriteLine("\tWELCOME TO ZEUS DECEMBER FRIDAY\n");

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("|\t\tDate - Category - Discount\t\t|");
            Console.WriteLine("---------------------------------------------------------");

            foreach (var deal in deals)
            {
                Console.WriteLine($"|\t{deal.DayOfMonth.ToLongDateString()} - {deal.Category} - {deal.PercentageOff}% Off\t|");
            }
            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine($"\n\nToday is {today.ToString("D")}");
            CheckForNextFriday(today.Day);
            //CheckForNextFriday(11);
        }

        static void createCategories()
        {
            /*
             * create different Category objects using static values, 
             * then add them all to categories property
            */

            var category1 = new Category("Food & Nutrition");
            category1.addProduct("Rice", 1000, 950);
            category1.addProduct("Beans", 1500, 1425);
            var category2 = new Category("Clothings & Acc");
            category2.addProduct("Clothe1", 1000, 900);
            category2.addProduct("Clothe2", 1500, 1350);
            var category3 = new Category("Electronics");
            category3.addProduct("Elect1", 1000, 850);
            category3.addProduct("Elect2", 1500, 1275);
            var category4 = new Category("Home & Office");
            category4.addProduct("Home1", 1000, 800);
            category4.addProduct("Home2", 1500, 1200);

            categories.AddRange(new List<Category> { category1, category2, category3, category4 });
        }
        static void createDeals()
        {
            /*
             * For each category add a Deal to deals property
            */

            int percentage = 5; /* Initial percentageOff */

            for(int i = 0; i < categories.Count; i++)
            {
                deals.Add(new Deal(fridays[i], categories[i].name, percentage * (i + 1)));
            }
        }
        static void CheckForNextFriday(int today)
        {
            /* Check for next black friday */

            var allBlackFridays = new List<int>();
            foreach (var deal in deals)
            {
                allBlackFridays.Add(deal.DayOfMonth.Day);
            }

            /* Find the next friday closest to today  */
            IEnumerable<int> nf = allBlackFridays.OrderBy(x => Math.Abs((int)x - today));
            int nextFriday = nf.ToArray()[1];
            
            bool todayIsFriday = false;
            foreach (int friday in allBlackFridays)
            {
                if (today == friday)
                {
                    nextFriday = today;
                    todayIsFriday = true;
                }
            }
            if (todayIsFriday)
            {
                var todaysDeal = deals[deals.FindIndex((i) => i.DayOfMonth.Day == today)];
                int percent = todaysDeal.PercentageOff;
                string category = todaysDeal.Category;

                Console.WriteLine($"Discounts are live today, Todays Discount is {percent}% on {category}\n");
                displayProducts(today);
            }
            else
            {
                Console.WriteLine("No discounts today, Come back on " + nextFriday);
            }
        }
        static void displayProducts(int day)
        {
            var todaysDeal = deals.FindIndex((i) => i.DayOfMonth.Day == day);

            Console.WriteLine("Produt name\t\tProduct Price\t\tDiscount Price");
            Console.WriteLine("--------------------------------------------------------------");

            foreach(var product in categories[todaysDeal].Products)
            {
                Console.WriteLine($"{product.name}\t\t\t{product.price}\t\t\t{product.discount}");
            }
        }
    }
}
