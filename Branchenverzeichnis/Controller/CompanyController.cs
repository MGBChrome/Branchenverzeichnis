using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Controller
{
    public class CompanyController
    {
        private RepoCompany _modelCompany;
        private RepoCompanyProduct _modelCompanyProduct;

        public CompanyController()
        {
            _modelCompany = new RepoCompany();
            _modelCompanyProduct = new RepoCompanyProduct();
        }

        // Read
        public List<CompanyViewModel> GetCompanyList()
        {
            var companies = _modelCompany.GetCompanyList();
            var companyViews = companies.Select(c => new CompanyViewModel()
            {
                CompanyID = c.CompanyID,
                Name = c.Name,
                Phonenumber = c.Phonenumber,
                Street = c.Street,
                PLZ = c.PLZ,
                Location = c.Location,
                CeoFirstName = c.CeoFirstName,
                CeoLastName = c.CeoLastName,
                IndustryID = c.IndustryID,
                IndustryName = c.Industry?.Name
            }).ToList();

            return companyViews;
        }

        public void EntryCompany(CompanyViewModel companyView)
        {
            if (companyView == null)
            {
                return;
            }

            Company company = MapCompanyViewModel(companyView);

            _modelCompany.EntryCompany(company);
        }

        public void UpdateCompany(CompanyViewModel companyView)
        {
            if (companyView == null)
                return;

            var company = MapCompanyViewModel(companyView);
            company.CompanyID = companyView.CompanyID;

            _modelCompany.UpdateCompany(company);
        }

        private static Company MapCompanyViewModel(CompanyViewModel companyView)
        {
            return new Company()
            {
                Name = companyView.Name,
                Phonenumber = companyView.Phonenumber,
                Street = companyView.Street,
                PLZ = companyView.PLZ,
                Location = companyView.Location,
                CeoFirstName = companyView.CeoFirstName,
                CeoLastName = companyView.CeoLastName,
                IndustryID = companyView.IndustryID
            };
        }

        public void DeleteCompany(int companyId)
        {
            _modelCompanyProduct.DeleteAllCompanyProducts(companyId);
            _modelCompany.DeleteCompany(companyId);
        }

        // Read
        public List<CompanyProductViewModel> GetCompanyProductList()
        {
            var companyProductList = _modelCompanyProduct.GetCompanyProductList();
            var companyProductViews = companyProductList.Select(c => new CompanyProductViewModel()
            {
                CompanyProductID = c.CompanyProductID,
                CompanyID = c.CompanyID,
                ProductID = c.ProductID,
                ProductName = c.Product?.Name
            }).ToList();

            return companyProductViews;
        }

        public void EntryCompanyProduct(CompanyViewModel companyView)
        {
            if (companyView == null)
            {
                return;
            }

            Company company = MapCompanyProductViewModel(companyView);

            _modelCompany.EntryCompany(company);
        }

        private static Company MapCompanyProductViewModel(CompanyViewModel companyView)
        {
            return new Company()
            {
                Name = companyView.Name,
                Phonenumber = companyView.Phonenumber,
                Street = companyView.Street,
                PLZ = companyView.PLZ,
                Location = companyView.Location,
                CeoFirstName = companyView.CeoFirstName,
                CeoLastName = companyView.CeoLastName,
                IndustryID = companyView.IndustryID
            };
        }

        public void DeleteCompanyProduct(int companyProductId)
        {
            _modelCompanyProduct.DeleteCompanyProduct(companyProductId);
        }
    }
}
