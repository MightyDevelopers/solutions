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

        protected override Profile GetValue(IDataReader dataReader)
        {
            return new Profile
            {
                EMail = dataReader.GetString(EmailOrdinal),
                FirstName = dataReader.GetString(FirstNameOrdinal),
                LastName = dataReader.GetString(LastNameOrdinal),
                LastUpdateDate = dataReader.GetUtcDateTime(LastUpdateDateOrdinal),
                RegistrationDate = dataReader.GetUtcDateTime(RegistrationDateOrdinal)
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
