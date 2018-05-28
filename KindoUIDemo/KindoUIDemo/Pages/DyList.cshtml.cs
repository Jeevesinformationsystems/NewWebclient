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
    public class DyListModel : PageModel
    {
        private IListData _productData;
        public IEnumerable<Dictionary<String, String>> products;
        public MDDList MyList;
        public DyListModel(IListData productData)
        {
            _productData = productData;
            var listDictionary = new Dictionary<String, String>();
            listDictionary.Add("ID", "1");
            listDictionary.Add("Name", "My List");
            MyList = new MDDList(listDictionary);
            var cellNames = new String[5] {"ProductId", "Product Name", "Unit Price", "Units In Stoke", "Discontinued"};
            for(int i = 0; i < 5; i++)
            {
                var cellDictionary = new Dictionary<String, String>();
                cellDictionary.Add("ID", (i + 1).ToString());
                cellDictionary.Add("Name", cellNames[i]);
                var cell = new MDDListCell(cellDictionary);
                MyList.MDListColumns.Add(cell);
            }
        }

        public void OnGet()
        {
            products = _productData.GetListData();  
        }
    }
}
