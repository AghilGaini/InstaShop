using DataLayerPetaPoco.Models.Generated.InstaShop;
using System.Linq;

namespace BusinessLite.InstaShop.dbo
{
    public class ShopBusiness : InstaShopBase<Shop>
    {
        public Shop GetByID(long ID)
        {
            var q = this.GetAll(1);
            q.And(Shop.Columns.ID, ID);

            return this.Fetch(q).FirstOrDefault();
        }
    }
}
