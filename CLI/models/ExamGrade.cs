using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class ExamGrade : ISerializable
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
        public DateOnly Date { get; set; }

        public void FromCSV(string[] values)
        {
            Id= int.Parse(values[0]);
            StudentId = int.Parse(values[1]);
            SubjectId = int.Parse(values[2]);
            Grade = int.Parse(values[3]);
            Date = BirthDate.Parse(values[4]);
        }
        public string[] ToCSV()
        {
            string[] values = { Id.ToString(),StudentId.ToString(),SubjectId.ToString(),Grade.ToString(),Date.ToString()};
            return values;
        }
        public override string ToString()
        {
            string s = Id.ToString()+", "+StudentId+", "+SubjectId+", "+Grade+", "+Date;
            return s;
        }
    }
}
