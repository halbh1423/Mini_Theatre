
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;
using Mini_Theatre.Models;

namespace Mini_Theatre.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Movie>> GetUpcomingMovies()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetPlayingMovies()
        {
            throw new NotImplementedException();
        }

    }
}
