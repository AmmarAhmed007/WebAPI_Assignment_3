using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_3;
using System.Net.Mime;
using AutoMapper;
using Assignment_3.Models.DTO.Movie;
using Assignment_3.Services.Interface;
using Assignment_3.Models.DTO.Character;

namespace Assignment_3.Controller
{
    [Route("api/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        //private readonly MovieDBContext _context;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateMovieDTO>>> GetMovies()
        {
            return _mapper.Map<List<CreateMovieDTO>>(await _movieService.GetAllMoviesAsync());   
        }

        /// <summary>
        /// Get specific Movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadMovieDTO>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadMovieDTO>(movie);
        }

        /// <summary>
        /// Update a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, CreateMovieDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            if (!_movieService.MovieExistence(id))
            {
                return NotFound();
            }

            //Map to domain
            Movie domain = _mapper.Map<Movie>(movie);
            await _movieService.UpdateMovieAsync(domain);

            return Ok();
        }

        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var dMovie = _mapper.Map<Movie>(movie);
            dMovie = await _movieService.CreateMovieAsync(dMovie);

            return CreatedAtAction("GetMovie", new { id = dMovie.Id }, _mapper.Map<ReadMovieDTO>(dMovie));
        }

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExistence(id))
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<ReadCharacterDTO>>> GetMovieCharacters(int id)
        {
            if (!_movieService.MovieExistence(id))
                return NotFound();

            return _mapper.Map<List<ReadCharacterDTO>>(
                await _movieService.GetCharactersMovieByIdAsync(id));
        }

        [HttpPatch("{id}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> character)
        {
            if (!_movieService.MovieExistence(id))
                return NotFound();
            try
            {
                await _movieService.UpdateCharactersMovieAsync(id, character);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
            string characters = " ";
            character.ForEach(m => characters += $"{m},");
            return Ok();
        }

        [HttpPatch("{id}/franchise")]
        public async Task<IActionResult> UpdateMovieFranchise(int id, List<int> franchise)
        {
            if (!_movieService.MovieExistence(id))
            {
                return NotFound();
            }

            try
            {
                await _movieService.UpdateFranchiseMovieAsync(id, franchise);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
