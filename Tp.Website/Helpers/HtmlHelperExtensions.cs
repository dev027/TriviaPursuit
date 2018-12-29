using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tp.Common.Constants;

namespace Tp.Website.Helpers
{
    ////public class ButtonTagHelper : TagHelper
    ////{
    ////    public string FontAwesomeIcon { get; set; }
    ////    public override void Process(TagHelperContext context, TagHelperOutput output)
    ////    {
    ////        TagBuilder icon = new TagBuilder("i");
    ////        icon.AddCssClass($"fa fa-{FontAwesomeIcon}");
    ////        if (FontAwesomeIcon == "spinner")
    ////        {
    ////            icon.AddCssClass("fa-spin");
    ////        }

    ////        output.PreContent.AppendHtml(icon);
    ////    }
    ////}
    public static class HtmlHelperExtensions
    {
        public static string Button(
            string defaultText,
            string buttonText,
            string fontAwesomeIcon,
            BootstrapContext buttonType,
            string id = null)
        {
            if (buttonText == null)
            {
                buttonText = defaultText;
            }
            else
            {
                buttonText = defaultText + " " + buttonText;
            }

            var tbIcon = new TagBuilder("i");
            tbIcon.AddCssClass("fa");
            tbIcon.AddCssClass("fa-" + fontAwesomeIcon);
            if (fontAwesomeIcon == "spinner")
            {
                tbIcon.AddCssClass("fa-spin");
            }
            if (!string.IsNullOrEmpty(buttonText)) tbIcon.AddCssClass("icon-offset");


            var tb = new TagBuilder("button");
            tb.AddCssClass("btn");
            tb.AddCssClass("btn-" + buttonType);

            tb.MergeAttribute("type", "button");
            if (id != null)
            {
                tb.GenerateId(id, " ");
            }
            tb.InnerHtml.AppendHtml(tbIcon);
            tb.InnerHtml.Append(buttonText);

            using (var writer = new StringWriter())
            {
                tb.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

    }
}