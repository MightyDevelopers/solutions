using SolutionsAI.Domain;

namespace SolutionsAI.Response.DTOs
{
    public class ProfileDTO: BaseDTO<User>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal override void FillFromEntity(User entity)
        {
            Email = entity.EMail;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
        }
    }
}
