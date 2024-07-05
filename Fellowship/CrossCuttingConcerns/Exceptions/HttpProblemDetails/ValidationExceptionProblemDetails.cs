using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

internal class ValidationExceptionProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; init; }

    public ValidationExceptionProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors occurred.";
        Errors = errors;
        StatusCode = StatusCodes.Status400BadRequest;
    }
}
