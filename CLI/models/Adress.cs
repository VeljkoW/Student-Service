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
            StringBuilder sb = new StringBuilder();
            sb.Append("Street: "+Street+", ");
            sb.Append("Street number:"+StreetNumber.ToString()+", ");
            sb.Append("City: "+City+", ");
            sb.Append("State: "+State+", ");
            return sb.ToString();
        }
        public Adress(string a,int b,string c,string d)
        {
            Street = a;
            StreetNumber= b;
            City= c;
            State = d;
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