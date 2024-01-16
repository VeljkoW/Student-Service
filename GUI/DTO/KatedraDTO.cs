using CLI;
using CLI.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class KatedraDTO : INotifyPropertyChanged
    {

        public ProfessorController professorController = new ProfessorController();
        public int Id { get; set; }
        private string name;
        public string DepartmentName
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

        public int idProfessor;
        public int IdProfessor
        {
            get
            {
                return idProfessor;
            }
            set
            {
                if (value != idProfessor)
                {
                    idProfessor = value;
                    OnPropertyChanged();
                }
            }
        }
       
        private string imeProfesora;
        public string ImeProfesora
        {
            get
            {
                return imeProfesora;
            }
            set
            {
                if (value != imeProfesora)
                {
                    imeProfesora = value;
                    OnPropertyChanged();
                }
            }
        }
        private string prezimeProfesora;
        public string PrezimeProfesora
        {
            get
            {
                return prezimeProfesora;
            }
            set
            {
                if (value != prezimeProfesora)
                {
                    prezimeProfesora = value;
                    OnPropertyChanged();
                }
            }
        }
        public KatedraDTO(Katedra katedra)
        {
            Id=katedra.Id;
            name=katedra.Name;
            imeProfesora = "";
            prezimeProfesora = "";
            idProfessor = katedra.IdProfesora;
            foreach(Professor professor in professorController.GetAllProfessors())
            {
                if (professor.Id ==idProfessor)
                {
                    imeProfesora=professor.Name;
                    prezimeProfesora = professor.Surname;
                }
            }
        }

        public KatedraDTO() 
        {
            Id = 0;
            name = "";
            idProfessor = 0;
            imeProfesora = "";
            prezimeProfesora = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
