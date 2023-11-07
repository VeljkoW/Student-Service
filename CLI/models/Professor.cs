using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Professor : ISerializable
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth {  get; set; }
        public Adress? ProfessorAdress {  get; set; }
        public string? PhoneNumber {  get; set; }
        public string? EmailAdress {  get; set; }
        public string? IDNumber {  get; set; }
        public string? Title { get; set; }
        public int? YearsOfService { get; set; }
        public List<Subject> Subjects { get; set; }

        public Professor(string name,string surname,DateOnly dateofbirth,Adress adresa,string phone,string email,string id,string title,int years,List<Subject> subjects)
        {
            Name = name;
            Surname=surname;
            DateOfBirth = dateofbirth;
            this.ProfessorAdress = adresa;
            PhoneNumber = phone;
            EmailAdress = email;
            IDNumber = id;
            Title = title;
            YearsOfService = years;
            Subjects = subjects;

        }
        public Professor() {
            Name = "Petar";
            Surname = "Peric";
            DateOfBirth = BirthDate.Parse("29.09.1945.");
            PhoneNumber = "064213214";
            EmailAdress = "petarperic@gmail.com";
            IDNumber = "124321432";
            Title = "Profesor";
            YearsOfService = 20;
            Subjects = new List<Subject>();
        }

        public string[] ToCSV()
        {
            string[] retString = {Name,Surname,DateOfBirth.ToString(),ProfessorAdress.ToString(),PhoneNumber,EmailAdress,IDNumber,Title,YearsOfService.ToString(),Subjects.ToString()};
            return retString;

        }
        public void FromCSV(string[] vals)
        {
            Name = vals[0];
            Surname = vals[1];
            DateOfBirth = BirthDate.Parse(vals[2]);
            ProfessorAdress = new Adress(vals[3], int.Parse(vals[4]), vals[5], vals[6]);
            PhoneNumber = vals[7];
            EmailAdress = vals[8];
            IDNumber = vals[9];
            Title = vals[10];
            YearsOfService = int.Parse(vals[11]);
            //Subjects = new List<Subject>()

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name:" + Name + ", ");
            sb.Append("Surname: " +  Surname + ", ");
            sb.Append("Subjects: ");
            sb.AppendJoin(", ",Subjects.Select(Subject => Subject.SubjectName));

            return sb.ToString(); 
        }





    }
}
