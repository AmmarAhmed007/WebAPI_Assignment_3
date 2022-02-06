using Assignment_3.Models;
using Assignment_3.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly MovieDBContext _context;
        public CharacterService(MovieDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method checks if Character Exists by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CharacterExistence(int id)
        {
            return _context.Characters.Any(c => c.Id == id);
        }

        /// <summary>
        /// Creates/Adds character and saves/updates db
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task<Character> CreateCharacterAsync(Character character)
        {
            _context.Characters.Add(character); 
            await _context.SaveChangesAsync();
            return character;
        }

        /// <summary>
        /// Deletes a character by Id and saves the change
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCharacterAsync(int id)
        {
            var chara = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(chara);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates character with movie id's
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task EditMoviesCharacterAsync(int id, List<int> movie)
        {
            var character = await GetCharacterAsync(id);

            character.Movies = await GetCharacterMoviesAsync(movie);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieve all characters
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await GetCharacterByIdAsync(id);
        }

        /// <summary>
        /// Updates character
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public async Task UpdateCharacterAsync(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            return await _context.Characters.Include(c => c.Movies).SingleOrDefaultAsync(c => c.Id == id);
        }

        private async Task<List<Movie>> GetCharacterMoviesAsync(List<int> movie)
        {
            var movies = new List<Movie>();
            foreach (int movieId in movie)
            {
                var film = await _context.Movies.FindAsync(movieId);
                movies.Add(film);
            }
            return movies;
        }
    }
}
