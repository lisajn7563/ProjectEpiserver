using System.ComponentModel.DataAnnotations;

namespace Nackademin_Episerver.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            GroupName = Globals.GroupNames.MetaData,
            Order = 100
            )]
        [CultureSpecific]
        public virtual string MetaTitle 
        { 
            get 
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);

                return !string.IsNullOrWhiteSpace(metaTitle)
                    ? metaTitle
                    : PageName;
            }
            set => this.SetPropertyValue(p => p.MetaTitle, value);
        }
        [UIHint("MetaRobots")]
        public virtual string MetaRobots { get; set; }

        [Display(
            GroupName = Globals.GroupNames.MetaData,
            Order = 100
        )]
        [CultureSpecific]
        public virtual string MetaDescription
        {
            get
            {
                var metaDescription = this.GetPropertyValue(p => p.MetaDescription);

                return !string.IsNullOrWhiteSpace(metaDescription) ? metaDescription : PageName;
            }
            set => this.SetPropertyValue(p => p.MetaDescription, value);
        }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            MetaRobots = "INDEX, FOLLOW";
        }
    }
}
