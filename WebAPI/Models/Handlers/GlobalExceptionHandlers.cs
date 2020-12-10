using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using MyException;
using Utilities;


namespace WebAPI.Models.Handlers
{
    public class GlobalExceptionHandlers : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            CustomException ex = null;
            if (context.Exception is CustomException)
                ex = (CustomException)context.Exception;

            var Res = new { code = ex.IsNotNull() ? ex.ExceptionCode : 8000, message = ex.IsNotNull() ? ex.Message : context.Exception.Message, count = 0, payload = new List<int>() };

            new Logger.LogBusiness().Log(Res.message, Logger.LogLevel.Error, Logger.LogType.File, ex.IsNotNull() ? ex : context.Exception);

            var jsonType = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonType.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            var Response = context.Request.CreateResponse(HttpStatusCode.ExpectationFailed, Res, jsonType);

            context.Result = new ResponseMessageResult(Response);

            return Task.FromResult(0);
        }
    }
}