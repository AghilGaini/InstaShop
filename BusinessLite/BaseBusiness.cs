using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLite
{
    public class BaseBusiness<T> where T : class
    {
        public virtual string _ConnectionString { get; }
        public string _TableName = PetaPoco.TableInfo.FromPoco(typeof(T)).TableName;
        public Query GetAll(int? _TopCount = null)
        {
            return new Query(this._TableName, _TopCount);
        }

        public List<T> Fetch(Query q)
        {
            return new PetaPoco.Database(this._ConnectionString).Fetch<T>(q.q);
        }

        public List<T> GetAllList()
        {
            return this.Fetch(GetAll());
        }
    }

    public class InstaShopBase<T> : BaseBusiness<T> where T : class
    {
        public override string _ConnectionString { get { return "InstaShop"; } }
    }
}
