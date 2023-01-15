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

        private ObservableCollection<ProductViewModel> _productList = new ObservableCollection<ProductViewModel>();

        public ObservableCollection<ProductViewModel> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                RaisePropertyChanged("ProductList");
            }
        }

        private ObservableCollection<string> _productListNames = new ObservableCollection<string>();

        public ObservableCollection<string> ProductListNames
        {
            get { return _productListNames; }
            set
            {
                _industryListNames = value;
                RaisePropertyChanged("ProductListNames");
            }
        }

        private CompanyViewModel _selectedCompany = new CompanyViewModel();
        public CompanyViewModel SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;
                SelectedNewProduct = new ProductViewModel();
                RefreshProductList();
                RaisePropertyChanged("SelectedCompany");
            }
        }

        private ProductViewModel _selectedProduct = new ProductViewModel();

        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        private ProductViewModel _selectedNewProduct = new ProductViewModel();

        public ProductViewModel SelectedNewProduct
        {
            get { return _selectedNewProduct; }
            set
            {
                _selectedNewProduct = value;
                RaisePropertyChanged("SelectedNewProduct");
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
            LoadProductList();
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

        private void LoadCompanyList(string searchWord = null)
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

        private void LoadIndustryList()
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

        private void LoadProductList()
        {
            var tmpProductList = _masterDataController.GetProductList();
            FillProductList(tmpProductList);
        }

        private void FillProductList(List<ProductViewModel> products)
        {
            foreach (var product in products)
            {
                ProductListNames.Add(product.Name);
            }
        }

        private void RefreshProductList()
        {
            ProductList.Clear();
            LoadCompanyProductList();
        }

        private void LoadCompanyProductList()
        {
            var tmpCompanyProductList = _companyController.GetCompanyProductList();

            FillProductList(tmpCompanyProductList);
        }

        private void FillProductList(IEnumerable<CompanyProductViewModel> companyProductList)
        {
            if (SelectedCompany == null || SelectedCompany.CompanyID == 0)
                return;

            foreach (var companyProduct in companyProductList.Where(cp => cp.CompanyID == SelectedCompany.CompanyID))
            {
                ProductList.Add(new ProductViewModel()
                {
                    ProductID = companyProduct.ProductID,
                    Name = companyProduct.ProductName
                });
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

        private void DeleteProductExecute()
        {
            if (SelectedProduct == null ||
                SelectedProduct.ProductID == 0)
                return;

            _companyController.DeleteCompanyProduct(SelectedCompany.CompanyID, SelectedProduct.ProductID);
            RefreshProductList();
        }

        public ICommand DeleteProduct
        {
            get { return new RelayCommand(DeleteProductExecute, CanExecute); }
        }

        private void SearchExecute()
        {
            RefreshCompanyList();
        }

        public ICommand Search
        {
            get { return new RelayCommand(SearchExecute, CanExecute); }
        }

        public void SelectNewProductExecute(string productName)
        {
            if (string.IsNullOrEmpty(productName) || SelectedCompany == null)
                return;

            CompanyProductViewModel newCompanyProductView = CreateNewCompanyProductViewModel(productName);

            _companyController.EntryCompanyProduct(newCompanyProductView);
            RefreshProductList();
        }

        private CompanyProductViewModel CreateNewCompanyProductViewModel(string productName)
        {
            var selectedProductID = GetSelectedNewProductID(productName);
            var newCompanyProductView = new CompanyProductViewModel()
            {
                CompanyID = SelectedCompany?.CompanyID ?? 0,
                ProductID = selectedProductID
            };

            return newCompanyProductView;
        }

        private int GetSelectedNewProductID(string productName)
        {
            var selectedProductView = _masterDataController.GetProductList().FirstOrDefault(p => p.Name.Equals(productName));
            return selectedProductView?.ProductID ?? 0;
        }
    }
}
