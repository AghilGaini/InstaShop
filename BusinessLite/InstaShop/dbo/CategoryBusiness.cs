using System;
using System.Collections.Generic;
using System.Linq;
using DataLayerPetaPoco.Models.Generated.InstaShop;
using Utilities;

namespace BusinessLite.InstaShop.dbo
{
    public class CategoryBusiness : InstaShopBase<Category>
    {
        private static List<Category> _category = new List<Category>();
        private static DateTime CacheTime = DateTime.Now;

        public List<Category> CategoryList
        {
            get
            {
                if (_category.IsNull() || _category.Count == 0 || DateTime.Now.Subtract(CacheTime).TotalSeconds > 300)
                {
                    _category = this.GetAllList();
                    CacheTime = DateTime.Now;
                }
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public Category GetByID(long ID)
        {
            var q = this.GetAll();
            q.And(Category.Columns.ID, ID);

            return this.Fetch(q).FirstOrDefault();
        }

        public List<Category> GetMainCategories()
        {
            var q = this.GetAll();
            q.And(Category.Columns.Gref, CompareFilter.Null, null);

            return this.Fetch(q);
        }
    }
}
