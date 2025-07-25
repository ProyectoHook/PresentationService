﻿using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Request;
using Application.Response;

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

        public async Task<slideResponseDto> CreateAsync(SlideRequest request)

        {
            var _slide = new Slide
            { 
                IdPresentation = request.IdPresentation,
                Title = request.Title,
                Position = request.Position,
                BackgroundColor = request.BackgroundColor,
                Url = request.url,
                CreateAt = DateTime.Now,
                ModifiedAt = DateTime.Now
                };

  
            await _slideCommand.InsertSlide(_slide);

            //SlideResponse slideResponde = new SlideResponse
            slideResponseDto slideResponde = new slideResponseDto
            {
                IdSlide = _slide.IdSlide,
                IdPresentation = _slide.IdPresentation,
                Title = _slide.Title,
                Position = _slide.Position,
                BackgroundColor = _slide.BackgroundColor,
                CreateAt = DateTime.Now,
            };
          
            return slideResponde;
        }

        public async Task<Slide> GetSlideId(int slideId)
        {
            return await _slideQuery.GetSlideId(slideId);
        }

        public async void DeleteSlide(int slideId)
        {
            var slide = await _slideQuery.GetSlideId(slideId);

            await _slideCommand.DeleteSlide(slide);
        }

        
        public async Task<slideResponseDto> UpdateSlide(int slideId, SlideRequest request)
        //public async Task<SlideResponse> UpdateSlide(int slideId, SlideRequest request)
        {
            var slide = await _slideQuery.GetSlideId(slideId);

            if (slide == null)

                throw new Exception("Slide no encontrado");

            slide.IdPresentation = request.IdPresentation;
            slide.Title = request.Title;
            slide.Position = request.Position;
            slide.BackgroundColor = request.BackgroundColor;
            slide.Url = request.url;
            slide.ModifiedAt = DateTime.Now;

            await _slideCommand.UpdateSlide(slide);

            //SlideResponse slideResponde = new SlideResponse
            slideResponseDto slideResponde = new slideResponseDto
            {
                IdSlide = slide.IdSlide,
                IdPresentation = request.IdPresentation,
                Title = request.Title,
                Position = request.Position,
                BackgroundColor = request.BackgroundColor,
                Url = request.url,
                CreateAt = slide.CreateAt,
                ModifiedAt = DateTime.Now
            };
            return slideResponde;
        }
    }
}
