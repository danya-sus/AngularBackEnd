using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AngularBackEnd.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionMiddleware> logger)
        {
            logger.LogInformation($"{httpContext.Request.Path}");

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Ticket number pattern invalid.")
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("Некорректный номер билета, проверьте входный данные...");
                }

                if (ex is FileNotFoundException)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("Ошибка сервера, попробуйте повторить запрос...");
                }

                if (ex is DbUpdateException dbUpdateException && dbUpdateException.Message == "Data is null")
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("Данных по запросу не найдено...");
                }

                if (ex is PostgresException)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("Ошибка сервера, попробуйте повторить запрос...");
                }

                if (ex is TimeoutException)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsync("Превышен лимит ожидания запроса...");
                }
            }
        }
    }
}
