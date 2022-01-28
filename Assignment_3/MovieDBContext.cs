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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(

                new Movie
                {
                    Id = 1,
                    MovieTitle = "Interstellar",
                    Genre = "Sci-fi",
                    ReleaseYear = 2014,
                    Director = "Christopher Nolan",
                    PhotoUrl = "https://www.imdb.com/title/tt0816692/mediaviewer/rm4043724800/",
                    YoutubeLink = "https://www.youtube.com/watch?v=zSWdZVtXT7E&t=60s"
                },

                new Movie
                {
                    Id = 2,
                    MovieTitle = "Avengers: End Game",
                    Genre = "Action, Sci-fi",
                    ReleaseYear = 2019,
                    Director = "Joe & Anthony Russo",
                    PhotoUrl = "https://www.imdb.com/title/tt4154796/mediaviewer/rm2775147008/",
                    YoutubeLink = "https://www.youtube.com/watch?v=TcMBFSGVi1c"
                },

                new Movie
                {
                    Id = 3,
                    MovieTitle = "The Godfather",
                    Genre = "Crime, Drama",
                    ReleaseYear = 1972,
                    Director = "Francis Ford Coppola",
                    PhotoUrl = "https://www.imdb.com/title/tt0068646/mediaviewer/rm746868224/",
                    YoutubeLink = "https://www.youtube.com/watch?v=sY1S34973zA"
                }
            );
        }

        //public static void CreateMovie()
        //{
        //    Movie movie1 = new Movie()
        //    {
        //        MovieTitle = "Interstellar",
        //        Genre = "Sci-fi",
        //        ReleaseYear = 2014,
        //        Director = "Christopher Nolan",
        //        PhotoUrl = "https://www.imdb.com/title/tt0816692/mediaviewer/rm4043724800/",
        //        YoutubeLink = "https://www.youtube.com/watch?v=zSWdZVtXT7E&t=60s"

        //    };
        //}
    }
}
