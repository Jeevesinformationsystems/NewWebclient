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
    public class MyDetailModel : PageModel
    {
        private IListData _productData;
        public Dictionary<String, String> product;
        public string[] countries;
        public MDFormLayout mdFormLayout;
        public MyDetailModel(IListData productData)
        {
            _productData = productData;
            mdFormLayout = new MDFormLayout();
            XElement xmlElement = XElement.Load(@"jiniDevExpress.xml");
            var columnList = xmlElement.Elements().ElementAt(1).Elements().ElementAt(0).Elements();
            mdFormLayout.FormColumnCount = columnList.Count();
            for(int j = 0; j < 3; j++)
            {
                for (int i = 0; i < mdFormLayout.FormColumnCount; i++)
                {
                    var column = columnList.ElementAt(i);
                    if(column.Elements().Count() > j)
                    {
                        var fieldElement = column.Elements().ElementAt(j);
                        var feild = new MDField { ID = fieldElement.Attribute("Id").Value, ControlType = fieldElement.Attribute("Type").Value, Name = fieldElement.Attribute("PromptText").Value };
                        mdFormLayout.FieldList.Add(feild);
                    }
                }
            }
        }

        public void OnGet(int id)
        {
            product = _productData.GetDetailData(id);
        }
    }
}