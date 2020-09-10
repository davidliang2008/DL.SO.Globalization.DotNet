using DL.SO.Globalization.DotNet.Web.UI.Filters;
using System.Web;
using System.Web.Mvc;

namespace DL.SO.Globalization.DotNet.Web.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LanguageFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
