using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class BirthDate
    {
            private static readonly string shape = "dd.MM.yyyy.";

            public static string ToString(DateOnly date)
            {
                return date.ToString(shape);
            }
            public static DateOnly Parse(string date)
            {
                return DateOnly.FromDateTime(DateTime.Parse(date));
            }
        
    }
}
