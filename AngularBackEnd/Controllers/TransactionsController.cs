using AngularBackEnd.Models;
using AngularBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AngularBackEnd.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/{controller}")]
    [ApiVersion("1.0")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _service;
        private readonly ILogger _logger;

        public TransactionsController(ITransactionsService service, ILogger<TransactionsController> logger)
        {
            this._service = service;
            this._logger = logger;
        }

        [Route("airlines")]
        [HttpGet]
        public async Task<IActionResult> GetAllAirlinesAsync()
        {
            return Ok(await _service.GetAirlinesAsync());
        }

        [Route("by_doc_number")]
        [HttpPost]
        public async Task<IActionResult> GetByDocNumberAsync([FromBody] InputDocDto dto)
        {
            if (dto.DocNumber == null) return BadRequest();

            return Ok(await _service.GetByDocNumAsync(dto));
        }

        [Route("by_ticket_number")]
        [HttpPost]
        public async Task<IActionResult> GetByTicketNumberAsync([FromBody] InputTicketDto dto)
        {
            if (dto.TicketNumber == null) return BadRequest();

            return Ok(await _service.GetByTicketNumAsync(dto));
        }

        [Route("get_doc_file")]
        [HttpPost]
        public async Task<IActionResult> GetDocCsvFileAsync([FromBody] InputDocFileDto dto)
        {
            if (dto.DocNumber == null || dto.AirlineCode == null) return BadRequest();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", $"attachment; filename={dto.AirlineCode}Report.xlsx");

            return Ok(await _service.GetFileByDocNumberAsync(dto));
        }

        [Route("get_ticket_file")]
        [HttpPost]
        public async Task<IActionResult> GetTicketCsvFileAsync([FromBody] InputTicketFileDto dto)
        {
            if (dto.TicketNumber == null || dto.AirlineCode == null) return BadRequest();

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", $"attachment; filename={dto.AirlineCode}Report.xlsx");

            return Ok(await _service.GetFileByTicketNumberAsync(dto));
        }
    }
}
