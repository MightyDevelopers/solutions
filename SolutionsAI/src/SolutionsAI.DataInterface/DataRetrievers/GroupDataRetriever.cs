using System.Data;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DatabaseTools.Utility;
using SolutionsAI.Domain;

namespace SolutionsAI.DataInterface.DataRetrievers
{
    public class GroupDataRetriever: BaseDataRetriever<Group>
    {
        private int _idOrdinal;
        private int _creationDateTimeOrdinal;
        private int _creatorIdOrdinal;
        private int _nameOrdinal;

        protected override Group GetValueUsingOrdinals(IDataReader dataReader)
        {
            return new Group
            {
                Id = dataReader.GetInt32(_idOrdinal),
                Name = dataReader.GetString(_nameOrdinal),
                CreatorId = dataReader.GetInt32(_creatorIdOrdinal),
                CreationDateTime = dataReader.GetUtcDateTime(_creationDateTimeOrdinal)
            };
        }

        protected override Group GetValueUsingIndexer(IDataReader dataReader)
        {
            return new Group
            {
                Id = (int) dataReader["Id"],
                Name = dataReader["Name"].ToString(),
                CreatorId = (int) dataReader["CreatorId"],
                CreationDateTime = dataReader.GetUtcDateTime("CreationDate")
            };
        }

        protected override void PopulateOrdinals(IDataReader dataReader)
        {
            _idOrdinal = dataReader.GetOrdinal("Id");
            _nameOrdinal = dataReader.GetOrdinal("Name");
            _creatorIdOrdinal = dataReader.GetOrdinal("CreatorId");
            _creationDateTimeOrdinal = dataReader.GetOrdinal("CreationDate");
        }
    }
}
