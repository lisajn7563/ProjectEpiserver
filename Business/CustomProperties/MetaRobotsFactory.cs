
using EPiServer.Shell.ObjectEditing;

namespace Nackademin_Episerver.Business.CustomProperties
{
    public class MetaRobotsFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var selections = new List<ISelectItem>
            {
                new SelectItem { Value = "INDEX, FOLLOW", Text = "INDEX, FOLLOW" },
                new SelectItem { Value = "INDEX, NOFOLLOW", Text = "INDEX, NOFOLLOW" },
                new SelectItem { Value = "NOINDEX, FOLLOW", Text = "NOINDEX, FOLLOW" },
                new SelectItem { Value = "NOINDEX, NOFOLLOW", Text = "NOINDEX, NOFOLLOW" }
            };

            return selections;
        }
    }
}
