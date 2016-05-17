using System.Collections.Generic;
using Microsoft.Extensions.OptionsModel;
using MySql.Data.MySqlClient;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface;

namespace SolutionsAI.Data.Repositories
{
    public class ProfileRepository: BaseMySqlRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(IOptions<ConnectionOptions> connectionOptions, IDataRetriever<Profile> dataRetriever)
            : base(connectionOptions, dataRetriever)
        {
        }

        public Profile GetUserProfile(string email)
        {
            var command = GetStoredProcedureCommand(
                "GetUserByEmail",
                new MySqlParameter("email", email));
            return GetItem(command);
        }

        public IEnumerable<Profile> GetAllUsers()
        {
            var command = GetStoredProcedureCommand("GetAllUsers");
            return GetItems(command);
        }
    }
}
