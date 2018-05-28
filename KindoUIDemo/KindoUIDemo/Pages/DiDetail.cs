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
    public class DiDetailModel : PageModel
    {
        private IListData _productData;
        public Dictionary<String, String> product;
        public string[] countries;
        public List<MDField> FormControlList;
        public DiDetailModel(IListData productData)
        {
            _productData = productData;
            FormControlList = new List<MDField>();
            var controlNames = new String[5] { "Unit Price", "Units In Stoke", "Discontinued","Country","Date" };
            var controltypes = new String[5] { "Editbox", "Editbox", "Checkbox", "Combobox","Date" };
            for (int i = 0; i < 5; i++)
            {
                var feild = new MDField { ID = (i + 3).ToString(), Name = controlNames[i], ControlType = controltypes[i] };
                FormControlList.Add(feild);
            }
            countries = new string[10] { "Sweden", "Norway", "Germany", "Finland", "Poland", "Italy", "Greece", "Spain", " Netherlands", "Switzerland" };
        }

        public void OnGet(int id)
        {
            product = _productData.GetDetailData(id);
        }
    }
}