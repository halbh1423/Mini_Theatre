
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;
using Mini_Theatre.Models;

namespace Mini_Theatre.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
