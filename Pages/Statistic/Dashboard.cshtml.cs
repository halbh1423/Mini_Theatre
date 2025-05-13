using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Theatre.Data;

namespace Mini_Theatre.Pages.Statistic
{
    public class DashboardModel : PageModel
    {
        private ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
