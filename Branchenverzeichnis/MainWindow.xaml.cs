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
        }

        
        private void OpenCompanyPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenMasterData_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MasterDataPage();
        }
    }
}
