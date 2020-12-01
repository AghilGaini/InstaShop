using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLite
{
    public static class FacadeInstaShop
    {
        public static BusinessLite.InstaShop.dbo.CategoryBusiness GetCategoryBusiness()
        {
            return new InstaShop.dbo.CategoryBusiness();
        }

        public static BusinessLite.InstaShop.dbo.ShopBusiness GetShopBusiness()
        {
            return new InstaShop.dbo.ShopBusiness();
        }

        public static BusinessLite.InstaShop.dbo.ShopPostBusiness GetShopPostBusiness()
        {
            return new InstaShop.dbo.ShopPostBusiness();
        }

        public static BusinessLite.InstaShop.dbo.BasicTypeBusiness GetBasicTypeBusiness()
        {
            return new InstaShop.dbo.BasicTypeBusiness();
        }

        public static BusinessLite.InstaShop.dbo.BasicValueBusiness GetBasicValueBusiness()
        {
            return new InstaShop.dbo.BasicValueBusiness();
        }
    }
}
