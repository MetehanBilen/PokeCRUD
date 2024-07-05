﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Handlers;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly IHttpContextAccessor _contextAccessor;

    public ExceptionMiddleware(
                                    RequestDelegate next,
                                    IHttpContextAccessor contextAccessor)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
        _contextAccessor = contextAccessor;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context.Response, exception);
        }
    }
        private Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExcptionAsync(exception);
        }
    
}
