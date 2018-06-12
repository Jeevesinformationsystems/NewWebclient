using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindoUIDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace KindoUIDemo.Controllers
{
    [Route("JeevesDetail/Index/{id=1}")]
    public class JeevesDetailController : Controller
    {
        private IListData _productData;

        public JeevesDetailController(IListData productData)
        {
            _productData = productData;
        }

        public IActionResult Index(int id)
        {
            var product = _productData.GetDetailData(id);
            return View(product);
        }
    }
}