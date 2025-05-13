using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Manage
{
    public class ManageMovieModel : PageModel
    {
        private ApplicationDbContext _context;

        public ManageMovieModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }

        public List<Genre> AllGenres { get; set; }
        public List<Actor> AllActors { get; set; }
        public List<Director> AllDirectors { get; set; }

        [BindProperty]
        public List<int> SelectedGenres { get; set; }
        [BindProperty]
        public List<int> SelectedActors { get; set; }
        [BindProperty]
        public List<int> SelectedDirectors { get; set; }

        public void OnGet()
        {
            Movie = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .FirstOrDefault();

            Movies = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .ToList();

            AllGenres = _context.Genres.ToList();
            AllActors= _context.Actors.ToList();
            AllDirectors = _context.Directors.ToList();
        }

        public IActionResult OnGetGetMovieDetails(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return new JsonResult(new
            {
                title = movie.Title,
                description = movie.Description,
                duration = movie.Duration,
                rating = movie.Rating,
                releaseDate = movie.ReleaseDate?.ToString("yyyy-MM-dd"),
                posterUrl = movie.PosterUrl,
                trailerUrl = movie.TrailerUrl,
                isActive = movie.IsActive,
                createTime = movie.CreateTime,
                updateTime = movie.UpdateTime,
                deleteTime = movie.DeleteTime,
                genres = movie.Genres.ToList(),
                actors = movie.Actors.ToList(),
                directors = movie.Directors.ToList()
            });
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Movie.UpdateTime = DateTime.Now;

            Movie.Genres = SelectedGenres.Select(id => new Genre { Id = id }).ToList();
            Movie.Actors = SelectedActors.Select(id => new Actor { Id = id }).ToList();
            Movie.Directors = SelectedDirectors.Select(id => new Director { Id = id }).ToList();

            _context.Attach(Movie).State = EntityState.Modified;

            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageMovie");
        }

        public IActionResult OnGetDelete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.DeleteTime = DateTime.Now;
            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageMovie");
        }
    }
}
