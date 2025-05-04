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
    public interface IAskService
    {
        Task<IEnumerable<Ask>> GetAllAsks();
        Task<Ask> GetAsk(int id);
        Task<AskResponse> CreateAsk(AskRequest request);
        Task<AskResponse> UpdateAsk(int id, AskRequest request);
    }
}
