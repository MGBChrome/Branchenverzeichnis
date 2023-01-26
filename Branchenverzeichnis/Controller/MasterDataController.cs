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
        private RepoProduct _modelProduct;

        public MasterDataController()
        {
            _modelIndustry = new RepoIndustry();
            _modelProduct = new RepoProduct();
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

        // Create
        public void EntryIndustry(IndustryViewModel industryView)
        {
            if (industryView == null)
            {
                return;
            }

            var industry = new Industry()
            {
                Name = industryView.Name
            };

            _modelIndustry.EntryIndustry(industry);
        }

        // Update
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

        // Delete
        public void DeleteIndustry(int industryId)
        {
            _modelIndustry.DeleteIndustry(industryId);
        }

        // Read
        public List<ProductViewModel> GetProductList()
        {
            var products = _modelProduct.GetProductList();
            var productViews = products.Select(i => new ProductViewModel()
            {
                ProductID = i.ProductID,
                Name = i.Name
            }).ToList();

            return productViews;
        }

        // Create
        public void EntryProduct(ProductViewModel productView)
        {
            if (productView == null)
            {
                return;
            }

            var product = new Product()
            {
                Name = productView.Name
            };

            _modelProduct.EntryProduct(product);
        }

        // Update
        public void UpdateProduct(ProductViewModel productView)
        {
            if (productView == null)
                return;

            var product = new Product()
            {
                ProductID = productView.ProductID,
                Name = productView.Name
            };

            _modelProduct.UpdateProduct(product);
        }

        // Delete
        public void DeleteProduct(int productId)
        {
            _modelProduct.DeleteProduct(productId);
        }
    }
}
