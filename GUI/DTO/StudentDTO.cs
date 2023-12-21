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
        public int Id { get; set; }

        private string name;
        public string Name
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
                    //OnPropertyChanged();
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
                    //OnPropertyChanged();
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

        private CLI.Index studentIndex;
        public CLI.Index StudentIndex
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
                   // OnPropertyChanged();
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


        public Student ToStudent()
        {
            return new Student(name,surname,dateOfBirth,adress,phone,email,studentIndex,studentYear,status);
        }

        public StudentDTO()
        {
        }
        public StudentDTO(Student student)
        {
            Id=student.Id;
            name=student.Name;
            surname=student.Surname;
            dateOfBirth=student.DateOfBirth;
            adress=student.Adress;
            phone=student.Phone;
            email=student.Email;
            studentIndex=student.StudentIndex;
            studentYear=student.StudentYear;
            status = student.Status;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
