using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace WebAPI2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
