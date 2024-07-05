using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.Extensions;

public static class ExceptionMidlewareExtensions
{
    public static void ConfigureCustomExceptionMiddlewre(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}
