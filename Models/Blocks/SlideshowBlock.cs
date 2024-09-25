
using Nackademin_Episerver.Models.Pages;
using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Blocks
{
    [ContentType(
       GUID = "BD629A31-904A-4491-807E-9C52C47C9818",
       GroupName = GroupNames.Specialized,
       DisplayName = "Slideshow",
       Description = "This is a slideshow block template"
       )]
    [ImageUrl("/pages/CMS-icon-page-03.png")]
    public class SlideshowBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [AllowedTypes(
            typeof(SlideshowPage) )]
        public virtual ContentArea Slideshow {  get; set; }
    }
}
