using System;
using System.Collections.Generic;
using System.Text;

namespace BlackFriday
{
     class Deal
    {
        public DateTime DayOfMonth { get; set; }
        public string Category { get; set; }
        public int PercentageOff { get; set; }

        public Deal(int day, string category, int percentageOff)
        {
            this.DayOfMonth = new DateTime(2020, 12, day);
            this.Category = category;
            this.PercentageOff = percentageOff;
        }
    }
}
