using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseDataRetriever<T>: IDataRetriever<T>
    {
        public virtual T GetValue(IDataReader dataReader, bool needRead, bool needPopulateOrdinals = true)
        {
            if (needPopulateOrdinals)
                PopulateOrdinals(dataReader);
            if (needRead)
                dataReader.Read();
            return GetValue(dataReader);
        }

        protected abstract T GetValue(IDataReader dataReader);

        public IEnumerable<T> GetValues(IDataReader dataReader)
        {
            PopulateOrdinals(dataReader);
            var result = new List<T>();
            while (dataReader.Read())
            {
                result.Add(GetValue(dataReader, false, false));
            }
            return result;
        }

        protected abstract void PopulateOrdinals(IDataReader dataReader);
    }
}
