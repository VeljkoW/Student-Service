using CLI;
using CLI.models;
using CLI.models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
   public class StudentDTO : INotifyPropertyChanged
    {
        public ExamGradeDAO examGradeDAO = new ExamGradeDAO();
        
        public int Id { get; set; }

        private string name;
        public string StudentName
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }
    
        private DateOnly dateOfBirth;
        public DateOnly DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                if (value != dateOfBirth)
                {
                    dateOfBirth = value;
                    OnPropertyChanged();
                }
            }
        }

        private Adress adress;
        public Adress Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (value != adress)
                {
                    adress = value;
                    OnPropertyChanged();
                }
            }
        }
     
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value != phone)
                {
                    phone = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }
     
        private string studentIndex;
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

        private int studentYear;
        public int StudentYear
        {
            get
            {
                return  studentYear;
            }
            set
            {
                if (value != studentYear)
                {
                    studentYear = value;
                    OnPropertyChanged();
                }
            }
        }

        private Status status;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }
        private double gradeAverage;
        public double GradeAverage
        {
            get
            {
                return gradeAverage = examGradeDAO.getAverageGrade(Id);
            }
            set
            {
                if (value != gradeAverage)
                {
                    gradeAverage = examGradeDAO.getAverageGrade(Id);
                    OnPropertyChanged();
                }
            }
        }




        public StudentDTO()
        {
            Id = 0;
            name = "";
            surname = "";
            studentIndex = "";
            adress = new Adress();
            phone = "";
            email = "";
            dateOfBirth = new DateOnly();
            studentYear = 0;
            status = new Status();
        }
        public StudentDTO(Student student)
        {
            Id=student.Id;
            name=student.Name;
            surname=student.Surname;
            email = student.Email;
            dateOfBirth = student.DateOfBirth;
            phone= student.Phone;
            adress=student.Adress;
            studentIndex=student.StudentIndex.ToString();
            studentYear=student.StudentYear;
            status = student.Status;
        }
       

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
