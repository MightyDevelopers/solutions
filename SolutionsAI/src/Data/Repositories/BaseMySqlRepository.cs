using System.Data;
using Microsoft.Extensions.OptionsModel;
using MySql.Data.MySqlClient;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data.Repositories
{
    public class BaseMySqlRepository<TEntity>: BaseRepository<TEntity>
    {
        public BaseMySqlRepository(IOptions<ConnectionOptions> options, IDataRetriever<TEntity> dataRetriever) : base(options, dataRetriever)
        {
        }

        protected override IDbConnection GetConnection(string connectionstring)
        {
            var builder = new MySqlConnectionStringBuilder();
            return new MySqlConnection(builder.GetConnectionString(true));
        }

        protected override IDbCommand GetStoredProcedureCommand()
        {
            return new MySqlCommand();
        }
    }
}
