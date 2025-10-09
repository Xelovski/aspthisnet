using Microsoft.EntityFrameworkCore;
using WebApplication2.Datalayer.Entities;

namespace WebApplication2.Datalayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userApp.db");
        }

    }
}
