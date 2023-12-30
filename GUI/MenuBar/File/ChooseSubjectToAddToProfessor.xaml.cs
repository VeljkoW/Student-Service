using CLI;
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
    /// Interaction logic for ChooseSubjectToAddToProfessor.xaml
    /// </summary>
    public partial class ChooseSubjectToAddToProfessor : Window
    {
        public ObservableCollection<SubjectDTO> Subjects { get; set; }
        public SubjectController subjectController { get; set; }
        public ProfessorDTO Professor;
        public ChooseSubjectToAddToProfessor(ProfessorDTO profesor)
        {
            InitializeComponent();
            subjectController = new SubjectController();
            Subjects = new ObservableCollection<SubjectDTO>();
            Professor = profesor;

            foreach (Subject subject in subjectController.GetAllSubjects())
            {
                if (subject.ProfessorId != Professor.ProfessorId)
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
            string subjectName = SubjectsComboBox.Text;
            foreach (Subject subject in subjectController.GetAllSubjects())
            {
                if (subject.SubjectName == subjectName)
                {
                    if (subject.ProfessorId != -1)
                    {
                        MessageBoxResult R = MessageBox.Show("Are you sure you want to change the professor for this subject", "Professor already exists", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (R == MessageBoxResult.Yes)
                        {
                            subject.ProfessorId = Professor.ProfessorId; // Ne radi trenutno
                            this.Close();
                        }
                    }
                }
            }

        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
