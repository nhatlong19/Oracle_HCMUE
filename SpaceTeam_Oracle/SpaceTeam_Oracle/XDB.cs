using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTeam_Oracle
{
    public class XDB
    {
        public static IQueryable<TEntity> FromSql<TEntity>(DbContext EFContext, RawSqlString sql, IEnumerable<OracleParameter> op) where TEntity : class
        {
            return EFContext.Set<TEntity>().FromSql(sql, op);
        }
    }
}
