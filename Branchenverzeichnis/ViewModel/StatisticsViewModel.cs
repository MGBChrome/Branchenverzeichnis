using Branchenverzeichnis.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.ViewModel
{
    public class StatisticsViewModel : ObservableObject
    {
        private string _industryName = string.Empty;
        public string IndustryName
        {
            get { return _industryName; }
            set
            {
                _industryName = value;
                RaisePropertyChanged("IndustryName");
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
