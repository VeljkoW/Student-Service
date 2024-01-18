using CLI;
using CLI.Controller;
using CLI.models.Enums;
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

namespace GUI.MenuBar.File
{
    /// <summary>
    /// Interaction logic for NewGrade.xaml
    /// </summary>

    public partial class NewGrade : Window
    {
        public SubjectDTO? SelectedSubject { get; set; }
        public StudentDTO? SelectedStudent { get; set; }
        public SubjectController subjectController { get; set; }
        public ObservableCollection<ExamGradeDTO> ExamGrades { get; set; }
        public ObservableCollection<SubjectDTO> StudentSubjects { get; set; }
        public ExamGradeController examGradeController { get; set; }
        public StudentSubjectController studentSubjectController { get; set; }
        public NewGrade(SubjectDTO selectedSubject,StudentDTO selectedStudent,ObservableCollection<ExamGradeDTO>examGrades, ObservableCollection<SubjectDTO> studentSubjects,SubjectController subjectControll,StudentSubjectController ssController,ExamGradeController exController)
        {
            DataContext = this;

            ExamGrades = examGrades;
            StudentSubjects = studentSubjects;



            SelectedSubject =selectedSubject;
            SelectedStudent=selectedStudent;

            subjectController = subjectControll;
            studentSubjectController = ssController;
            examGradeController = exController;

            InitializeComponent();
            SubjectName.Text = selectedSubject.SubjectName.ToString();
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
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent != null && SelectedSubject != null)
            {
                int Grade = 0;
                switch (GradeComboBox.SelectedIndex)
                {
                    case 0:
                        Grade = 6;
                        break;
                    case 1:
                        Grade = 7;
                        break;
                    case 2:
                        Grade = 8;
                        break;
                    case 3:
                        Grade = 9;
                        break;
                    case 4:
                        Grade = 10;
                        break;
                }
                DateOnly date;
                if (!DateOnly.TryParse(DatePicker.Text, out DateOnly result))
                {
                    MessageBox.Show("Make sure you put a grade date!", "Date is empty", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    date = DateOnly.Parse(DatePicker.Text);
                    //CLI.Index indeks = new CLI.Index(SelectedStudent.StudentIndex);
                    //string subjname = SelectedSubject.SubjectName;
                    ExamGrade exGrade = new ExamGrade(SelectedSubject.Id, SelectedStudent.Id, SelectedSubject.Id, Grade, date);
                    examGradeController.Add(exGrade);
                    ExamGradeDTO examGrade = new ExamGradeDTO(exGrade);
                    ExamGrades.Add(examGrade);
                    studentSubjectController.Delete(SelectedStudent.Id, SelectedSubject.Id);

                    StudentSubjects.Clear();

                    foreach (StudentSubject s in studentSubjectController.GetAllSubjects())
                    {
                        foreach (Subject subject in subjectController.GetAllSubjects())
                        {
                            if (s.subjectId == subject.Id && SelectedStudent.Id == s.studentId)
                            {
                                StudentSubjects.Add(new SubjectDTO(subject));
                            }
                        }
                    }
                    ExamGrades.Clear();
                    foreach (ExamGrade grade in examGradeController.GetAllExamGrades())
                    {
                        if (grade.StudentId == SelectedStudent.Id)
                        {
                            ExamGrades.Add(new ExamGradeDTO(grade));
                        }
                    }
                    Close();
                }
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
