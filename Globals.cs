using System.ComponentModel.DataAnnotations;

namespace Nackademin_Episerver
{
    public class Globals
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(
                Name = "Metadata",
                Order = 40
            )]
            public const string MetaData = "Metadata";

            [Display(
                Name = "Specialized",
                Order = 50
            )]
            public const string Specialized = "Specialized";
        }
    }
}
