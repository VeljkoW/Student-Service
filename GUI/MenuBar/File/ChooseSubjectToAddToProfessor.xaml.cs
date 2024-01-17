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
        public ObservableCollection<SubjectDTO> SubjectList {  get; set; }
        public SubjectController subjectController { get; set; }
        public ProfessorDTO Professor;
        public ChooseSubjectToAddToProfessor(ProfessorDTO profesor,SubjectController subjectC,ObservableCollection<SubjectDTO> subjects)
        {
            InitializeComponent();
            subjectController = subjectC;
            Subjects = subjects;
            Professor = profesor;
            SubjectList = new ObservableCollection<SubjectDTO>();

            SubjectList.Clear();

            foreach (Subject subject in subjectController.GetAllSubjects())
            {
                if (subject.ProfessorId != Professor.ProfessorId && subject.ProfessorId == -1)
                {
                    SubjectList.Add(new SubjectDTO(subject));
                }
            }

            SubjectsComboBox.ItemsSource = SubjectList;
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
                            subject.ProfessorId = Professor.ProfessorId;
                            subjectController.Update(subject);
                            Subjects.Add(new SubjectDTO(subject));
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
