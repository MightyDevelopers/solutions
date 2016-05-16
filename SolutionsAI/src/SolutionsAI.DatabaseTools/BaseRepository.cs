using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseRepository<TEntity>
    {
        private readonly ConnectionOptions _options;

        protected BaseRepository(ConnectionOptions options)
        {
            _options = options;
        }

        protected abstract TEntity GetItem(IDbCommand command);

        protected abstract IEnumerable<TEntity> GetItems(IDbCommand command);

        protected TResult ExecuteUsingConnection<TResult>(Func<IDataReader, TResult> retrieve, IDbCommand command)
        {
            var builder = new MySqlConnectionStringBuilder(_options.ConnectionString);
            using (
                var connection =
                    new MySqlConnection(
                        builder.GetConnectionString(true)))
            {
                connection.Open();
                command.Connection = connection;

                using (var reader = command.ExecuteReader())
                {
                    return retrieve(reader);
                }
            }
        }
    }
}
