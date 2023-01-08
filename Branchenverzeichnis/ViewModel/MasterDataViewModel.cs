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
        private enum EditMode { New, Edit };
        private EditMode _eMode;

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

        public MasterDataViewModel()
        {
            _masterDataController = new MasterDataController();
            LoadIndustryList();
            IndustryListNames = new ObservableCollection<string>(_industryList.Select(i => i.Name));
            _eMode = EditMode.Edit;
        }

        private void RefreshIndustryList()
        {
            IndustryList.Clear();
            //GetIndustryList(SearchWord);
            LoadIndustryList();
        }

        private bool ValidateIndustryInput(IndustryViewModel industryView)
        {
            if (string.IsNullOrEmpty(industryView.Name))
            {
                System.Windows.Forms.MessageBox.Show($"Bitte alle Felder komplett ausfüllen!", "Hinweis", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool CanExecute()
        {
            return true;
        }

        public void LoadIndustryList(string searchWord = null)
        {
            var tmpIndustryList = string.IsNullOrEmpty(searchWord)
                ? _masterDataController.GetIndustryList()
                : _masterDataController.GetIndustryList().Where(x => x.Name.ToUpper().Contains(searchWord.ToUpper()));

            FillIndustryList(tmpIndustryList);
        }

        private void FillIndustryList(IEnumerable<IndustryViewModel> industries)
        {
            foreach (var industry in industries)
            {
                IndustryList.Add(industry);
            }
        }

        private void NewEntryExecute()
        {
            SelectedIndustry = null;
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

            if (SelectedIndustry != null)
                return;

            SelectedIndustry = new IndustryViewModel();
        }

        public ICommand NewEntry
        {
            get { return new RelayCommand(NewEntryExecute, CanExecute); }
        }

        private void SaveExecute()
        {
            if (_eMode == EditMode.Edit)
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
            get { return new RelayCommand(SaveExecute, CanExecute); }
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
    }
}
