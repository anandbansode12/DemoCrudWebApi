using Microsoft.EntityFrameworkCore;

namespace DemoCrudWebApi.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<PlayersModel> Players { get; set; }
    }
}
