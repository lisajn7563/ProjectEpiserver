using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Models.ViewModels
{
    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public List<MovieDetails> Movies { get; set; } = [];
    }
}
