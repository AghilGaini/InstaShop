﻿using System.Linq;
using Models.Generated.InstaShop;

namespace BusinessLite.InstaShop.dbo
{
    public class CategoryBusiness : InstaShopBase<Category>
    {
        public Category GetByID(long ID)
        {
            var q = this.GetAll();
            q.And(Category.Columns.ID, ID);

            return this.Fetch(q).FirstOrDefault();
        }
    }
}
