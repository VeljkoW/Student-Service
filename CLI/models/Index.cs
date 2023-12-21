using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class Index : ISerializable
    {
        public string Usm { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public void FromCSV(string[] values)
        {
            Usm = values[0];
            Number = int.Parse(values[1]);
            Year= int.Parse(values[2]);
        }
        public string[] ToCSV()
        {
            string[] retString = { Usm, Number.ToString(),Year.ToString()};
            return retString;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Usm);
            sb.Append(Number.ToString());
            sb.Append('-');
            sb.Append(Year.ToString());
            return sb.ToString();
        }
        public Index(string a,int b, int c)
        {
            Usm = a;
            Number = b;
            Year = c;
        }
        public Index()
        {
            Usm=string.Empty;
            Number = 0;
            Year = 0;
        }

        public Index(string input)
        {
            string pattern = @"^(?<Usm>[A-Z]{2})(?<number>\d{1,3})-(?<year>\d{4})$";

            Match match = Regex.Match(input, pattern);
            if(match.Success)
            {
                Usm = match.Groups["Usm"].Value;
                Number = int.Parse(match.Groups["number"].Value);
                Year = int.Parse(match.Groups["year"].Value);
            }
            else
            {
                Usm = "";
                Number = 0;
                Year= 0;
                Console.WriteLine("Invalid index");
            }
        }
    }
}