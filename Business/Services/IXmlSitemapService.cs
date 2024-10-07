using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Services
{
    public interface IXmlSitemapService
    {
        List<SitePageData> GetPages(XmlSitemap currentPage);
    }
}
