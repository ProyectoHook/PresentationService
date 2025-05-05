using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services;

namespace Application.UseCase
{
    public class PresentationService : IPresentationService
    {
        private readonly IPresentationQuery _presentationQuery;
        private readonly IPresentationCommands _presentationCommand;
        public PresentationService(IPresentationQuery presentationQuery, IPresentationCommands presentationCommand)
        {
            _presentationQuery = presentationQuery;
            _presentationCommand = presentationCommand;
        }
        public async Task<IEnumerable<Presentation>> GetAllPresentations()
        {
            return await _presentationQuery.GetAllPresentations();
        }
        public async Task<PresentationResponse> GetPresentation(int id)
        {
            Presentation presentation = await _presentationQuery.GetPresentation(id);

            PresentationResponse response = new PresentationResponse
            {
                title = presentation.Title,
                activityStatus = presentation.ActivityStatus,
                createdAt = presentation.CreatedAt,
                idUserCreat = presentation.IdUserCreat,
                slides = presentation.Slides
            };
            return response;
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
        public async Task<PresentationResponse> UpdatePresentation(int id, PresentationRequest request)
        {
            var presentation = await _presentationQuery.GetPresentation(id);

            if (presentation == null)
            {
                throw new Exception("Presentation not found");
            }

            presentation.Title = request.title;
            presentation.ActivityStatus = request.activityStatus;
            presentation.ModifiedAt = DateTime.Now;

            await _presentationCommand.UpdatePresentation(presentation);

            return new PresentationResponse
            {
                title = presentation.Title,
                activityStatus = presentation.ActivityStatus,
                modifiedAt = (DateTime)presentation.ModifiedAt,
                createdAt = presentation.CreatedAt,
                idUserCreat = presentation.IdUserCreat
            };
        }

    }
}