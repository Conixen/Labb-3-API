using Labb_3___API.DataContext;
using Labb_3___API.Models;

namespace Labb_3___API.Services
{
    public class LinkService
    {
        private readonly PersonDbContext _context;
        public LinkService(PersonDbContext context)
        {
            _context = context;
        }
        public async Task<bool> NewLinkAsync(int perosnId, int intrestId, string url)
        {
            var person = await _context.Persons.FindAsync(perosnId);
            var interest = await _context.Interests.FindAsync(intrestId);
            if (person == null || interest == null)
            {
                return false;
            }

            var link = new Link { PersonId = perosnId, InterestId = intrestId, Url = url };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
