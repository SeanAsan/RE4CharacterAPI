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
    public class OrganizationController : ControllerBase
    {
        private readonly RE4CharacterAPIDBContext _context;

        public OrganizationController(RE4CharacterAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
        {
          if (_context.Organizations == null)
          {
              return NotFound();
          }
            return await _context.Organizations.ToListAsync();
        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
          if (_context.Organizations == null)
          {
              return NotFound();
          }
            var organization = await _context.Organizations.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: api/Organization/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return BadRequest();
            }

            _context.Entry(organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organization
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
          if (_context.Organizations == null)
          {
              return Problem("Entity set 'RE4CharacterAPIDBContext.Organizations'  is null.");
          }
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganization", new { id = organization.OrganizationId }, organization);
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteOrganization(int id)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(s => s.OrganizationId == id);
            var response = new Response();

            if (organization == null)
            {
                response.statusCode = 404;
                response.statusDescription = "L Code. Thats not it chief.";
                return response;
            }

            else
            {
                response.statusCode = 200;
                response.statusDescription = "ITS VALID!!!! YESSIRRRR!!!!!";

                _context.Organizations.Remove(organization);

                await _context.SaveChangesAsync();

                return response;
            }
            
        }

        private bool OrganizationExists(int id)
        {
            return (_context.Organizations?.Any(e => e.OrganizationId == id)).GetValueOrDefault();
        }
    }
}
