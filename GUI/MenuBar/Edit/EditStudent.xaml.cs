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
            AddressTextBox.Text = (selectedStudent.Adress).ToString();
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
            Adress adresa = Adress.Parse(AddressTextBox.Text);
            DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            CLI.Index brojIndexa = CLI.Index.Parse(IndexNumberTextBox.Text);
            int trenutnaGodinaStudija = int.Parse(YearTextBox.Text);
            Status nacinFinansiranja;
            if (FinancingStatusComboBox.Text.ToString() == "Samofinansiranje")
            {
                nacinFinansiranja = Status.SAMOFINANSIRANJE;
            }
            else
            {
                nacinFinansiranja = Status.BUDZET;
            }

            Student student = new Student(selectedStudent1.Id,ime, prezime, dateofbirth, adresa, brojTelefona, email, brojIndexa, trenutnaGodinaStudija, nacinFinansiranja);
            studentController.Update(student);
            
            studentDTO = new StudentDTO(student);
           
            for(int i = 0; i < Students.Count; i++)
            {
                if(Students[i].Id == student.Id)
                {
                    Students[i] = studentDTO;
                }
            }
            
            Close();

        }
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
