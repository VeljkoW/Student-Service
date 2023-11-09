using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Katedra : ISerializable
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Head { get; set; }
        public List<int> Professors { get; set;}

        public Katedra() 
        {
            Id = 1;
            Name = "Katedra1";
            Head = 1;
            Professors= new List<int>();
        }

        public Katedra(int id, string name, int head)
        {
            Id = id;
            Name = name;
            Head = head;
            Professors = new List<int>();
        }

        public string[] ToCSV()
        {
            List<string> retString = new List<string>
             {
              Id.ToString(),
              Name,
              Head.ToString()

              };

            return retString.ToArray();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Head = int.Parse(values[2]);
        }

        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,20} | Head professor ID: {Head,3}";
            return s;
        }

    }
}
