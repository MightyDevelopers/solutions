using System;
using System.Data;
using SolutionsAI.DatabaseTools;
using SolutionsAI.Domain;
using SolutionsAI.DatabaseTools.Utility;

namespace SolutionsAI.DataInterface.DataRetrievers
{
    public class UserDataRetriever: BaseDataRetriever<User>
    {
        private int IdOrdinal { get; set; }
        private int EmailOrdinal { get; set; }
        private int PasswordOrdinal { get; set; }
        private int RegistrationDateOrdinal { get; set; }
        private int LastUpdateDateOrdinal { get; set; }
        private int LastNameOrdinal { get; set; }
        private int FirstNameOrdinal { get; set; }

        protected override User GetValueUsingOrdinals(IDataReader dataReader)
        {
            return new User
            {
                Id = dataReader.GetInt32(IdOrdinal),
                EMail = dataReader.GetString(EmailOrdinal),
                Password = dataReader.GetString(PasswordOrdinal),
                FirstName = dataReader.GetNullable(FirstNameOrdinal),
                LastName = dataReader.GetNullable(LastNameOrdinal),
                LastUpdateDate = dataReader.GetUtcDateTime(LastUpdateDateOrdinal),
                RegistrationDate = dataReader.GetUtcDateTime(RegistrationDateOrdinal)
            };
        }

        protected override User GetValueUsingIndexer(IDataReader dataReader)
        {
            return new User
            {
                Id = (int) dataReader["Id"],
                EMail = dataReader["Email"].ToString(),
                Password = dataReader["Password"].ToString(),
                FirstName = dataReader.GetNullable("FirstName"),
                LastName = dataReader.GetNullable("LastName"),
                LastUpdateDate = dataReader.GetUtcDateTime("LastUpdateDate"),
                RegistrationDate = dataReader.GetUtcDateTime("RegistrationDate")
            };
        }

        protected override void PopulateOrdinals(IDataReader dataReader)
        {
            IdOrdinal = dataReader.GetOrdinal("Id");
            EmailOrdinal = dataReader.GetOrdinal("Email");
            PasswordOrdinal = dataReader.GetOrdinal("Password");
            FirstNameOrdinal = dataReader.GetOrdinal("FirstName");
            LastNameOrdinal = dataReader.GetOrdinal("LastName");
            LastUpdateDateOrdinal = dataReader.GetOrdinal("LastUpdateDate");
            RegistrationDateOrdinal = dataReader.GetOrdinal("RegistrationDate");
        }
    }
}
