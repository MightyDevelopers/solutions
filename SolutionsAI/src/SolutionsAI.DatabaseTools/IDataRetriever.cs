using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public interface IDataRetriever<out TEntity>
    {
        TEntity GetValue(IDataReader dataReader, bool needRead, bool needPopulateOrdinals = true);
        IEnumerable<TEntity> GetValues(IDataReader dataReader);
    }
}
