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
        private MDFormLayout mdFormLayout;
        public List<MDField> _fieldList = new List<MDField>();
        public MyTGDetail(IListData productData)
        {
            _productData = productData;
            mdFormLayout = new MDFormLayout();
            XElement xmlElement = XElement.Load(@"jiniDevExpress.xml");
            var columnList = xmlElement.Elements().ElementAt(1).Elements().ElementAt(0).Elements();
            mdFormLayout.FormColumnCount = columnList.Count();
            for (int i = 0; i < mdFormLayout.FormColumnCount; i++)
            {
                var column = columnList.ElementAt(i);
                foreach(var fieldElement in column.Elements())
                {
                    var feild = new MDField { ID = fieldElement.Attribute("Id").Value, ControlType = fieldElement.Attribute("Type").Value, Name = fieldElement.Attribute("PromptText").Value };
                    mdFormLayout.FieldList.Add(feild);
                    _fieldList.Add(feild);
                }
            }
        }

        public void OnGet(int id)
        {
            product = _productData.GetDetailData(id);
        }
    }
}