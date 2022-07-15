using AngularBackEnd.Data;
using AngularBackEnd.Models;
using AngularBackEnd.Models.Validation;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AngularBackEnd.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _repository;
        private readonly IValidatorForAirline _validator;
        private readonly IConfiguration _configuration;

        public TransactionsService(ITransactionsRepository repository, IValidatorForAirline validator, IConfiguration configuration)
        {
            this._repository = repository;
            this._validator = validator;
            this._configuration = configuration;
        }

        public async Task<IEnumerable<Airline>> GetAirlinesAsync()
        {
            return await _repository.GetAllAirlinesAsync();
        }

        public async Task<IEnumerable<AllData>> GetByDocNumAsync(InputDocDto dto)
        {
            var result = _repository.GetByDocNumAsync(dto.DocNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                return await result;
            }

            throw new TimeoutException();
        }

        public async Task<IEnumerable<AllData>> GetByTicketNumAsync(InputTicketDto dto)
        {
            Task<IEnumerable<AllData>> result;

            if (dto.IsChecked) result = _repository.GetByTicketNumAsync(dto.TicketNumber);
            else result = _repository.GetByTicketNumAllAsync(dto.TicketNumber);

            if (await Task.WhenAny(result, Task.Delay(60000)) == result)
            {
                return await result;
            }

            throw new TimeoutException();
        }

        public async Task<MemoryStream> GetFileByDocNumberAsync(InputDocFileDto dto)
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

                return memoryStream;
            }

            throw new TimeoutException();
        }

        public async Task<MemoryStream> GetFileByTicketNumberAsync(InputTicketFileDto dto)
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

                return memoryStream;
            }

            throw new TimeoutException();
        }
    }
}
