using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class IndustryViewModel
    {
        private Industry _industry;

        public IndustryViewModel()
        {
            _industry = new Industry();
        }

        public int IndustryID 
        { 
            get { return _industry.IndustryID; }
            set { _industry.IndustryID = value; } 
        }

        public string Name
        {
            get { return _industry.Name; }
            set { _industry.Name = value; }
        }

    }
}
