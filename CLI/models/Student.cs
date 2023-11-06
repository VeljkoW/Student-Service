using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Student : ISerializable
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Adress? StudentAdress { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public int IndexNumber { get; set; }
        public int StudentYear { get; set; }
        public float GradeAvg { get; set; }
        public int[]? FinishedExams { get; set; }
        public List<string>? ToDoExams { get; set; }

        public string[] ToCSV()
        {
            string[] retString = { Name, Surname, DateOfBirth.ToString(), StudentAdress.ToString(), Phone.ToString(), Email, IndexNumber.ToString(), StudentYear.ToString(), GradeAvg.ToString(), FinishedExams.ToString(), ToDoExams.ToString() };
            return retString;
        }
        public void FromCSV(string[] values)
        {
            Name = values[0];
            Surname = values[1];
            DateOfBirth = BirthDate.Parse(values[2]);
            StudentAdress = new Adress(values[3], int.Parse(values[4]), values[5], values[6]);
        }


        public override string ToString()
        {
            StringBuilder x = new StringBuilder();
            x.Append("Name: " + Name + ",");
            x.Append("Surname: " + Surname + ",");
            x.Append("Surname: " + Surname + ",");
            x.Append("BirthDate: " + DateOfBirth + ",");
            x.Append("Adress: " + StudentAdress.ToString() + ",");
            return x.ToString();
        }
    }
}