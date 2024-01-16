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
using System.Xml.Linq;

namespace GUI.MenuBar.View
{
    /// <summary>
    /// Interaction logic for StudentCondition.xaml
    /// </summary>
    public partial class StudentCondition : Window, IObserver
    {
        public SubjectDTO FirstSubject;
        public Subject SecondSubject;
        public ObservableCollection<SubjectDTO> Subjects {  get; set; }
        public ObservableCollection<StudentDTO> StudentsAttendingBoth {  get; set; }
        public ObservableCollection<StudentDTO> StudentsPassedFirst { get; set; }
        public ObservableCollection<StudentDTO> StudentsPassedSecond { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public ExamGradeController examGradeController { get; set; }
        public SubjectController subjectController { get; set; }
        public StudentController studentController { get; set; }
        public StudentDTO? SelectedStudent1 { get; set; }
        public StudentCondition(SubjectDTO firstSubject)
        {
            DataContext = this;

            FirstSubject = firstSubject;
            SecondSubject = new Subject();
            Subjects = new ObservableCollection<SubjectDTO>();
            StudentsAttendingBoth = new ObservableCollection<StudentDTO>();
            StudentsPassedFirst = new ObservableCollection<StudentDTO>();
            StudentsPassedSecond = new ObservableCollection<StudentDTO>();
            subjectController = new SubjectController();
            studentController = new StudentController();
            studentSubjectController = new StudentSubjectController();
            examGradeController = new ExamGradeController();

            subjectController.Subscribe(this);
            studentController.Subscribe(this);
            studentSubjectController.Subscribe(this);
            examGradeController.Subscribe(this);
            InitializeComponent();

            FirstSubjectTextBox.Text = FirstSubject.SubjectName;

            foreach(Subject subject in subjectController.GetAllSubjects()) 
            {
                bool isSelectedSubject = false;

                if(subject.Id == FirstSubject.Id)
                {
                    isSelectedSubject = true;
                }

                if(!isSelectedSubject)
                {
                    Subjects.Add(new SubjectDTO(subject));
                }

            }
            SecondSubjectComboBox.ItemsSource = Subjects;
            SecondSubjectComboBox.DisplayMemberPath = "SubjectName";

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

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(SecondSubjectComboBox.Text)) 
            {
                MessageBox.Show("Make sure you select the second subject!", "Subject 2 required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string SecondSubjectName = SecondSubjectComboBox.Text;
                foreach(Subject subject in subjectController.GetAllSubjects())
                {
                    if(subject.SubjectName == SecondSubjectName)
                    {
                        SecondSubject = subject;
                    }
                }

                Update();
               
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Update()
        {
            StudentsAttendingBoth.Clear();

            foreach (Student student in studentController.GetAllStudents())
            {
                bool isListeningtoFirst = false;
                bool isListeningtoSecond = false;

                foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                {
                    if (studentSubject.subjectId == FirstSubject.Id && studentSubject.studentId == student.Id)
                    {
                        isListeningtoFirst = true;
                        break;
                    }
                }
                foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                {
                    if (studentSubject.subjectId == SecondSubject.Id && studentSubject.studentId == student.Id)
                    {
                        isListeningtoSecond = true;
                        break;
                    }
                }

                if (isListeningtoFirst && isListeningtoSecond)
                {
                    StudentsAttendingBoth.Add(new StudentDTO(student));
                }

            }

            StudentsPassedFirst.Clear();
            StudentsPassedSecond.Clear();

            foreach(Student student1 in studentController.GetAllStudents())
            {
                bool passedFirst = false;
                bool passedSecond = false;
                bool AttendingFirst = false;
                bool AttendingSecond = false;

                foreach (ExamGrade examGrade in examGradeController.GetAllExamGrades())
                {
                    if (examGrade.SubjectId == FirstSubject.Id && examGrade.StudentId == student1.Id)
                    {
                        passedFirst = true;
                        break;
                    }
                }
                foreach (ExamGrade examGrade in examGradeController.GetAllExamGrades())
                {
                    if (examGrade.SubjectId == SecondSubject.Id && examGrade.StudentId == student1.Id)
                    {
                        passedSecond = true;
                        break;
                    }
                }

                foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                {
                    if (studentSubject.subjectId == FirstSubject.Id && studentSubject.studentId == student1.Id)
                    {
                        AttendingFirst = true;
                        break;
                    }
                }
                foreach (StudentSubject studentSubject in studentSubjectController.GetAllSubjects())
                {
                    if (studentSubject.subjectId == SecondSubject.Id && studentSubject.studentId == student1.Id)
                    {
                        AttendingSecond = true;
                        break;
                    }
                }


                if (passedFirst && !passedSecond && AttendingSecond)
                {
                    StudentsPassedFirst.Add(new StudentDTO(student1));
                }
                else if(!passedFirst && passedSecond && AttendingFirst)
                {
                    StudentsPassedSecond.Add(new StudentDTO(student1));
                }
            }

        }
    }
}
