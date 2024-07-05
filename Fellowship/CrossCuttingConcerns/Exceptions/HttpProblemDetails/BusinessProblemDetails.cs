using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(String detail)
    {
        Title = "Rule Violation";
        Detail = detail;
        StatusCode = StatusCodes.Status400BadRequest;

    }
}
