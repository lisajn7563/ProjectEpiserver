﻿

using Nackademin_Episerver.Models;
using Newtonsoft.Json;

namespace Nackademin_Episerver.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MovieService> _logger;

        public MovieService(HttpClient httpClient, ILogger<MovieService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<MovieDetails>> GetMoviesWithDetailsAsync(string query)
        {
            var movies = new List<MovieDetails>();
            try
            {
                var firstRequest = new HttpRequestMessage(HttpMethod.Post, $"https://www.omdbapi.com/?s={query}&apikey=e411ccd9");
                var firstResponse = await _httpClient.SendAsync(firstRequest);

                if (firstResponse.IsSuccessStatusCode)
                {
                    var firstJson = await firstResponse.Content.ReadAsStringAsync();
                    var searchResult = JsonConvert.DeserializeObject<Root>(firstJson);

                    if (searchResult?.Search != null)
                    {
                        foreach (var movie in searchResult.Search)
                        {
                            var secondRequest = new HttpRequestMessage(HttpMethod.Post, $"https://www.omdbapi.com/?i={movie.ImdbID}&apikey=e411ccd9");
                            var secondResponse = await _httpClient.SendAsync(secondRequest);

                            if (secondResponse.IsSuccessStatusCode)
                            {
                                var secondJson = await secondResponse.Content.ReadAsStringAsync();
                                var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(secondJson);

                                if (movieDetails != null)
                                {
                                    movies.Add(movieDetails);
                                }
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return movies;
        }
    }

    //public class MovieService : IMovieService
    //{

    //private readonly HttpClient _httpClient;
    //private readonly ILogger<MovieService> _logger;
    //public MovieService(HttpClient httpClient, ILogger<MovieService> logger)
    //{
    //    _httpClient = httpClient;
    //    _logger = logger;
    //}

    //public async Task<List<MovieDetails>> GetMoviesWithDetailsAsync(string query)
    //{
    //    var movies = new List<MovieDetails>();

    //try
    //{
    //    //todo bryt ut apinyckeln
    //    var firstRequest = new HttpRequestMessage(HttpMethod.Post, $"https://www.omdbapi.com/?s={query}&apikey=e411ccd9");
    //    var firstResponse = await _httpClient.SendAsync(firstRequest);

    //    if (firstResponse.IsSuccessStatusCode)
    //    {
    //        var firstJson = await firstResponse.Content.ReadAsStringAsync();
    //        var searchResult = JsonConvert.DeserializeObject<Root>(firstJson);

    //        if (searchResult?.Search != null)
    //        {
    //            foreach (var movie in searchResult.Search)
    //            {
    //                var secondRequest = new HttpRequestMessage(HttpMethod.Post, $"https://www.omdbapi.com/?i={movie.ImdbID}&apikey=e411ccd9");
    //                var secondResponse = await _httpClient.SendAsync(secondRequest);

    //                if (secondResponse.IsSuccessStatusCode)
    //                {
    //                    var secondJson = await secondResponse.Content.ReadAsStringAsync();
    //                    var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(secondJson);

    //                    if (movieDetails != null)
    //                    {
    //                        movies.Add(movieDetails);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    //catch (Exception e)
    //{
    //    _logger.LogError(e.Message);
    //}

    //return movies;

    // }
    // }
}
