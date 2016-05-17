using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.OptionsModel;

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
            using (
                var connection =
                    GetConnection(_options.ConnectionString))
            {
                connection.Open();
                command.Connection = connection;

                using (var reader = command.ExecuteReader())
                {
                    return retrieve(reader);
                }
            }
        }

        protected virtual IDbCommand GetStoredProcedureCommand(string text, params IDbDataParameter[] parameters)
        {
            var command = GetStoredProcedureCommand();
            command.CommandText = text;
            command.CommandType = CommandType.StoredProcedure;
            foreach (var dbDataParameter in parameters)
            {
                command.Parameters.Add(dbDataParameter);
            }
            return command;
        }

        protected abstract IDbConnection GetConnection(string connectionstring);

        protected abstract IDbCommand GetStoredProcedureCommand();
    }
}
