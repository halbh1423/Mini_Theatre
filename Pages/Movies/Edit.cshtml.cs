using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        [BindProperty]
        public List<int> SelectedGenres { get; set; }
        [BindProperty]
        public List<int> SelectedActors { get; set; }
        [BindProperty]
        public List<int> SelectedDirectors { get; set; }

        public List<Genre> Genres { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await _context.Movies
                                  .Include(m => m.Genres)
                                  .Include(m => m.Actors)
                                  .Include(m => m.Directors)
                                  .FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            Genres = await _context.Genres.ToListAsync();
            Actors = await _context.Actors.ToListAsync();
            Directors = await _context.Directors.ToListAsync();

            SelectedGenres = Movie.Genres.Select(g => g.Id).ToList();
            SelectedActors = Movie.Actors.Select(a => a.Id).ToList();
            SelectedDirectors = Movie.Directors.Select(d => d.Id).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Genres = await _context.Genres.ToListAsync();
                Actors = await _context.Actors.ToListAsync();
                Directors = await _context.Directors.ToListAsync();
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var movieGenres = _context.MovieGenres.Where(mg => mg.MovieId == Movie.Id).ToList();
            var movieActors = _context.MovieActors.Where(ma => ma.MovieId == Movie.Id).ToList();
            var movieDirectors = _context.MovieDirectors.Where(md => md.MovieId == Movie.Id).ToList();

            _context.MovieGenres.RemoveRange(movieGenres);
            _context.MovieActors.RemoveRange(movieActors);
            _context.MovieDirectors.RemoveRange(movieDirectors);
            await _context.SaveChangesAsync();

            if (SelectedGenres != null)
            {
                foreach (var genreId in SelectedGenres)
                {
                    _context.MovieGenres.Add(new MovieGenre { MovieId = Movie.Id, GenreId = genreId });
                }
            }

            if (SelectedActors != null)
            {
                foreach (var actorId in SelectedActors)
                {
                    _context.MovieActors.Add(new MovieActor { MovieId = Movie.Id, ActorId = actorId });
                }
            }

            if (SelectedDirectors != null)
            {
                foreach (var directorId in SelectedDirectors)
                {
                    _context.MovieDirectors.Add(new MovieDirector { MovieId = Movie.Id, DirectorId = directorId });
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
