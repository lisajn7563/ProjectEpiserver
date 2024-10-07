using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Models.Pages;
using Nackademin_Episerver.Models.ViewModels;

namespace Nackademin_Episerver.Controllers
{
    public class ErrorPageController : PageControllerBase<ErrorPage>
    {
        public IActionResult Index(ErrorPage currentPage)
        {
            var model = new ErrorPageViewModel(currentPage);

            return View(model);
        }
    }
}
