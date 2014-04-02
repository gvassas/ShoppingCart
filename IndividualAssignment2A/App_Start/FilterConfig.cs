using System.Web;
using System.Web.Mvc;

namespace IndividualAssignment2A
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}