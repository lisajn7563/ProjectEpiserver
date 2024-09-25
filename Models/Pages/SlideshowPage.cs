using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
	[ContentType(
		GUID = "9094BB18-B3BD-4866-B20E-3C05A43E8F28",
		GroupName = GroupNames.Specialized,
		DisplayName = "Slideshow",
		Description ="This is a slideshow template"
	)]
	[ImageUrl("/pages/CMS-icon-page-06.png")]
	public class SlideshowPage : SitePageData
	{
		[Display(
			GroupName = SystemTabNames.Content,
			Order = 10
		)]
		[UIHint(UIHint.Image)]
		public virtual ContentReference Image {  get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        public virtual Url LinkUrl { get; set; }

    }
}
