using MyException;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Utilities;

namespace WebAPI.Controllers.Shop
{
    public class ShopController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCategory(long CategoryID)
        {
            var MainCategory = BusinessLite.FacadeInstaShop.GetCategoryBusiness().CategoryList.FirstOrDefault(r => r.ID == CategoryID);

            if (MainCategory.IsNull())
                throw new CustomException("CategoryNotFound");

            var CategoryIDs = new List<long>();
            var CategoryQueues = new Queue<DataLayerPetaPoco.Models.Generated.InstaShop.Category>();

            CategoryQueues.Enqueue(MainCategory);
            while (CategoryQueues.Count != 0)
            {
                var Category = CategoryQueues.Dequeue();
                CategoryIDs.Add(Category.ID);
                var ChildCategories = BusinessLite.FacadeInstaShop.GetCategoryBusiness().CategoryList.FindAll(r => r.Gref == Category.Gid);
                foreach (var item in ChildCategories)
                {
                    if (CategoryQueues.FirstOrDefault(r => r.ID == item.ID).IsNull())
                        CategoryQueues.Enqueue(item);
                }
            }

            var Shops = new List<DataLayerPetaPoco.Models.Generated.InstaShop.Shop>();
            foreach(var item in CategoryIDs)
            {
                var TempShops = BusinessLite.FacadeInstaShop.GetShopBusiness().GetbyCategoryIDs(CategoryIDs);
                if (TempShops.Count != 0)
                    Shops.AddRange(TempShops);
            }

            return Ok(new
            {
                code = 200,
                message = "seccess",
                count = Shops.Count,
                payload = Shops
            });
        }

        [HttpGet]
        public IHttpActionResult Get(long ID)
        {
            var Res = new List<DataLayerPetaPoco.Models.Generated.InstaShop.Shop>();
            var TempRes = BusinessLite.FacadeInstaShop.GetShopBusiness().GetByID(ID);
            if (TempRes.IsNotNull())
                Res.Add(TempRes);

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
