﻿using GUI.MenuBar.File;
using GUI.MenuBar.Edit;
using GUI.MenuBar.Help;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using CLI;
using GUI.DTO;
using CLI.Controller;
using CLI.Observer;
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        public ObservableCollection<StudentDTO> Students { get; set; }

        public ObservableCollection<ExamGradeDTO> ExamGrades { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        public ObservableCollection<SubjectDTO> Subjects { get; set; }

        public StudentDTO? SelectedStudent { get; set; }
        public ExamGradeDTO? SelectedExamGrade {  get; set; }
        public SubjectDTO? SelectedSubject { get; set; }
        public ProfessorDTO? SelectedProfessor { get; set; }
        private StudentController studentController {  get; set; }
        private ExamGradeController examGradeController { get; set; }
        private ProfessorController professorController { get; set; }
        private SubjectController subjectController { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            Students = new ObservableCollection<StudentDTO>();
            ExamGrades = new ObservableCollection<ExamGradeDTO>();
            Professors = new ObservableCollection<ProfessorDTO>();
            Subjects = new ObservableCollection<SubjectDTO>();


            studentController = new StudentController();
            examGradeController = new ExamGradeController();
            professorController = new ProfessorController();
            subjectController = new SubjectController();


            examGradeController.Subscribe(this);
            studentController.Subscribe(this);
            professorController.Subscribe(this);
            Update();
        }
        private void LoadFunctions(object sender, RoutedEventArgs e)
        {
            CenterWindowFunction();
            StatusBarCurrentTimeAndDate();
            StatusBarCurrentTabShowing();
        }

        private void StatusBarCurrentTimeAndDate()
        {
            
            statusBarDateAndTime.Text = $"{DateTime.Now.ToString("HH:mm  dd.MM.yyyy.")}";
        }
        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatusBarCurrentTabShowing();
        }
        private void StatusBarCurrentTabShowing()
        {
            if (Tab.SelectedIndex == 0)
            {
                StatusBarCurrentTab.Text = "Students";

            }
            else if (Tab.SelectedIndex == 1)
            {
                StatusBarCurrentTab.Text = "Grades";
            }
            else if (Tab.SelectedIndex == 2)
            {
                StatusBarCurrentTab.Text = "Subjects";
            }
            else if (Tab.SelectedIndex == 3)
            {
                StatusBarCurrentTab.Text = "Professors";
            }
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

        private void OpenNewLayout(object sender, RoutedEventArgs e)
        {
            if (Tab.SelectedIndex == 0)
            {
                NewStudent sle = new NewStudent(Students);
                sle.Show();
            }
            else if (Tab.SelectedIndex == 1)
            {

            }
            else if (Tab.SelectedIndex == 2)
            {

            }
            else if (Tab.SelectedIndex == 3)
            {
                NewProfessor sle = new NewProfessor(Professors);
                sle.Show();
            }
        }
        private void ClickSave(object sender, RoutedEventArgs e)
        {
            Save sle = new Save();
            sle.Show();
        }

        private void OpenOpenLayout(object sender, RoutedEventArgs e)
        {
            Open sle = new Open();
            sle.Show();
        }

        private void ClickClose(object sender, RoutedEventArgs e)
        {
            MessageBoxResult R = MessageBox.Show("Are you sure you want to close the aplication?", "Close Aplication", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(R == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }
        private void OpenEditWindow(object sender, RoutedEventArgs e)
        {
            if (Tab.SelectedIndex == 0)
            {
                if (SelectedStudent == null)
                {
                    MessageBox.Show("Please choose a student you want to edit!");
                }
                else
                {
                    EditStudent sle = new EditStudent(SelectedStudent,Students);
                    sle.Show();
                }
            }
            else if (Tab.SelectedIndex == 1)
            {
                if (SelectedExamGrade == null)
                {
                    MessageBox.Show("Please choose a grade you want to edit!");
                }
                else
                {
                    
                }
            }
            else if (Tab.SelectedIndex == 2)
            {
                if (SelectedSubject == null)
                {
                    MessageBox.Show("Please choose a subject you want to edit!");
                }
                else
                {
                    EditSubject sle = new EditSubject(SelectedSubject, Subjects);
                    sle.Show();
                }
            }
            else if (Tab.SelectedIndex == 3)
            {
                if (SelectedProfessor == null)
                {
                    MessageBox.Show("Please choose a professor you want to edit!");
                }
                else
                {
                    EditProfesor sle = new EditProfesor(SelectedProfessor, Professors);
                    sle.Show();
                }
            }
        }
        private void OpenDeleteWindow(object sender, RoutedEventArgs e)
        {
            
            if(Tab.SelectedIndex==0)
            {
                if(SelectedStudent == null)
                {
                    MessageBox.Show("Please choose a student you want to delete!");
                }
                else
                {
                    Delete del = new Delete(SelectedStudent,Students);
                    del.Show();
                }
            }
            else if(Tab.SelectedIndex==1)
            {
                if(SelectedExamGrade == null)
                {
                    MessageBox.Show("Please choose a grade you want to delete!");
                }
                else
                {
                    Delete del = new Delete(SelectedExamGrade,ExamGrades);
                    del.Show();
                }
            }
            else if (Tab.SelectedIndex == 2)
            {
                if (SelectedSubject == null)
                {
                    MessageBox.Show("Please choose a subject you want to delete!");
                }
                else
                {
                    Delete del = new Delete(SelectedSubject, Subjects);
                    del.Show();
                }
            }
            else if (Tab.SelectedIndex == 3)
            {
                if (SelectedProfessor == null)
                {
                    MessageBox.Show("Please choose a professor you want to delete!");
                }
                else
                {
                    Delete del = new Delete(SelectedProfessor, Professors);
                    del.Show();
                }
            }
        }
        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {
            About sle = new About();
            sle.Show();
        }

        public void Update()
        {
            Students.Clear();
            ExamGrades.Clear();
            Subjects.Clear();
            Professors.Clear();
            foreach (Student student in studentController.GetAllStudents()) Students.Add(new StudentDTO(student));
            foreach (ExamGrade examgrade in examGradeController.GetAllExamGrades()) ExamGrades.Add(new ExamGradeDTO(examgrade));
            foreach (Subject subject in subjectController.GetAllSubjects()) Subjects.Add(new SubjectDTO(subject));
            foreach (Professor professor in professorController.GetAllProfessors()) Professors.Add(new ProfessorDTO(professor));
        }
    }
}
