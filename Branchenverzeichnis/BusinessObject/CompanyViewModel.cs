using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class CompanyViewModel
    {
        private Company _company;

        public CompanyViewModel()
        {
            _company = new Company();
        }

        public int CompanyID
        {
            get { return _company.CompanyID; }
            set { _company.CompanyID = value; }
        }

        public string Name
        {
            get { return _company.Name; }
            set { _company.Name = value; }
        }

        public string Phonenumber
        {
            get { return _company.Phonenumber; }
            set { _company.Phonenumber = value; }
        }

        public string Street
        {
            get { return _company.Street; }
            set { _company.Street = value; }
        }

        public string PLZ
        {
            get { return _company.PLZ; }
            set { _company.PLZ = value; }
        }

        public string Location
        {
            get { return _company.Location; }
            set { _company.Location = value; }
        }

        public string CeoFirstName
        {
            get { return _company.CeoFirstName; }
            set { _company.CeoFirstName = value; }
        }

        public string CeoLastName
        {
            get { return _company.CeoLastName; }
            set { _company.CeoLastName = value; }
        }

        public int? IndustryID
        {
            get { return _company.IndustryID; }
            set { _company.IndustryID = value; }
        }

        public string IndustryName { get; set; }
    }
}
