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
using Assignment_3.Models.DTO.Character;
using Assignment_3.Services.Interface;

namespace Assignment_3.Controller
{
    [Route("api/v1/characters")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _mapper = mapper;
            _characterService = characterService;
        }

        /// <summary>
        /// Get all the characters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCharacterDTO>>> GetCharacters()
        {
            return _mapper.Map<List<ReadCharacterDTO>>(await _characterService.GetAllCharactersAsync());
        }

        /// <summary>
        /// Get character by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCharacterDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return _mapper.Map<ReadCharacterDTO>(character);
        }

        /// <summary>
        /// Update a character
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            var chara = _mapper.Map<Character>(character);
            await _characterService.UpdateCharacterAsync(chara);
            return Ok($"Updated Character");
        }

        /// <summary>
        /// Add a new character
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateCharacterDTO>> PostCharacter(CreateCharacterDTO character)
        {
            var chara = _mapper.Map<Character>(character);
            chara = await _characterService.CreateCharacterAsync(chara);

            string uri = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                + HttpContext.Request.Path + "/" + chara.Id;

            return CreatedAtAction(uri, _mapper.Map<ReadCharacterDTO>(character));
        }

        /// <summary>
        /// Delete a character
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!_characterService.CharacterExistence(id))
                return NotFound();

            await _characterService.DeleteCharacterAsync(id);
            return Ok();
        }

        /// <summary>
        /// Updates characters movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPatch("{id}/movies")]
        public async Task<IActionResult> PatchCharacterMovie(int id, List<int> movie)
        {
            if (!_characterService.CharacterExistence(id))
                return NotFound();

            await _characterService.EditMoviesCharacterAsync(id, movie);
            return Ok();
        }
    }
}
