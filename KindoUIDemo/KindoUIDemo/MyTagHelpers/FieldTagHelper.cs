﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KindoUIDemo.MyTagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project

    public class FieldTagHelper : TagHelper
    {
        

        [HtmlAttributeName("prompt-text")]
        public string Title { get; set; }
        [HtmlAttributeName("type")]
        public string Type { get; set; }
        [HtmlAttributeName("id")]
        public string Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            var type = "text";
            var model = context.Items["model"] as Dictionary<String, String>;
            var value = model[Id];
            if(Type == "Date")
            {
                type = "datetime-local";
                value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            }
            var lable = "<label>"+ Title + "</label>";
            output.PreElement.SetHtmlContent(lable);
            output.TagName = "input";
            output.Attributes.Add("class", "form-control");
            output.Attributes.Add("type", type);
            output.Attributes.Add("id", "product_" + Id);
            output.Attributes.Add("name", "product[" + Id + "]");
            output.Attributes.Add("value", value);
        }
    }
}
