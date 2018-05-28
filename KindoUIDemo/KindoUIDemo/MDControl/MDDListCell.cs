using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.MDControl
{
    public class MDDListCell : DynamicObject
    {
        private Dictionary<String, String> cellValues;

        public MDDListCell(Dictionary<String, String> cellDictionary)
        {
            cellValues = cellDictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "";
            if(cellValues.ContainsKey(binder.Name))
            {
                result = cellValues[binder.Name];
                return true;
            }
            return false;
        }
    }
}
