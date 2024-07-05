using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;

public class ProblemDetails
{

    public string Title { get; set; }
    public string Detail { get; set; }
    public int StatusCode { get; set; }

}
