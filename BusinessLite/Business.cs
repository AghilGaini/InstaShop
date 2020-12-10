
namespace BusinessLite
{
    public static class FacadeInstaShop
    {
        #region dbo
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
        #endregion

        #region log
        public static BusinessLite.InstaShop.log.ApiLoggerBusiness GetApiLoggerBusiness()
        {
            return new InstaShop.log.ApiLoggerBusiness();
        }
        #endregion
    }
}
