using Branchenverzeichnis.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Branchenverzeichnis.View
{
    /// <summary>
    /// Interaction logic for CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : Page
    {
        public CompaniesPage()
        {
            InitializeComponent();
        }

        private void TxbCompProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (IndustryDirectoryViewModel)CompanyList.DataContext;
            string productName = (sender as ComboBox).SelectedItem as string;
            viewModel.SelectNewProductExecute(productName);
        }
    }
}
