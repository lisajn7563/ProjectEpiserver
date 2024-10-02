using EPiServer.DataAccess;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Security;
using EPiServer.Web;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.ScheduledJobs
{
    [ScheduledPlugIn(
        DisplayName = "Handle Movie Page",
        Description = "This job deletes movies pages",
        GUID = "7BC44EA2-58C0-4AD2-BCAB-CB270F806419")]
    public class HandleMoviePages : ScheduledJobBase
    {
        private readonly IContentLoader _contentLoader;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;

        public HandleMoviePages(IContentLoader contentLoader,
            ISiteDefinitionRepository siteDefinitionRepository, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;
            _siteDefinitionRepository = siteDefinitionRepository;
            _contentRepository = contentRepository;

            IsStoppable = true;
        }

        public override void Stop()
        {
            _stopSignaled = true;
        }

        public override string Execute()
        {
            CreateMoviePages();

            return $"1 movie page created";

            //var movies = GetMoviePage();
        }

        private List<SavedMoviePage> GetMoviePages()
        {
            var movies = new List<SavedMoviePage>();
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var settingsPage = _contentLoader.GetChildren<SettingsPage>(contentReference).FirstOrDefault();

            if (settingsPage.LinkToMoviesContainer != null)
            {
                var moviesContainer = _contentLoader.Get<ContainerPage>(settingsPage.LinkToMoviesContainer);
                movies = _contentLoader.GetChildren<SavedMoviePage>(moviesContainer.ContentLink).ToList();
            }

            return movies;
        }
        private void CreateMoviePages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var settingsPage = _contentLoader.GetChildren<SettingsPage>(contentReference).FirstOrDefault();

            if (settingsPage.LinkToMoviesContainer != null)
            {
                var moviesContainer = _contentLoader.Get<ContainerPage>(settingsPage.LinkToMoviesContainer);
                var savedMoviePage = _contentRepository.GetDefault<SavedMoviePage>(moviesContainer.ContentLink);

                // Set properties
                savedMoviePage.Name = "Inception";
                savedMoviePage.Heading = "Nice movie";

                // Save and publish the page
                _contentRepository.Save(savedMoviePage, SaveAction.Publish, AccessLevel.NoAccess);
            }
        }
    }
}
