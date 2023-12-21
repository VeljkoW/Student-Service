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

namespace GUI.MenuBar.File
{
    /// <summary>
    /// Interaction logic for New.xaml
    /// </summary>
    public partial class NewStudent : Window
    {
        public StudentDTO studentDTO {  get; set; }
        public StudentDAO studentDAO { get; set; }
        public NewStudent()
        {
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
            string adresa = AddressTextBox.Text;
            DateOnly dateofbirth = DateOnly.Parse(DateOfBirthTextBox.Text);
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string brojIndexa = IndexNumberTextBox.Text;
            string trenutnaGodinaStudija = YearTextBox.Text;
            string nacinFinansiranja = FinancingStatusComboBox.SelectedItem?.ToString();

            //Student student = studentDTO.ToStudent(ime, prezime, dateofbirth, adresa,brojTelefona,email,brojIndexa,trenutnaGodinaStudija,nacinFinansiranja);
            //studentDAO.AddStudent(student);
            Close();
        }

    }
}
