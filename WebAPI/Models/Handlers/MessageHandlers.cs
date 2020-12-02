using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Utilities;

namespace WebAPI.Models.Handlers
{
    public class MessageHandlers : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var Method = request.Method;
            string IP = HttpContext.Current.Request.UserHostAddress;
            string Token = "";
            if (request.Headers.Contains("Token"))
                Token = request.Headers.GetValues("Token").FirstOrDefault();
            var action = request.GetRequestContext().RouteData.Values["action"].ToNullableString();
            var controller = request.GetRequestContext().RouteData.Values["controller"].ToNullableString();

            string Input = "Input Is File";
            if (request.Content.Headers.ContentType.IsNotNull() && request.Content.Headers.ContentType.MediaType.IsNotNull()
                && request.Content.Headers.ContentType.MediaType != "multipart/form-data")
                Input = await request.Content.ReadAsStringAsync();
            Input = Input.Replace("\r", "");
            Input = Input.Replace("\n", "");

            var response = await base.SendAsync(request, cancellationToken);

            var Output = response.Content.ReadAsStringAsync().Result;
            Output = Output.Replace("\r", "");
            Output = Output.Replace("\n", "");
            Output = Output.Replace("   ", "").Replace("    ", "").Replace("      ", "");


            new Logger.LogBusiness().Log(string.Format("\t{{Method:{0}}}//{{IP:{1}}}//{{controller:{2}}}//{{action:{3}}}//{{Token:{4}}}//{{Input:{5}}}//{{Output:{6}}}", Method, IP, controller, action, Token, Input, Output), Logger.LogLevel.Info, Logger.LogType.File);

            return response;
        }
    }
}