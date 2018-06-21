using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using KindoUIDemo.Data;
using KindoUIDemo.MDControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KindoUIDemo.Pages
{
    public class IndexModel : PageModel
    {
        private IListData _productData;
        public IEnumerable<Dictionary<String, String>> products;
        public MDList MDList;
        public IndexModel(IListData productData)
        {
            _productData = productData;
            MDList = new MDList { ID = "1", Name = "My List"};
            XElement xmlElement = XElement.Load(@"jiniDevExpress.xml");
            var cellList = xmlElement.Elements().ElementAt(0).Elements();
            foreach(var cellElement in cellList)
            {
                var id = cellElement.Attribute("Id").Value;
                var name = cellElement.Attribute("HeaderText").Value;
                var cell = new MDListCell { ID = id, Name = name };
                MDList.MDListColumns.Add(cell);
            }
        }

        public void OnGet()
        {
            products = _productData.GetListData(MDList);  
        }
    }
}
