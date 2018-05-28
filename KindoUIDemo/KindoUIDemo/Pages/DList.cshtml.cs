using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindoUIDemo.Data;
using KindoUIDemo.MDControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KindoUIDemo.Pages
{
    public class DListModel : PageModel
    {
        private IProductData _productData;
        public IEnumerable<Product> products;
        public DListModel(IProductData productData)
        {
            _productData = productData;
        }

        public void OnGet()
        {
            products = _productData.GetProducts();  
        }
    }
}
