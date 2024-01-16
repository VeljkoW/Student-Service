using CLI.Controller;
using CLI;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for NewDepartment.xaml
    /// </summary>
    public partial class NewDepartment : Window
    {
        public KatedraDTO katedraDTO = new KatedraDTO();
        public KatedraController katedraController = new KatedraController();
        public ProfessorController professorController = new ProfessorController();
        public ObservableCollection<KatedraDTO> Departments { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }

        public NewDepartment(ObservableCollection<KatedraDTO> katedras, ObservableCollection<ProfessorDTO> professors)
        {
            Departments = katedras;
            Professors = professors;
            InitializeComponent();

            HeadProfessorComboBox.ItemsSource = Professors;
            HeadProfessorComboBox.DisplayMemberPath = "ProfessorNameAndSurname";
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            string ime = NameTextBox.Text;
            string professor = HeadProfessorComboBox.Text;
            int professorId = 0;

            foreach (ProfessorDTO prof in Professors)
            {
                if (prof.ProfessorNameAndSurname == professor)
                {
                    professorId = prof.ProfessorId;
                }
            }

            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(HeadProfessorComboBox.Text))
            {
                MessageBox.Show("Make sure you fill in each text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                foreach(Professor professor1 in professorController.GetAllProfessors())
                {
                    if(professorId == professor1.Id)
                    {
                        Katedra katedra = new Katedra(ime,professor1);
                        katedraController.Add(katedra);
                        katedraDTO = new KatedraDTO(katedra);
                        Departments.Add(katedraDTO);
                    }
                }
                Close();
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

    }
}
