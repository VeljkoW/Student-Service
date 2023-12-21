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
        private Professor head;
        public Professor Head
        {
            get
            {
             
                return head;
            }
            set
            {
                if (value != head)
                {
                    head = value;
                    OnPropertyChanged();
                }
            }
        }
        /*
        private string imeProfesora;
        public string ImeProfesora
        {
            get
            {
                imeProfesora = head.Name;
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
        */
        public KatedraDTO(Katedra katedra)
        {
            Id=katedra.Id;
            name=katedra.Name;
            head=katedra.Head;
        }

        public KatedraDTO() 
        {
            Id = 0;
            name = "";
            head = new Professor();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
