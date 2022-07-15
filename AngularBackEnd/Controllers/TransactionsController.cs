using AngularBackEnd.Data;
using AngularBackEnd.Formatters;
using AngularBackEnd.Models;
using AngularBackEnd.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

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
        private readonly IConfiguration _configuration;

        public TransactionsController(ITransactionsRepository repository, ILogger<TransactionsController> logger, IValidatorForAirline validator, IConfiguration configuration)
        {
            this._repository = repository;
            this._logger = logger;
            this._validator = validator;
            this._configuration = configuration;
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

            var result = _repository.GetByDocNumAsync(dto.DocNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                return Ok(await result);
            }

            throw new TimeoutException();
        }

        [Route("by_ticket_number")]
        [HttpPost]
        public async Task<IActionResult> GetByTicketNumberAsync([FromBody] InputTicketDto dto)
        {
            Task<IEnumerable<AllData>> result;

            if (dto.IsChecked) result = _repository.GetByTicketNumAsync(dto.TicketNumber);
            else result = _repository.GetByTicketNumAllAsync(dto.TicketNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                return Ok(await result);
            }

            throw new TimeoutException();
        }

        [Route("get_doc_file")]
        [HttpPost]
        public async Task<IActionResult> GetDocCsvFileAsync([FromBody] InputDocFileDto dto)
        {
            var result = _repository.GetByDocNumAsync(dto.DocNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                var models = await result;
                _validator.Validation(models, dto.AirlineCode);

                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Report1");
                var streamReader = new StreamReader(_configuration.GetSection("Formatters")["RussianFormatter"]);
                var formatter = streamReader.ReadToEnd();
                workSheet.Cells[1, 1].LoadFromArrays(new[] { formatter.Split(",") });
                workSheet.Cells[2, 1].LoadFromCollection(models, false);

                var memoryStream = new MemoryStream();
                await excel.SaveAsAsync(memoryStream);
                memoryStream.Position = 0;

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Headers.Add("content-disposition", $"attachment; filename={dto.AirlineCode}Report.xlsx");

                return Ok(memoryStream);
            }

            throw new TimeoutException();
        }

        [Route("get_ticket_file")]
        [HttpPost]
        public async Task<IActionResult> GetTicketCsvFileAsync([FromBody] InputTicketFileDto dto)
        {
            Task<IEnumerable<AllData>> result;

            if (dto.IsChecked) result = _repository.GetByTicketNumAsync(dto.TicketNumber);
            else result = _repository.GetByTicketNumAllAsync(dto.TicketNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                var models = await result;
                _validator.Validation(models, dto.AirlineCode);

                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Report1");
                var streamReader = new StreamReader(_configuration.GetSection("Formatters")["RussianFormatter"]);
                var formatter = streamReader.ReadToEnd();
                workSheet.Cells[1, 1].LoadFromArrays(new[] { formatter.Split(",") });
                workSheet.Cells[2, 1].LoadFromCollection(models, false);

                var memoryStream = new MemoryStream();
                await excel.SaveAsAsync(memoryStream);
                memoryStream.Position = 0;

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Headers.Add("content-disposition", $"attachment; filename={dto.AirlineCode}Report.xlsx");

                return Ok(memoryStream);
            }

            throw new TimeoutException();
        }
    }
}
