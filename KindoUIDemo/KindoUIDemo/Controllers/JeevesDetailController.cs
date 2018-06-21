using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindoUIDemo.Data;
using KindoUIDemo.Models;
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
            var model = new JeevesDetailModel();
            model.Data = product;
            return View("Index", model);
        }
    }
}