using System.Threading.Tasks;
using Application.Interfaces.Commands;
using Application.UseCase;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


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
        public async Task UpdatePresentation(Presentation presentation)
        {
            _context.Update(presentation);
            _context.SaveChanges();
        }

    }
}