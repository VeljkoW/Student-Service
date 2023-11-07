using CLI.models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class Subject : ISerializable
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Semester Semester { get; set; }
        public int Year { get; set; }
        public Professor Professor { get; set; }
        public int ESPBPoints { get; set; }
        public List<Student> StudentsWhoPassed { get; set; }
        public List<Student> StudentsWhoDidntPass { get; set; }

        public Subject(int subjectID, string subjectName, Semester sem, int year, Professor professor, int eSPBPoints, List<Student> studentsWhoPassed, List<Student> studentsWhoDidntPass)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Semester = sem;
            Year = year;
            this.Professor = professor;
            ESPBPoints = eSPBPoints;
            StudentsWhoPassed = studentsWhoPassed;
            StudentsWhoDidntPass = studentsWhoDidntPass;
        }
        public Subject()
        {
            SubjectID = 1;
            SubjectName = "Analiza";
            Semester = Semester.ZIMSKI;
            Year = 2023;
            Professor = new Professor();
            ESPBPoints = 8;
            StudentsWhoPassed = new List<Student>();
            StudentsWhoDidntPass= new List<Student>();
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
            //Professor = new Professor(val[4], val[5], val[6],  , val[8], val[9], val[10], val[11], int.Parse(val[12]), val[13]);
            ESPBPoints= int.Parse(val[12]);
            //StudentsWhoPassed = new List<Student>();
            //StudentsWhoDidntPass = new List<Student>();
        }

        public string[] ToCSV()
        {
            string[] retString =
            {
                SubjectID.ToString(), SubjectName, Semester.ToString(),Year.ToString(),Professor.ToString(),ESPBPoints.ToString(),StudentsWhoPassed.ToString(),StudentsWhoDidntPass.ToString()
            };
            return retString;
        }
        

    }
}
