using EPiServer.Web.Mvc;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {

    }
}
