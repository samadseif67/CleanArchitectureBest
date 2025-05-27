using Dapper_App.Modals;
using Microsoft.EntityFrameworkCore;

namespace Dapper_App.ContextApp
{
    public class ShopContext:DbContext
    {

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }


        public DbSet<Person> Persons { get; set; }



    }
}
