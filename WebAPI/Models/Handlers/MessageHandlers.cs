using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Utilities;
using DataLayerPetaPoco.Models.Generated.InstaShop;

namespace WebAPI.Models.Handlers
{
    public class MessageHandlers : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var LogObject = new ApiLogger();
            LogObject.CreatedBy = "WebApi";
            LogObject.CreatedDate = DateTime.Now;
            LogObject.CreatedTime = DateTime.Now;

            try
            {
                //string Token = "";
                //if (request.Headers.Contains("Token"))
                //    Token = request.Headers.GetValues("Token").FirstOrDefault();

                string Input = "Input Is File";
                if (request.Content.Headers.ContentType.IsNotNull() && request.Content.Headers.ContentType.MediaType.IsNotNull()
                    && request.Content.Headers.ContentType.MediaType != "multipart/form-data")
                    Input = await request.Content.ReadAsStringAsync();
                Input = Input.Replace("\r", "");
                Input = Input.Replace("\n", "");

                LogObject.Method = request.Method.ToString();
                LogObject.MethodTypeID = typeof(Utilities.Constants.BasicValue.ApiMethodType).GetProperty(request.Method.ToString()).GetValue(typeof(int)).ToLong();
                LogObject.IP = HttpContext.Current.Request.UserHostAddress;
                LogObject.Action = request.GetRequestContext().RouteData.Values["action"].ToNullableString();
                LogObject.Controller = request.GetRequestContext().RouteData.Values["controller"].ToNullableString();
                LogObject.Input = Input;

                var response = await base.SendAsync(request, cancellationToken);

                LogObject.AbsoluteUri = response.RequestMessage.RequestUri.AbsoluteUri;
                LogObject.Host = response.RequestMessage.RequestUri.Host;
                LogObject.IsFile = response.RequestMessage.RequestUri.IsFile;
                LogObject.IsLoopback = response.RequestMessage.RequestUri.IsLoopback;
                LogObject.LocalPath = response.RequestMessage.RequestUri.LocalPath;
                LogObject.OriginalString = response.RequestMessage.RequestUri.OriginalString;
                LogObject.Port = response.RequestMessage.RequestUri.Port;
                LogObject._Query = response.RequestMessage.RequestUri.Query;

                var Output = response.Content.ReadAsStringAsync().Result;
                Output = Output.Replace("\r", "");
                Output = Output.Replace("\n", "");
                Output = Output.Replace("\r\n", "");
                Output = Output.Replace("   ", "").Replace("    ", "").Replace("      ", "");

                new Logger.LogBusiness().Log(string.Format("\t{{Method:{0}}}//{{IP:{1}}}//{{controller:{2}}}//{{action:{3}}}//{{Token:{4}}}//{{Input:{5}}}//{{Output:{6}}}",
                    LogObject.MethodTypeID, LogObject.IP, LogObject.Controller, LogObject.Action, "", Input, Output),
                    Logger.LogLevel.Info, Logger.LogType.File);

                LogObject.Message = Output;
                LogObject.IsSuccess = true;
                LogObject.ResponseCode = 200;
                LogObject.HttpResponseMessage = response.StatusCode.ToString();

                return response;
            }
            catch (Exception ex)
            {
                LogObject.Message = ex.Message;
                LogObject.IsSuccess = false;
                return new HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                LogObject.Save();
            }
        }
    }
}