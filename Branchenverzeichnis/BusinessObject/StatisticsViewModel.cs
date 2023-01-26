using Branchenverzeichnis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class StatisticsViewModel : ObservableObject
    {
        private string _industryName = string.Empty;
        public string CategoryName
        {
            get { return _industryName; }
            set
            {
                _industryName = value;
                RaisePropertyChanged("CategoryName");
            }
        }

        private int _ratio;
        public int Ratio
        {
            get { return _ratio; }
            set
            {
                _ratio = value;
                RaisePropertyChanged("Ratio");
            }
        }
    }
}
