using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using Application.Request;
using Application.Response;


namespace Application.Interfaces
{


    public interface IPresentationService
    {
        Task<PresentationResponse> CreatePresentation(PresentationRequest request);
        Task<Presentation> GetPresentation(int id);
        Task<IEnumerable<Presentation>> GetAllPresentations();
        Task<PresentationResponse> UpdatePresentation(int id, PresentationRequest request);

    }
}