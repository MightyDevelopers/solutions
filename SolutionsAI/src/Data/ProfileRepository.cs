using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.OptionsModel;
using MySql.Data.MySqlClient;
using SolutionsAI.Data.DataRetrievers;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DatabaseTools.Extensions;
using SolutionsAI.DataInterface;

namespace SolutionsAI.Data
{
    public class ProfileRepository: BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(IOptions<ConnectionOptions> connectionOptions, IDataRetriever<Profile> dataRetriever)
            : base(connectionOptions, dataRetriever)
        {
        }

        public Profile GetUserProfile(string email)
        {
            var command = CommandExtensions.GetStoredProcedureCommand(
                "GetUserByEmail",
                new MySqlParameter("email", email));
            return GetItem(command);
        }

        public IEnumerable<Profile> GetAllUsers()
        {
            var command = CommandExtensions.GetStoredProcedureCommand("GetAllUsers");
            return GetItems(command);
        }
    }
}
