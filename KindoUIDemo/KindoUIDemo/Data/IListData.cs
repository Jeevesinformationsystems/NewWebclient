using KindoUIDemo.MDControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.Data
{
    public interface IListData
    {
        IEnumerable<Dictionary<String, String>> GetListData();
        IEnumerable<Dictionary<String, String>> GetListData(MDList mdList);
        Dictionary<String, String> GetDetailData(int productID);
    }

    public class ListData : IListData
    {
        private List<Dictionary<String, String>> _products;
        public ListData()
        {
            _products = new List<Dictionary<String, String>>();
            for (int i = 1; i < 10001; i++)
            {
                var product = new Dictionary<String, String>();
                product.Add("1", $"{i}");
                product.Add("2", $"Product{i}");
                product.Add("3", $"{i * 3}");
                product.Add("4", $"{i * 10}");
                product.Add("5", $"{i % 2 > 0}");
                _products.Add(product);
            }
        }

        public Dictionary<string, string> GetDetailData(int productID)
        {
            return _products[productID - 1];
        }

        public IEnumerable<Dictionary<String, String>> GetListData(MDList mdList)
        {
            _products = new List<Dictionary<String, String>>();
            for (int i = 1; i < 10001; i++)
            {
                var product = new Dictionary<String, String>();
                product.Add("1", $"{i}");
                foreach (var cell in mdList.MDListColumns)
                {
                    product.Add(cell.ID, $"{cell.Name}{i}");
                }
                _products.Add(product);
            }
            return _products;
        }

        public IEnumerable<Dictionary<string, string>> GetListData()
        {
            return _products;
        }
    }
}
