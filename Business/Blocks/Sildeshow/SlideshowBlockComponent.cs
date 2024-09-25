using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Models.Blocks;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Blocks.Sildeshow
{
    public class SlideshowBlockComponent : AsyncBlockComponent<SlideshowBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(SlideshowBlock currentContent)
        {
            var model = new SlideshowBlockViewModel();

            foreach (var item in currentContent.Slideshow.FilteredItems.Select(x => x.LoadContent()))
            {
                if (item is SlideshowPage)
                {
                    var page = item as SlideshowPage;

                    model.Pages.Add(page);
                }
            }
            return await Task.FromResult(View("~/business/blocks/slideshow/default.cshtml", model));
        }
    }
}
