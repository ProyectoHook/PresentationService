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
    public class OptionCommand : IOptionCommands
    {
        private readonly ServiceContext _context;

        public OptionCommand(ServiceContext serviceContext)
        {
            _context = serviceContext;
        }

        public async Task<Option> InsertOption(Option option)
        {
            await _context.options.AddAsync(option);
            await _context.SaveChangesAsync();
            return option;
        }

        public async Task UpdateOption(Option option)
        {
            _context.options.Update(option);
            await _context.SaveChangesAsync();
        }
    }
}
