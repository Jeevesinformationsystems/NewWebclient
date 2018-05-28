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
    public class DDetailModel : PageModel
    {
        private IProductData _productData;
        public Product product;
        public string[] countries;
        public DDetailModel(IProductData productData)
        {
            _productData = productData;
            countries = new string[10] { "Sweden", "Norway", "Germany", "Finland", "Poland", "Italy", "Greece", "Spain", " Netherlands", "Switzerland" };
        }

        public void OnGet(int id)
        {
            product = _productData.GetProduct(id);
        }
    }
}