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
            Adress adresa = Adress.Parse(AddressTextBox.Text);
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string idCard = IDCardNumberTextBox.Text;
            string title = TitleTextBox.Text;
            int yearsofservice= int.Parse(YearsOfServiceTextBox.Text);
            DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);
            Professor profesor = new Professor(ime,prezime,dateofbirth,adresa,brojTelefona,email,idCard,title, yearsofservice);
            professorController.Add(profesor);
            professorDTO =new ProfessorDTO(profesor);
            Professors.Add(professorDTO);
            /*
            Student student = new Student(ime, prezime, dateofbirth, adresa, brojTelefona, email, brojIndexa, trenutnaGodinaStudija, nacinFinansiranja);
            studentController.Add(student);
            ProfessorDTO = new ProfessorDTO(student);
            Students.Add(ProfessorDTO);*/
            Close();
        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
