using System.Threading.Tasks;
using Application.UserCase;
using Domain.Entities;
using Application.Request;

namespace Application.Interfaces.Commands
{
    public interface IPresentationCommands
    {
        Task<Presentation> InsertPresentation(Presentation request);
        Task UpdatePresentation(Presentation presentation);
    }
}