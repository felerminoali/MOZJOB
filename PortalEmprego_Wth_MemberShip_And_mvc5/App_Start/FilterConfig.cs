using System.Web;
using System.Web.Mvc;

namespace PortalEmprego_Wth_MemberShip_And_mvc5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
