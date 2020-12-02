using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Generated.InstaShop;

namespace BusinessLite.InstaShop.dbo
{
    public class BasicValueBusiness : InstaShopBase<BasicValue>
    {
        public List<BasicValue> GetExceptions()
        {
            var q = this.GetAll();
            q.And(BasicValue.Columns.BasicType, 1);
            q.And(BasicValue.Columns.IsActive, true);

            return this.Fetch(q);
        }

        public List<BasicValue> GetByType(int BasicTypeID)
        {
            var q = this.GetAll();
            q.And(BasicValue.Columns.BasicType, BasicTypeID);
            q.And(BasicValue.Columns.IsActive, true);

            return this.Fetch(q);
        }

        public BasicValue GetByTypeAndIdentifier(int BasicTypeID, int Identifier)
        {
            var q = this.GetAll(1);
            q.And(BasicValue.Columns.BasicType, BasicTypeID);
            q.And(BasicValue.Columns.Identifier, Identifier);
            q.And(BasicValue.Columns.IsActive, true);

            return this.Fetch(q).FirstOrDefault();

        }
    }
}
