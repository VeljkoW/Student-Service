using CLI;
using CLI.models.Enums;
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
   public class SubjectDTO : INotifyPropertyChanged
    {
        private string subjectID;
        public string SubjectID {
            get 
            { 
                return subjectID; 
            } set 
            { 
                if (value != subjectID) 
                { subjectID = value;
                    OnPropertyChanged();
                } 
            } 
        }

        private string subjectName;
        public string SubjectName
        {
            get
            {
                return subjectName;
            }
            set
            {
                if (value != subjectName)
                {
                    subjectName = value;
                    OnPropertyChanged();
                }
            }
        }

        public Semester semestar;
        public Semester Semestar
        {
            get
            {
                return semestar;
            }
            set
            {
                if (value != semestar)
                {
                    semestar = value;
                    OnPropertyChanged();
                }
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value != year)
                {
                    year = value;
                    OnPropertyChanged();
                }
            }
        }

        private int professorId;
        public int ProfessorId
        {
            get
            {
                return professorId;
            }
            set
            {
                if (value != professorId)
                {
                    professorId = value;
                    OnPropertyChanged();
                }
            }
        }

        private int espbPoints;
        public int ESPBPoints
        {
            get
            {
                return espbPoints;
            }
            set
            {
                if (value != espbPoints)
                {
                    espbPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        public Subject ToSubject()
        {
            return new Subject(subjectName,semestar,year,professorId,espbPoints);
        }

        public SubjectDTO()
        {
            SubjectID = "";
            subjectName = string.Empty;
            semestar = new Semester();
            year = 0;
            professorId = 0;
            espbPoints = 0;
        }
        public SubjectDTO(Subject s)
        {
            SubjectID = s.SubjectID;
            subjectName = s.SubjectName;
            semestar = s.Semester;
            year = s.Year;
            professorId= s.ProfessorId;
            espbPoints = s.ESPBPoints;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
