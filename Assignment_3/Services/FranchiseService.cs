using Assignment_3.Models;
using Assignment_3.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDBContext _context;

        public FranchiseService(MovieDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new franchise to Db
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public async Task<Franchise> CreateFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }

        /// <summary>
        /// Delete a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if franchise exists by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FranchiseExistence(int id)
        {
            return _context.Franchises.Any(f => f.Id == id);
        }

        /// <summary>
        /// Retrieves all the franchices
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
        {
            return await _context.Franchises.Include(f => f.Movies).ToListAsync();
        }

        /// <summary>
        /// Retrive franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Franchise> GetFranchiseById(int id)
        {
            return await _context.Franchises.Include(f => f.Movies).SingleOrDefaultAsync(f => f.Id == id);
        }

        /// <summary>
        /// Get all the characters connected to a movie in franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Character>> GetFranchiseCharacterByIdAsync(int id)
        {
            var franchiseCharater = await _context.Movies.Include(m => m.Characters)
                .Where(m => m.FranchiseId == id).Select(m => m.Characters.ToList())
                .FirstOrDefaultAsync();
            return franchiseCharater;
        }

        /// <summary>
        /// Get all the movies connected to a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetFranchiseMovieByIdAsync(int id)
        {
            var franchise = await GetFranchiseById(id);
            return franchise.Movies.ToList();
        }

        /// <summary>
        /// Updates a franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
