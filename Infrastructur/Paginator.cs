using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;


namespace Store.Infrastructur
{
    [HtmlTargetElement("div", Attributes="page-info")]
    public class Paginator : TagHelper
    { 
       private IUrlHelperFactory urlHelperFactory { get; set; }
        public Paginator(IUrlHelperFactory url)
        {
            urlHelperFactory = url;
        }


        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public PageInfo PageInfo { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix ="page-categoria-")]
        public Dictionary<string, object> PageCategoria { get; set; } = new Dictionary<string, object>();
            
                
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageInfo.AllPage; i++)
            {
                TagBuilder tagA = new TagBuilder("a");
                PageCategoria["ProductPage"] = i;
                tagA.Attributes["href"] = urlHelper.Action(PageAction, PageCategoria);
                tagA.Attributes["class"] = "btn btn-primary";
                tagA.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tagA);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
