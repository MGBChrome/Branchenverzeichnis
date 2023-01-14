using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class CompanyProductViewModel
    {
        private CompanyProduct _companyProduct;

        public CompanyProductViewModel()
        {
            _companyProduct = new CompanyProduct();
            _companyProduct.Product = new Product();
        }

        public int CompanyProductID 
        {
            get { return _companyProduct.CompanyProductID; } 
            set { _companyProduct.CompanyProductID = value; } 
        }
        
        public int CompanyID 
        { 
            get { return _companyProduct.CompanyID; } 
            set { _companyProduct.CompanyID = value; } 
        }
        
        public int ProductID 
        { 
            get { return _companyProduct.ProductID; }
            set { _companyProduct.ProductID = value; } 
        }
        
        public string ProductName 
        { 
            get { return _companyProduct.Product?.Name; }
            set
            {
                if (_companyProduct.Product != null)
                {
                    _companyProduct.Product.Name = value;
                }
            } 
        }
    }
}
