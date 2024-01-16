using CLI;
using CLI.Controller;
using CLI.Observer;
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

namespace GUI.MenuBar.View
{
    /// <summary>
    /// Interaction logic for ProfessorStudents.xaml
    /// </summary>
    public partial class ProfessorStudents : Window,IObserver
    {
        
        public ProfessorDTO SelectedProfessor {  get; set; }
        public ObservableCollection<StudentDTO> ProfessorsStudents { get; set; }
        public StudentController studentController { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public SubjectController subjectController {  get; set; }
        public ProfessorStudents(ProfessorDTO selectedProfessor)
        {
            DataContext = this;
            SelectedProfessor = selectedProfessor;
            ProfessorsStudents = new ObservableCollection<StudentDTO>();

            studentController = new StudentController();
            studentSubjectController = new StudentSubjectController();
            subjectController = new SubjectController();

            studentController.Subscribe(this);
            studentSubjectController.Subscribe(this);
            subjectController.Subscribe(this);

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
            foreach(Subject subject in subjectController.GetAllSubjects())
            {
                if(subject.ProfessorId == SelectedProfessor.ProfessorId)
                {
                    foreach(Student student in studentController.GetAllStudents())
                    {
                        bool Attends = false;

                        foreach(StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                        {
                            if(studentSubject.subjectId == subject.Id && studentSubject.studentId == student.Id)
                            {
                                Attends = true;
                                break;
                            }
                        }

                        if(Attends)
                        {
                            StudentDTO studentDTO = new StudentDTO(student);
                            bool exists = false;
                            foreach(StudentDTO s in ProfessorsStudents)
                            {
                                if(s.Id == studentDTO.Id)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (!exists)
                            {
                                ProfessorsStudents.Add(new StudentDTO(student));
                            }
                        }

                    }
                }
            }
            
        }
    }
}
