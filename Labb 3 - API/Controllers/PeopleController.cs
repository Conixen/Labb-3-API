using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDBContext _context;
        public PeopleController(PeopleDBContext context)
        {
            _context = context;
        }
        [HttpGet()]

        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var people = await _context.Persons.ToListAsync();
            if (people == null || people.Count == 0)
            {
                return NotFound();
            }
            return Ok(people);
        }
        HttpPost()]
    }
}
