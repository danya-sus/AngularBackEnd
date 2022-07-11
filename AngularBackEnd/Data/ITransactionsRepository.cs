using AngularBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularBackEnd.Data
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Airline>> GetAllAirlinesAsync();

        Task<IEnumerable<AllData>> GetByDocNumAsync(string docNum);

        Task<IEnumerable<AllData>> GetByTicketNumAsync(string ticketNum);

        Task<IEnumerable<AllData>> GetByTicketNumAllAsync(string ticketNum);
    }
}
