using CLI.models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class Subject : ISerializable
    {
        public int Id {  get; set; }
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Semester Semester { get; set; }
        public int Year { get; set; }
        public int ProfessorId { get; set; }
        public int ESPBPoints { get; set; }
        public List<Student> StudentsWhoPassed { get; set; }
        public List<Student> StudentsWhoDidntPass { get; set; }

        public Subject(int id,string subjectID, string subjectName, Semester sem, int year, int eSPBPoints)//izbrisao profesor
        {
            Id = id;
            SubjectID = subjectID;
            SubjectName = subjectName;
            Semester = sem;
            Year = year;
            ProfessorId = 0;
            ESPBPoints = eSPBPoints;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass = new List<Student>();
        }
        //Konstruktor bez Id-eva
        public Subject(string subjectID,string subjectName, Semester sem, int year, int eSPBPoints) //bez profesor Id
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Semester = sem;
            Year = year;
            ProfessorId = 0;
            ESPBPoints = eSPBPoints;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass = new List<Student>();
        }
        public Subject()
        {
            Id = 0;
            SubjectID = "";
            SubjectName = "Analiza";
            Semester = Semester.ZIMSKI;
            Year = 2023;
            ProfessorId =0;
            ESPBPoints = 8;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass = new List<Student>();
        }

        public void FromCSV(string[] val)
        {
            Id = int.Parse(val[0]);
            SubjectID = val[1];
            SubjectName = val[2];
            if (val[3]=="ZIMSKI")
            {
                Semester = Semester.ZIMSKI;

            }
            else
            {
                Semester = Semester.LETNJI;
            }
            Year = int.Parse(val[4]);
            ProfessorId = int.Parse(val[5]);
            ESPBPoints= int.Parse(val[6]);
        }
        public string[] ToCSV()
        {
            string[] retString =
            {
                Id.ToString(),SubjectID, SubjectName, Semester.ToString(),Year.ToString(),ProfessorId.ToString(),ESPBPoints.ToString()
            };
            return retString;
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}|SubjectID:{SubjectID,5}| Name: {SubjectName,20} | Semester: {Semester,6} | Year: {Year,4} | Professor ID:{ProfessorId,3}| ESPB Points: {ESPBPoints,1}";
            return s;
        }
    }
}
