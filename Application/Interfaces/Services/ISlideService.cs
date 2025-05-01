using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISlideService
    {
        Task<SlideResponse> CreateAsync(SlideRequest request);
        Task<Slide> GetSlideId(int slideId);
        void DeleteSlide(int slideId);
        Task<SlideResponse> UpdateSlide(int slideId, SlideRequest request);
    }
}
