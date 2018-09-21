using JSONValidationTest.Validation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace JSONValidationTest.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                await WriteResponse(exception, exception.Validations, StatusCodes.Status422UnprocessableEntity, context);
            }
            catch (Exception exception)
            {
                await WriteResponse(exception, new { }, StatusCodes.Status500InternalServerError, context);
            }
        }

        private async Task WriteResponse(Exception exception, object response, int statusCode, HttpContext context)
        {
            var jsonResponse = JsonConvert.SerializeObject(response);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}