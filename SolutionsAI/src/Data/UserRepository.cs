using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using SolutionsAI.Data.DataRetrievers;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data
{
    public class UserRepository: BaseRepository<Profile>
    {
        public UserRepository(ConnectionOptions connectionOptions): base(connectionOptions)
        {
        }

        public Profile GetUserProfile(string email)
        {
            var command = new MySqlCommand($"select * from User where Email = '{email}';");
            return GetItem(command);
        }

        public IEnumerable<Profile> GetAllUsers()
        {
            var command = new MySqlCommand("select * from User;");
            return GetItems(command);
        }

        protected override Profile GetItem(IDbCommand command)
        {
            var retriever = new DataRetrieverProvider().GetRetriever<Profile>();
            return ExecuteUsingConnection(reader => retriever.GetValue(reader, true), command);
        }

        protected override IEnumerable<Profile> GetItems(IDbCommand command)
        {
            var retriever = new DataRetrieverProvider().GetRetriever<Profile>();
            return ExecuteUsingConnection(retriever.GetValues, command);
        }
    }
}
