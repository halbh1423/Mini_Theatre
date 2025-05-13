using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public class MovieDto
        {
            public Movie Movie { get; set; }
            public List<ScheduleDto> ScheduleDtos { get; set; }
        }
        public class ScheduleDto
        {
            public int ScheduleId { get; set; }
            public DateTime ShowTime { get; set; }
        }

        public List<Movie> PlayingMovies { get; set; }
        public List<Movie> UpcomingMovies { get; set; }
        public List<MovieDto> MoviesSchedules { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
            PlayingMovies = new();
            UpcomingMovies = new();
            MoviesSchedules = new();
        }

        public void OnGet(DateTime? showDate)
        {
            DateTime searchDate = showDate ?? DateTime.Today;

            var movies = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .Include(m => m.Schedules)
                .ToList();

            PlayingMovies = movies
                .Where(m => m.Schedules.Any(s => s.ShowDate.Date == DateTime.Today))
                .ToList();

            UpcomingMovies = movies
                .Where(m => !m.Schedules.Any(s => s.ShowDate.Date <= DateTime.Today))
                .ToList();

            MoviesSchedules = movies
                .Where(m => m.Schedules.Any(s => s.ShowDate.Date == searchDate.Date))
                .Select(movie => new MovieDto
                {
                    Movie = movie,
                    ScheduleDtos = movie.Schedules
                        .Where(s => s.ShowDate.Date == searchDate)
                        .Select(s => new ScheduleDto
                        {
                            ScheduleId = s.Id,
                            ShowTime = s.ShowTime
                        })
                        .ToList()
                })
                .ToList();
        }
    }
}
