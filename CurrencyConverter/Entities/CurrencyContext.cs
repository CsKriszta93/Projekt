using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Entities
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }

        public DbSet<Money> Currencies { get; set; }
    }
}
