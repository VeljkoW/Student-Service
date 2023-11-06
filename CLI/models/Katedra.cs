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
        public Professor Head { get; set; }
        public List<Professor> Professors { get; set;}

        public Katedra() 
        {
            Id = "1";
            Name = "Katedra1";
            Head = new Professor();
            Professors= new List<Professor>();
        }

        public Katedra(string id, string name, Professor head, List<Professor> professors)
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

            foreach (Professor p in Professors)
            {
                retString.Add(p.ToString());
            }

            return retString.ToArray();
        }

        public void FromCSV(string[] values)
        {
            throw new NotImplementedException();    //treba izmeniti
        }
    }
}
