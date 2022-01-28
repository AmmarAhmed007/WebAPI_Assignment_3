using Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-S6N08V2\\SQLEXPRESS; Initial Catalog = MoviesDB; Integrated Security=true;");
        }
    }
}
