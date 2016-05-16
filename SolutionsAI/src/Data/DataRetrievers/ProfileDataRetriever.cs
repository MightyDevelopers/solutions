using System;
using System.Data;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data.DataRetrievers
{
    public class ProfileDataRetriever: BaseDataRetriever<Profile>
    {
        public override Profile GetValue(IDataReader dataReader)
        {
            return new Profile
            {
                EMail = dataReader["Email"].ToString(),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                LastUpdateDate = (DateTime)dataReader["LastUpdateDate"],
                RegistrationDate = (DateTime)dataReader["RegistrationDate"]
            };
        }
    }
}
