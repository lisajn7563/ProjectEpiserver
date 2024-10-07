using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Extensions
{
    public static class ContentLoaderExtensions
    {
        public static IEnumerable<SitePageData> GetDescendentsAndSelf(this IContentLoader contentLoader,
            ContentReference startPageReference)
        {
            // Försök hämta startPage som PageData först, sedan omvandla den om möjligt
            var startPage = contentLoader.Get<PageData>(startPageReference) as SitePageData;

            // Hantera om startPage inte är av typen SitePageData
            if (startPage == null)
            {
                return Enumerable.Empty<SitePageData>();
            }

            // Hämta efterkommande sidor
            var descendants = contentLoader.GetDescendents(startPageReference)
                .Select(contentRef => contentLoader.Get<PageData>(contentRef)) // Hämta som PageData först
                .Where(content => content is SitePageData && content is not XmlSitemap) // Filtrera bort andra typer
                .Cast<SitePageData>(); // Omvandla till SitePageData

            return new[] { startPage }.Concat(descendants);
        }
    }
}
