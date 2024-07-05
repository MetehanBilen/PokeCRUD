using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using z.Fellowship.CrossCuttingConcerns.Exceptions.Types;

namespace z.Fellowship.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExcptionAsync(Exception exception) =>
               exception switch
               {
                   Types.ValidationException validationException => HandleException(validationException),
                   BusinessException businessException => HandleException(businessException),
                   _ => HandleException(exception)
               };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(Exception exception);
    protected abstract Task HandleException(Types.ValidationException validationException);
}
