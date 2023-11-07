using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Adress: ISerializable
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int StreetNumber{ get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string[] ToCSV() {
            string[] sb = {
                Street,
                StreetNumber.ToString(),City, State
            };
            return sb;
        }
        public void FromCSV(string[] values) {
            Street= values[0];
            StreetNumber= int.Parse(values[1]);
            City= values[2];
            State= values[3];
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Street: {Street,21} | StreetNum: {StreetNumber,4} | City: {City,15} |State:{State,17}|";
            return s;
        }
        public Adress(string b,int c,string d,string e)
        {
            Street = b;
            StreetNumber= c;
            City= d;
            State = e;
        }
        public Adress()
        {
            Street = "Bulevar Oslobodjenja";
            StreetNumber = 12;
            City = "Novi Sad";
            State = "Serbia";
        }
    }
}