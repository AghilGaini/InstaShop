using PetaPoco;

namespace BusinessLite
{
    public enum CompareFilter
    {
        Like = 1,
        NotLike = 2,
        In = 3,
        NotIn = 4,
        Null = 5,
        NotNull = 6,
        Equal = 7,
        NotEqual = 8,
        GreaterThan = 9,
        GreaterThanOrEqual = 10,
        LessThan = 11,
        LessThanOrEqual = 12
    }

    public class Query
    {
        public Sql q;
        private bool IsNew;

        public string SQL { get { return q.SQL; } }

        public Query()
        {
            q = new Sql();
            IsNew = true;
        }
        public Query(string TableName, int? TopCount = null)
        {
            IsNew = true;
            if (TopCount.HasValue)
            {
                q = new Sql(string.Format(" SELECT TOP {0} * FROM {1} WITH(NOLOCK) ", TopCount.Value, TableName));
            }
            else
            {
                q = new Sql(string.Format(" SELECT * FROM {0} WITH(NOLOCK) ", TableName));
            }
        }

        public void And(string col, object value)
        {
            if (IsNew)
            {
                IsNew = false;
                q.Where(string.Format(" {0} = @0 ", col), value);
            }
            else
            {
                q.Append(string.Format(" AND {0} = @0 ", col), value);
            }
        }
        public void And(string col, CompareFilter comp, object value)
        {
            string c = "";
            if (comp == CompareFilter.Like)
                c = " LIKE ";
            else if (comp == CompareFilter.NotLike)
                c = " NOT LIKE ";
            else if (comp == CompareFilter.In)
                c = " IN ";
            else if (comp == CompareFilter.NotIn)
                c = " NOT IN ";
            else if (comp == CompareFilter.Null)
                c = " IS NULL ";
            else if (comp == CompareFilter.NotNull)
                c = " IS NOT NULL ";
            else if (comp == CompareFilter.Equal)
                c = " = ";
            else if (comp == CompareFilter.NotEqual)
                c = " <> ";
            else if (comp == CompareFilter.GreaterThan)
                c = " > ";
            else if (comp == CompareFilter.GreaterThanOrEqual)
                c = " >= ";
            else if (comp == CompareFilter.LessThan)
                c = " < ";
            else if (comp == CompareFilter.LessThanOrEqual)
                c = " <= ";

            if (IsNew)
            {
                IsNew = false;
                if (value != null)
                {
                    if (comp == CompareFilter.Like || comp == CompareFilter.NotLike)
                        q.Where(string.Format(" {0} {1} N'%{2}%' ", col, c, value));
                    else if (comp == CompareFilter.In || comp == CompareFilter.NotIn)
                        q.Where(string.Format(" {0} {1} (@0) ", col, c), value);
                    else
                        q.Where(string.Format(" {0} {1} @0", col, c), value);
                }
                else
                    q.Where(string.Format(" {0} {1} ", col, c));
            }
            else
            {
                q.Append(" AND ");
                if (value != null)
                {
                    if (comp == CompareFilter.Like || comp == CompareFilter.NotLike)
                        q.Append(string.Format(" {0} {1} N'%@0%' ", col, c), value);
                    else if (comp == CompareFilter.In || comp == CompareFilter.NotIn)
                        q.Append(string.Format(" {0} {1} (@0) ", col, c), value);
                    else
                        q.Append(string.Format(" {0} {1} @0", col, c), value);
                }
                else
                    q.Append(string.Format(" {0} {1} ", col, c));
            }

        }
        public void OrderBy(string col, string OrderType = "DESC")
        {
            q.Append(string.Format(" ORDER BY {0} {1} ", col, OrderType));
        }
        public void Offset(int Rows)
        {
            q.Append(string.Format(" OFFSET {0}  ROWS ", Rows));
        }

        public void Take(int Rows)
        {
            q.Append(string.Format(" FETCH NEXT {0} ROWS ONLY ", Rows));
        }

        public void SkipTake(int Skip, int Take)
        {
            q.Append(string.Format(" OFFSET {0}  ROWS  FETCH NEXT {1} ROWS ONLY ", Skip, Take));
        }

    }
}
