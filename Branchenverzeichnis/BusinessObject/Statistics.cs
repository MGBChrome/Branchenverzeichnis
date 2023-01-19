using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class Statistics
    {
        public string Table { get; set; }
        public string Theme { get; set; }
        public int Count { get; set; }

        public List<Statistics> StatisticsList { get; set; }

        public Statistics()
        {
            StatisticsList = new List<Statistics>();
        }
    }
}
