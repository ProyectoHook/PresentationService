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
    public class OptionQuery : IOptionQuery
    {
        private readonly ServiceContext _context;

        public OptionQuery(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Option>> GetAllOptions()
        {
            return await _context.options.ToListAsync();
        }

        public async Task<Option> GetOption(int id)
        {
            return await _context.options.FirstOrDefaultAsync(o => o.IdOption == id);
        }
    }
}
