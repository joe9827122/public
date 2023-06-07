using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StarterM
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement("tag-name")]
    public class MyImageTagHelper : TagHelper
    {
        public string ImageName { get; set; } = "cat_box";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            //output.Attributes.SetAttribute("src", "/images/cats/cat_box.png");
            output.Attributes.SetAttribute("src", $"/images/cats/{ImageName}.png");
            output.TagMode = TagMode.StartTagOnly;
        }
    }
}
