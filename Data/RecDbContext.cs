using Microsoft.EntityFrameworkCore;

namespace RazorSecond.Data
{
    public class RecDbContext : DbContext
    {
        public RecDbContext(
            DbContextOptions<RecDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorSecond.Models.TreatRecord> TreatRecord { get; set; }
    }
}