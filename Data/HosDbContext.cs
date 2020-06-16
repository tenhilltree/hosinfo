using Microsoft.EntityFrameworkCore;

namespace RazorSecond.Data
{
    public class HosDbContext : DbContext
    {
        public HosDbContext (
            DbContextOptions<HosDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorSecond.Models.Stuff> Stuff { get; set; }
    }
}