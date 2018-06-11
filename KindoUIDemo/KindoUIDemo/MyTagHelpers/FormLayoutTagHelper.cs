
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KindoUIDemo.MyTagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [RestrictChildren("form-column")]
    public class FormLayoutTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["model"] = For.Model;
            output.TagName = "div";
            output.Attributes.Add("class", "row");
        }
    }
}
