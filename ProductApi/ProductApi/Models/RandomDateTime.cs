using System;

namespace ProductApi.Models
{
    public class RandomDateTime
    {
        Random rnd = new Random();
        DateTime datetoday = DateTime.Now;

        public RandomDateTime()
        {

        }

        public DateTime CreateRandomDate()
        {
            int rndYear = rnd.Next(2000, datetoday.Year);
            //This doesn't account for leap years
            int rndMonth = rnd.Next(1, 12);
            int rndDay;
            if (rndMonth == 4 || rndMonth == 6|| rndMonth == 9|| rndMonth == 11)
            {
                rndDay = rnd.Next(1, 30);
            }
            else if( rndMonth == 2)
            {
                rndDay = rnd.Next(1, 28);
            }
            else
            {
                rndDay = rnd.Next(1, 31);
            }
            int rndHour = rnd.Next(1, 24);
            int rndMin = rnd.Next(1, 60);

            return new DateTime(rndYear, rndMonth, rndDay, rndHour, rndMin, 0);
        }

        public TimeSpan CreateRandomTimeSpan()
        {
            return new TimeSpan(0, 0, 0, new Random().Next(86400));
        }
    }

}
