using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;



namespace z.Fellowship.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(String detail)
    {
        ProblemDetails problemDetails = new ProblemDetails();

        problemDetails.Title = "Interna Server Error";
        problemDetails.Detail = detail;

        problemDetails.StatusCode = StatusCodes.Status500InternalServerError;
    
    }
}
