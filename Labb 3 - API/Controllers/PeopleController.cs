using Labb_3___API.DataContext;
using Labb_3___API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PeopleController(PersonDbContext context)
        {
            _context = context;
        }

        // GET all people
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersonas()
        {
            return await _context.Persons.ToListAsync();

        }
        // GET all Interests of 1 person
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPersonasInterests(int id)
        {
            var getIntrests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Select(pi => pi.Interest)
                .ToListAsync();

            return getIntrests;
        }
        // GET all Links of 1 person
        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<Link>>> GetPersonasLinks(int id)
        {
            var getLinks = await _context.Links
                .Where(l => l.PersonId == id)
                .ToListAsync();
            if (getLinks == null || getLinks.Count == 0)
            {
                return NotFound("No links found for this person.");
            }
            return getLinks;
        }
        // POST a new intrest to a person
        [HttpPost("{personId}/interests/{intrestId}")]
        public async Task<IActionResult> NewActivity2Persona(int personId, int intrestId)
        {
            var postPersonas = await _context.Persons.FindAsync(personId);
            var postIntrest = await _context.Interests.FindAsync(intrestId);

            if (postPersonas == null || postIntrest == null)
            {
                return NotFound("Person or Interest not found.");
            }
            var newMtmInterest = new MtmInterest
            {
                PersonId = personId,
                InterestId = intrestId
            };
            _context.PersonInterests.Add(newMtmInterest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
