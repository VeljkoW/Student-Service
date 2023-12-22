using CLI;
using CLI.Controller;
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
    /// <summary>
    /// Interaction logic for EditProfesor.xaml
    /// </summary>
    public partial class EditProfesor : Window
    {
        public ProfessorDTO professorDTO = new ProfessorDTO();
        public ProfessorController professorController = new ProfessorController();
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        ProfessorDTO selectedProfessor1;
        public EditProfesor(ProfessorDTO selectedProfessor, ObservableCollection<ProfessorDTO> professors)
        {
            this.Professors = professors;
            selectedProfessor1 = selectedProfessor;
            InitializeComponent();
            NameTextBox.Text = selectedProfessor.ProfessorName;
            SurnameTextBox.Text = selectedProfessor.ProfessorSurname;
            AddressTextBox.Text = (selectedProfessor.ProfessorAdress).ToString();
            PhoneNumberTextBox.Text = selectedProfessor.PhoneNumber;
            EmailTextBox.Text = selectedProfessor.ProfessorEmail;
            IDCardNumberTextBox.Text = selectedProfessor.IDCardNumber;
            TitleTextBox.Text = selectedProfessor.ProfessorTitle;
            YearsOfServiceTextBox.Text = (selectedProfessor.YearsOfService).ToString();
            DateOfBirthDatePicker.Text = (selectedProfessor.DateOfBirth).ToString();
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
            string brojTelefona = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string idCard = IDCardNumberTextBox.Text;
            string title = TitleTextBox.Text;
            int yearsofservice = int.Parse(YearsOfServiceTextBox.Text);
            DateOnly dateofbirth = DateOnly.Parse(DateOfBirthDatePicker.Text);
            Professor profesor = new Professor(selectedProfessor1.ProfessorId, ime, prezime, dateofbirth, adresa, brojTelefona, email, idCard, title, yearsofservice);
            professorController.Update(profesor);

            professorDTO = new ProfessorDTO(profesor);

            for (int i = 0; i < Professors.Count; i++)
            {
                if (Professors[i].ProfessorId == profesor.Id)
                {
                    Professors[i] = professorDTO;
                }
            }

            Close();
        }
    }
}
