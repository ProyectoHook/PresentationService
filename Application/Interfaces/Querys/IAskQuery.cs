using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Querys
{
    public interface IAskQuery
    {
        Task<IEnumerable<Ask>> GetAllAsks();
        Task<Ask> GetAsk(int id);
    }
}
