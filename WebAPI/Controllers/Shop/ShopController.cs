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
        public IHttpActionResult GetCategory(long CategoryID, int PageNumber = 0)
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

            int SkipPage = 0;
            if (PageNumber > 0)
                SkipPage = PageNumber - 1;
            int PageItemCount = 9;
            int ShopsCount = 0;
            var Shops = new List<DataLayerPetaPoco.Models.Generated.InstaShop.Shop>();
            foreach (var item in CategoryIDs)
            {
                var TempShops = BusinessLite.FacadeInstaShop.GetShopBusiness().ShopList.FindAll(r => r.CategoryID == item);
                ShopsCount = (TempShops.IsNull() || TempShops.Count == 0) ? 0 : TempShops.Count;

                TempShops = TempShops.Skip(SkipPage * 9).Take(PageItemCount).ToList();

                if (TempShops.Count != 0)
                    Shops.AddRange(TempShops);

            }

            return Ok(new
            {
                code = 200,
                message = "seccess",
                count = Shops.Count,
                payload = new { Shops = Shops, ShopsCount = ShopsCount }
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
