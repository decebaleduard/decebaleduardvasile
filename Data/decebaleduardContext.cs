using Microsoft.EntityFrameworkCore;

namespace decebaleduard.Data
{
    public class decebaleduardContext : DbContext
    {
        public decebaleduardContext(DbContextOptions<decebaleduardContext> options)
            : base(options)
        {
        }

        public DbSet<decebaleduard.Models.Client> Client { get; set; } = default!;

        public DbSet<decebaleduard.Models.Store> Store { get; set; }

        public DbSet<decebaleduard.Models.Watch> Watch { get; set; }

    }
}
