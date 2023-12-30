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
        public int IdProfesora {  get; set; }
        public string ImeProfesora { get; set; }
        public string PrezimeProfesora { get; set; }
        public List<Professor> Professors { get; set;}

        public Katedra() 
        {
            Id = 1;
            Name = "Katedra1";
            Head = new Professor();
            IdProfesora = Head.Id;
            ImeProfesora = Head.Name;
            PrezimeProfesora = Head.Surname;
            Professors= new List<Professor>();
        }
        public Katedra(int id, string name, Professor head)
        {
            Id = id;
            Name = name;
            Head = head;
            IdProfesora = head.Id;
            ImeProfesora = head.Name;
            PrezimeProfesora = head.Surname;
            Professors = new List<Professor>();
        }
        public string[] ToCSV()
        {
            List<string> retString = new List<string>
             {
              Id.ToString(),
              Name,
              IdProfesora.ToString(),
              ImeProfesora,
              PrezimeProfesora

              };

            return retString.ToArray();
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            IdProfesora = int.Parse(values[2]);
            ImeProfesora = values[3];
            PrezimeProfesora= values[4];
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,20} | Head professor ID: {Head}";
            return s;
        }

    }
}
