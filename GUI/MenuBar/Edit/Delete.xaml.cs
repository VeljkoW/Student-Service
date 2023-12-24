using CLI;
using CLI.Controller;
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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public StudentDTO? SelectedStudent { get; }
        public ExamGradeDTO? SelectedExamGrade { get; }
        public SubjectDTO? SelectedSubject { get; }
        public ProfessorDTO? SelectedProfessor { get; }
        public KatedraDTO? SelectedDepartment { get; }

        public StudentController studentController = new StudentController();
        public ExamGradeController examGradeController = new ExamGradeController();
        public SubjectController subjectController = new SubjectController();
        public ProfessorController professorController = new ProfessorController();
        public KatedraController departmentController = new KatedraController();

        public ObservableCollection<StudentDTO>? Students { get; set; }
        public ObservableCollection<ExamGradeDTO>? ExamGrades { get; set; }
        public ObservableCollection<SubjectDTO>? Subjects { get; set; }
        public ObservableCollection<ProfessorDTO>? Professors { get; set; }
        public ObservableCollection<KatedraDTO>? Departments { get; set; }
        public Delete()
        {
            InitializeComponent();

        }
        //konstruktor za delete studenta
        public Delete(StudentDTO selectedStudent,ObservableCollection<StudentDTO> students)
        {
            this.SelectedStudent = selectedStudent;
            this.Students = students;
            InitializeComponent();
        }
        //konstruktor za delete ExamGrade
        public Delete(ExamGradeDTO examGrade,ObservableCollection<ExamGradeDTO> examGrades)
        {
            this.SelectedExamGrade = examGrade;
            this.ExamGrades = examGrades;
            InitializeComponent();
        }
        //konstruktor za delete subject
        public Delete(SubjectDTO subject, ObservableCollection<SubjectDTO> subjects)
        {
            this.SelectedSubject = subject;
            this.Subjects = subjects;
            InitializeComponent();
        }
        //konstruktor za delete Professor
        public Delete(ProfessorDTO professor, ObservableCollection<ProfessorDTO> professors)
        {
            this.SelectedProfessor = professor;
            this.Professors = professors;
            InitializeComponent();
        }
        //konstruktor za delete katedra
        public Delete(KatedraDTO department, ObservableCollection<KatedraDTO> departments)
        {
            this.SelectedDepartment = department;
            this.Departments = departments;
            InitializeComponent();
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
        private void CloseWindow(object sender, RoutedEventArgs e)
        { 
           this.Close();
        }
        private void ExecuteDelete(object sender, RoutedEventArgs e)
        {
            if(SelectedStudent != null && Students != null)
            {
                studentController.Delete(SelectedStudent.Id);
                Students.Remove(SelectedStudent);
                this.Close();
            }
            else if(SelectedExamGrade != null && ExamGrades != null)
            {
                examGradeController.Delete(SelectedExamGrade.Id);
                ExamGrades.Remove(SelectedExamGrade);
                this.Close();
            }
            else if (SelectedSubject != null && Subjects != null)
            {
                subjectController.Delete(SelectedSubject.Id);
                Subjects.Remove(SelectedSubject);
                this.Close();
            }
            else if (SelectedProfessor != null && Professors!= null)
            {
                professorController.Delete(SelectedProfessor.ProfessorId);
                Professors.Remove(SelectedProfessor);
                this.Close();
            }
            else if(SelectedDepartment != null && Departments != null)
            {
                departmentController.Delete(SelectedDepartment.Id);
                Departments.Remove(SelectedDepartment);
                this.Close();
            }
        }

    }
}
