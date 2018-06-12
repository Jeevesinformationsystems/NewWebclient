using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using KindoUIDemo.Data;
using KindoUIDemo.MDControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KindoUIDemo.Pages
{
    public class MyTGDetail : PageModel
    {
        private IListData _productData;
        public Dictionary<String, String> product;

        public MyTGDetail(IListData productData)
        {
            _productData = productData;
        }

        public void OnGet(int id)
        {
            product = _productData.GetDetailData(id);
        }
    }
}