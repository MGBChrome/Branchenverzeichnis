using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.Model
{
    public class RepoProduct
    {
        private IndustryDirectoryEntities _context;

        public RepoProduct()
        {
            _context = new IndustryDirectoryEntities();
        }

        // Read
        public List<Product> GetProductList()
        {
            return _context.Product.ToList();
        }

        // Create
        public void EntryProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        // Update
        public void UpdateProduct(Product product)
        {
            if (product == null)
                return;

            _context.Product.AddOrUpdate(product);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteProduct(int productId)
        {
            var product = _context.Product.SingleOrDefault(x => x.ProductID == productId);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}
