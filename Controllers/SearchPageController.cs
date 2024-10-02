﻿using Microsoft.AspNetCore.Mvc;
using Nackademin_Episerver.Business.Services;
using Nackademin_Episerver.Models;
using Nackademin_Episerver.Models.Pages;
using Nackademin_Episerver.Models.ViewModels;

namespace Nackademin_Episerver.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        private readonly IMovieService _movieService;

        public SearchPageController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index(SearchPage currentPage)
        {
            var model = new SearchPageViewModel(currentPage);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchMovie(SearchPage currentPage, string query)
        {
            var model = new SearchPageViewModel(currentPage)
            {
                Movies = await _movieService.GetMoviesWithDetailsAsync(query)
            };

            return View("~/views/searchpage/index.cshtml", model);
        }


        [HttpPost]
        public IActionResult RenderMoviePage(SearchPage currentPage, MovieDetails item)
        {
            var model = new MoviePageViewModel(currentPage);
            model.Movie = item;

            return View("~/views/searchpage/movie.cshtml", model);
        }
    }
}
