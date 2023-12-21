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
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Semester Semester { get; set; }
        public int Year { get; set; }
        public int ProfessorId { get; set; }
        public int ESPBPoints { get; set; }
        public List<Student> StudentsWhoPassed { get; set; }
        public List<Student> StudentsWhoDidntPass { get; set; }

        public Subject(int subjectID, string subjectName, Semester sem, int year, int professor, int eSPBPoints)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Semester = sem;
            Year = year;
            ProfessorId = professor;
            ESPBPoints = eSPBPoints;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass = new List<Student>();
        }
        //Konstruktor bez Id-eva
        public Subject( string subjectName, Semester sem, int year, int professor, int eSPBPoints)
        {
         
            SubjectName = subjectName;
            Semester = sem;
            Year = year;
            ProfessorId = professor;
            ESPBPoints = eSPBPoints;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass = new List<Student>();
        }
        public Subject()
        {
            SubjectID = 1;
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
            SubjectID = int.Parse(val[0]);
            SubjectName = val[1];
            if (val[2]=="ZIMSKI")
            {
                Semester = Semester.ZIMSKI;

            }
            else
            {
                Semester = Semester.LETNJI;
            }
            Year = int.Parse(val[3]);
            ProfessorId = int.Parse(val[4]);
            ESPBPoints= int.Parse(val[5]);
        }
        public string[] ToCSV()
        {
            string[] retString =
            {
                SubjectID.ToString(), SubjectName, Semester.ToString(),Year.ToString(),ProfessorId.ToString(),ESPBPoints.ToString()
            };
            return retString;
        }
        public override string ToString()
        {
            string s = $"ID:{SubjectID,3}| Name: {SubjectName,20} | Semester: {Semester,6} | Year: {Year,4} | Professor ID:{ProfessorId,3}| ESPB Points: {ESPBPoints,1}";
            return s;
        }
    }
}
