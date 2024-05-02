using Microsoft.EntityFrameworkCore;
using WagglyDBHosting.Models;

namespace WagglyDBHosting.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<Walkers>  Walkers { get; set; }
    }
}
