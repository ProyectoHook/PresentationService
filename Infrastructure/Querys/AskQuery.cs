using Application.Interfaces.Querys;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class AskQuery : IAskQuery
    {
        private readonly ServiceContext _context;

        public AskQuery(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ask>> GetAllAsks()
        {
            return await _context.Asks.ToListAsync();
        }

        public async Task<Ask> GetAsk(int id)
        {
            var ask = await _context.Asks.FindAsync(id);

            return ask;

        }
    }

}
