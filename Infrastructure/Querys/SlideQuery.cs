using Application.Interfaces.Querys;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Querys
{
    public class SlideQuery:ISlideQuery
    {
        private readonly ServiceContext _context;

        public SlideQuery (ServiceContext context)
        {
            _context = context;
        }

        public async Task<Slide> GetSlideId(int slideId)
        {
            var slide = await _context.Slides
                .Include(s => s.Ask)
                .FirstOrDefaultAsync(s => s.IdSlide == slideId);

            return slide;
        }
    }
}
