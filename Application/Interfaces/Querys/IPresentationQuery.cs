 using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
 

namespace Application.Interfaces.Querys
{

    public interface IPresentationQuery
    {
        Task<List<Presentation>> GetAllPresentations();
        Task<Presentation> GetPresentation(int id);
        Task<List<Presentation>> GetPresentationsByUserId(Guid userId);
    }
}