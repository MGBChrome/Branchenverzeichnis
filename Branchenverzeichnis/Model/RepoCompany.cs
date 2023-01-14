using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Model
{
    public class RepoCompany
    {
        private IndustryDirectoryEntities _context;

        public RepoCompany()
        {
            _context= new IndustryDirectoryEntities();
        }

        // Read
        public List<Company> GetCompanyList()
        {
            return _context.Company.Include("Industry").ToList();
        }

        // Create
        public void EntryCompany(Company company)
        {
            _context.Company.Add(company);
            _context.SaveChanges();
        }

        // Update
        public void UpdateCompany(Company company)
        {
            if (company == null)
                return;

            _context.Company.AddOrUpdate(company);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteCompany(int companyId)
        {
            var company = _context.Company.SingleOrDefault(x => x.CompanyID == companyId);
            _context.Company.Remove(company);
            _context.SaveChanges();
        }
    }
}
