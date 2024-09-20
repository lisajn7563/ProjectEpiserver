using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        LayoutModel Layout { get; set; }
    }
}
