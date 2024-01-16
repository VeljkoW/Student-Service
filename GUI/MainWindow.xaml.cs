using GUI.MenuBar.File;
using GUI.MenuBar.Edit;
using GUI.MenuBar.Help;
using GUI.MenuBar.View;
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
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using CLI.models.comparer;

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
        public ObservableCollection<KatedraDTO> Departments { get; set; }

        public StudentDTO? SelectedStudent { get; set; }
        public ExamGradeDTO? SelectedExamGrade {  get; set; }
        public SubjectDTO? SelectedSubject { get; set; }
        public ProfessorDTO? SelectedProfessor { get; set; }
        public KatedraDTO? SelectedDepartment { get; set; }

        private StudentController studentController {  get; set; }
        private ExamGradeController examGradeController { get; set; }
        private ProfessorController professorController { get; set; }
        private SubjectController subjectController { get; set; }
        private KatedraController departmentController {  get; set; }
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            Students = new ObservableCollection<StudentDTO>();
            ExamGrades = new ObservableCollection<ExamGradeDTO>();
            Professors = new ObservableCollection<ProfessorDTO>();
            Subjects = new ObservableCollection<SubjectDTO>();
            Departments = new ObservableCollection<KatedraDTO>();


            studentController = new StudentController();
            examGradeController = new ExamGradeController();
            professorController = new ProfessorController();
            subjectController = new SubjectController();
            departmentController = new KatedraController();


            examGradeController.Subscribe(this);
            studentController.Subscribe(this);
            professorController.Subscribe(this);
            subjectController.Subscribe(this);
            departmentController.Subscribe(this);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerFunction;
            timer.Start();

            Update();
        }
        private void LoadFunctions(object sender, RoutedEventArgs e)
        {
            CenterWindowFunction();
            StatusBarCurrentTabShowing();
            Keyboard.Focus(this);
        }
        private void TimerFunction(object? sender,EventArgs e)
        {
            StatusBarCurrentTimeAndDate();
        }
        private void StatusBarCurrentTimeAndDate()
        {
            
            statusBarDateAndTime.Text = $"{DateTime.Now.ToString("HH:mm  dd.MM.yyyy.")}";
        }
        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatusBarCurrentTabShowing();
            if (Tab.SelectedIndex == 2)
            {
                StudentConditionButton.Visibility = Visibility.Visible;
                ViewTab.Visibility = Visibility.Visible;
                StudentConditionTab.Visibility = Visibility.Visible;
                ProfessorStudentsTab.Visibility = Visibility.Collapsed;
            }
            else if(Tab.SelectedIndex == 3)
            {
                StudentConditionButton.Visibility = Visibility.Visible;
                ViewTab.Visibility= Visibility.Visible;
                StudentConditionTab.Visibility = Visibility.Collapsed;
                ProfessorStudentsTab.Visibility = Visibility.Visible;
            }
            else
            {
                StudentConditionButton.Visibility= Visibility.Collapsed;
                ViewTab.Visibility =Visibility.Collapsed;
                StudentConditionTab.Visibility= Visibility.Collapsed;
                ProfessorStudentsTab.Visibility = Visibility.Collapsed;
            }
        }
        private void StatusBarCurrentTabShowing()
        {
            if (Tab.SelectedIndex == 0)
            {
                StatusBarCurrentTab.Text = ":  Students";

            }
            else if (Tab.SelectedIndex == 1)
            {
                StatusBarCurrentTab.Text = ":  Grades";
            }
            else if (Tab.SelectedIndex == 2)
            {
                StatusBarCurrentTab.Text = ":  Subjects";
            }
            else if (Tab.SelectedIndex == 3)
            {
                StatusBarCurrentTab.Text = ":  Professors";
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
        private void MainKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenNewLayout(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                ClickSave(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.Q && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                ClickClose(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenDeleteWindow(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.E && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenEditWindow(sender, e);
                e.Handled = true;
            }
            else if (e.Key == Key.I && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenAboutWindow(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.U && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) && (Tab.SelectedIndex == 2 || Tab.SelectedIndex ==3) )
            {
                StudentConditionWindow(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.D1 || e.Key == Key.NumPad1) && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenStudents(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.D2 || e.Key == Key.NumPad2) && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenGrades(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.D3 || e.Key == Key.NumPad3) && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenSubjects(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.D4 || e.Key == Key.NumPad4) && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenProfessors(sender, e);
                e.Handled = true;
            }
            else if ((e.Key == Key.D5 || e.Key == Key.NumPad5) && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                OpenDepartments(sender, e);
                e.Handled = true;
            }
        }
        private void SearchBarKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SearchBarButtonClick(sender, e);
            }
        }
        private void SearchBarButtonClick(object sender, RoutedEventArgs e)
        {
            string searchBarString = SearchBarTextBox.Text.ToLower();
            SearchBar(searchBarString);
        }
        private void SearchBar(string searchBarString)
        {
            if (!string.IsNullOrEmpty(searchBarString))
            {
                if (Tab.SelectedIndex == 0)
                {
                    Update();
                    ObservableCollection<StudentDTO> FilteredStudents = new ObservableCollection<StudentDTO>();
                    string[] searchSplit = searchBarString.Split(",");

                    if(searchSplit.Length == 1)
                    {
                        string surname = searchSplit[0].Trim();

                        foreach (StudentDTO student in Students)
                        {

                            if (student.Surname.ToLower().Contains(surname))
                            {
                                FilteredStudents.Add(student);
                            }
                        }
                    }
                    else if(searchSplit.Length == 2)
                    {
                        string surname = searchSplit[0].Trim();
                        string name = searchSplit[1].Trim();

                        foreach(StudentDTO student in Students)
                        {
                            if(student.Surname.ToLower().Contains(surname) && student.StudentName.ToLower().Contains(name)) 
                            {
                                FilteredStudents.Add(student);
                            }
                        }
                    }
                    else if(searchSplit.Length == 3)
                    {
                        string index = searchSplit[0].Trim();
                        string name = searchSplit[1].Trim();
                        string surname = searchSplit[2].Trim();

                        foreach (StudentDTO student in Students)
                        {
                            if (student.Surname.ToLower().Contains(surname) && student.StudentName.ToLower().Contains(name) && student.StudentIndex.ToString().ToLower().Contains(index))
                            {
                                FilteredStudents.Add(student);
                            }
                        }
                    }

                    ShowFilteredStudents(FilteredStudents);

                }
                else if (Tab.SelectedIndex == 1)
                {

                }
                else if (Tab.SelectedIndex == 2)
                {
                    Update();
                    ObservableCollection<SubjectDTO> FilteredSubjects = new ObservableCollection<SubjectDTO>();
                    string[] searchSplit = searchBarString.Split(",");

                    if (searchSplit.Length == 1)
                    {
                        string name = searchSplit[0].Trim();
                        name = name.ToLower();

                        foreach (SubjectDTO subject in Subjects)
                        {

                            if (subject.SubjectName.ToLower().Contains(name))
                            {
                                FilteredSubjects.Add(subject);
                            }
                        }
                    }
                    else if (searchSplit.Length == 2)
                    {
                        string name = searchSplit[0].Trim();
                        name = name.ToLower();
                        string subjId = searchSplit[1].Trim();
                        subjId = subjId.ToLower();

                        foreach (SubjectDTO subject in Subjects)
                        {
                            if (subject.SubjectName.ToLower().Contains(name) && subject.SubjectID.ToLower().Contains(subjId))
                            {
                                FilteredSubjects.Add(subject);
                            }
                        }
                    }
                    ShowFilteredSubjects(FilteredSubjects);
                }
                else if (Tab.SelectedIndex == 3)
                {
                    Update();
                    ObservableCollection<ProfessorDTO> FilteredProfessors = new ObservableCollection<ProfessorDTO>();
                    string[] searchSplit = searchBarString.Split(",");

                    if (searchSplit.Length == 1)
                    {
                        string surname = searchSplit[0].Trim();
                        surname = surname.ToLower();

                        foreach (ProfessorDTO professor in Professors)
                        {

                            if (professor.ProfessorSurname.ToLower().Contains(surname))
                            {
                                FilteredProfessors.Add(professor);
                            }
                        }
                    }
                    else if (searchSplit.Length == 2)
                    {
                        string surname = searchSplit[0].Trim();
                        surname = surname.ToLower();
                        string name = searchSplit[1].Trim();
                        name=name.ToLower();

                        foreach (ProfessorDTO professor in Professors)
                        {
                            if (professor.ProfessorSurname.ToLower().Contains(surname) && professor.ProfessorName.ToLower().Contains(name))
                            {
                                FilteredProfessors.Add(professor);
                            }
                        }
                    }
                    ShowFilteredProfessors(FilteredProfessors);
                }
            }
            else
            {
                if (Tab.SelectedIndex == 0)
                {
                    Update();
                }
                if (Tab.SelectedIndex == 2)
                {
                    Update();
                }
                if (Tab.SelectedIndex == 3)
                {
                    Update();
                }
            }
        }

        private void OpenNewLayout(object sender, RoutedEventArgs e)
        {
            if (Tab.SelectedIndex == 0)
            {
                NewStudent newStudent = new NewStudent(Students);
                newStudent.Owner = this;
                newStudent.ShowDialog();
            }
            else if (Tab.SelectedIndex == 1)
            {

            }
            else if (Tab.SelectedIndex == 2)
            {
                NewSubject newSubject = new NewSubject(Subjects,Professors);
                newSubject.Owner = this;
                newSubject.ShowDialog();
            }
            else if (Tab.SelectedIndex == 3)
            {
                NewProfessor newProfessor = new NewProfessor(Professors);
                newProfessor.Owner = this;
                newProfessor.ShowDialog();
            }
            else if (Tab.SelectedIndex == 4)
            {
                NewDepartment newDepartment = new NewDepartment(Departments,Professors);
                newDepartment.Owner = this;
                newDepartment.ShowDialog();
            }
        }
        private void ClickSave(object sender, RoutedEventArgs e)
        {
            Save save = new Save();
            save.ShowDialog();
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
                    MessageBox.Show("Please choose a student you want to edit!", "Student not selected");
                }
                else
                {
                    EditStudent editStudent = new EditStudent(SelectedStudent,Students);
                    editStudent.Owner = this;
                    editStudent.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 1)
            {
                if (SelectedExamGrade == null)
                {
                    MessageBox.Show("Please choose a grade you want to edit!", "Grade not selected");
                }
                else
                {
                    
                }
            }
            else if (Tab.SelectedIndex == 2)
            {
                if (SelectedSubject == null)
                {
                    MessageBox.Show("Please choose a subject you want to edit!", "Subject not selected");
                }
                else
                {
                    EditSubject editSubject = new EditSubject(SelectedSubject, Subjects,Professors);
                    editSubject.Owner = this;
                    editSubject.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 3)
            {
                if (SelectedProfessor == null)
                {
                    MessageBox.Show("Please choose a professor you want to edit!", "Professor not selected");
                }
                else
                {
                    EditProfesor editProfesor = new EditProfesor(SelectedProfessor, Professors);
                    editProfesor.Owner = this;
                    editProfesor.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 4)
            {
                if (SelectedDepartment == null)
                {
                    MessageBox.Show("Please choose a department you want to edit!", "Department not selected");
                }
                else
                {
                    EditDepartment editDepartment = new EditDepartment(SelectedDepartment, Departments,Professors);
                    editDepartment.Owner = this;
                    editDepartment.ShowDialog();
                }
            }
        }
        private void OpenDeleteWindow(object sender, RoutedEventArgs e)
        {
            
            if(Tab.SelectedIndex==0)
            {
                if(SelectedStudent == null)
                {
                    MessageBox.Show("Please choose a student you want to delete!", "Student not selected");
                }
                else
                {
                    Delete delete = new Delete(SelectedStudent,Students);
                    delete.Owner = this;
                    delete.ShowDialog();
                }
            }
            else if(Tab.SelectedIndex==1)
            {
                if(SelectedExamGrade == null)
                {
                    MessageBox.Show("Please choose a grade you want to delete!", "Grade not selected");
                }
                else
                {
                    Delete delete = new Delete(SelectedExamGrade,ExamGrades);
                    delete.Owner = this;
                    delete.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 2)
            {
                if (SelectedSubject == null)
                {
                    MessageBox.Show("Please choose a subject you want to delete!", "Subject not selected");
                }
                else
                {
                    Delete delete = new Delete(SelectedSubject, Subjects);
                    delete.Owner = this;
                    delete.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 3)
            {
                if (SelectedProfessor == null)
                {
                    MessageBox.Show("Please choose a professor you want to delete!", "Professor not selected");
                }
                else
                {
                    Delete delete = new Delete(SelectedProfessor, Professors);
                    delete.Owner = this;
                    delete.ShowDialog();
                }
            }
            else if (Tab.SelectedIndex == 4)
            {
                if (SelectedDepartment == null)
                {
                    MessageBox.Show("Please choose a department you want to delete!","Department not selected");
                }
                else
                {
                    Delete delete = new Delete(SelectedDepartment, Departments);
                    delete.Owner = this;
                    delete.ShowDialog();
                }
            }
        }
        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }
        public void StudentConditionWindow(object sender,RoutedEventArgs e)
        {
            if (Tab.SelectedIndex == 2)
            {
                if (SelectedSubject == null)
                {
                    MessageBox.Show("Please choose a subject!", "Subject not selected");
                }
                else
                {
                    StudentCondition studentCondition = new StudentCondition(SelectedSubject);
                    studentCondition.Owner = this;
                    studentCondition.ShowDialog();
                }
            }
            else if(Tab.SelectedIndex == 3)
            {
                if(SelectedProfessor == null)
                {
                    MessageBox.Show("Please select a professor!", "Professor not selected");
                }
                else
                {
                    ProfessorStudents professorStudents = new ProfessorStudents(SelectedProfessor);
                    professorStudents.Owner = this;
                    professorStudents.ShowDialog();
                }
            }
                
        }
        private void OpenStudents(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 0;
        }
        private void OpenGrades(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 1;
        }
        private void OpenSubjects(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 2;
        }
        private void OpenProfessors(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 3;
        }
        private void OpenDepartments(object sender, RoutedEventArgs e)
        {
            Tab.SelectedIndex = 4;
        }

        public void ShowFilteredStudents(ObservableCollection<StudentDTO> filteredStudents)
        {
            Students.Clear();
            foreach(StudentDTO student in filteredStudents)
            {
                Students.Add(student);
            }
        }
        public void ShowFilteredProfessors(ObservableCollection<ProfessorDTO> filteredProfessors)
        {
            Professors.Clear();
            foreach (ProfessorDTO professor in filteredProfessors)
            {
                Professors.Add(professor);
            }
        }
        public void ShowFilteredSubjects(ObservableCollection<SubjectDTO> filteredSubjects)
        {
            Subjects.Clear();
            foreach (SubjectDTO subject in filteredSubjects)
            {
                Subjects.Add(subject);
            }
        }
        public void Update()
        {
            Students.Clear();
            ExamGrades.Clear();
            Subjects.Clear();
            Professors.Clear();
            Departments.Clear();
            foreach (Student student in studentController.GetAllStudents()) Students.Add(new StudentDTO(student));
            foreach (ExamGrade examgrade in examGradeController.GetAllExamGrades()) ExamGrades.Add(new ExamGradeDTO(examgrade));
            foreach (Subject subject in subjectController.GetAllSubjects()) Subjects.Add(new SubjectDTO(subject));
            foreach (Professor professor in professorController.GetAllProfessors()) Professors.Add(new ProfessorDTO(professor));
            foreach (Katedra katedra in departmentController.GetAllKatedras()) Departments.Add(new KatedraDTO(katedra));
        }
        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        bool ascending = true;
        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {
            if (sender is DataGridColumnHeader columnHeader)
            {
          
                DataGridColumn column = columnHeader.Column;

                if (ascending)
                {
                    column.SortDirection = ListSortDirection.Ascending;
                    List<Student> allStudents = studentController.GetAllStudents();
                    var sortedStudents = allStudents.OrderBy(student => student, new StudentIndexComparer());

                    this.Students.Clear();
                    foreach (Student student in sortedStudents)
                    {
                        this.Students.Add(new StudentDTO(student));
                    }
      
                }
                else
                {
                    column.SortDirection = ListSortDirection.Descending;
                    List<Student> allStudents = studentController.GetAllStudents();
                    var sortedStudents = allStudents.OrderByDescending(student => student, new StudentIndexComparer());
        
                    this.Students.Clear();
                    foreach (Student student in sortedStudents)
                    {
                        this.Students.Add(new StudentDTO(student));
                    }

                }

                ascending = !ascending; 
            }
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.Header.ToString() == "Index")
            {
               e.Handled = true;
            }
          
        }

    }
}
