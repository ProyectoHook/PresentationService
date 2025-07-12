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
        private readonly ISlideService _slideService;
        public PresentationService(IPresentationQuery presentationQuery, IPresentationCommands presentationCommand, ISlideService slideService)
        {
            _presentationQuery = presentationQuery;
            _presentationCommand = presentationCommand;
            _slideService = slideService;
        }
        public async Task<List<PresentationResponse>> GetAllPresentations()
        {
            // Trae todas las presentaciones desde la capa de consultas
            List<Presentation> presentations = await _presentationQuery.GetAllPresentations();

            // Si no hay resultados devolvemos una lista vacía (evita null?checks posteriores)
            if (presentations == null || presentations.Count == 0)
                return new List<PresentationResponse>();

            // Proyección 1?a?1 ? PresentationResponse
            List<PresentationResponse> response = presentations.Select(p => new PresentationResponse
            {
                id = p.IdPresentation,
                title = p.Title,
                activityStatus = p.ActivityStatus,
                modifiedAt = p.ModifiedAt,
                createdAt = p.CreatedAt,
                idUserCreat = p.IdUserCreat,

                slides = p.Slides?.Select(slide => new slideResponseDto
                {
                    IdSlide = slide.IdSlide,
                    Url = slide.Url,
                    BackgroundColor = slide.BackgroundColor,
                    Title = slide.Title,
                    Content = slide.Content,
                    CreateAt = slide.CreateAt,
                    ModifiedAt = slide.ModifiedAt,
                    Position = slide.Position,
                    IdPresentation = p.IdPresentation,
                    Ask = slide.Ask == null ? null : new askResponseDto
                    {
                        IdAsk = slide.Ask.IdAsk,
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
            }).ToList();

            return response;
        }



        public async Task<PresentationResponse> GetPresentation(int id)
        {
            Presentation presentation = await _presentationQuery.GetPresentation(id);

            if (presentation == null)
                return new PresentationResponse(); ;

           
            PresentationResponse response = new PresentationResponse
            {
                id = presentation.IdPresentation,
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
                    Content = slide.Content,
                    CreateAt = slide.CreateAt,
                    ModifiedAt = slide.ModifiedAt,
                    Position = slide.Position,
                    Ask = slide.Ask == null ? null : new askResponseDto
                    {
                        IdAsk= slide.Ask.IdAsk,
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
                ActivityStatus = true,
                CreatedAt = DateTime.Now,
                IdUserCreat = request.idUserCreat
            };

            var _slides = new List<Slide>();

            
            foreach (var slide in request.slides)
            {
                var options = new List<Option>();

                if (slide.Ask != null) 
                {
                    foreach (var option in slide.Ask.Options) 
                    {
                        var tempOption = new Option()
                        { 
                            OptionText = option.OptionText,
                            IsCorrect = option.IsCorrect,
                            CreatedAt = DateTime.Now
                        };
                        options.Add(tempOption);
                    }
                }

                var temp = new Slide()
                {
                    Url = slide.url,
                    BackgroundColor = slide.BackgroundColor,
                    Presentation = _presentation,
                    Title = slide.Title,
                    Content = slide.Content,
                    CreateAt = DateTime.Now,
                    Position = slide.Position,
                    Ask = slide.Ask == null ? null : new Ask()
                    {
                        Name = slide.Ask.Name,
                        Description = slide.Ask.Description,
                        AskText = slide.Ask.AskText,
                        Options = options
                    },
                };

                _slides.Add(temp);
            }

            _presentation.Slides = _slides;

            await _presentationCommand.InsertPresentation(_presentation);

            PresentationResponse presentationResponse = new PresentationResponse
            {
                id = _presentation.IdPresentation,
                title = _presentation.Title,
                activityStatus = _presentation.ActivityStatus,
                createdAt = _presentation.CreatedAt,
                idUserCreat = _presentation.IdUserCreat
            };


            return presentationResponse;
        }

        public async Task<List<PresentationResponse>> GetPresentationsByUserId(Guid userId)
        {
            var presentations = await _presentationQuery.GetPresentationsByUserId(userId);

            if (presentations == null || presentations.Count == 0)
                return new List<PresentationResponse>();

            //FILTRO PARA LAS PRESENTACIONES ACTIVAS
            presentations = presentations.Where(p => p.ActivityStatus == true).ToList();

            // ProyecciÃ³n 1?a?1 ? PresentationResponse
            List<PresentationResponse> response = presentations.Select(p => new PresentationResponse
            {
                id = p.IdPresentation,
                title = p.Title,
                activityStatus = p.ActivityStatus,
                modifiedAt = p.ModifiedAt,
                createdAt = p.CreatedAt,
                idUserCreat = p.IdUserCreat,

                slides = p.Slides?.Select(slide => new slideResponseDto
                {
                    IdSlide = slide.IdSlide,
                    Url = slide.Url,
                    BackgroundColor = slide.BackgroundColor,
                    Title = slide.Title,
                    Content = slide.Content,
                    CreateAt = slide.CreateAt,
                    ModifiedAt = slide.ModifiedAt,
                    Position = slide.Position,
                    IdPresentation = p.IdPresentation,
                    Ask = slide.Ask == null ? null : new askResponseDto
                    {
                        IdAsk = slide.Ask.IdAsk,
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
            }).ToList();

            return response;
        }

        public async Task<PresentationResponse> UpdatePresentation(int id, UpdatePresentationRequest request)
        {
            var presentation = await _presentationQuery.GetPresentation(id);

            if (presentation == null)
                throw new Exception("Presentation not found");

            presentation.ActivityStatus = false;

            await _presentationCommand.UpdatePresentation(presentation);

            var newPresentation = new PresentationRequest()
            {
                title = request.title,
                activityStatus = true,
                idUserCreat = presentation.IdUserCreat,
                slides = request.slides
            };

            return await CreatePresentation(newPresentation);

        }

        public async Task delete(int id)
        {
            var presentation = await _presentationQuery.GetPresentation(id);

            if (presentation == null) { throw new Exception("Presentación no encontrada"); }

            presentation.ActivityStatus = false;

            await _presentationCommand.UpdatePresentation(presentation);
        }
    }
}