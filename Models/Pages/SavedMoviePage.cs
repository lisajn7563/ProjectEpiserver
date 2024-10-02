using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
    [ContentType(
        GUID = "90A09CE6-35E0-4F56-B7CD-CC06D7A6E37D",
        GroupName = GroupNames.Specialized
    )]
    [ImageUrl("/pages/CMS-icon-page-04.png")]
    public class SavedMoviePage : SitePageData
    {

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;
    }
}
