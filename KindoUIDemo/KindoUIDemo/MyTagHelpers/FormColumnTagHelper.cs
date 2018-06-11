using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KindoUIDemo.MyTagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [RestrictChildren("field")]
    public class FormColumnTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "col-md-3");
        }
    }
}
