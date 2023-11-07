using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ExamGrade : ISerializable
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
        public DateOnly Date { get; set; }

        public void FromCSV(string[] values)
        {
            StudentId = int.Parse(values[0]);
            SubjectId = int.Parse(values[1]);
            Grade = int.Parse(values[2]);
            Date = BirthDate.Parse(values[3]);
        }
        public string[] ToCSV()
        {
            string[] values = { StudentId.ToString(),SubjectId.ToString(),Grade.ToString(),Date.ToString()};
            return values;
        }
    }
}
