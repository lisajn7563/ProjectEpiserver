using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Models.ViewModels
{
    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
    {
        public List<SitePageData> Pages { get; set; }
        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
        {
            
        }
    }
}
