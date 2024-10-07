using Nackademin_Episerver.Models.Blocks;
using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
    [ContentType(
        GUID = "1900F9AC-4BA2-4472-8CDC-BA8804C9793F",
        GroupName = GroupNames.Specialized
    )]
    [ImageUrl("/pages/CMS-icon-page-02.png")]
    [AvailableContentTypes(
        Availability.Specific,
        Include =
        [
            typeof(SettingsPage),
			typeof(ContainerPage),
            typeof(SearchPage),
            typeof(XmlSitemap),
            typeof(ErrorPage)
        ]
    )]
    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

		[Display(
	        GroupName = SystemTabNames.Content,
	        Order = 30,
            Name = "Slideshow",
            Description = ""
        )]
        [AllowedTypes(
            typeof(SlideshowPage),
            typeof(SlideshowBlock)
        )]
		public virtual ContentArea Content { get; set; }
	}
}
