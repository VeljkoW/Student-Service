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
    /// Interaction logic for ChooseSubjectToAddToProfessor.xaml
    /// </summary>
    public partial class ChooseSubjectToAddToProfessor : Window
    {
        public ChooseSubjectToAddToProfessor()
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

        }
        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
