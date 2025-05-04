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

        public async Task<OptionResponse> CreateOption(OptionRequest request)
        {
            var option = new Option
            {
                OptionText = request.OptionText,
                IdAsk = request.IdAsk,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _optionCommands.InsertOption(option);

            return new OptionResponse
            {
                IdOption = result.IdOption,
                OptionText = result.OptionText,
                CreatedAt = result.CreatedAt,
                IdAsk = result.IdAsk
            };
        }

        public async Task<Option> GetOption(int id)
        {
            return await _optionQuery.GetOption(id);
        }

        public async Task<IEnumerable<Option>> GetAllOptions()
        {
            return await _optionQuery.GetAllOptions();
        }

        public async Task<Option> UpdateOption(int id, OptionRequest request)
        {
            var option = await _optionQuery.GetOption(id);
            if (option == null) throw new Exception("Option not found");

            option.OptionText = request.OptionText;
            option.IdAsk = request.IdAsk;
            option.ModifiedAt = DateTime.UtcNow;

            await _optionCommands.UpdateOption(option);
            return option;
        }
    }
}
