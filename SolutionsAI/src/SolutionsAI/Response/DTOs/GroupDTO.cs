using SolutionsAI.Domain;

namespace SolutionsAI.Response.DTOs
{
    public class GroupDTO: BaseDTO<Group>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        internal override void FillFromEntity(Group entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}
