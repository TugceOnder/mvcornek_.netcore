using Microsoft.EntityFrameworkCore;

namespace MvcWebUI3.Models
{
    public class NorthwndContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=NORTHWND;trusted_connection=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
