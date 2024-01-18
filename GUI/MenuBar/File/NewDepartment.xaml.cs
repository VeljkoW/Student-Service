using CLI.Controller;
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
    /// Interaction logic for NewDepartment.xaml
    /// </summary>
    public partial class NewDepartment : Window
    {
        public KatedraDTO katedraDTO = new KatedraDTO();
        public KatedraController katedraController;
        public ProfessorController professorController;
        public ObservableCollection<KatedraDTO> Departments { get; set; }
        public ObservableCollection<ProfessorDTO> Professors { get; set; }

        public NewDepartment(ObservableCollection<KatedraDTO> katedras, ObservableCollection<ProfessorDTO> professors,KatedraController katedraC,ProfessorController professorC)
        {
            Departments = katedras;
            Professors = professors;
            katedraController = katedraC;
            professorController = professorC;
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
           

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Make sure you fill in the text box!", "Object missing", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                        Professor profa = new Professor(-1, "", "", DateOnly.Parse("12.12.2021"), new Adress(), "", "", "", "", 0);
                        Katedra katedra = new Katedra(ime,profa);
                        katedraController.Add(katedra);
                        katedraDTO = new KatedraDTO(katedra);
                        Departments.Add(katedraDTO);
                   
                Close();
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

    }
}
