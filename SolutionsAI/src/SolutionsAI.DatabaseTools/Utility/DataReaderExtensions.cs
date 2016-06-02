using System;
using System.Data;

namespace SolutionsAI.DatabaseTools.Utility
{
    public static class DataReaderExtensions
    {
        public static string GetNullable(this IDataReader dataReader, int ordinal)
        {
            return dataReader.IsDBNull(ordinal) ? null : dataReader.GetString(ordinal);
        }

        public static string GetNullable(this IDataReader dataReader, string columnName)
        {
            var ordinal = dataReader.GetOrdinal(columnName);
            return dataReader.IsDBNull(ordinal) ? null : dataReader.GetString(ordinal);
        }

        public static DateTime GetUtcDateTime(this IDataReader dataReader, int dateTimeOrdinal)
        {
            var value = dataReader.GetDateTime(dateTimeOrdinal);
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public static DateTime GetUtcDateTime(this IDataReader dataReader, string dateTimeColumnName)
        {
            var value = (DateTime)dataReader[dateTimeColumnName];
            return DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
