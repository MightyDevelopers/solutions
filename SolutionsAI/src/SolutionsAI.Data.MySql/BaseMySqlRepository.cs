using System.Data;
using Microsoft.Extensions.OptionsModel;
using MySql.Data.MySqlClient;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data.MySql
{
    public class BaseMySqlRepository<TEntity>: BaseRepository<TEntity>
    {
        public BaseMySqlRepository(IOptions<ConnectionOptions> options, IDataRetriever<TEntity> dataRetriever) : base(options, dataRetriever)
        {
        }

        protected override IDbConnection GetConnection(string connectionstring)
        {
            return new MySqlConnection(connectionstring);
        }

        public override IDbDataParameter GetDataParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        protected override IDbCommand GetStoredProcedureCommand()
        {
            return new MySqlCommand();
        }
    }
}
