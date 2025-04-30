using Labb_3___API.DataContext;
using Labb_3___API.Models;
using Labb_3___API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //private readonly PersonDbContext _context;
        //public PeopleController(PersonDbContext context)      // Moved to LaPerosnaService
        //{                                                     // And LinkService for better separation (srp)
        //    _context = context;
        //}
        private readonly LaPerosnaService _laPersonaService;
        private readonly LinkService _linkService;
        public PeopleController(LaPerosnaService laPersonaService, LinkService linkService)
        {
            _laPersonaService = laPersonaService;
            _linkService = linkService;
        }

        // GET all people
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersonas()
        {
            var persons = await _laPersonaService.GetAllPersonasAsync();
            return Ok(persons);

        }

        // GET all Interests of 1 person
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPersonInterests(int id)
        {
            return await _laPersonaService.GetPersonInterestsAsync(id);
        }

        // GET all Links of 1 person
        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<Link>>> GetPersonLinks(int id)
        {
            var links = await _laPersonaService.GetPersonLinksAsync(id);
            
            if (links == null || links.Count == 0)
                return NotFound("No links found for this person.");

            return Ok(links);
        }

        // POST a new intrest to a person
        [HttpPost("{personId}/interests/{interestId}")]
        public async Task<IActionResult> AddInterestToPerson(int personId, int interestId)
        {
            var result = await _laPersonaService.AddInterestToPersonAsync(personId, interestId);
            
            if (!result)
                return NotFound("Person or Interest not found.");

            return NoContent();
        }

        // POST a new link to a person
        [HttpPost("{personId}/intrests/{interestId}/links")]
        public async Task<IActionResult> AddNewLinkPersonaIntrest(int personId, int interestId, [FromBody] string url)
        {
            var result = await _linkService.NewLinkAsync(personId, interestId, url);

            if (!result)
                return NotFound("Person or Interest not found.");
            return NoContent();
        }
    }
}