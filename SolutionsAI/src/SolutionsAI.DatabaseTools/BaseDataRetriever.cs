using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseDataRetriever<T>: IDataRetriever<T>
    {
        public virtual T GetValue(IDataReader dataReader, bool useOrdinals = true)
        {
            if (useOrdinals)
                PopulateOrdinals(dataReader);
            dataReader.Read();
            return useOrdinals 
                ? GetValueUsingOrdinals(dataReader) 
                : GetValueUsingIndexer(dataReader);
        }

        protected abstract T GetValueUsingOrdinals(IDataReader dataReader);
        protected abstract T GetValueUsingIndexer(IDataReader dataReader);

        public IEnumerable<T> GetValues(IDataReader dataReader)
        {
            PopulateOrdinals(dataReader);
            var result = new List<T>();
            while (dataReader.Read())
            {
                result.Add(GetValueUsingOrdinals(dataReader));
            }
            return result;
        }

        protected abstract void PopulateOrdinals(IDataReader dataReader);
    }
}
