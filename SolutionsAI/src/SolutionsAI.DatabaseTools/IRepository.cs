using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public interface IRepository<TEntity>
    {
        TEntity GetItem(string commandText, params IDbDataParameter[] parameters);

        IEnumerable<TEntity> GetItems(string commandText, params IDbDataParameter[] parameters);

        IDbDataParameter GetDataParameter(string name, object value);
    }
}
