using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Controller;
using Branchenverzeichnis.Helper;
using Branchenverzeichnis.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Branchenverzeichnis.ViewModel
{
    public class IndustryDirectoryViewModel : ObservableObject
    {
        private CompanyController _companyController;
        private MasterDataController _masterDataController;

        private ObservableCollection<CompanyViewModel> _companyList = new ObservableCollection<CompanyViewModel>();
        public ObservableCollection<CompanyViewModel> CompanyList
        {
            get { return _companyList; }
            set
            {
                _companyList = value;
                RaisePropertyChanged("CompanyList");
            }
        }

        private ObservableCollection<IndustryViewModel> _industryList = new ObservableCollection<IndustryViewModel>();

        public ObservableCollection<IndustryViewModel> IndustryList
        {
            get { return _industryList; }
            set
            {
                _industryList = value;
                RaisePropertyChanged("IndustryList");
            }
        }

        private ObservableCollection<string> _industryListNames = new ObservableCollection<string>();

        public ObservableCollection<string> IndustryListNames
        {
            get { return new ObservableCollection<string>(_industryList.Select(i => i.Name)); }
            set
            {
                _industryListNames = value;
                RaisePropertyChanged("IndustryListNames");
            }
        }

        private CompanyViewModel _selectedCompany = new CompanyViewModel();
        public CompanyViewModel SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;
                RaisePropertyChanged("SelectedCompany");
            }
        }

        private string _searchWord = string.Empty;
        public string SearchWord
        {
            get { return _searchWord; }
            set
            {
                _searchWord = value;
                RaisePropertyChanged("SearchWord");
            }
        }

        public IndustryDirectoryViewModel()
        {
            _companyController = new CompanyController();
            _masterDataController = new MasterDataController();
            LoadCompanyList();
            LoadIndustryList();
        }
        private void RefreshCompanyList()
        {
            CompanyList.Clear();
            LoadCompanyList(SearchWord);
        }

        private bool CanExecute()
        {
            return true;
        }

        public void LoadCompanyList(string searchWord = null)
        {
            var tmpCompanyList = string.IsNullOrEmpty(searchWord)
                ? _companyController.GetCompanyList()
                : _companyController.GetCompanyList().Where(x => x.Name.ToUpper().Contains(searchWord.ToUpper()));
            
            FillCompanyList(tmpCompanyList);
        }

        private void FillCompanyList(IEnumerable<CompanyViewModel> companies)
        {
            foreach (var company in companies)
            {
                CompanyList.Add(company);
            }
        }

        public void LoadIndustryList()
        {
            var tmpIndustryList = _masterDataController.GetIndustryList();
            FillIndustryList(tmpIndustryList);
        }

        private void FillIndustryList(List<IndustryViewModel> industries)
        {
            foreach (var industry in industries)
            {
                IndustryList.Add(industry);
            }
        }

        private void DeleteExecute()
        {
            if (SelectedCompany == null)
                return;

            _companyController.DeleteCompany(SelectedCompany.CompanyID);
            RefreshCompanyList();
        }

        public ICommand Delete
        {
            get { return new RelayCommand(DeleteExecute, CanExecute); }
        }
    }
}
