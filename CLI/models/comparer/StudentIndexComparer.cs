using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.models.comparer
{
    public class StudentIndexComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            string xCharacters = x.StudentIndex.Usm;
            string yCharacters = y.StudentIndex.Usm;

            int charactersComparison = xCharacters.CompareTo(yCharacters);


            if (charactersComparison != 0)
            {
                return charactersComparison;
            }


            int xYear = x.StudentIndex.Year;
            int yYear = y.StudentIndex.Year;

            
            int yearComparison = xYear.CompareTo(yYear);

           
            if (yearComparison != 0)
            {
                return yearComparison;
            }

            
            int xNumber = x.StudentIndex.Number;
            int yNumber = y.StudentIndex.Number;

            return xNumber.CompareTo(yNumber);
        }
    }
}
