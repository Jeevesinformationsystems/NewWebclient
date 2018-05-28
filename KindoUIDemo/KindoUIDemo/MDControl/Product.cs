using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.MDControl
{
    public class Product
    {
         public int ProductId { get; set; }
         public string ProductName { get; set ; }
         public int  UnitPrice { get; set; }
         public int UnitInStock { get; set; }
         public Boolean Discontinued { get; set; }
    }
}
