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
                var Biz = BusinessLite.FacadeInstaShop.GetCategoryBusiness();
                var q = Biz.GetAll();
                q.OrderBy("ID", "DESC");
                q.SkipTake(2, 2);

                var r = Biz.Fetch(q);
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
