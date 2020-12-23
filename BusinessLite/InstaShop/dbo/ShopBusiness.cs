using DataLayerPetaPoco.Models.Generated.InstaShop;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

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

        public List<Shop> GetbyCategoryIDs(List<long> CategoryIDs)
        {
            if (CategoryIDs.IsNull())
                return new List<Shop>();
            var q = this.GetAll();
            q.And(Shop.Columns.CategoryID, CompareFilter.In, CategoryIDs);

            return this.Fetch(q);
        }
    }
}
