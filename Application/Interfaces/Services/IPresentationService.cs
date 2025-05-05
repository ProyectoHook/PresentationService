using System.Threading.Tasks;
using Domain.Entities;
using System.Collections.Generic;
using Application.Request;
using Application.Response;


namespace Application.Interfaces.Services
{


    public interface IPresentationService
    {
        Task<PresentationResponse> CreatePresentation(PresentationRequest request);
        Task<PresentationResponse> GetPresentation(int id);
        Task<IEnumerable<Presentation>> GetAllPresentations();
        Task<PresentationResponse> UpdatePresentation(int id, PresentationRequest request);

    }
}