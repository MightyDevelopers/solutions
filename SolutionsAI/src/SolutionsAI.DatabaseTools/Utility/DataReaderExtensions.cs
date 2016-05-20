using System;
using System.Data;

namespace SolutionsAI.DatabaseTools.Utility
{
    public static class DataReaderExtensions
    {
        public static DateTime GetUtcDateTime(this IDataReader dataReader, int dateTimeOrdinal)
        {
            var value = dataReader.GetDateTime(dateTimeOrdinal);
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
