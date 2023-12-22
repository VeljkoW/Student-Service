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

namespace GUI.MenuBar.Edit
{
    public partial class EditSubject : Window
    {
        public SubjectDTO subjectDTO = new SubjectDTO();
        public SubjectController studentController = new SubjectController();
        public ObservableCollection<SubjectDTO> Subjects { get; set; }
        SubjectDTO selectedStudent1;
        public EditSubject(SubjectDTO selectedSubject, ObservableCollection<SubjectDTO> subjects)
        {
            Subjects = subjects;
            selectedStudent1 = selectedSubject;
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
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
