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
using CLI.Observer;
using GUI.MenuBar.File;

namespace GUI.MenuBar.Edit
{
    /// <summary>
    /// Interaction logic for EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window, IObserver
    {
        public KatedraDTO katedraDTO = new KatedraDTO();
        public KatedraController katedraController { get; set; }
        public ProfessorController professorController { get; set; }
        public ProfessorDTO? SelectedProfessor { get; set; }
        public ObservableCollection<KatedraDTO> Departments { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        public ObservableCollection<ProfessorDTO> DepartmentProfessors { get; set; } = new ObservableCollection<ProfessorDTO>();
        public KatedraDTO SelectedDepartment { get; set; }

        public EditDepartment(KatedraDTO selectedKatedra,ObservableCollection<KatedraDTO> katedras, ObservableCollection<ProfessorDTO> professors,ProfessorController profController,KatedraController kcontroller)
        {
            DataContext = this;

            Departments = katedras;
            Professors = professors;
            SelectedDepartment = selectedKatedra;
            professorController=profController;
            katedraController = kcontroller;

            professorController.Subscribe(this);
            katedraController.Subscribe(this);
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
        private void AddProfessor(object e, EventArgs args)
        {
            ChoseProfessorToAddToDepartment fun = new ChoseProfessorToAddToDepartment(professorController,SelectedDepartment,Professors);
            fun.Owner = this;
            fun.ShowDialog();
        }
        private void RemoveProfessor(object e, EventArgs args)
        {
            if (SelectedProfessor == null)
            {
                MessageBox.Show("Please choose a professor you want to remove!", "Professor not selected");
            }
            else if(SelectedProfessor.ProfessorId == SelectedDepartment.IdProfessor){
                MessageBox.Show("You can not delete this professor,they are the head of this department!", "Professor is the head of the department");
            }
            else
            {
                MessageBoxResult R = MessageBox.Show("Are you sure you want to remove this professor?", "Remove the professor", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (R == MessageBoxResult.Yes)
                {
                    if (professorController.GetProfessorById(SelectedProfessor.ProfessorId) != null)
                    {
                        Professor? prof = professorController.GetProfessorById(SelectedProfessor.ProfessorId);
                        if(prof != null)
                        {
                            prof.DepartmentId = -1;
                            professorController.Update(prof);
                        }
                        Update();
                    }
                }
            }
        }
        private void CenterWindow(object sender, RoutedEventArgs e)
        {
            CenterWindowFunction();
            Update();
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

        public void Update()
        {
            DepartmentProfessors.Clear();
            foreach (Professor prof in professorController.GetAllProfessors())
            {
                if (prof.DepartmentId == SelectedDepartment.Id)
                {
                    DepartmentProfessors.Add(new ProfessorDTO(prof));
                }
            }
            foreach (ProfessorDTO prof in Professors)
            {
                if (SelectedDepartment.IdProfessor == prof.ProfessorId)
                {
                    HeadProfessorComboBox.Text = prof.ProfessorNameAndSurname;
                }
            }
        }
    }
}
