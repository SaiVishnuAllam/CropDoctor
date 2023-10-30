using CropDoctor.Services.Core.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CropDoctor.Services.Core.Core.Exceptions
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int status;
            string message= ex.Message;
            var exType = ex.GetType();
            var stack = ex.StackTrace;
            if (exType == typeof(UnauthorizedException))
            {
                status = (int)HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(InternalServerErrorException))
            {
                status = (int)HttpStatusCode.InternalServerError;
            }
            else if (exType == typeof(NotFoundException))
            {
                status = (int)HttpStatusCode.NotFound;
            }

            else if (exType == typeof(BadRequestException))
            {
                status = (int)HttpStatusCode.BadGateway;
            }
            else
            {
                var errors = JsonSerializer.Serialize(new
                {
                    error = message,
                    stack
                });                
                return context.Response.WriteAsync(errors);
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            var exception = JsonSerializer.Serialize(new
            {
                StatusCode = status,
                error = message,
                stack
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exception);
        }
    }
}
