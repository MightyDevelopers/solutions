using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public interface IDataRetriever<out TEntity>
    {
        TEntity GetValue(IDataReader dataReader);
        TEntity GetValue(IDataReader dataReader, bool needRead);
        IEnumerable<TEntity> GetValues(IDataReader dataReader);
    }
}
