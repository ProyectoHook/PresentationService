using Application.Interfaces.Commands;
using Application.Interfaces.Models;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SlideService:ISlideService
    {
        private readonly ISlideCommand _slideCommand;
        private readonly ISlideQuery _slideQuery;

        public SlideService(ISlideCommand slideCommand, ISlideQuery slideQuery)
        {
            _slideCommand = slideCommand;
            _slideQuery = slideQuery;
        }

        public async Task<SlideResponse> CreateAsync(SlideRequest request)

        {
            var _slide = new Slide
            {
                IdPresentation  = request.IdPresentation,
                Title = request.Title,
                Position = request.Position,
                BackgroundColor = request.BackgroundColor,
                IdAsk = request.IdAsk,
                IdContentType = request.IdContentType

            };
            await _slideCommand.InsertSlide(_slide);

            SlideResponse slideResponde = new SlideResponse
            {
                IdSlide = _slide.IdSlide,
                IdPresentation =_slide.IdPresentation,
                Title = _slide.Title,
                Position = _slide.Position,
                BackgroundColor = _slide.BackgroundColor,
                IdAsk = _slide.IdAsk,
                IdContentType = _slide.IdContentType,
                CreateAt =DateTime.Now,
                ModifiedAt =DateTime.Now
            };
            return slideResponde;
        }
    }
}
