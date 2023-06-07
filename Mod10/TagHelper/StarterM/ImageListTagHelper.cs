using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StarterM
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement("tag-name")]
    public class ImageListTagHelper : TagHelper
    {
        public string[]? ImageNames { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "figure";
            foreach(var item in ImageNames)
            {
                output.Content.AppendHtml($"<img src='/images/cats/{item}.png'>");
            }
        }
    }
}
