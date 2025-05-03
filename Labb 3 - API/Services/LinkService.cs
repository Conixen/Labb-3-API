using Labb_3___API.DataContext;
using Labb_3___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Services
{
    public class LinkService
    {
        private readonly PersonDbContext _context;
        public LinkService(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<bool> NewLinkAsync(int personId, int interestId, string url)
        {
            var mtmInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(m => m.PersonId == personId && m.InterestId == interestId);

            if (mtmInterest == null)
                return false;

            var link = new Link
            {
                MtmInterestId = mtmInterest.MtmInterestId,
                Url = url
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
