using Nackademin_Episerver.Models;

namespace Nackademin_Episerver.Business.Services
{
    public interface IMovieService
    {
        Task<List<MovieDetails>> GetMoviesWithDetailsAsync(string query);
    }
}
