using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Movies
{
    public class ListModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public ListModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? GenreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ReleaseDateFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ReleaseDateTo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } = "name";

        private const int PageSize = 12;

        public async Task<IActionResult> OnGetAsync()
        {
            Genres = await _context.Genres.ToListAsync();

            var query = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .AsQueryable();

            if (GenreId.HasValue)
            {
                query = query.Where(m => m.Genres.Any(g => g.Id == GenreId.Value));
            }

            if (ReleaseDateFrom.HasValue)
            {
                query = query.Where(m => m.ReleaseDate >= ReleaseDateFrom.Value);
            }

            if (ReleaseDateTo.HasValue)
            {
                query = query.Where(m => m.ReleaseDate <= ReleaseDateTo.Value);
            }

            switch (SortBy.ToLower())
            {
                case "release year":
                    query = query.OrderBy(m => m.ReleaseDate);
                    break;
                case "rating":
                    query = query.OrderBy(m => m.Rating);
                    break;
                default:
                    query = query.OrderBy(m => m.Title);
                    break;
            }

            var totalItems = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            Movies = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return Page();
        }
    }
}