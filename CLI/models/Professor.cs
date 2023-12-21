using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Professor : ISerializable
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth {  get; set; }
        public Adress ProfessorAdress {  get; set; }
        public string PhoneNumber {  get; set; }
        public string EmailAdress {  get; set; }
        public string IDCardNumber {  get; set; }
        public string Title { get; set; }
        public int YearsOfService { get; set; }
        public List<Subject> Subjects { get; set; }
        public Professor(int id,string name,string surname,DateOnly dateofbirth,Adress adresa,string phone,string email,string idcard,string title,int years)
        {
            Id = id;
            Name = name;
            Surname=surname;
            DateOfBirth = dateofbirth;
            ProfessorAdress = adresa;
            PhoneNumber = phone;
            EmailAdress = email;
            IDCardNumber = idcard;
            Title = title;
            YearsOfService = years;
            Subjects = new List<Subject>();
        }
        public Professor() {
            Id=0;
            Name = "Petar";
            Surname = "Peric";
            DateOfBirth = new DateOnly();
            ProfessorAdress = new Adress();
            PhoneNumber = "43214523";
            EmailAdress = "profesor@gmail.com";
            IDCardNumber = "235423";
            Title = "Profesor";
            YearsOfService = 13;
            Subjects = new List<Subject>();
        }

        public string[] ToCSV()
        {
            string[] retString = {Id.ToString(),Name,Surname,DateOfBirth.ToString(),ProfessorAdress.ToString(),PhoneNumber,EmailAdress,IDCardNumber,Title,YearsOfService.ToString()};
            return retString;


        }
        public void FromCSV(string[] vals)
        {
            Id = int.Parse(vals[0]);
            Name = vals[1];
            Surname = vals[2];
            DateOfBirth = DateOnly.Parse(vals[3]);
            ProfessorAdress = new Adress(vals[4], int.Parse(vals[5]), vals[6], vals[7]);
            PhoneNumber = vals[8];
            EmailAdress = vals[9];
            IDCardNumber = vals[10];
            Title = vals[11];
            YearsOfService = int.Parse(vals[12]);

        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,15} | Surname: {Surname,20} | Date of bitrh: {DateOfBirth,15} | Adress ID:{ProfessorAdress}| Phone: {PhoneNumber,13} | E-mail: {EmailAdress,30} | ID card number: {IDCardNumber,10} | Title: {Title,10} | Years of service: {YearsOfService,2}";
            return s;
        }
    }
}
