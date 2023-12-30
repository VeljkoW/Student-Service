using CLI;
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
            imeProfesora=katedra.ImeProfesora;
            prezimeProfesora = katedra.PrezimeProfesora;
        }

        public KatedraDTO() 
        {
            Id = 0;
            name = "";
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
