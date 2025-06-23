using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Querys;
using Domain.Entities;
using Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{


    public class PresentationQuery : IPresentationQuery
    {
        private readonly ServiceContext _context;

        public PresentationQuery(ServiceContext serviceContext)
        {
            _context = serviceContext;
        }

        public async Task<IEnumerable<Presentation>> GetAllPresentations()
        {
            return await _context.Presentations.ToListAsync();
        }

        public async Task<Presentation> GetPresentation(int id)
        {
            return await _context.Presentations
                .Include(p => p.Slides)
                    .ThenInclude(s => s.Ask)
                        .ThenInclude(a => a.Options)
                .FirstOrDefaultAsync(p => p.IdPresentation == id);
        }


    }
}