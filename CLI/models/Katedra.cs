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
        public Professor Head { get; set; }
        public List<Professor> Professors { get; set;}

        public Katedra() 
        {
            Id = 1;
            Name = "Katedra1";
            Head = new Professor();
            Professors= new List<Professor>();
        }

        public Katedra(int id, string name, Professor head)
        {
            Id = id;
            Name = name;
            Head = head;
            Professors = new List<Professor>();
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
            Head = new Professor();
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,20} | Head professor ID: {Head}";
            return s;
        }

    }
}
