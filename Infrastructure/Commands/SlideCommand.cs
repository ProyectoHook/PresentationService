using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class SlideCommand:ISlideCommand
    {
        private readonly ServiceContext _context;

        public SlideCommand(ServiceContext context)
        {
            _context = context;
        }

        public async Task InsertSlide(Slide slide)
        {
            _context.Add(slide);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSlide(Slide slide)
        {
            _context.Slides.Update(slide);
            await _context.SaveChangesAsync();
        }
    }
}
