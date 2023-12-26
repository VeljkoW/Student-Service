using CLI.Controller;
using CLI.models.Enums;
using CLI;
using GUI.DTO;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using GUI.MenuBar.File;

namespace GUI.MenuBar.Edit
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public StudentDTO studentDTO = new StudentDTO();
        public StudentController studentController = new StudentController();
        public ObservableCollection<StudentDTO> Students { get; set; }
        StudentDTO selectedStudent1;
        public EditStudent(StudentDTO selectedStudent,ObservableCollection<StudentDTO> students)
        {
            Students= students;
            selectedStudent1= selectedStudent;
            InitializeComponent();
            NameTextBox.Text = selectedStudent.StudentName;
            SurnameTextBox.Text = selectedStudent.Surname;
            StreetTextBox.Text = selectedStudent.Adress.Street;
            StreetNumberTextBox.Text = selectedStudent.Adress.StreetNumber.ToString();
            CityTextBox.Text = selectedStudent.Adress.City;
            StateTextBox.Text = selectedStudent.Adress.State;
            PhoneNumberTextBox.Text = selectedStudent.Phone;
            DateOfBirthDatePicker.Text = selectedStudent.DateOfBirth.ToString();
            EmailTextBox.Text = selectedStudent.Email;
            IndexNumberTextBox.Text = selectedStudent.StudentIndex.ToString();
            YearTextBox.Text = selectedStudent.StudentYear.ToString();
            if(selectedStudent.Status == CLI.models.Enums.Status.SAMOFINANSIRANJE)
            {
                FinancingStatusComboBox.Text = "Samofinansiranje";
            }
            else
            {
                FinancingStatusComboBox.Text = "Budžet";
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

            string ime = NameTextBox.Text;
            string prezime = SurnameTextBox.Text;
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            CLI.Index brojIndexa = CLI.Index.Parse(IndexNumberTextBox.Text);
            Status nacinFinansiranja;
            if (FinancingStatusComboBox.Text.ToString() == "Budžet")
            {
                nacinFinansiranja = Status.BUDZET;
            }
            else
            {
                nacinFinansiranja = Status.SAMOFINANSIRANJE;
            }

            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(StreetTextBox.Text) || string.IsNullOrEmpty(StreetNumberTextBox.Text) || string.IsNullOrEmpty(CityTextBox.Text) || string.IsNullOrEmpty(StateTextBox.Text) || string.IsNullOrEmpty(DateOfBirthDatePicker.Text) || string.IsNullOrEmpty(brojTelefona) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(IndexNumberTextBox.Text) || string.IsNullOrEmpty(YearTextBox.Text) || string.IsNullOrEmpty(FinancingStatusComboBox.Text))
            {
                MessageBox.Show("Make sure you fill in each text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!int.TryParse(YearTextBox.Text,out int result))
                {
                MessageBox.Show("Make sure you put a number in the Year texbox!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(!int.TryParse(StreetNumberTextBox.Text,out int result1))
            {
                MessageBox.Show("Make sure you put a number in the street number textbox!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);
                int ulica_broj = int.Parse(StreetNumberTextBox.Text);
                string ulica = StreetTextBox.Text;
                string grad = CityTextBox.Text;
                string drzava = StateTextBox.Text;
                Adress adresa = new Adress(ulica, ulica_broj, grad, drzava);
                int trenutnaGodinaStudija = int.Parse(YearTextBox.Text);
                Student student = new Student(selectedStudent1.Id, ime, prezime, dateofbirth, adresa, brojTelefona, email, brojIndexa, trenutnaGodinaStudija, nacinFinansiranja);
                studentController.Update(student);

                studentDTO = new StudentDTO(student);

                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].Id == student.Id)
                    {
                        Students[i] = studentDTO;
                    }
                }

                Close();

            }

        }
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DismissGradeFun(object sender, RoutedEventArgs e)
        {
            /*
            if (SelectedPassedSubjects == null)
            {
                MessageBox.Show("Please choose a subject which grade you want to dismiss!");
            }
            else
            {  */
                MessageBoxResult R = MessageBox.Show("Are you sure you want to dismiss this grade?", "Dismiss the grade", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (R == MessageBoxResult.Yes)
                {

                }
            //}
        }
        private void AddSubjectFun(object sender, RoutedEventArgs e)
        {
           ChooseSubjectToAddToStudent chooseSubjectToAdd = new ChooseSubjectToAddToStudent();
           chooseSubjectToAdd.Owner = this;
           chooseSubjectToAdd.ShowDialog();
        }
        private void RemoveSubjectFun(object sender, RoutedEventArgs e)
        {
            MessageBoxResult R = MessageBox.Show("Are you sure you want to remove this subject?", "Remove the subject", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (R == MessageBoxResult.Yes)
            {

            }
        }
        private void NewGradeFun(object sender, RoutedEventArgs e)
        {
            NewGrade newGrade = new NewGrade();
            newGrade.Owner = this;
            newGrade.ShowDialog();
        }
    }
}
