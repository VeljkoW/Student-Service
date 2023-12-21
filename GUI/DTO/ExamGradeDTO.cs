using CLI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GUI.DTO
{
    public class ExamGradeDTO : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        private int grade;
        public int Grade
        {
            get
            {
                return grade;
            }
            set
            {
                if (value != grade)
                {
                    grade = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateOnly date;
        public DateOnly Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }

        public ExamGrade ToExamGrade()
        {
            return new ExamGrade(grade,date);
        }

        public ExamGradeDTO()
        {
        }

        public ExamGradeDTO(ExamGrade examgrade)
        {
            Id=examgrade.Id;
            StudentId=examgrade.StudentId;
            SubjectId=examgrade.SubjectId;
            grade=examgrade.Grade;
            date=examgrade.Date;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
