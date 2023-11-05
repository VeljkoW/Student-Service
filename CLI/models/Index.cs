using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class Index : ISerializable
    {
        public string? Id { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }

        public void FromCSV(string[] values)
        {
            Id= values[0];
            Number = int.Parse(values[1]);
            Year= int.Parse(values[2]);
        }

        public string[] ToCSV()
        {
            string[] retString = { Id,Number.ToString(),Year.ToString()};
            return retString;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id);
            sb.Append(',');
            sb.Append(Number.ToString());
            sb.Append(',');
            sb.Append(Year.ToString());
            return sb.ToString();
        }
        public Index()
        {
            Id = "RA";
            Number = 24;
            Year = 2049;
        }
        public Index(string a,int b, int c)
        {
            Id = a;
            Number = b;
            Year = c;
        }
    }
}