using System;
using Windows.UI.Xaml.Data;

namespace UWP.Data
{
    //converting values for binding
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dt = (DateTime)value;
            int dow = (int)dt.DayOfWeek;
            string day;
            switch (dow)
            {
                case 1:
                    day = "Monday";
                    break;

                case 2:
                    day = "Tuesday";
                    break;

                default:
                    day = "Unknown";
                    break;
            }

            return day;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string day = (string)value;
            int dow;
            switch (day)
            {
                case "Monday":
                    dow = 1;
                    break;

                case "Tuesday":
                    dow = 2;
                    break;

                default:
                    dow = 0;
                    break;
            }

            DateTime dt = DateTime.Now;
            int dow2 = (int)dt.DayOfWeek;

            return dt.AddDays(dow2 * -1).AddDays(dow);
        }
    }
}