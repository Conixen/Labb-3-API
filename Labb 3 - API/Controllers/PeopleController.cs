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

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersonas()
        {
            return await _context.Persons.ToListAsync();

        }
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterests(int id)
        {
            var intrests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Select(pi => pi.Interest)
                .ToListAsync();

            return intrests;
        }

    }
}
