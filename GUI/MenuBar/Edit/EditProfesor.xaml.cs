using CLI;
using CLI.Controller;
using CLI.Observer;
using GUI.DTO;
using GUI.MenuBar.File;
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
    public partial class EditProfesor : Window, IObserver
    {
        public ProfessorDTO professorDTO = new ProfessorDTO();
        public ProfessorController professorController = new ProfessorController();
        public ObservableCollection<ProfessorDTO> Professors { get; set; }
        public ObservableCollection<SubjectDTO> Subjects { get; set; }
        public SubjectController subjectController { get; set; }
        public SubjectDTO? SelectedSubject {  get; set; }


        ProfessorDTO selectedProfessor1;
        public EditProfesor(ProfessorDTO selectedProfessor, ObservableCollection<ProfessorDTO> professors)
        {
            DataContext = this;

            this.Professors = professors;
            selectedProfessor1 = selectedProfessor;
            Subjects = new ObservableCollection<SubjectDTO>();
            subjectController = new SubjectController();
            subjectController.Subscribe(this);

            InitializeComponent();

            NameTextBox.Text = selectedProfessor.ProfessorName;
            SurnameTextBox.Text = selectedProfessor.ProfessorSurname;
            StreetTextBox.Text = selectedProfessor.ProfessorAdress.Street;
            StreetNumberTextBox.Text = selectedProfessor.ProfessorAdress.StreetNumber.ToString();
            CityTextBox.Text = selectedProfessor.ProfessorAdress.City;
            StateTextBox.Text = selectedProfessor.ProfessorAdress.State;
            PhoneNumberTextBox.Text = selectedProfessor.PhoneNumber;
            EmailTextBox.Text = selectedProfessor.ProfessorEmail;
            IDCardNumberTextBox.Text = selectedProfessor.IDCardNumber;
            TitleTextBox.Text = selectedProfessor.ProfessorTitle;
            YearsOfServiceTextBox.Text = (selectedProfessor.YearsOfService).ToString();
            DateOfBirthDatePicker.Text = (selectedProfessor.DateOfBirth).ToString();

            Update();
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
            string idCard = IDCardNumberTextBox.Text;
            string title = TitleTextBox.Text;

            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(SurnameTextBox.Text) || string.IsNullOrEmpty(StreetTextBox.Text) || string.IsNullOrEmpty(StreetNumberTextBox.Text) || string.IsNullOrEmpty(CityTextBox.Text) || string.IsNullOrEmpty(StateTextBox.Text) || string.IsNullOrEmpty(PhoneNumberTextBox.Text) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(IDCardNumberTextBox.Text) || string.IsNullOrEmpty(TitleTextBox.Text) || string.IsNullOrEmpty(YearsOfServiceTextBox.Text) || string.IsNullOrEmpty(DateOfBirthDatePicker.Text))
            {
                MessageBox.Show("Make sure you fill in each text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!int.TryParse(StreetNumberTextBox.Text, out int result))
            {
                MessageBox.Show("Make sure you put a number in the street number texbox!", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (!int.TryParse(YearsOfServiceTextBox.Text, out int result1))
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
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        private void AddSubjectFun(object sender, RoutedEventArgs e)
        {
            ChooseSubjectToAddToProfessor chooseSubjectToAdd = new ChooseSubjectToAddToProfessor(selectedProfessor1);
            chooseSubjectToAdd.Owner = this;
            chooseSubjectToAdd.ShowDialog();
        }
        private void RemoveSubjectFun(object sender, RoutedEventArgs e)
        {
            MessageBoxResult R = MessageBox.Show("Are you sure you want to remove this subject?", "Remove the subject", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (R == MessageBoxResult.Yes)
            {
                if (SelectedSubject != null && subjectController.GetSubjectById(SelectedSubject.Id) != null)
                {
                    Subject? s = subjectController.GetSubjectById(SelectedSubject.Id);
                    if (s != null)
                    {
                        s.ProfessorId = -1;
                    subjectController.Update(s);
                    }
                    Update();
                }
            }
        }
        public void Update()
        {
            Subjects.Clear();
            foreach(Subject subject in  subjectController.GetAllSubjects())
            {
                if(subject.ProfessorId == selectedProfessor1.ProfessorId)
                {
                    Subjects.Add(new SubjectDTO(subject));
                }
            }
        }
    }
}
