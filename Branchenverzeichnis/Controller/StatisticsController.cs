using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Controller
{
    public class StatisticsController
    {
        private RepoCompany _modelCompany;
        private RepoCompanyProduct _modelCompanyProduct;

        public StatisticsController()
        {
            _modelCompany = new RepoCompany();
            _modelCompanyProduct = new RepoCompanyProduct();
        }

        // Read
        public Statistics GetIndustryStatistics()
        {
            var industryStatistics = _modelCompany.GetIndustryStatistics();

            var statistics = new Statistics();

            foreach (var item in industryStatistics)
            {
                var statistic = new Statistics()
                {
                    Table = "Industry",
                    Theme = item.Field,
                    Count = item.Ncount
                };

                statistics.StatisticsList.Add(statistic);
            }

            return statistics;
        }

        public Statistics GetProductStatistics()
        {
            var productStatistics = _modelCompanyProduct.GetProductStatistics();

            var statistics = new Statistics();

            foreach (var item in productStatistics)
            {
                var statistic = new Statistics()
                {
                    Table = "Product",
                    Theme = item.Field,
                    Count = item.Ncount
                };

                statistics.StatisticsList.Add(statistic);
            }

            return statistics;
        }
    }
}
