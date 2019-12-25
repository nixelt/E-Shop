namespace E_Shop.Helpers
{
    using System.Text;
    using System.Web.Mvc;

    using Antlr.Runtime.Misc;

    using Models;

    public static class PagerHelpers
    {
        public static MvcHtmlString Pagination(this HtmlHelper html, Pager pager, Func<int, string> pageUrl)
        {
            if (pager == null || pager.TotalPages == 1)
            {
                return null;
            }

            var result = new StringBuilder();
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination col-12 d-flex flex-wrap justify-content-center my-1");
            for (var i = 1; i <= pager.TotalPages; i++)
            {
                var liTag = new TagBuilder("li");
                liTag.AddCssClass("page-item");
                if (i == pager.CurrentPage)
                {
                    liTag.AddCssClass("active");
                }

                var aTag = new TagBuilder("a");
                aTag.AddCssClass("btn page-link");
                aTag.MergeAttribute("href", pageUrl(i));
                aTag.InnerHtml = i.ToString();
                liTag.InnerHtml = aTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }

            result.Append(ulTag);
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PaginationAjax(this HtmlHelper html, Pager pager)
        {
            if (pager == null || pager.TotalPages == 1)
            {
                return null;
            }

            var result = new StringBuilder();
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination col-12 d-flex flex-wrap justify-content-center my-1");
            for (var i = 1; i <= pager.TotalPages; i++)
            {
                var liTag = new TagBuilder("li");
                liTag.AddCssClass("page-item");
                if (i == pager.CurrentPage)
                {
                    liTag.AddCssClass("active");
                }

                var buttonTag = new TagBuilder("button");
                buttonTag.AddCssClass("btn page-link");
                buttonTag.MergeAttribute("type", "submit");
                buttonTag.MergeAttribute("name", "page");
                buttonTag.MergeAttribute("value", i.ToString());
                buttonTag.InnerHtml = i.ToString();
                liTag.InnerHtml = buttonTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }

            result.Append(ulTag);
            return MvcHtmlString.Create(result.ToString());
        }
    }
}