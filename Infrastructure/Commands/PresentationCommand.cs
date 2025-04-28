using System.Threading.Tasks;
using Application.Interfaces.Commands;
using Application.UserCase;
using Domain.Entities;
using Infrastructure.Persistence;
 

namespace Infrastructure.Commands
{
    public class PresentationCommand : IPresentationCommands
    {
        private readonly ServiceContext _context;

        public PresentationCommand(ServiceContext serviceContext)
        {
            _context = serviceContext;
        }

        public async Task<Presentation> InsertPresentation(Presentation presnetation)
        {
            _context.Presentations.AddAsync(presnetation);
            await _context.SaveChangesAsync();
            return presnetation;

        }

        
    }
}