using CLI;
using CLI.Controller;
using CLI.models.comparer;
using CLI.Observer;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.MenuBar.View
{
    /// <summary>
    /// Interaction logic for ProfessorStudents.xaml
    /// </summary>
    public partial class DepartmentSubjects : Window,IObserver
    {
        
        public KatedraDTO SelectedDepartment{  get; set; }
        public ObservableCollection<SubjectDTO> DepartmentSubjectsList { get; set; }
        public ProfessorController professorController { get; set; }
        public SubjectController subjectController { get; set; }
        public KatedraController katedraController { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public ObservableCollection<ProfessorDTO> ProfessorList { get; set; }
        public DepartmentSubjects(KatedraDTO selectedStudent, ProfessorController profController,SubjectController subjController,KatedraController katedraControl,StudentSubjectController ssController)
        {
            DataContext = this;
            SelectedDepartment = selectedStudent;
            DepartmentSubjectsList = new ObservableCollection<SubjectDTO>();
            katedraController = katedraControl;
            professorController = profController;
            subjectController = subjController;
            studentSubjectController = ssController;

            ProfessorList = new ObservableCollection<ProfessorDTO>();


            professorController.Subscribe(this);
            subjectController.Subscribe(this);
            katedraController.Subscribe(this);
            InitializeComponent();

            Update();
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
        public void Update()
        {
            DepartmentSubjectsList.Clear();
            if (SelectedDepartment != null)
            {
                //DepartmentSubjects . add 
                foreach(Professor p in professorController.GetAllProfessors())
                {
                    if(p.DepartmentId == SelectedDepartment.Id)
                    {
                        foreach(Subject s in subjectController.GetAllSubjects())
                        {
                            if(s.ProfessorId == p.Id)
                            {
                                DepartmentSubjectsList.Add(new SubjectDTO(s));
                            }
                        }
                    }
                }

            }
        }
    }
}