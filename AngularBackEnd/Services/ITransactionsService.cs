using AngularBackEnd.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngularBackEnd.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Airline>> GetAirlinesAsync();

        Task<IEnumerable<AllData>> GetByDocNumAsync(InputDocDto dto);

        Task<IEnumerable<AllData>> GetByTicketNumAsync(InputTicketDto dto);

        Task<MemoryStream> GetFileByDocNumberAsync(InputDocFileDto dto);

        Task<MemoryStream> GetFileByTicketNumberAsync(InputTicketFileDto dto);
    }
}
