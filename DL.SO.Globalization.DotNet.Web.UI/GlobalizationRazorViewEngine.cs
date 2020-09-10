using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace DL.SO.Globalization.DotNet.Web.UI
{
    public class GlobalizationRazorViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            partialPath = GetGlobalizeViewPath(controllerContext, partialPath);
            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            viewPath = GetGlobalizeViewPath(controllerContext, viewPath);
            return base.CreateView(controllerContext, viewPath, masterPath);
        }

        private string GetGlobalizeViewPath(ControllerContext controllerContext, string viewPath)
        {
         var request = controllerContext.HttpContext.Request;
            var values = controllerContext.RouteData.Values;

            string languageCode = (string)values["lang"];
            if (!String.IsNullOrWhiteSpace(languageCode))
            {
                string localizedViewPath = Regex.Replace(viewPath,
                    "^~/Views/",
                    String.Format("~/{0}/Views/", languageCode)
                );

                if (File.Exists(request.MapPath(localizedViewPath)))
                {
                    viewPath = localizedViewPath;
                }
            }

            return viewPath;
        }
    }
}