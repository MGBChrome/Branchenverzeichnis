using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branchenverzeichnis.BusinessObject
{
    public class ProductViewModel
    {
        private Product _product;

        public ProductViewModel()
        {
            _product = new Product();
        }

        public int ProductID
        {
            get { return _product.ProductID; }
            set { _product.ProductID = value; }
        }

        public string Name
        {
            get { return _product.Name; }
            set { _product.Name = value; }
        }
    }
}
