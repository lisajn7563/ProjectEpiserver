using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Models.ViewModels
{
    public class MoviePageViewModel : PageViewModel<SearchPage>
    {
        public MoviePageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public MovieDetails Movie { get; set; }
    }
}
