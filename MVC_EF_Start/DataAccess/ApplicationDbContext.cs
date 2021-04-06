using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Placed> Places { get; set; }
    }
}