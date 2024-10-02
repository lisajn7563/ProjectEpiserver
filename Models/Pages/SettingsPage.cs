using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
    [ContentType(
        GUID = "C63E711D-AF8E-4F68-A41D-9A0D4597B212",
        GroupName = GroupNames.Specialized
        )]
    [ImageUrl("/pages/CMS-icon-page-03.png")]
    public class SettingsPage : SitePageData
    {
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10
       )]
        public virtual ContentReference LinkToMoviesContainer { get; set; }
    }
}
