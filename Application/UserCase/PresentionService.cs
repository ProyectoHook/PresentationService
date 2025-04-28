using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Request;
using Application.Response;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCase
{
    public class PresentationService : IPresentationService
    {
        private readonly IPresentationQuery _presenntationQuery;
        private readonly IPresentationCommands _presentationCommand;
        public PresentationService(IPresentationQuery presentationQuery, IPresentationCommands presentationCommand)
        {
            _presenntationQuery = presentationQuery;
            _presentationCommand = presentationCommand;
        }
        public async Task<IEnumerable<Presentation>> GetAllPresentations()
        {
            return await _presenntationQuery.GetAllPresentations();
        }
        public async Task<Presentation> GetPresentation(int id)
        {
            return await _presenntationQuery.GetPresentation(id);
        }
        public async Task<PresentationResponse> CreatePresentation(PresentationRequest request)
        {

            Presentation _presentation = new Presentation
            {
                Title = request.title,
                ActivityStatus = request.activityStatus,
                CreatedAt = DateTime.Now,
                IdUserCreat = request.idUserCreat
            };

            await _presentationCommand.InsertPresentation(_presentation);

            PresentationResponse presentationResponse = new PresentationResponse
            {
                title = _presentation.Title,
                activityStatus = _presentation.ActivityStatus,
                createdAt = _presentation.CreatedAt,
                idUserCreat = _presentation.IdUserCreat
            };


            return presentationResponse;
        }

    }
}