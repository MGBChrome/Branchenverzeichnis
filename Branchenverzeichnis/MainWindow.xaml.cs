using Branchenverzeichnis.Model;
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

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Debug-button clicked");
            Console.WriteLine("Print all products from database");

            IndustryDirectoryEntities context = new IndustryDirectoryEntities();
            var products = context.Product;
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID}; Name: {product.Name}");
            }

            Console.WriteLine("Print all industries from database");
            var repoIndustry = new RepoIndustry();
            PrintAllIndustries(repoIndustry);

            var newIndustry = new Industry()
            {
                Name = "ExampleIndustry" + DateTime.Now.Ticks
            };

            repoIndustry.EntryIndustry(newIndustry);

            PrintAllIndustries(repoIndustry);
        }

        private static void PrintAllIndustries(RepoIndustry repoIndustry)
        {
            foreach (var industry in repoIndustry.GetIndustryList())
            {
                Console.WriteLine($"ID: {industry.IndustryID}; Name: {industry.Name}");
            }
        }
    }
}
