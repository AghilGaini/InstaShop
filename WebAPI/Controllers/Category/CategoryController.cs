using System.Collections.Generic;
using System.Web.Http;
using Utilities;
using DataLayerPetaPoco.Models.Generated.InstaShop;

namespace WebAPI.Controllers.Category
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(bool? MainCategories = false)
        {
            var Res = new List<DataLayerPetaPoco.Models.Generated.InstaShop.Category>();
            if (MainCategories.Value.ToBoolean())
            {
                Res = BusinessLite.FacadeInstaShop.GetCategoryBusiness().GetMainCategories();
            }
            else
            {
                Res = BusinessLite.FacadeInstaShop.GetCategoryBusiness().GetAllList();
            }

            return Ok(new
            {
                code = 200,
                message = "success",
                count = Res.Count,
                payload = Res
            });
        }

        [HttpGet]
        public IHttpActionResult Get(long ID)
        {
            var Res = new List<DataLayerPetaPoco.Models.Generated.InstaShop.Category> { BusinessLite.FacadeInstaShop.GetCategoryBusiness().GetByID(ID) };

            return Ok(new
            {
                code = 200,
                message = "success",
                count = Res.Count,
                payload = Res
            });
        }
    }
}
