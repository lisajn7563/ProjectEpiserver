using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Models.Pages;
using Nackademin_Episerver.Models.ViewModels;

namespace Nackademin_Episerver.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public IActionResult Index(StartPage currentPage)
        {
            var model = new StartPageViewModel(currentPage);

            return View(model);
        }
    }
}
