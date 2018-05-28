using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.MDControl
{
    public class MDDList : DynamicObject
    {
        public List<MDDListCell> MDListColumns = new List<MDDListCell>();
        private Dictionary<String, String> listValues;

        public MDDList(Dictionary<String, String> listDictionary)
        {
            listValues = listDictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "";
            if(listValues.ContainsKey(binder.Name))
            {
                result = listValues[binder.Name];
                return true;
            }
            return false;
        }
    }
}
