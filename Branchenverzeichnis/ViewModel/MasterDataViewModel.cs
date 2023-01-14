using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Controller;
using Branchenverzeichnis.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Branchenverzeichnis.ViewModel
{
    public class MasterDataViewModel : ObservableObject
    {
        private EditMode _eIndustryMode;
        private EditMode _eProductMode;

        private MasterDataController _masterDataController;

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

        private IndustryViewModel _selectedIndustry;

        public IndustryViewModel SelectedIndustry
        {
            get { return _selectedIndustry; }
            set 
            { 
                _selectedIndustry = value;
                RaisePropertyChanged("SelectedIndustry");
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

        private ProductViewModel _selectedProduct;

        public ProductViewModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        #region ViewControl
        private SolidColorBrush _newIndustryEntryBackground = new SolidColorBrush(Colors.White);
        public SolidColorBrush NewIndustryEntryBackground
        {
            get { return _newIndustryEntryBackground; }
            set
            {
                _newIndustryEntryBackground = value;
                RaisePropertyChanged("NewIndustryEntryBackground");
            }
        }

        private SolidColorBrush _newProductEntryBackground = new SolidColorBrush(Colors.White);
        public SolidColorBrush NewProductEntryBackground
        {
            get { return _newProductEntryBackground; }
            set
            {
                _newProductEntryBackground = value;
                RaisePropertyChanged("NewProductEntryBackground");
            }
        }

        private bool _isIndustryEnabled = true;
        public bool IsIndustryEnabled
        {
            get { return _isIndustryEnabled; }
            set
            {
                _isIndustryEnabled = value;
                RaisePropertyChanged("IsIndustryEnabled");
            }
        }

        private bool _isProductEnabled = true;
        public bool IsProductEnabled
        {
            get { return _isProductEnabled; }
            set
            {
                _isProductEnabled = value;
                RaisePropertyChanged("IsProductEnabled");
            }
        }
        #endregion

        public MasterDataViewModel()
        {
            _masterDataController = new MasterDataController();
            LoadIndustryList();
            LoadProductList();
            _eIndustryMode = EditMode.Edit;
            _eProductMode = EditMode.Edit;
        }

        private void RefreshIndustryList()
        {
            IndustryList.Clear();
            LoadIndustryList();
        }

        private bool ValidateIndustryInput(IndustryViewModel industryView)
        {
            return ValidateInput(industryView.Name);
        }

        private bool CanExecute()
        {
            return true;
        }

        public void LoadIndustryList()
        {
            var tmpIndustryList = _masterDataController.GetIndustryList();

            FillIndustryList(tmpIndustryList);
        }

        private void FillIndustryList(IEnumerable<IndustryViewModel> industries)
        {
            foreach (var industry in industries)
            {
                IndustryList.Add(industry);
            }
        }

        private void NewIndustryEntryExecute()
        {
            SelectedIndustry = null;
            if (_eIndustryMode == EditMode.Edit)
            {
                _eIndustryMode = EditMode.New;
                NewIndustryEntryBackground = Brushes.Green;
                IsIndustryEnabled = false;
            }
            else
            {
                _eIndustryMode = EditMode.Edit;
                NewIndustryEntryBackground = Brushes.White;
                IsIndustryEnabled = true;
            }

            if (SelectedIndustry != null)
                return;

            SelectedIndustry = new IndustryViewModel();
        }

        public ICommand NewIndustryEntry
        {
            get { return new RelayCommand(NewIndustryEntryExecute, CanExecute); }
        }

        private void SaveIndustryExecute()
        {
            if (_eIndustryMode == EditMode.Edit)
            {
                if (SelectedIndustry == null)
                    return;
                if (!ValidateIndustryInput(SelectedIndustry))
                    return;

                _masterDataController.UpdateIndustry(SelectedIndustry);
            }
            else
            {
                if (!ValidateIndustryInput(SelectedIndustry))
                    return;

                _masterDataController.EntryIndustry(SelectedIndustry);
            }

            RefreshIndustryList();
        }

        public ICommand SaveIndustry
        {
            get { return new RelayCommand(SaveIndustryExecute, CanExecute); }
        }

        private void DeleteIndustryExecute()
        {
            if (SelectedIndustry == null)
                return;

            _masterDataController.DeleteIndustry(SelectedIndustry.IndustryID);
            RefreshIndustryList();
        }

        public ICommand DeleteIndustry
        {
            get { return new RelayCommand(DeleteIndustryExecute, CanExecute); }
        }

        private void RefreshProductList()
        {
            ProductList.Clear();
            LoadProductList();
        }

        private bool ValidateProductInput(ProductViewModel productView)
        {
            return ValidateInput(productView.Name);
        }

        private static bool ValidateInput(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                System.Windows.Forms.MessageBox.Show($"Bitte alle Felder komplett ausfüllen!", "Hinweis", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void LoadProductList()
        {
            var tmpProductList = _masterDataController.GetProductList();

            FillProductList(tmpProductList);
        }

        private void FillProductList(IEnumerable<ProductViewModel> products)
        {
            foreach (var product in products)
            {
                ProductList.Add(product);
            }
        }

        private void NewProductEntryExecute()
        {
            SelectedProduct = null;
            if (_eProductMode == EditMode.Edit)
            {
                _eProductMode = EditMode.New;
                NewProductEntryBackground = Brushes.Green;
                IsProductEnabled = false;
            }
            else
            {
                _eProductMode = EditMode.Edit;
                NewProductEntryBackground = Brushes.White;
                IsProductEnabled = true;
            }

            if (SelectedProduct != null)
                return;

            SelectedProduct = new ProductViewModel();
        }

        public ICommand NewProductEntry
        {
            get { return new RelayCommand(NewProductEntryExecute, CanExecute); }
        }

        private void SaveProductExecute()
        {
            if (_eProductMode == EditMode.Edit)
            {
                if (SelectedProduct == null)
                    return;
                if (!ValidateProductInput(SelectedProduct))
                    return;

                _masterDataController.UpdateProduct(SelectedProduct);
            }
            else
            {
                if (!ValidateProductInput(SelectedProduct))
                    return;

                _masterDataController.EntryProduct(SelectedProduct);
            }

            RefreshProductList();
        }

        public ICommand SaveProduct
        {
            get { return new RelayCommand(SaveProductExecute, CanExecute); }
        }

        private void DeleteProductExecute()
        {
            if (SelectedProduct == null)
                return;

            _masterDataController.DeleteProduct(SelectedProduct.ProductID);
            RefreshProductList();
        }

        public ICommand DeleteProduct
        {
            get { return new RelayCommand(DeleteProductExecute, CanExecute); }
        }
    }
}
