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
        public int SubjectID { get; set; }

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
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
