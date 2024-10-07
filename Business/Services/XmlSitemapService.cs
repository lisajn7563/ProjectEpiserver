using Nackademin_Episerver.Business.Extensions;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Services
{
    public class XmlSitemapService : IXmlSitemapService
    {
        private readonly IContentLoader _contentLoader;

        public XmlSitemapService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public List<SitePageData> GetPages(XmlSitemap currentPage)
        {
            var startPage = _contentLoader.GetAncestors(currentPage.ContentLink).FirstOrDefault(x => x is StartPage) as PageData;
            var descendants = Enumerable.Empty<SitePageData>();

            if (startPage != null)
            {
                descendants = _contentLoader.GetDescendentsAndSelf(startPage.ContentLink);
            }

            return descendants.ToList();
        }
    }
}
