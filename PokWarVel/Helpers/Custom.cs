using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHtmlHelper.Helpers
{
    public static class Custom
    {
        public static MvcHtmlString Vote(this HtmlHelper hh, List<VoteModel> laListe)
        {
            TagBuilder olTag = new TagBuilder("ol");
            foreach(VoteModel item in laListe)
            {
                TagBuilder liTag = new TagBuilder("li");
                liTag.SetInnerText(item.Eval);
                olTag.InnerHtml += liTag.ToString();
            }
            return new MvcHtmlString(olTag.ToString());
        }
    }
}