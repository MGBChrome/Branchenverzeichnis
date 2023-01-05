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
    public class MasterDataViewModel : ObservableObject
    {
        private MasterDataController _masterDataController;

        private ObservableCollection<IndustryViewModel> _industryList = new ObservableCollection<IndustryViewModel>();

        public ObservableCollection<IndustryViewModel> IndustryList
        {
            get { return _industryList; }
            set 
            {
                _industryList = value;
                RaisePropertyChanged("AbteilungList");
            }
        }

        private ObservableCollection<string> _industryListNames = new ObservableCollection<string>();
        public ObservableCollection<string> IndustryListNames
        {
            get { return new ObservableCollection<string>(_industryList.Select(x => x.Name)); }
            set
            {
                _industryListNames = value;
                RaisePropertyChanged("IndustryListNames");
            }
        }

        public MasterDataViewModel()
        {
            _masterDataController = new MasterDataController();
            LoadAbteilungList();
            IndustryListNames = new ObservableCollection<string>(_industryList.Select(i => i.Name));
        }

        private void LoadAbteilungList()
        {
            var industries = _masterDataController.GetIndustryList();
            foreach (var industry in industries)
            {
                IndustryList.Add(industry);
            }
        }
    }
}
