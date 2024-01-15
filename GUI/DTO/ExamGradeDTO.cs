using CLI;
using CLI.Controller;
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
        public StudentController studentController = new StudentController();
        public SubjectController subjectController = new SubjectController();

        private string studentIndex {  get; set; }
        public string StudentIndex
        {
            get
            {
                return studentIndex;
            }
            set
            {
                if (value != studentIndex)
                {
                    studentIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        private string subjectIDName {  get; set; }
        public string SubjectIDName
        {
            get
            {
                return subjectIDName;
            }
            set
            {
                if (value != subjectIDName)
                {
                    subjectIDName = value;
                    OnPropertyChanged();
                }
            }
        }

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

    
        public ExamGradeDTO()
        {
            Id = 0;
            StudentId = 0;
            SubjectId = 0;
            grade = 5;
            date = new DateOnly();
            studentIndex = "";
            subjectIDName = "";
        }

        public ExamGradeDTO(ExamGrade examgrade)
        {
            Id=examgrade.Id;
            StudentId=examgrade.StudentId;
            SubjectId=examgrade.SubjectId;
            grade=examgrade.Grade;
            date=examgrade.Date;
            studentIndex = "";
            foreach(Student student in studentController.GetAllStudents())
            {
                if(student.Id == examgrade.StudentId)
                {
                    studentIndex = student.StudentIndex.ToString();
                }
            }
            subjectIDName = "";
            foreach(Subject subject in subjectController.GetAllSubjects())
            {
                if(subject.Id == examgrade.SubjectId)
                {
                    subjectIDName = subject.SubjectID;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
