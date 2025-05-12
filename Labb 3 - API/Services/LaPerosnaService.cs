using Labb_3___API.DataContext;
using Labb_3___API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Services
{
    public class LaPerosnaService
    {
        private readonly PersonDbContext _context;
        public LaPerosnaService(PersonDbContext context)
        {
            _context = context;
        }

        // GET all people
        public async Task<List<Person>> GetAllPersonasAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET all Interests of 1 person
        public async Task<List<Interest>> GetPersonInterestsAsync(int personId)
        {
            return await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Include(pi => pi.Interest)
                .Select(pi => pi.Interest)
                .ToListAsync();
        }

        // GET all Links of 1 person
        public async Task<List<Link>> GetPersonLinksAsync(int personId)
        {
            return await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Include(pi => pi.Links)
                .SelectMany(pi => pi.Links)
                .ToListAsync();
        }

        // POST a new interest to a person
        public async Task<string?> AddInterestToPersonAsync(int personId, int interestId)
        {
            var person = await _context.Persons.FindAsync(personId);
            if (person == null)
                return "Person not found.";

            var interest = await _context.Interests.FindAsync(interestId);
            if (interest == null)
                return "Interest not found.";

            var existingConnection = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            if (existingConnection != null)
                return "Person is already connected to this interest.";

            var newConnection = new MtmInterest
            {
                PersonId = personId,
                InterestId = interestId
            };

            _context.PersonInterests.Add(newConnection);
            await _context.SaveChangesAsync();

            return null; // Success!
        }

    }
}
