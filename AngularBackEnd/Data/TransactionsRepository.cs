using AngularBackEnd.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json.Linq;

namespace AngularBackEnd.Data
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly TransactionsContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public TransactionsRepository(TransactionsContext context, IMapper mapper, IConfiguration configuration, ILogger<TransactionsRepository> logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._configuration = configuration;
            this._logger = logger;
        }

        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["GetAirlines"]);

            var result = _mapper.Map<IEnumerable<Airline>>(
                await _context.airline_company.FromSqlRaw(sqlRequest).ToListAsync());

            if (result.Count() > 0)
            {
                return result;
            }
            throw new DbUpdateException("Data is null");
        }

        public async Task<IEnumerable<AllData>> GetByDocNumAsync(string docNumber)
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["ByDocNum"]);

            var result = _mapper.Map<IEnumerable<AllData>>(
                await _context.data_all.FromSqlRaw(sqlRequest, docNumber).ToListAsync());

            foreach (var item in result)
            {
                item.Validate();
            }

            if (result.Count() > 0)
            {
                return result;
            }
            throw new DbUpdateException("Data is null");
            }

        public async Task<IEnumerable<AllData>> GetByTicketNumAsync(string ticketNumber)
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["ByTicketNum"]);

            var result = _mapper.Map<IEnumerable<AllData>>(
                await _context.data_all.FromSqlRaw(sqlRequest, ticketNumber).ToListAsync());

            foreach (var item in result)
            {
                item.Validate();
            }

            if (result.Count() > 0)
            {
                return result;
            }
            throw new DbUpdateException("Data is null");
        }

        public async Task<IEnumerable<AllData>> GetByTicketNumAllAsync(string ticketNumber)
        {
            var result = await GetByTicketNumAsync(ticketNumber);
            return result = await GetByDocNumAsync(result.First().PassengerDocumentNumber);
        }
    }
}
