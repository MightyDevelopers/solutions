using System;
using System.Collections.Generic;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data.DataRetrievers
{
    public class DataRetrieverProvider
    {
        private readonly Dictionary<Type, object> _retrievers; 

        public DataRetrieverProvider()
        {
            _retrievers = new Dictionary<Type, object>
            {
                {typeof (Profile), new ProfileDataRetriever()}
            };
        }

        public IDataRetriever<T> GetRetriever<T>()
        {
            return (IDataRetriever<T>) _retrievers[typeof (T)];
        }
    }
}