using System.Data;
using SolutionsAI.DatabaseTools;
using SolutionsAI.Domain;
using SolutionsAI.DatabaseTools.Utility;

namespace SolutionsAI.DataInterface.DataRetrievers
{
    public sealed class ProfileDataRetriever: BaseDataRetriever<Profile>
    {
        private int EmailOrdinal { get; set; }
        private int FirstNameOrdinal { get; set; }
        private int LastNameOrdinal { get; set; }
        private int LastUpdateDateOrdinal { get; set; }
        private int RegistrationDateOrdinal { get; set; }

        protected override Profile GetValueUsingOrdinals(IDataReader dataReader)
        {
            return new Profile
            {
                EMail = dataReader.GetString(EmailOrdinal),
                FirstName = dataReader.GetNullable(FirstNameOrdinal),
                LastName = dataReader.GetNullable(LastNameOrdinal),
                LastUpdateDate = dataReader.GetUtcDateTime(LastUpdateDateOrdinal),
                RegistrationDate = dataReader.GetUtcDateTime(RegistrationDateOrdinal)
            };
        }

        protected override Profile GetValueUsingIndexer(IDataReader dataReader)
        {
            return new Profile
            {
                EMail = dataReader["Email"].ToString(),
                FirstName = dataReader.GetNullable("FirstName"),
                LastName = dataReader.GetNullable("LastName"),
                LastUpdateDate = dataReader.GetUtcDateTime("LastUpdateDate"),
                RegistrationDate = dataReader.GetUtcDateTime("RegistrationDate")
            };
        }

        protected override void PopulateOrdinals(IDataReader dataReader)
        {
            EmailOrdinal = dataReader.GetOrdinal("Email");
            FirstNameOrdinal = dataReader.GetOrdinal("FirstName");
            LastNameOrdinal = dataReader.GetOrdinal("LastName");
            LastUpdateDateOrdinal = dataReader.GetOrdinal("LastUpdateDate");
            RegistrationDateOrdinal = dataReader.GetOrdinal("RegistrationDate");
        }
    }
}
