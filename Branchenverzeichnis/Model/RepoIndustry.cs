using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Model
{
    public class RepoIndustry
    {
        private IndustryDirectoryEntities _context;

        public RepoIndustry()
        {
            _context = new IndustryDirectoryEntities();
        }

        // Read
        public List<Industry> GetIndustryList()
        {
            return _context.Industry.ToList();
        }

        // Create
        public void EntryIndustry(Industry industry)
        {
            _context.Industry.Add(industry);
            _context.SaveChanges();
        }

        // Update
        public void UpdateIndustry(Industry industry)
        {
            if (industry == null)
                return;

            _context.Industry.AddOrUpdate(industry);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteIndustry(int industryId)
        {
            var industry = _context.Industry.SingleOrDefault(x => x.IndustryID == industryId);
            _context.Industry.Remove(industry);
            _context.SaveChanges();
        }
    }
}
