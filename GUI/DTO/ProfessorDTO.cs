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
   public class ProfessorDTO : INotifyPropertyChanged
    {
        private int id;
        public int ProfessorId
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateOnly birthDate;
        public DateOnly DateOfBirth
        {
            get
            {
                return birthDate;
            }
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    //OnPropertyChanged();
                }
            }
        }
        private Adress professorAdress;
        public Adress ProfessorAdress
        {
            get
            {
                return professorAdress;
            }
            set
            {
                if (value != professorAdress)
                {
                    professorAdress = value;
                    OnPropertyChanged();
                }
            }
        }
        private string phonenumber;
        public string PhoneNumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                if (value != phonenumber)
                {
                    phonenumber = value;
                    OnPropertyChanged();
                }
            }
        }
        private string idCardNumber;
        public string IDCardNumber
        {
            get
            {
                return idCardNumber;
            }
            set
            {
                if (value != idCardNumber)
                {
                    idCardNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        private int yearsOfService;
        public int YearsOfService
        {
            get
            {
                return yearsOfService;
            }
            set
            {
                if (value != yearsOfService)
                {
                    yearsOfService = value;
                    OnPropertyChanged();
                }
            }
        }

        private string name;
        public string ProfessorName
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
        public string ProfessorSurname
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

        private string email;
        public string ProfessorEmail
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
        private string title;
        public string ProfessorTitle
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }
        public ProfessorDTO()
        {
            id = 0;
            name = "";
            surname = "";
            birthDate = new DateOnly();
            professorAdress = new Adress();
            phonenumber = "";
            idCardNumber = "";
            email = "";
            title = "";
            yearsOfService = 0;
        }
        public ProfessorDTO(Professor prof)
        {
            id=prof.Id;
            name=prof.Name;
            surname=prof.Surname;
            birthDate = prof.DateOfBirth;
            professorAdress = prof.ProfessorAdress;
            phonenumber = prof.PhoneNumber;
            idCardNumber = prof.IDCardNumber;
            email = prof.EmailAdress;
            title = prof.Title;
            yearsOfService=prof.YearsOfService;
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
