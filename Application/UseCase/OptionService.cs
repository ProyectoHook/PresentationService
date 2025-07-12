using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class OptionService : IOptionService
    {
        private readonly IOptionCommands _optionCommands;
        private readonly IOptionQuery _optionQuery;

        public OptionService(IOptionCommands optionCommands, IOptionQuery optionQuery)
        {
            _optionCommands = optionCommands;
            _optionQuery = optionQuery;
        }

        public async Task<Option> GetOption(int id)
        {
            return await _optionQuery.GetOption(id);
        }

        public async Task<IEnumerable<Option>> GetAllOptions()
        {
            return await _optionQuery.GetAllOptions();
        }

    }
}
