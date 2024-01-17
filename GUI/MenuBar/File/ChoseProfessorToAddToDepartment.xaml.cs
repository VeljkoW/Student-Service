using CLI;
using CLI.Controller;
using CLI.Observer;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.MenuBar.File
{
    public partial class ChoseProfessorToAddToDepartment : Window
    {
        public ProfessorController controller { get; set; }
        public KatedraDTO SelectedDepartment { get; set; }
        ObservableCollection<ProfessorDTO> Professors { get; set; }
        ObservableCollection<ProfessorDTO> ProfessorsList { get; set; }
        public ChoseProfessorToAddToDepartment(ProfessorController prof,KatedraDTO department,ObservableCollection<ProfessorDTO>professors)
        {
            controller=prof;
            Professors = professors;
            SelectedDepartment = department;

            InitializeComponent();
            ProfessorsList = new ObservableCollection<ProfessorDTO>();
            ProfessorsList.Clear();

            foreach (Professor p in prof.GetAllProfessors())
            {
                if (p.DepartmentId == -1)
                {
                    ProfessorsList.Add(new ProfessorDTO(p));
                }
            }

            ProfessorComboBox.ItemsSource = ProfessorsList;
            ProfessorComboBox.DisplayMemberPath = "ProfessorNameAndSurname";
        }
        private void Cancel(object e, RoutedEventArgs e2)
        {
            Close();
        }
        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string professor = ProfessorComboBox.Text;
            int professorId = 0;
            foreach (ProfessorDTO proff in ProfessorsList)
            {
                if (proff.ProfessorNameAndSurname == professor)
                {
                    professorId = proff.ProfessorId;
                    Professor? p = controller.GetProfessorById(professorId);
                    if(p != null)
                    {
                        p.DepartmentId = SelectedDepartment.Id;
                        controller.Update(p);
                        Professors.Add(new ProfessorDTO(p));
                    }
                }
            }
            Close();
        }
        private void CenterWindow(object sender, RoutedEventArgs e)
        {
            CenterWindowFunction();
        }

        private void CenterWindowFunction()
        {
            double SWidth = SystemParameters.PrimaryScreenWidth;
            double SHeight = SystemParameters.PrimaryScreenHeight;
            double WWidth = this.Width;
            double WHeight = this.Height;

            this.Left = (SWidth - WWidth) / 2;
            this.Top = (SHeight - WHeight) / 2;
        }
    }
}
