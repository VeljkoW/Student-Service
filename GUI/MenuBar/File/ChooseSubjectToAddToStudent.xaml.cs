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

namespace GUI.MenuBar.File
{
    /// <summary>
    /// Interaction logic for ChooseSubjectToAdd.xaml
    /// </summary>
    public partial class ChooseSubjectToAddToStudent : Window
    {
        public ObservableCollection<SubjectDTO> Subjects { get; set; }
        public SubjectController subjectController { get; set; }
        public ExamGradeController examGradeController { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public ObservableCollection<SubjectDTO> StudentSubjects { get; set; }
        public StudentDTO Student;
        public ChooseSubjectToAddToStudent(StudentDTO student,ObservableCollection<SubjectDTO> studentSubjects)
        {
            InitializeComponent();
            subjectController = new SubjectController();
            examGradeController = new ExamGradeController();
            studentSubjectController = new StudentSubjectController();
            StudentSubjects = studentSubjects;
            Student = student;
            Subjects = new ObservableCollection<SubjectDTO>();

            foreach (Subject subject in subjectController.GetAllSubjects())
            {
                bool isSubjectPassed = false;
                bool isSubjectBeingListened = false;

                foreach (ExamGrade examGrade in examGradeController.GetAllExamGrades())
                {
                    if (examGrade.SubjectId == subject.Id && examGrade.StudentId == student.Id)
                    {
                        isSubjectPassed = true;
                        break;
                    }
                }

                foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                {
                    if (studentSubject.subjectId == subject.Id && studentSubject.studentId == student.Id)
                    {
                        isSubjectBeingListened = true;
                        break;
                    }
                }

                if (!isSubjectPassed && !isSubjectBeingListened)
                {
                    Subjects.Add(new SubjectDTO(subject));
                }
            }

            SubjectsComboBox.ItemsSource = Subjects;
            SubjectsComboBox.DisplayMemberPath = "SubjectName";
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
            foreach(Subject subject in subjectController.GetAllSubjects())
            {
                if(SubjectsComboBox.Text == subject.SubjectName)
                {
                    StudentSubjects.Add(new SubjectDTO(subject));
                    studentSubjectController.Add(new StudentSubject(Student.Id, subject.Id));
                }
            }
            Close();
        }
            private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
