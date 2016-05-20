using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.OptionsModel;

namespace SolutionsAI.DatabaseTools
{
    public abstract class BaseRepository<TEntity>: IRepository<TEntity>
    {
        private readonly ConnectionOptions _options;
        private readonly IDataRetriever<TEntity> _dataRetriever;

        protected BaseRepository(IOptions<ConnectionOptions> options, IDataRetriever<TEntity> dataRetriever)
        {
            _options = options.Value;
            _dataRetriever = dataRetriever;
        }

        public virtual TEntity GetItem(string commandText, params IDbDataParameter[] parameters)
        {
            return ExecuteUsingConnection(reader => _dataRetriever.GetValue(reader, true), GetStoredProcedureCommand(commandText, parameters));
        }

        public virtual IEnumerable<TEntity> GetItems(string commandText, params IDbDataParameter[] parameters)
        {
            return ExecuteUsingConnection(_dataRetriever.GetValues, GetStoredProcedureCommand(commandText, parameters));
        }

        private TResult ExecuteUsingConnection<TResult>(Func<IDataReader, TResult> retrieve, IDbCommand command)
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

        public abstract IDbDataParameter GetDataParameter(string name, object value);
    }
}
