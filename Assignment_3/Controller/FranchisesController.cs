using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_3;
using Assignment_3.Models;
using System.Net.Mime;
using AutoMapper;
using Assignment_3.Models.DTO.Franchise;
using Assignment_3.Services.Interface;
using Assignment_3.Models.DTO.Movie;
using Assignment_3.Models.DTO.Character;

namespace Assignment_3.Controller
{
    [Route("api/v1/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _mapper = mapper;
            _franchiseService = franchiseService;
        }

        /// <summary>
        /// Get all franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadFranchiseDTO>>> GetFranchises()
        {
            return _mapper.Map<List<ReadFranchiseDTO>>(await _franchiseService.GetAllFranchisesAsync());
        }

        /// <summary>
        /// Get a specific franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadFranchiseDTO>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetFranchiseById(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadFranchiseDTO>(franchise);
        }

        /// <summary>
        /// Update a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, UpdateFranchiseDTO franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            if (!_franchiseService.FranchiseExistence(id))
                return BadRequest();

            var franch = _mapper.Map<Franchise>(franchise);
            await _franchiseService.UpdateFranchiseAsync(franch);
            return Ok($"Updated franchise succesfully!");
        }
            

        /// <summary>
        /// Add a new franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReadFranchiseDTO>> PostFranchise(CreateFranchiseDTO franchise)
        {
            var franch = _mapper.Map<Franchise>(franchise);
            franch = await _franchiseService.CreateFranchiseAsync(franch);

            string uri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + franch.Id;
            return Created(uri, _mapper.Map<ReadFranchiseDTO>(franchise));
        }

        /// <summary>
        /// Delete a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_franchiseService.FranchiseExistence(id))
                return NotFound();

            await _franchiseService.DeleteFranchiseAsync(id);
            return Ok();
        }

        /// <summary>
        /// Retrives franchises related to a character
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<ReadCharacterDTO>>> GetFranchiseCharacters(int id)
        {
            if (!_franchiseService.FranchiseExistence(id))
                return NotFound();

            return _mapper.Map<List<ReadCharacterDTO>>(
                await _franchiseService.GetFranchiseCharacterByIdAsync(id));
        }

        /// <summary>
        /// Retrieves movies related to franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<ReadMovieDTO>>> GetFranchisesMovies(int id)
        {
            if (!_franchiseService.FranchiseExistence(id))
                return NotFound($"Franchise with Id: {id} was not found");

            return _mapper.Map<List<ReadMovieDTO>>(
                await _franchiseService.GetFranchiseMovieByIdAsync(id));
        }
    }
}
