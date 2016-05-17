using System.Data;
using MySql.Data.MySqlClient;

namespace SolutionsAI.DatabaseTools.Extensions
{
    public static class CommandExtensions
    {
        public static MySqlCommand GetStoredProcedureCommand(string name, params MySqlParameter[] parameters)
        {
            var command = new MySqlCommand()
            {
                CommandText = name,
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(parameters);
            return command;
        }
    }
}
