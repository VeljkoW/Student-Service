using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Katedra : ISerializable
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public int Head { get; set; }
        public List<int> Professors { get; set;}

        public Katedra() 
        {
            Id = "1";
            Name = "Katedra1";
            Head = 1;
            Professors= new List<int>();
        }

        public Katedra(string id, string name, int head, List<int> professors)
        {
            Id = id;
            Name = name;
            Head = head;
            Professors = professors;
        }

        public string[] ToCSV()
        {
            List<string> retString = new List<string>
             {
              Id,
              Name,
              Head.ToString()

              };

            return retString.ToArray();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();    //treba izmeniti
        }
    }
}
