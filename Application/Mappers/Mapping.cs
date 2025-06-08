using Application.Request;
using Application.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Presentation,PresentationResponse>();
            CreateMap<Slide, SlideResponse>();
        }
    }
}
