using System;
using Assignment_05.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assignment05.Infastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        //this helps to build the URL
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        //Attributes of the tag helper -----------------------------------------------
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        // End of Attributes of the tag helper ----------------------------------------

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            //this sets the target element to a div tag
            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //this creates a tab for each page number and sets the href to the associated page
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });

                //This is for the styling options for the tag we are creating
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }
            //This adds the created element to the html page that is being rendered
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
