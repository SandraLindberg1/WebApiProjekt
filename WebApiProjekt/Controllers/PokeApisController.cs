using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt.Models;

namespace WebApiProjekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokeApisController : ControllerBase
    {
        private readonly PokeDbContext _context;

        public PokeApisController(PokeDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokeDTO>>> Get()
        {
            return await _context.Pokeapi.Select(t => t.ToDTO()).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeDTO>> GetPoke(int id)
        {
            var poke = await _context.Pokeapi.FindAsync(id);

            if (poke == null)
            {
                return NotFound();
            }

            return poke.ToDTO();

        }


        [HttpPost]
        public async Task<ActionResult<PokeDTO>> PostTodo(PokeDTO dto)
        {
            var poke = dto.ToModel();
            _context.Pokeapi.Add(poke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokeapi", new { id = poke.Id }, dto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoke(int id)
        {
            var todo = await _context.Pokeapi.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Pokeapi.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
