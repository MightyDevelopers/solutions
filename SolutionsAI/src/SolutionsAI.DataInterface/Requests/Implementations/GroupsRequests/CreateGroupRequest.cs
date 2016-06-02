namespace SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests
{
    public class CreateGroupRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public CreateGroupRequest(string name, int userId)
        {
            UserId = userId;
            Name = name;
        }
    }
}
