using System.Web;
using System.Web.Mvc;

namespace LibrGB.Sys.DigitCasaMatriz.UIWebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
