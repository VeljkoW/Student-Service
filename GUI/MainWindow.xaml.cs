using GUI.MenuBar.File;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        public ObservableCollection<StudentDTO> Students { get; set; }

        public ObservableCollection<ExamGradeDTO> ExamGrades { get; set; }

        public ObservableCollection<KatedraDTO> Katedras { get; set; }

        public StudentDTO? SelectedStudent { get; set; }

        public ExamGradeDTO? SelectedExamGrade {  get; set; }

        public KatedraDTO? SelectedKatedra { get; set; }

        private StudentController studentController {  get; set; }

        private ExamGradeController examGradeController { get; set; }

        private KatedraController katedraController { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Students = new ObservableCollection<StudentDTO>();
            ExamGrades = new ObservableCollection<ExamGradeDTO>();
            Katedras = new ObservableCollection<KatedraDTO>();
            studentController = new StudentController();
            examGradeController = new ExamGradeController();
            katedraController = new KatedraController();
            katedraController.Subscribe(this);
            examGradeController.Subscribe(this);
            studentController.Subscribe(this);
            Update();

            
        }

        private void LoadFunctions(object sender, RoutedEventArgs e)
        {
            CenterWindowFunction();
            StatusBarCurrentTimeAndDate();
        }
        private void StatusBarCurrentTimeAndDate()
        {
            
            statusBarDateAndTime.Text = $"{DateTime.Now.ToString("HH:mm  dd.MM.yyyy.")}";
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
            New sle = new New();
            sle.Show();
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
            Close sle = new Close();
            sle.Show();
        }
        private void OpenEditWindow(object sender, RoutedEventArgs e)
        {
            Edit sle = new Edit();
            sle.Show();
        }
        private void OpenDeleteWindow(object sender, RoutedEventArgs e)
        {
            Delete sle = new Delete();
            sle.Show();
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
            Katedras.Clear();
            foreach (Student student in studentController.GetAllStudents()) Students.Add(new StudentDTO(student));
            foreach (ExamGrade examgrade in examGradeController.GetAllExamGrades()) ExamGrades.Add(new ExamGradeDTO(examgrade));
            foreach (Katedra katedra in katedraController.GetAllKatedras()) Katedras.Add(new KatedraDTO(katedra)) ;
        }
    }
}
