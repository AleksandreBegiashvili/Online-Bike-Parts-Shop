using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Common.Middleware
{
    public class CustomExceptionMiddleware
    {
        //private readonly RequestDelegate _next;

        //public CustomExceptionMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //}

        //public async Task InvokeAsync(HttpContext httpContext)
        //{
        //    try
        //    {
        //        await _next(httpContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        await HandleExceptionAsync(httpContext, ex);
        //    }
        //}

        //private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        //{
        //    httpContext.Response.ContentType = "application/json";
        //    httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

        //    return httpContext.Response.WriteAsync(new
        //    {
        //        httpContext.Response.StatusCode,
        //        Meesage = "Internal server error from the custom exception middleware."
        //    }.ToString());
        //}
    }
}
