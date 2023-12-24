using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLI
{
    public class ExamGrade : ISerializable
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Index StudentIndex { get; set; }
        public string SubjectIdName { get; set; }
        public int Grade { get; set; }
        public DateOnly Date { get; set; }

        public ExamGrade() 
        {
            Id= 0;
            StudentId= 0;
            SubjectId = 0;
            StudentIndex= new Index();
            SubjectIdName = "";
            Grade = 6;
            Date = new DateOnly();
        }
        public ExamGrade(int id, int studentId, int subjectId, int grade, DateOnly date,Index studentindex,string subjectIdName)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
            Grade = grade;
            Date = date;
            StudentIndex = studentindex;
            SubjectIdName = subjectIdName;
        }
        
        public void FromCSV(string[] values)
        {
            Id= int.Parse(values[0]);
            StudentId = int.Parse(values[1]);
            StudentIndex = Index.Parse(values[2]);
            SubjectId = int.Parse(values[3]);
            SubjectIdName = values[4];
            Grade = int.Parse(values[5]);
            Date = DateOnly.Parse(values[6]);
        }
        public string[] ToCSV()
        {
            string[] values = { Id.ToString(),StudentId.ToString(),StudentIndex.ToString(),SubjectId.ToString(),SubjectIdName,Grade.ToString(),Date.ToString()};
            return values;
        }
        public override string ToString()
        {
            string s = $"ID:{Id,3}| Student ID: {StudentId,3} | Subject ID: {SubjectId,3} | Grade: {Grade,2} | Date:{Date,11}";
            return s;
        }
    }
}
