using Branchenverzeichnis.BusinessObject;
using Branchenverzeichnis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Controller
{
    public class MasterDataController
    {
        private RepoIndustry _modelIndustry;

        public MasterDataController()
        {
            _modelIndustry = new RepoIndustry();
        }

        // Read
        public List<IndustryViewModel> GetIndustryList()
        {
            var industries = _modelIndustry.GetIndustryList();
            var industryViewModels = industries.Select(i => new IndustryViewModel()
            {
                IndustryID = i.IndustryID,
                Name = i.Name
            }).ToList();

            return industryViewModels;
        }
    }
}
