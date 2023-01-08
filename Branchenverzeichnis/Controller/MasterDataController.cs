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
            var industryViews = industries.Select(i => new IndustryViewModel()
            {
                IndustryID = i.IndustryID,
                Name = i.Name
            }).ToList();

            return industryViews;
        }

        public void EntryIndustry(IndustryViewModel industryView)
        {
            var industry = new Industry()
            {
                Name = industryView.Name
            };

            _modelIndustry.EntryIndustry(industry);
        }

        public void UpdateIndustry(IndustryViewModel industryView)
        {
            if (industryView == null)
                return;

            var industry = new Industry()
            {
                IndustryID = industryView.IndustryID,
                Name = industryView.Name
            };

            _modelIndustry.UpdateIndustry(industry);
        }

        public void DeleteIndustry(int industryId)
        {
            _modelIndustry.DeleteIndustry(industryId);
        }
    }
}
