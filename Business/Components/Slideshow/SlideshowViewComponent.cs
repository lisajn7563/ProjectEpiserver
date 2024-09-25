using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Components.Slideshow
{
	public class SlideshowViewComponent : ViewComponent
	{
		private readonly IContentLoader _contentLoader;

		public SlideshowViewComponent(IContentLoader contentLoader)
        {
			_contentLoader = contentLoader;
		}

		public IViewComponentResult Invoke(IContentLoader contentLoader)
		{
			var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
			var model = new SlideshowViewComponentModel();

			if (startPage.Content != null)
			{
				foreach (var item in startPage.Content.FilteredItems.Select(x => x.LoadContent())) 
				{
					if (item is SlideshowPage)
					{
						var page = item as SlideshowPage;
						model.Pages.Add(page);
					}
				}
			}
			return View ("~/business/components/slideshow/default.cshtml", model);
		}
    }
}
