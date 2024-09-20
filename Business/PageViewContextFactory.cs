using EPiServer.ServiceLocation;
using EPiServer.Web;
using Nackademin_Episerver.Models.Pages;
using Nackademin_Episerver.Models.ViewModels;

namespace Nackademin_Episerver.Business
{
    [ServiceConfiguration]
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;
        private readonly ILogger<PageViewContextFactory> _logger;

        public PageViewContextFactory(IContentLoader contentLoader, ILogger<PageViewContextFactory> logger)
        {
            _contentLoader = contentLoader;
            _logger = logger;
        }

        public ILogger<PageViewContextFactory> Logger { get; }

        public virtual LayoutModel CreateLayoutModel (ContentReference contentReference, HttpContext httpContext)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;

            if (contentReference.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = contentReference;
            }

            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);

            return new LayoutModel
            {
                StartPage = startPage,
                SettingsPage = GetSettingsPage()
            };
        }

        private SettingsPage GetSettingsPage ()
        {
            if (SiteDefinition.Current.StartPage != ContentReference.EmptyReference)
            {
                var settingsPage = _contentLoader.GetChildren<SettingsPage>(SiteDefinition.Current.StartPage).FirstOrDefault();
                if (settingsPage != null)
                {
                    return settingsPage;
                }
                else
                {
                    // log
                    _logger.LogError("Settingssidan finns inte");
                }
            }
            else
            {
                //log
                _logger.LogError("Startsidan finns inte");

            }
            return null;
        }
    }
}
