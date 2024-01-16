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

namespace GUI.MenuBar.Edit
{
    /// <summary>
    /// Interaction logic for EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window
    {
        public KatedraDTO katedraDTO = new KatedraDTO();
        public KatedraController katedraController = new KatedraController();
        public ProfessorController professorController = new ProfessorController();
        public ObservableCollection<KatedraDTO> Departments { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        public KatedraDTO SelectedDepartment { get; set; }

        public EditDepartment(KatedraDTO selectedKatedra,ObservableCollection<KatedraDTO> katedras, ObservableCollection<ProfessorDTO> professors)
        {
            Departments = katedras;
            Professors = professors;
            SelectedDepartment = selectedKatedra;
            InitializeComponent();

            HeadProfessorComboBox.ItemsSource = Professors;
            HeadProfessorComboBox.DisplayMemberPath = "ProfessorNameAndSurname";

            foreach (ProfessorDTO prof in Professors)
            {
                if (SelectedDepartment.IdProfessor == prof.ProfessorId)
                {
                    HeadProfessorComboBox.Text = prof.ProfessorNameAndSurname;
                }
            }
            NameTextBox.Text = SelectedDepartment.DepartmentName;
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
                foreach (Professor professor1 in professorController.GetAllProfessors())
                {
                    if (professorId == professor1.Id)
                    {
                        Katedra katedra = new Katedra(SelectedDepartment.Id,ime, professor1);
                        katedraController.Update(katedra);
                        katedraDTO = new KatedraDTO(katedra);
                        for (int i = 0; i < Departments.Count; i++)
                        {
                            if (Departments[i].Id == katedra.Id)
                            {
                                Departments[i] = katedraDTO;
                            }
                        }
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
