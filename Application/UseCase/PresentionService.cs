using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Request;
using Application.Response;
using Domain.Entities;
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

            if (presentation == null)
                return null;

           
            PresentationResponse response = new PresentationResponse
            {
                title = presentation.Title,
                activityStatus = presentation.ActivityStatus,
                modifiedAt = presentation.ModifiedAt,
                createdAt = presentation.CreatedAt,
                idUserCreat = presentation.IdUserCreat,
                slides = presentation.Slides?.Select(slide => new slideResponseDto
                {
                    IdSlide = slide.IdSlide,
                    Url = slide.Url,
                    BackgroundColor = slide.BackgroundColor,
                    Title = slide.Title,
                    CreateAt = slide.CreateAt,
                    ModifiedAt = slide.ModifiedAt,
                    Position = slide.Position,
                    IdContentType = slide.IdContentType,
                    Content = slide.Content,
                    Ask = slide.Ask == null ? null : new askResponseDto
                    {
                        Name = slide.Ask.Name,
                        Description = slide.Ask.Description,
                        AskText = slide.Ask.AskText,
                        CreatedAt = slide.Ask.CreatedAt,
                        ModifiedAt = slide.Ask.ModifiedAt,
                        Options = slide.Ask.Options?.Select(option => new optionResponseDto
                        {
                            IdOption = option.IdOption,
                            OptionText = option.OptionText,
                            IsCorrect = option.IsCorrect,
                            IdAsk = option.IdAsk,
                            CreatedAt = option.CreatedAt,
                            ModifiedAt = option.ModifiedAt
                        }).ToList()
                    }
                    
                }).ToList()
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