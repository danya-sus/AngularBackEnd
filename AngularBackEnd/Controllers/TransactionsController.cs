using AngularBackEnd.Data;
using AngularBackEnd.Models;
using AngularBackEnd.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AngularBackEnd.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/{controller}")]
    [ApiVersion("1.0")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _repository;
        private readonly ILogger _logger;
        private readonly IValidatorForAirline _validator;

        public TransactionsController(ITransactionsRepository repository, ILogger<TransactionsController> logger, IValidatorForAirline validator)
        {
            this._repository = repository;
            this._logger = logger;
            this._validator = validator;
        }

        [Route("airlines")]
        [HttpGet]
        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            return await _repository.GetAllAirlinesAsync();
        }

        [Route("by_doc_number")]
        [HttpPost]
        public async Task<IActionResult> GetByDocNumberAsync([FromBody] InputDocDto dto)
        {
            if (dto.DocNumber == null) return BadRequest();

            return Ok(await _repository.GetByDocNumAsync(dto.DocNumber));
        }

        [Route("by_ticket_number")]
        [HttpPost]
        public async Task<IActionResult> GetByTicketNumberAsync([FromBody] InputTicketDto dto)
        {
            if (dto.IsChecked)
            {
                return Ok(await _repository.GetByTicketNumAsync(dto.TicketNumber));
            }
            return Ok(await _repository.GetByTicketNumAllAsync(dto.TicketNumber));
        }

        [Route("get_doc_file")]
        [HttpPost]
        public async Task<IActionResult> GetDocCsvFileAsync([FromBody] InputDocFileDto dto)
        {
            var models = await _repository.GetByDocNumAsync(dto.DocNumber);

            _validator.Validation(models, dto.AirlineCode);

            var cd = new ContentDisposition()
            {
                FileName = $"Report{dto.AirlineCode}.csv",
                Inline = false
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("Content-Type", "text/csv");
            
            return Ok(models);
        }

        [Route("get_ticket_file")]
        [HttpPost]
        public async Task<IActionResult> GetTicketCsvFileAsync([FromBody] InputTicketFileDto dto)
        {
            IEnumerable<AllData> models;

            if (dto.IsChecked) models = await _repository.GetByTicketNumAsync(dto.TicketNumber);
            else models = await _repository.GetByTicketNumAllAsync(dto.TicketNumber);

            _validator.Validation(models, dto.AirlineCode);

            var cd = new ContentDisposition()
            {
                FileName = $"Report{dto.AirlineCode}.csv",
                Inline = false
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());
            Response.Headers.Add("Content-Type", "text/csv");

            return Ok(models);
        }
    }
}
