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
        public int ProfessorAdressId {  get; set; }
        public string? PhoneNumber {  get; set; }
        public string? EmailAdress {  get; set; }
        public string? IDNumber {  get; set; }
        public string? Title { get; set; }
        public int? YearsOfService { get; set; }
        public List<int> Subjects { get; set; }

        public Professor(string name,string surname,DateOnly dateofbirth,int adresa,string phone,string email,string id,string title,int years,List<int> subjects)
        {
            Name = name;
            Surname=surname;
            DateOfBirth = dateofbirth;
            ProfessorAdressId = adresa;
            PhoneNumber = phone;
            EmailAdress = email;
            IDNumber = id;
            Title = title;
            YearsOfService = years;
            Subjects = subjects;

        }
        public Professor() {
        }

        public string[] ToCSV()
        {
            string[] retString = {Name,Surname,DateOfBirth.ToString(),ProfessorAdressId.ToString(),PhoneNumber,EmailAdress,IDNumber,Title,YearsOfService.ToString(),Subjects.ToString()};
            return retString;


        }
        public void FromCSV(string[] vals)
        {
            Name = vals[0];
            Surname = vals[1];
            DateOfBirth = DateOnly.Parse(vals[2]);
            ProfessorAdressId = int.Parse(vals[3]);
            PhoneNumber = vals[4];
            EmailAdress = vals[5];
            IDNumber = vals[6];
            Title = vals[7];
            YearsOfService = int.Parse(vals[8]);
            //Subjects = new List<Subject>()

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name:" + Name + ", ");
            sb.Append("Surname: " +  Surname + ", ");
            sb.Append("Subjects: ");
            return sb.ToString(); 
        }





    }
}
