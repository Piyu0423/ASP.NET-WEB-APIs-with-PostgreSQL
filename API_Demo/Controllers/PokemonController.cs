using API_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PokemonController(AppDbContext context) {
            _context = context;
        }
        [HttpGet("GetPokemons")]
        public async Task<IActionResult> GetPokemon()
        {
            var results = await _context.Pokemon.Select(x => new Pokemon
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
            }).ToListAsync();
            return Ok(results);
        }

        [HttpPost("CreatePokemon")]
        public async Task<IActionResult> CreatePokemon([FromBody] Pokemon pokemon)
        {
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("EditPokemon")]
        public async Task<IActionResult> EditPokemon([FromBody] Pokemon pokemon)
            {
            var rows = await _context.Pokemon.Where(x=>x.Id == pokemon.Id)
            .ExecuteUpdateAsync(x=>x.SetProperty(x=>x.Name, pokemon.Name));
            return Ok(rows);
            }

        [HttpDelete("DeletePokemon")]
        public async Task<IActionResult> DeletePokemon(int pokemonId)
        {
            var rows = await _context.Pokemon.Where(x => x.Id == pokemonId).ExecuteDeleteAsync();
            return Ok(true);
        }

    }
}
