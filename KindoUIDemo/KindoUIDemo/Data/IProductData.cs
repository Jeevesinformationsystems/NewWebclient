using KindoUIDemo.MDControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.Data
{
    public interface IProductData
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productID);
    }

    class ProductData : IProductData
    {
        private List<Product> _products; 
        public ProductData()
        {
            _products = new List<Product>();
            for(int i = 1; i< 101; i++)
            {
                var product = new Product {
                    ProductId = i,
                    ProductName = $"Product{i}",
                    UnitPrice = i*3,
                    UnitInStock = i*10,
                    Discontinued = i%2 > 0 
                };
                _products.Add(product);
            }
        }
        public Product GetProduct(int productID)
        {
            var product = _products.Find(p => p.ProductId == productID);
            if (product == null) 
            {
                product = new Product
                {
                    ProductId = productID,
                    ProductName = $"Product{productID}",
                    UnitPrice = productID * 3,
                    UnitInStock = productID * 10,
                    Discontinued = productID % 2 > 0
                };
                _products.Add(product);
            }
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
