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
    /// Interaction logic for NewProfessor.xaml
    /// </summary>
    public partial class NewProfessor : Window
    {
        public ProfessorDTO professorDTO = new ProfessorDTO();
        public ProfessorController professorController = new ProfessorController();
        public ObservableCollection<ProfessorDTO> Professors { get; set; }


        public NewProfessor(ObservableCollection<ProfessorDTO> proffesors)
        {
            Professors = proffesors;
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
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string idCard = IDCardNumberTextBox.Text;
            string title = TitleTextBox.Text;

            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(SurnameTextBox.Text) || string.IsNullOrEmpty(StreetTextBox.Text) || string.IsNullOrEmpty(StreetNumberTextBox.Text) || string.IsNullOrEmpty(CityTextBox.Text) || string.IsNullOrEmpty(StateTextBox.Text) || string.IsNullOrEmpty(PhoneNumberTextBox.Text) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(IDCardNumberTextBox.Text) || string.IsNullOrEmpty(TitleTextBox.Text) || string.IsNullOrEmpty(YearsOfServiceTextBox.Text) || string.IsNullOrEmpty(DateOfBirthDatePicker.Text))
            {
                MessageBox.Show("Make sure you fill in each text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(!int.TryParse(StreetNumberTextBox.Text,out int result))
            {
                MessageBox.Show("Make sure you put a number in the street number texbox!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(!int.TryParse(YearsOfServiceTextBox.Text,out int result1))
            {
                MessageBox.Show("Make sure you put a number in the years of service texbox!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string ulica = StreetTextBox.Text;
                int ulica_broj = int.Parse(StreetNumberTextBox.Text);
                string grad = CityTextBox.Text;
                string drzava = StateTextBox.Text;
                Adress adresa = new Adress(ulica, ulica_broj, grad, drzava);
                int yearsofservice = int.Parse(YearsOfServiceTextBox.Text);
                DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);

                Professor profesor = new Professor(ime, prezime, dateofbirth, adresa, brojTelefona, email, idCard, title, yearsofservice);
                professorController.Add(profesor);
                professorDTO = new ProfessorDTO(profesor);
                Professors.Add(professorDTO);
                Close();
            }
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
