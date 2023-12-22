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

namespace GUI.MenuBar.File
{
    public partial class NewStudent : Window
    {
        public StudentDTO studentDTO = new StudentDTO();
        public StudentController studentController = new StudentController();
        public ObservableCollection<StudentDTO> Students { get; set; }
       

        public NewStudent(ObservableCollection<StudentDTO> students)
        {
            Students = students;
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

            string ime = NameTextBox.Text;
            string prezime = SurnameTextBox.Text;
            Adress adresa = Adress.Parse(AddressTextBox.Text);
            DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            CLI.Index brojIndexa = CLI.Index.Parse(IndexNumberTextBox.Text);
            int trenutnaGodinaStudija = int.Parse(YearTextBox.Text);
            Status nacinFinansiranja;
            if(FinancingStatusComboBox.Text.ToString() == "Samofinansiranje")
            {
                nacinFinansiranja = Status.SAMOFINANSIRANJE;
            }
            else
            {
                nacinFinansiranja = Status.BUDZET;
            }

            Student student = new Student(ime, prezime, dateofbirth, adresa,brojTelefona,email,brojIndexa,trenutnaGodinaStudija,nacinFinansiranja);
            studentController.Add(student);
            studentDTO =new StudentDTO(student);
            Students.Add(studentDTO);
            Close();
        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
