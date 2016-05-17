using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.OptionsModel;
using MySql.Data.MySqlClient;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseRepository<TEntity>
    {
        private readonly ConnectionOptions _options;
        private readonly IDataRetriever<TEntity> _dataRetriever;

        protected BaseRepository(IOptions<ConnectionOptions> options, IDataRetriever<TEntity> dataRetriever)
        {
            _options = options.Value;
            _dataRetriever = dataRetriever;
        }

        protected virtual TEntity GetItem(IDbCommand command)
        {
            return ExecuteUsingConnection(reader => _dataRetriever.GetValue(reader, true), command);
        }

        protected virtual IEnumerable<TEntity> GetItems(IDbCommand command)
        {
            return ExecuteUsingConnection(_dataRetriever.GetValues, command);
        }

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
