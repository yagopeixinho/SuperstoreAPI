using Microsoft.EntityFrameworkCore;
using Superstore.Models;

namespace Superstore.Context
{
    public class SuperstoreContext : DbContext
    {
        public SuperstoreContext(DbContextOptions<SuperstoreContext> options) : base(options) 
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
