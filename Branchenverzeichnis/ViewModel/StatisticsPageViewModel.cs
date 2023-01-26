using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Controller;
using Branchenverzeichnis.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.ViewModel
{
    public class StatisticsPageViewModel : ObservableObject
    {
        private readonly StatisticsController _statisticsController;

        private ObservableCollection<StatisticsViewModel> _industryStatisticsList = new ObservableCollection<StatisticsViewModel>();

        public ObservableCollection<StatisticsViewModel> IndustryStatisticsList
        {
            get { return _industryStatisticsList; }
            set
            {
                _industryStatisticsList = value;
                RaisePropertyChanged("IndustryStatisticsList");
            }
        }

        private ObservableCollection<StatisticsViewModel> _productStatisticsList = new ObservableCollection<StatisticsViewModel>();

        public ObservableCollection<StatisticsViewModel> ProductStatisticsList
        {
            get { return _productStatisticsList; }
            set
            {
                _productStatisticsList = value;
                RaisePropertyChanged("ProductStatisticsList");
            }
        }

        public StatisticsPageViewModel()
        {
            _statisticsController = new StatisticsController();
            LoadIndustryStatisticsList();
            LoadProductStatisticsList();
        }

        private void LoadIndustryStatisticsList()
        {
            var industryStatistics = _statisticsController.GetIndustryStatistics();
            FillStatisticsList(industryStatistics, _industryStatisticsList);
        }

        private void LoadProductStatisticsList()
        {

            var productStatistics = _statisticsController.GetProductStatistics();
            FillStatisticsList(productStatistics, _productStatisticsList);
        }

        private void FillStatisticsList(Statistics industryStatistics, ObservableCollection<StatisticsViewModel> statisticsList)
        {
            statisticsList.Clear();

            var countSum = industryStatistics.StatisticsList.Sum(s => s.Count);

            foreach (var item in industryStatistics.StatisticsList.OrderByDescending(s => s.Count))
            {
                statisticsList.Add(new StatisticsViewModel()
                {
                    CategoryName = item.Theme,
                    Ratio = CalculateRatio(item.Count, countSum)
                });
            }
        }

        private static int CalculateRatio(int count, int countSum)
        {
            return (int)Math.Round((float)count / countSum * 100);
        }
    }
}
