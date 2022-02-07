using Assignment_3.Models;
using Assignment_3.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDBContext _context;

        public MovieService(MovieDBContext context)
        {
            _context = context;
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var film = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(film);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Characters).ToListAsync();
        }

        public async Task<IEnumerable<Character>> GetCharactersMovieByIdAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            return movie.Characters.ToList();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await GetMovie(id);
        }

        public bool MovieExistence(int id)
        {
            return _context.Movies.Any(m => m.Id == id);
        }

        public async Task UpdateCharactersMovieAsync(int movie, List<int> character)
        {
            var film = await GetMovie(movie);
            film.Characters = await GetCharacterAsync(character);
            await _context.SaveChangesAsync();
        }

        public Task UpdateFranchiseMovieAsync(int movie, List<int> characters)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets character Async
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        private async Task<List<Character>> GetCharacterAsync(List<int> character)
        {
            var chara = new List<Character>();
            foreach (int characters in character)
            {
                var film = await _context.Characters.FindAsync(characters);
                if (chara == null)
                    throw new KeyNotFoundException();
                chara.Add(film);
            }
            return chara;
        }

        public async Task<Movie> GetMovie(int movie)
        {
            return await _context.Movies.Include(m => m.Characters).SingleOrDefaultAsync(m => m.Id == movie);
        }


    }
}
