using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utilities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                //new Logger.LogBusiness().Log("Test Exception New", Logger.LogLevel.Error, Logger.LogType.File, ex);

                //new Logger.LogBusiness().Log(string.Format("\t{{Method:{0}}}//{{IP:{1}}}//{{controller:{2}}}//{{action:{3}}}//{{Token:{4}}}//{{Input:{5}}}//{{Output:{6}}}",
                //    "Method", "IP", "controller", "action", "Token", "Input", "Output"),
                //    Logger.LogLevel.Info, Logger.LogType.DataBase);

                var a = new Models.Generated.InstaShop.ApiLogger()
                {
                    Action = "Action",
                    Controller = "Controller",
                    CreatedBy = "CreatedBy",
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    Input = "Input",
                    IP = "IP",
                    IsSuccess = true,
                    Message = "Message",
                    MethodTypeID = 1,
                    ResponseCode = 1,
                    Host = "HOST",
                    AbsoluteUri = "AbsoluteUri",
                    HttpResponseMessage = "HttpResponseMessage",
                    IsFile = true,
                    IsLoopback = true,
                    LocalPath = "LocalPath",
                    Method = "Method",
                    OriginalString = "OriginalString",
                    Port = 80,
                    _Query = "Query"
                };
                var ta = "t";
                //var json = new JavaScriptSerializer().Serialize(a);
                //var aa = Newtonsoft.Json.JsonConvert.SerializeObject(a);

                //var b = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Generated.InstaShop.ApiLogger>(aa);


                //var aa = typeof(Utilities.Constants.BasicValue.ApiMethodType).GetProperty("GET").GetValue(typeof(int));

                var t = a.ToJson();

                var b = t.FromJson<Models.Generated.InstaShop.ApiLogger>();

                Console.WriteLine(a);

                Console.ReadLine();

            }
        }
    }
}
