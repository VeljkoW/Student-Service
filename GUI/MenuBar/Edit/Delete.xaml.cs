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
        public KatedraDTO? SelectedKatedra { get; }

        public StudentController studentController = new StudentController();
        public ExamGradeController examGradeController = new ExamGradeController();
        public KatedraController katedraController = new KatedraController();

        public ObservableCollection<StudentDTO>? Students { get; set; }
        public ObservableCollection<ExamGradeDTO>? ExamGrades { get; set; }

        public ObservableCollection<KatedraDTO>? Katedras { get; set; }
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
        //konstruktor za delete Katedra
        public Delete(KatedraDTO katedra,ObservableCollection<KatedraDTO> katedras)
        {
            this.SelectedKatedra = katedra;
            this.Katedras = katedras;
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
            else if(SelectedKatedra != null && Katedras != null)
            {
                katedraController.Delete(SelectedKatedra.Id);
                Katedras.Remove(SelectedKatedra);
                this.Close();
            }
        }

    }
}
