using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RE4CharacterAPI.Models;

namespace RE4CharacterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly RE4CharacterAPIDBContext _context;

        public CharacterController(RE4CharacterAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.Include(s => s.Organization).ToListAsync();
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCharacter(int id)
        {
            var character = await _context.Characters.Include(s => s.Organization).FirstOrDefaultAsync(s => s.CharacterId == id);

            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "L Code. Thats not it chief.";

            if (character != null)
            {
                response.statusCode = 200;
                response.statusDescription = "ITS VALID!!!! YESSIRRRR!!!!!";
                response.Characters.Add(character);
            }

            return response;
        }

        // PUT: api/Character/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Character
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostCharacter(Character character)
        {
            
            var response = new Response();

            response.statusCode = 400;
            response.statusDescription = "L Code. Thats not it chief.";

            if (_context.Characters != null)
            {
                response.statusCode = 200;
                response.statusDescription = "ITS VALID!!!! YESSIRRRR!!!!!";

                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
            } 

            return response;
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteCharacter(int id)
        {
            var character = await _context.Characters.Include(s => s.Organization).FirstOrDefaultAsync(s => s.CharacterId == id);
            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "L Code. Thats not it chief.";

            if (character != null)
            {
                response.statusCode = 200;
                response.statusDescription = "ITS VALID!!!! YESSIRRRR!!!!!";

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }

            return response;

        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.CharacterId == id)).GetValueOrDefault();
        }
    }
}
