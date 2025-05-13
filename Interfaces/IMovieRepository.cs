using Mini_Theatre.Models;

namespace Mini_Theatre.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetUpcomingMovies();
        Task<IEnumerable<Movie>> GetPlayingMovies();
    }
}
