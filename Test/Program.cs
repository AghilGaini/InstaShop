using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new Logger.LogBusiness().Log("Test Exception New", Logger.LogLevel.Error, Logger.LogType.File, ex);
            }
        }
    }
}
