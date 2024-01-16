using CLI.models.Enums;
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
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Index StudentIndex { get; set; }
        public int StudentYear { get; set; }
        public Status Status { get; set; }
        public float GradeAvg { get; set; }
        public List<ExamGrade> FinishedExams { get; set; }
        public List<Subject> ToDoExams { get; set; }
        public Student()
        {
            Id = 0;
            Name = "Nemanja";
            Surname = "Vojnic";
            DateOfBirth = new DateOnly();
            Adress=new Adress();
            Phone = "34325435";
            Email = "NemanjaV@gmail.com";
            StudentIndex = new Index("RA",214,2021);
            StudentYear = 3;
            GradeAvg = 10;
            Status = Status.BUDZET;
            ToDoExams = new List<Subject>();
            FinishedExams = new List<ExamGrade>();
        }
        public string[] ToCSV()
        {
            string[] retString = { Id.ToString(),Name, Surname, DateOfBirth.ToString(), Adress.ToString(), Phone.ToString(), Email, StudentIndex.ToString(), StudentYear.ToString(), GradeAvg.ToString(),Status.ToString()};
            return retString;
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Surname = values[2];
            DateOfBirth = DateOnly.Parse(values[3]);
            Adress = new Adress(values[4], int.Parse(values[5]), values[6], values[7]);
            Phone = values[8];
            Email = values[9];
            StudentIndex=new Index(values[10]);
            StudentYear= int.Parse(values[11]);
            GradeAvg= int.Parse(values[12]);
            if (values[13] == "SAMOFINANSIRANJE")
            {
                Status = Status.SAMOFINANSIRANJE;
            }
            else
            {
                Status = Status.BUDZET;
            }
            }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Name: {Name} | Surname: {Surname} | Date of bitrh: {DateOfBirth} |Adress ID:{Adress}| Phone: {Phone} | E-mail: {Email} | Index: {StudentIndex} | Student Year: {StudentYear} | Grade Average: {GradeAvg}| Status: {Status}";
            return s;
        }
        public Student(int id,string name, string surname, DateOnly dateOfBirth, Adress adress, string phone, string email, Index studentIndex, int studentYear,Status status)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Adress = adress;
            Phone = phone;
            Email = email;
            StudentIndex = studentIndex;
            StudentYear = studentYear;
            Status = status;
            ToDoExams = new List<Subject>();
            FinishedExams = new List<ExamGrade>();
        }
        //Konstruktor bez id-a
        public Student(string name, string surname, DateOnly dateOfBirth, Adress adress, string phone, string email, Index studentIndex, int studentYear, Status status)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Adress = adress;
            Phone = phone;
            Email = email;
            StudentIndex = studentIndex;
            StudentYear = studentYear;
            Status = status;
            ToDoExams = new List<Subject>();
            FinishedExams = new List<ExamGrade>();
        }

        public static int Compare(Student x, Student y)
        {
            int xNumber = x.StudentIndex.Number;
            int yNumber = y.StudentIndex.Number;

            return yNumber.CompareTo(xNumber);
        }
    }
}