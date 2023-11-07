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
        public int Id { get; set; }
        public string? Usm { get; set; }
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
        public Index()
        {
            Usm = "RA";
            Number = 24;
            Year = 2049;
        }
        public Index(string a,int b, int c)
        {
            Usm = a;
            Number = b;
            Year = c;
        }
        public Index(string input)
        {
            // Define a regex pattern to match the desired format
            string pattern = @"^(?<id>[A-Z]{2})(?<number>\d{1,3})-(?<year>\d{4})$";

            // Match the input string against the pattern
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                Usm = match.Groups["id"].Value;
                Number = int.Parse(match.Groups["number"].Value);
                Year = int.Parse(match.Groups["year"].Value);
            }
            else
            {
                throw new ArgumentException("Invalid input format. Format should be like 'RA206-2021'.");
            }
        }
    }
}