using DustyBeerShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace DustyBeerShop.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
    }
}