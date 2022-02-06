using Assignment_3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_3.Services.Interface
{
    public interface IFranchiseService
    {
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        public Task<IEnumerable<Character>> GetFranchiseCharactersByIdAsync(int id);
        public Task<IEnumerable<Movie>> GetFranchiseMovieByIdAsync(int id);
        public Task<Franchise> GetFranchiseById(int id);
        public Task<Franchise> CreateFranchiseAsync(Franchise franchise);
        public Task UpdateCharacterAsync(Franchise franchise);
        public Task DeleteFranchiseAsync(int id);
        public bool FranchiseExistence(int id);
    }
}
