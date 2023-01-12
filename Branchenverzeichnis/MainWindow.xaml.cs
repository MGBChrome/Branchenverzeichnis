using Branchenverzeichnis.View;
using System.Windows;

namespace Branchenverzeichnis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new CompaniesPage();
        }

        
        private void OpenCompanyPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CompaniesPage();
        }

        private void OpenMasterData_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MasterDataPage();
        }
    }
}
