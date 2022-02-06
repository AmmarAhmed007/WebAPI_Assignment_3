using Assignment_3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_3.Services.Interface
{
    public interface ICharacterService
    {
        public Task<IEnumerable<Character>> GetAllCharactersAsync();
        public Task<Character> GetCharacterByIdAsync(int id);
        public Task<Character> CreateCharacterAsync(Character character);
        public Task UpdateCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public Task EditMoviesCharacterAsync(int id, List<int> movie);
        public bool CharacterExistence(int id);
    }
}
