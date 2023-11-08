using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace CLI
{
    public class Student : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int AdressId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Index StudentIndex { get; set; }
        public int StudentYear { get; set; }
        public float GradeAvg { get; set; }
        public List<int> FinishedExams { get; set; }
        public List<int> ToDoExams { get; set; }
        public Student()
        {
            Id = 0;
            Name = "Nemanja";
            Surname = "Vojnic";
            DateOfBirth = new DateOnly();
            AdressId = 0;
            Phone = "34325435";
            Email = "NemanjaV@gmail.com";
            StudentIndex = new Index("RA",214,2021);
            StudentYear = 3;
            GradeAvg = 0;
            ToDoExams = new List<int>();
            FinishedExams = new List<int>();

        }
        public string[] ToCSV()
        {
            string[] retString = { Id.ToString(),Name, Surname, DateOfBirth.ToString(), AdressId.ToString(), Phone.ToString(), Email, StudentIndex.ToString(), StudentYear.ToString(), GradeAvg.ToString()};
            return retString;
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Surname = values[2];
            DateOfBirth = DateOnly.Parse(values[3]);
            AdressId = int.Parse(values[4]);
            Phone = values[5];
            Email = values[6];
            StudentIndex=new Index(values[7]);
            StudentYear= int.Parse(values[8]);
            GradeAvg= int.Parse(values[9]);
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name,20} | Surname: {Surname,25} | Date of bitrh: {DateOfBirth,15} |Adress ID:{AdressId,3}| Phone: {Phone,13} | E-mail: {Email,64} | Index: {StudentIndex,10} | Student Year: {StudentYear,2} | Grade Average: {GradeAvg,4}";
            return s;
        }
        public Student(int id,string name, string surname, DateOnly dateOfBirth, int adressId, string phone, string email, Index studentIndex, int studentYear, float gradeAvg)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            AdressId = adressId;
            Phone = phone;
            Email = email;
            StudentIndex = studentIndex;
            StudentYear = studentYear;
            GradeAvg = gradeAvg;
            ToDoExams = new List<int>();
            FinishedExams = new List<int>();
        }
    }
}