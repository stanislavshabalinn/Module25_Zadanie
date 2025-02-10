using Microsoft.EntityFrameworkCore;
using Module25_Zadanie.Entity;


namespace Module25_Zadanie.DB
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFCore;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
