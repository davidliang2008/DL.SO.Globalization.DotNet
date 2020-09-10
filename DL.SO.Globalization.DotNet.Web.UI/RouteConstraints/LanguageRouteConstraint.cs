using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace DL.SO.Globalization.DotNet.Web.UI.RouteConstraints
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return Regex.IsMatch((string)values[parameterName], @"^[a-z]{2}$");
        }
    }
}