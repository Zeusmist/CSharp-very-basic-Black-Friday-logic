using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
     class Discount
    {
        public DateTime DayOfMonth;
        public Category Category;
        public int PercentageOff;

        public Discount(DateTime day, Category category, int percentageOff)
        {
            this.DayOfMonth = day;
            this.Category = category;
            this.PercentageOff = percentageOff;
        }
    }
}
