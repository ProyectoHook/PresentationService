using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class AskCommand : IAskCommands
    {
        private readonly ServiceContext _context;

        public AskCommand(ServiceContext context)
        {
            _context = context;
        }

        public async Task<Ask> InsertAsk(Ask ask)
        {
            await _context.asks.AddAsync(ask);
            await _context.SaveChangesAsync();
            return ask;
        }

        public async Task UpdateAsk(Ask ask)
        {
            _context.asks.Update(ask);
            await _context.SaveChangesAsync();
        }
    }
}
