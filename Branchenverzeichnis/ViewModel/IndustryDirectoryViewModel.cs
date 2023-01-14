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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Branchenverzeichnis.ViewModel
{
    public enum EditMode { New, Edit };

    public class IndustryDirectoryViewModel : ObservableObject
    {
        private EditMode _eMode;

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

        #region ViewControl
        private SolidColorBrush _newEntryBackground = new SolidColorBrush(Colors.White);
        public SolidColorBrush NewEntryBackground
        {
            get { return _newEntryBackground; }
            set
            {
                _newEntryBackground = value;
                RaisePropertyChanged("NewEntryBackground");
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }
        #endregion

        public IndustryDirectoryViewModel()
        {
            _companyController = new CompanyController();
            _masterDataController = new MasterDataController();
            LoadCompanyList();
            LoadIndustryList();
            _eMode = EditMode.Edit;
        }
        private void RefreshCompanyList()
        {
            CompanyList.Clear();
            LoadCompanyList(SearchWord);
        }

        private bool ValidateCompanyInput(CompanyViewModel companyView)
        {
            if (string.IsNullOrEmpty(companyView.Name) ||
                string.IsNullOrEmpty(companyView.Phonenumber) ||
                string.IsNullOrEmpty(companyView.Street) ||
                string.IsNullOrEmpty(companyView.PLZ) ||
                string.IsNullOrEmpty(companyView.Location) ||
                string.IsNullOrEmpty(companyView.CeoFirstName) ||
                string.IsNullOrEmpty(companyView.CeoLastName))
            {
                MessageBox.Show($"Bitte alle Felder komplett ausfüllen!", "Hinweis", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            return true;
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

        private void NewEntryExecute()
        {
            SelectedCompany = null;
            if (_eMode == EditMode.Edit)
            {
                _eMode = EditMode.New;
                NewEntryBackground = Brushes.Green;
                IsEnabled = false;
            }
            else
            {
                _eMode = EditMode.Edit;
                NewEntryBackground = Brushes.White;
                IsEnabled = true;
            }

            if (SelectedCompany != null)
                return;

            SelectedCompany = new CompanyViewModel();
        }

        public ICommand NewEntry
        {
            get { return new RelayCommand(NewEntryExecute, CanExecute); }
        }

        private void SaveExecute()
        {
            if (_eMode == EditMode.Edit)
            {
                if (SelectedCompany == null)
                    return;
                if (!ValidateCompanyInput(SelectedCompany))
                    return;

                LoadSelectedIndustryID();

                _companyController.UpdateCompany(SelectedCompany);
            }
            else
            {
                if (!ValidateCompanyInput(SelectedCompany))
                    return;

                LoadSelectedIndustryID();

                _companyController.EntryCompany(SelectedCompany);
            }

            RefreshCompanyList();
        }

        private void LoadSelectedIndustryID()
        {
            SelectedCompany.IndustryID = _industryList.FirstOrDefault(i => i.Name.Equals(SelectedCompany.IndustryName))?.IndustryID;
        }

        public ICommand Save
        {
            get { return new RelayCommand(SaveExecute, CanExecute); }
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

        private void SearchExecute()
        {
            RefreshCompanyList();
        }

        public ICommand Search
        {
            get { return new RelayCommand(SearchExecute, CanExecute); }
        }
    }
}
