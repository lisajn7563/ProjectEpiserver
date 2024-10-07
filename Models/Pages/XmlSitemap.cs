using Nackademin_Episerver.Models.Blocks;
using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
    [ContentType(
        GUID = "14DCD18E-ED7B-4BD2-B1E0-207F4352CD1D",
        DisplayName = "XML sitemap",
        Description = "This is a XLM sitemap template",
        GroupName = GroupNames.Specialized
    )]
    public class XmlSitemap : SitePageData
    {

	}
}
