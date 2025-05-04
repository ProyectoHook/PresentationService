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
    public interface IOptionService
    {
        Task<OptionResponse> CreateOption(OptionRequest request);
        Task<Option> GetOption(int id);
        Task<IEnumerable<Option>> GetAllOptions();
        Task<Option> UpdateOption(int id, OptionRequest request);
    }
}
