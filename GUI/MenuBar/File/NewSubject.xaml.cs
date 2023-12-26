using CLI.Controller;
using CLI.models.Enums;
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
    /// Interaction logic for NewSubject.xaml
    /// </summary>
    public partial class NewSubject : Window
    {
        public SubjectDTO subjectDTO = new SubjectDTO();
        public SubjectController subjectController = new SubjectController();
        public ObservableCollection<SubjectDTO> Subjects { get; set; }


        public NewSubject(ObservableCollection<SubjectDTO> subjects)
        {
            Subjects = subjects;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            string subjectID = SubjectIDTextBox.Text;
            string subjectName = SubjectNameTextBox.Text;
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
            else if(!int.TryParse(ESPBNameTextBox.Text,out int result))
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

                Subject subject = new Subject(subjectID, subjectName, semestar, YearStatus, EspbPoints);
                subjectController.Add(subject);
                subjectDTO = new SubjectDTO(subject);
                Subjects.Add(subjectDTO);

                Close();
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
