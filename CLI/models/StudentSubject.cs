using CLI.models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class StudentSubject : ISerializable
    {
        public int studentId {  get; set; }
        public int subjectId {  get; set; }

        public StudentSubject(int studentId, int subjectId)
        {
            this.studentId = studentId;
            this.subjectId = subjectId;
        }
        public StudentSubject() { }
        public void FromCSV(string[] val)
        {
            studentId = int.Parse(val[0]);
            subjectId = int.Parse(val[1]);
        }
        public string[] ToCSV()
        {
            string[] retString =
            {
                studentId.ToString(),subjectId.ToString()
            };
            return retString;
        }
    }
}
