using System.Collections.Generic;
using System.Data;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseDataRetriever<T>: IDataRetriever<T>
    {
        public virtual T GetValue(IDataReader dataReader, bool needRead)
        {
            if (needRead)
                dataReader.Read();
            return GetValue(dataReader);
        }

        public abstract T GetValue(IDataReader dataReader);

        public IEnumerable<T> GetValues(IDataReader dataReader)
        {
            var result = new List<T>();
            while (dataReader.Read())
            {
                result.Add(GetValue(dataReader, false));
            }
            return result;
        }
    }
}
