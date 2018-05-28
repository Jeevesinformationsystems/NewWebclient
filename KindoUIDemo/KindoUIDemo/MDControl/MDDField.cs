using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.MDControl
{
    public class MDDField : DynamicObject
    {
        private Dictionary<String, String> fieldValues;

        public MDDField(Dictionary<String, String> listDictionary)
        {
            fieldValues = listDictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = "";
            if(fieldValues.ContainsKey(binder.Name))
            {
                result = fieldValues[binder.Name];
                return true;
            }
            return false;
        }
    }
}
