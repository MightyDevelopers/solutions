using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Requests.Implementations.ProfileRequests;

namespace SolutionsAI.DataInterface.Commands.Profile
{
    public class UpdateProfileCommand: 
        BaseInitializableCommand<Domain.User, Domain.User, UpdateProfileRequest>
    {
        public UpdateProfileCommand(
            IRepository<Domain.User> repository) : base(repository)
        {
        }
        
        protected override string Name => "UpdateProfileCommand";
        public override void Execute()
        {
            HandleExecute(() => Repository.GetItem("UpdateProfile",
                Repository.GetDataParameter("email", Request.Email),
                Repository.GetDataParameter("firstName", Request.FirstName),
                Repository.GetDataParameter("lastName", Request.LastName)));
        }
    }
}
