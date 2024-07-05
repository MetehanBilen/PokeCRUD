using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;
using z.Fellowship.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{

    private HttpResponse? _response;
    public HttpResponse Response
    {

        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Types.ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new ValidationExceptionProblemDetails(validationException.Errors).AsJson();
        return Response.WriteAsync(details);
    }
}
