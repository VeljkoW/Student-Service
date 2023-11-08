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
        public int ProfessorAdressId {  get; set; }
        public string PhoneNumber {  get; set; }
        public string EmailAdress {  get; set; }
        public string IDCardNumber {  get; set; }
        public string Title { get; set; }
        public int YearsOfService { get; set; }
        public List<int> Subjects { get; set; }

        public Professor(int id,string name,string surname,DateOnly dateofbirth,int adresa,string phone,string email,string idcard,string title,int years)
        {
            Id = id;
            Name = name;
            Surname=surname;
            DateOfBirth = dateofbirth;
            ProfessorAdressId = adresa;
            PhoneNumber = phone;
            EmailAdress = email;
            IDCardNumber = idcard;
            Title = title;
            YearsOfService = years;
            Subjects = new List<int>();

        }
        public Professor() {
            Id=0;
            Name = "Petar";
            Surname = "Peric";
            DateOfBirth = new DateOnly();
            ProfessorAdressId =0;
            PhoneNumber = "43214523";
            EmailAdress = "profesor@gmail.com";
            IDCardNumber = "235423";
            Title = "Profesor";
            YearsOfService = 13;
            Subjects = new List<int>();
        }

        public string[] ToCSV()
        {
            string[] retString = {Name,Surname,DateOfBirth.ToString(),ProfessorAdressId.ToString(),PhoneNumber,EmailAdress,IDCardNumber,Title,YearsOfService.ToString()};
            return retString;


        }
        public void FromCSV(string[] vals)
        {
            Id = int.Parse(vals[0]);
            Name = vals[1];
            Surname = vals[2];
            DateOfBirth = DateOnly.Parse(vals[3]);
            ProfessorAdressId = int.Parse(vals[4]);
            PhoneNumber = vals[5];
            EmailAdress = vals[6];
            IDCardNumber = vals[7];
            Title = vals[8];
            YearsOfService = int.Parse(vals[9]);

        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,20} | Surname: {Surname,25} | Date of bitrh: {DateOfBirth,15} | Adress ID:{ProfessorAdressId,3}| Phone: {PhoneNumber,13} | E-mail: {EmailAdress,64} | ID card number: {IDCardNumber,10} | Title: {Title,10} | Years of service: {YearsOfService,2}";
            return s;
        }





    }
}
