﻿using Application.Interfaces.Commands;
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
    public class AskService : IAskService
    {
        private readonly IAskCommands _askCommand;
        private readonly IAskQuery _askQuery;
        private readonly ISlideService _service;


        public AskService(IAskQuery askQuery, IAskCommands askComman, ISlideService slideService)
        {
            _askQuery = askQuery;
            _askCommand = askComman;
            _service = slideService;
        }

        public async Task<IEnumerable<Ask>> GetAllAsks()
        {
            return await _askQuery.GetAllAsks();
        }

        public async Task<Ask> GetAsk(int id)
        {
            return await _askQuery.GetAsk(id);
        }
        public async Task<AskResponse> UpdateAsk(int id, AskRequest request)
        {
            var ask = await _askQuery.GetAsk(id);

            if (ask == null)
                throw new Exception("Ask not found");

            ask.Name = request.Name;
            ask.Description = request.Description;
            ask.AskText = request.AskText;
            ask.ModifiedAt = DateTime.Now;

            await _askCommand.UpdateAsk(ask);

            return new AskResponse
            {
                Name = ask.Name,
                Description = ask.Description,
                AskText = ask.AskText,
                CreatedAt = ask.CreatedAt,
                ModifiedAt = ask.ModifiedAt
            };
        }
    }
}
