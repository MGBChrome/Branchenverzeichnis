using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Model
{
    public class RepoCompanyProduct
    {
        private IndustryDirectoryEntities _context;

        public RepoCompanyProduct()
        {
            _context = new IndustryDirectoryEntities();
        }

        // Read
        public List<CompanyProduct> GetCompanyProductList()
        {
            return _context.CompanyProduct.Include("Company").Include("Product").ToList();
        }

        // Create
        public void EntryCompanyProduct(CompanyProduct companyProduct)
        {
            _context.CompanyProduct.Add(companyProduct);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteCompanyProduct(int companyId)
        {
            var company = _context.Company.SingleOrDefault(x => x.CompanyID == companyId);
            _context.Company.Remove(company);
            _context.SaveChanges();
        }

        public void DeleteAllCompanyProducts(int companyId)
        {
            var selectedCompanyProducts = _context.CompanyProduct.Where(cp => cp.CompanyID == companyId);
            _context.CompanyProduct.RemoveRange(selectedCompanyProducts);
            _context.SaveChanges();
        }
    }
}
