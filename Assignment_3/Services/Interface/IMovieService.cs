using Assignment_3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_3.Services.Interface
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<IEnumerable<Character>> GetCharactersMovieByIdAsync(int id);
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<Movie> CreateMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
        public Task UpdateFranchiseMovieAsync(int movie, List<int> characters);
        public Task UpdateCharactersMovieAsync(int franchise, int movie);
        public bool MovieExistence(int id);
    }
}
