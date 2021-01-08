using System;

namespace BlackFriday
{
    class Program
    {
        static void CheckForNextFriday(int today)
        {
            int[] fridays = { 04, 11, 18, 25 };
            int nextFriday = 0;
            bool todayIsFriday = false;

            foreach(int i in fridays)
            {
                if (today == i)
                {
                    nextFriday = today;
                    todayIsFriday = true;
                }
            }

            if(nextFriday == 0)
            {
                //nextFriday = fridays.MinBy(x => Math.Abs((long)x - targetNumber));
                nextFriday = today < 04 ? 04 : today > 04 && today < 11 ? 11 : today > 11 && today < 18 ? 18 : 25;
            }
            if (todayIsFriday)
            {
                Console.WriteLine("Discounts are live today, Todays Discount is {0} on {1} items", today == 04 ? "5%" : today == 11 ? "10%" : today == 18 ? "15%" : "20%", today == 04 ? "Food & Nutrition" : today == 11 ? "Clothings & Accessories" : today == 18 ? "Electronics" : "Home & Office");
                Console.WriteLine("\n");
                displayProducts(today);

            } else
            {
                Console.WriteLine("No discounts today, Come back on " + nextFriday);
            }

        }

        static void displayProducts(int friday)
        {
            Categories categoriesObj = new Categories();
            categoriesObj.setCategories();
            Console.WriteLine("Produt name\t\tProduct Price\t\tDiscount Price");
            if(friday == 04)
            {
                foreach (Product i in categoriesObj.Food)
                {
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}", i.name, i.price, i.discount);
                }
            }
            if (friday == 11)
            {
                foreach (Product i in categoriesObj.Clothes)
                {
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}", i.name, i.price, i.discount);
                }
            }
            if (friday == 18)
            {
                foreach (Product i in categoriesObj.Electronics)
                {
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}", i.name, i.price, i.discount);
                }
            }
            if (friday == 25)
            {
                foreach (Product i in categoriesObj.Home)
                {
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t{2}", i.name, i.price, i.discount);
                }
            }
        }
        static void Main(string[] args)
        {

            DateTime today = DateTime.Today;
            Friday objFriday = new Friday();
            Console.WriteLine("\t\t\t\tWELCOME TO ZEUS DECEMBER FRIDAY\t\t\t\t\n\n");
            Console.WriteLine("\t\tList of Fridays, Categories and Discounts\t\t");
            Console.WriteLine("{0} - Food & Nutrition - 5% 0ff", objFriday.getFriday(2020, 12, 4));
            Console.WriteLine("{0} - Clothings & Accessories - 10% 0ff", objFriday.getFriday(2020, 12, 11));
            Console.WriteLine("{0} - Electronics - 15% 0ff", objFriday.getFriday(2020, 12, 18));
            Console.WriteLine("{0} - Home & Office - 20% 0ff\n\n", objFriday.getFriday(2020, 12, 25));

            Console.WriteLine("Today is " + today.ToString("D") + "\n");
            //CheckForNextFriday(today.Day);
            CheckForNextFriday(11);


        }
    }

    public class Product
    {
        public string name;
        public int price;
        public int discount;
        public void SetInfo(string name, int price, int discount)
        {
            this.name = name;
            this.price = price;
            this.discount = discount;
        }
    }

    class Categories
    {
        public Product[] Food = new Product[2];
        public Product[] Clothes = new Product[2];
        public Product[] Electronics = new Product[2];
        public Product[] Home = new Product[2];
        public void setCategories()
        {
            Food[0] = new Product();
            Food[1] = new Product();
            Food[0].SetInfo("Rice", 1000, 950);
            Food[1].SetInfo("Beans", 1500, 1425);
            Clothes[0] = new Product();
            Clothes[1] = new Product();
            Clothes[0].SetInfo("Clothe1", 1000, 900);
            Clothes[1].SetInfo("Clothe2", 1500, 1350);
            Electronics[0] = new Product();
            Electronics[1] = new Product();
            Electronics[0].SetInfo("Elect1", 1000, 850);
            Electronics[1].SetInfo("Elect2", 1500, 1275);
            Home[0] = new Product();
            Home[1] = new Product();
            Home[0].SetInfo("Home1", 1000, 800);
            Home[1].SetInfo("Home2", 1500, 1200);
        }
    }

    class Friday
    {
        public string getFriday(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            return date.ToLongDateString();
        }
    }
    
}
