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
        // Get all Interests of 1 person
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPersonasInterests(int id)
        {
            var intrests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Select(pi => pi.Interest)
                .ToListAsync();

            return intrests;
        }
        // Get all Links of 1 person
        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<Link>>> GetPersonasLinks(int id)
        {
            var getLinks = await _context.Links
                .Where(gL => gL.PersonId == id)
                .ToListAsync();
            if (getLinks == null || getLinks.Count == 0)
            {
                return NotFound("No links found for this person.");
            }
            return getLinks;
        }
        // Post a new intrest to a person
    }
}
