using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CLI
{
    public class Adress: ISerializable
    {
        public string Street { get; set; }
        public int StreetNumber{ get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string[] ToCSV() {
            string[] sb = {
                Street,
                StreetNumber.ToString(),
                City,
                State
            };
            return sb;
        }
        public void FromCSV(string[] values) {
            Street= values[1];
            StreetNumber= int.Parse(values[2]);
            City= values[3];
            State= values[4];
        }
        public override string ToString()
        {

            return ($"{Street}|{StreetNumber}|{City}|{State}");
        }
        public Adress(string b,int c,string d,string e)
        {
            Street = b;
            StreetNumber= c;
            City= d;
            State = e;
        }
        public Adress(string input)
        {
            string pattern = @"^([^|]+)\|([^|]+)\|([^|]+)\|([^|]+)$";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                Street = match.Groups[1].Value;
                StreetNumber = int.Parse(match.Groups[2].Value);
                City = match.Groups[3].Value;
                State = match.Groups[4].Value;
            }
            else
            {
                throw new ArgumentException("Invalid input format");
            }
        }
        public Adress()
        {
            Street = "";
            City = "";
            State = "";
        }
    }
}