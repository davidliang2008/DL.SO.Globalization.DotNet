using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DL.SO.Globalization.DotNet.Web.UI.Filters
{
    public class LanguageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var values = filterContext.RouteData.Values;

            string languageCode = (string)values["lang"] ?? "en";

            var cultureInfo = new CultureInfo(languageCode);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}