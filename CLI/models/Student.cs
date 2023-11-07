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
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int AdressId { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public Index? StudentIndex { get; set; }
        public int StudentYear { get; set; }
        public float GradeAvg { get; set; }
        public int[]? FinishedExams { get; set; }
        public List<string>? ToDoExams { get; set; }
        public string[] ToCSV()
        {
            string[] retString = { Id.ToString(),Name, Surname, DateOfBirth.ToString(), AdressId.ToString(), Phone.ToString(), Email, StudentIndex.ToString(), StudentYear.ToString(), GradeAvg.ToString(), FinishedExams.ToString(), ToDoExams.ToString() };
            return retString;
        }
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Surname = values[2];
            DateOfBirth = BirthDate.Parse(values[3]);
            AdressId = int.Parse(values[4]);
            Phone = int.Parse(values[5]);
            Email = values[6];
            StudentIndex=new Index(values[7]);
            StudentYear= int.Parse(values[8]);
            GradeAvg= int.Parse(values[9]);
        }
        public override string ToString()
        {
            StringBuilder x = new StringBuilder();
            x.Append("Name: " + Name + ",");
            x.Append("Surname: " + Surname + ",");
            x.Append("Surname: " + Surname + ",");
            x.Append("BirthDate: " + DateOfBirth + ",");
            x.Append("Adress: " + AdressId.ToString() + ",");
            return x.ToString();
        }
    }
}