using DiziFilm.Project.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiziFilm.Project.DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CEREBRUM-PC\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=True;");
        }

        public DbSet<Product> Products{ get; set; }
        
        public DbSet<Category> Categories{ get; set; }



    }
}
