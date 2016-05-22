using System;
using System.Data;
using SolutionsAI.DatabaseTools;
using SolutionsAI.Domain;

namespace SolutionsAI.DataInterface.DataRetrievers
{
    public class UserDataRetriever: BaseDataRetriever<User>
    {
        private int IdOrdinal { get; set; }
        private int EmailOrdinal { get; set; }
        private int PasswordOrdinal { get; set; }

        protected override User GetValueUsingOrdinals(IDataReader dataReader)
        {
            return new User
            {
                Id = dataReader.GetInt32(IdOrdinal),
                EMail = dataReader.GetString(EmailOrdinal),
                Password = dataReader.GetString(PasswordOrdinal)
            };
        }

        protected override User GetValueUsingIndexer(IDataReader dataReader)
        {
            return new User
            {
                Id = (int) dataReader["Id"],
                EMail = dataReader["Email"].ToString(),
                Password = dataReader["Password"].ToString()
            };
        }

        protected override void PopulateOrdinals(IDataReader dataReader)
        {
            IdOrdinal = dataReader.GetOrdinal("Id");
            EmailOrdinal = dataReader.GetOrdinal("Email");
            PasswordOrdinal = dataReader.GetOrdinal("Password");
        }
    }
}
