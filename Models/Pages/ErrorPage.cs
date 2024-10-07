using System.ComponentModel.DataAnnotations;
using static Nackademin_Episerver.Globals;

namespace Nackademin_Episerver.Models.Pages
{
    [ContentType(
       GUID = "FC08A01A-DF3B-4E9D-836B-892640DA194A",
       GroupName = GroupNames.Specialized
   )]
    public class ErrorPage : SitePageData
    {
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10
       )]
        public virtual string Header { get; set; }
    }
}
