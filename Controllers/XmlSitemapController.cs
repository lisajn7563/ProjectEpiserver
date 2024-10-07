using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Business.Services;
using Nackademin_Episerver.Models.Pages;
using Nackademin_Episerver.Models.ViewModels;

namespace Nackademin_Episerver.Controllers
{
    public class XmlSitemapController : PageControllerBase<XmlSitemap>
    {
        private readonly IXmlSitemapService _xmlSitemapService;

        public XmlSitemapController(IXmlSitemapService xmlSitemapService)
        {
            _xmlSitemapService = xmlSitemapService;
        }
        public IActionResult Index(XmlSitemap currentPage)
        {
            var model = new XmlSitemapViewModel(currentPage)
            {
                Pages = _xmlSitemapService.GetPages(currentPage)
            };

            return View(model);
        }
    }
}
