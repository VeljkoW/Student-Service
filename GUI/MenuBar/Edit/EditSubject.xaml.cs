using CLI;
using CLI.Controller;
using CLI.models.Enums;
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
    public partial class EditSubject : Window
    {
        public SubjectDTO subjectDTO = new SubjectDTO();
        public SubjectController subjectController;
        public ObservableCollection<SubjectDTO> Subjects { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        public ObservableCollection<ProfessorDTO> ProfessorsTemp = new ObservableCollection<ProfessorDTO> ();
        public SubjectDTO selectedSubject1;
        public EditSubject(SubjectDTO selectedSubject, ObservableCollection<SubjectDTO> subjects,ObservableCollection<ProfessorDTO> professors,SubjectController subjectC)
        {
            subjectController= subjectC;
            Subjects = subjects;
            Professors = professors;
            Professor profa = new Professor(-1,"", "No professor currently", DateOnly.Parse("12.12.2021"),new Adress(), "", "", "", "",0);
            ProfessorDTO nullproff = new ProfessorDTO (profa);
            ProfessorsTemp.Add(nullproff);

            foreach(ProfessorDTO p in Professors )
            {
                ProfessorsTemp.Add (p);
            }
            selectedSubject1 = selectedSubject;
            InitializeComponent();

            ProfessorComboBox.ItemsSource = ProfessorsTemp;
            ProfessorComboBox.DisplayMemberPath = "ProfessorNameAndSurname";

            SubjectIDTextBox.Text = selectedSubject.SubjectID;
            SubjectNameTextBox.Text = selectedSubject.SubjectName;
            foreach(ProfessorDTO prof in ProfessorsTemp)
            {
                if(selectedSubject.ProfessorId == prof.ProfessorId)
                {
                    ProfessorComboBox.Text = prof.ProfessorNameAndSurname;
                }
            }

            ESPBNameTextBox.Text = selectedSubject.ESPBPoints.ToString();
            if (selectedSubject.Semestar == Semester.ZIMSKI)
            {
                SemesterStatusComboBox.Text = "Zimski";
            }
            else
            {
                SemesterStatusComboBox.Text = "Letnji";
            }
            switch (selectedSubject.Year)
            {
                case 1:
                    YearStatusComboBox.Text = "1";
                    break;
                case 2:
                    YearStatusComboBox.Text = "2";
                    break;
                case 3:
                    YearStatusComboBox.Text = "3";
                    break;
                default:
                    YearStatusComboBox.Text = "4";
                    break;
            }

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
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string subjectID = SubjectIDTextBox.Text;
            string subjectName = SubjectNameTextBox.Text;

            string professor = ProfessorComboBox.Text;
            int professorId = 0;
            if (professor == "No professor currently")
            {
                professorId = -1;
            }
            else
            {
                foreach (ProfessorDTO prof in ProfessorsTemp)
                {
                    if (prof.ProfessorNameAndSurname == professor)
                    {
                        professorId = prof.ProfessorId;
                    }
                }
            }

            Semester semestar;
            if (SemesterStatusComboBox.Text.ToString() == "Letnji")
            {
                semestar = Semester.LETNJI;
            }
            else
            {
                semestar = Semester.ZIMSKI;
            }
           
            if (string.IsNullOrEmpty(SubjectIDTextBox.Text) || string.IsNullOrEmpty(SubjectNameTextBox.Text) || string.IsNullOrEmpty(ESPBNameTextBox.Text) || string.IsNullOrEmpty(SemesterStatusComboBox.Text) || string.IsNullOrEmpty(YearStatusComboBox.Text))
            {
                MessageBox.Show("Make sure you fill in each text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!int.TryParse(ESPBNameTextBox.Text, out int result))
            {
                MessageBox.Show("Make sure you put a number in the EspbPoints text box!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {

                int EspbPoints = int.Parse(ESPBNameTextBox.Text);
                int YearStatus;
                switch (YearStatusComboBox.Text.ToString())
                {
                    case "1":
                        YearStatus = 1;
                        break;
                    case "2":
                        YearStatus = 2;
                        break;
                    case "3":
                        YearStatus = 3;
                        break;
                    default:
                        YearStatus = 4;
                        break;
                }
                Subject subject = new Subject(selectedSubject1.Id, subjectID, subjectName, semestar, YearStatus,professorId, EspbPoints);

                subjectController.Update(subject);

                subjectDTO = new SubjectDTO(subject);

                for (int i = 0; i < Subjects.Count; i++)
                {
                    if (Subjects[i].Id == subject.Id)
                    {
                        Subjects[i] = subjectDTO;
                    }
                }
                Close();

            }
        }
    }
}
