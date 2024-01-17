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
    public partial class StudentProfessors : Window,IObserver
    {
        
        public StudentDTO SelectedStudent {  get; set; }
        public ObservableCollection<ProfessorDTO> studentProfessors{ get; set; }
        public ProfessorController professorController { get; set; }
        public SubjectController subjectController { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public List<Professor> ProfessorList { get; set; } = new List<Professor>();
        public StudentProfessors(StudentDTO selectedStudent, ProfessorController profController,SubjectController subjController)
        {
            DataContext = this;
            SelectedStudent = selectedStudent;
            studentProfessors = new ObservableCollection<ProfessorDTO>();

            professorController = profController;
            subjectController = subjController;
            studentSubjectController = new StudentSubjectController();


            professorController.Subscribe(this);
            studentSubjectController.Subscribe(this);

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
            studentProfessors.Clear();
            List<int> listaId = new List<int>();
            foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
            {
                if(studentSubject.studentId == SelectedStudent.Id)
                {
                    Subject? subj = subjectController.GetSubjectById(studentSubject.subjectId);
                    if(subj != null)
                    {
                        Professor? prof = professorController.GetProfessorById(subj.ProfessorId);
                        if(prof != null)
                        {
                            ProfessorDTO profForList = new ProfessorDTO(prof);
                            if (!listaId.Contains(profForList.ProfessorId))
                            {
                                listaId.Add(profForList.ProfessorId);
                            }
                        }
                    }
                }
            }
            foreach(int id in listaId) 
            {
                Professor? profa= professorController.GetProfessorById(id);
                if (profa != null)
                {
                    studentProfessors.Add(new ProfessorDTO(profa));
                }
            }
        }
    }
}