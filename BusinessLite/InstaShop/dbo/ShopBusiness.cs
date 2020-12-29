using DataLayerPetaPoco.Models.Generated.InstaShop;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace BusinessLite.InstaShop.dbo
{
    public class ShopBusiness : InstaShopBase<Shop>
    {
        static private List<Shop> _shop = new List<Shop>();
        static private DateTime ShopCacheTime = DateTime.Now;


        public List<Shop> ShopList
        {
            get
            {
                if (_shop.IsNull() || _shop.Count == 0 || DateTime.Now.Subtract(ShopCacheTime).TotalSeconds > 0)
                {
                    _shop = this.GetAllList().OrderByDescending(r => r.CategoryID).ToList();
                    ShopCacheTime = DateTime.Now;
                }
                return _shop;
            }
            set
            {
                _shop = value;
            }
        }

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
