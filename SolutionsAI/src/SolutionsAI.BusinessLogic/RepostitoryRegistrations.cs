using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.BusinessLogic.Services.Implementation;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Data.MySql;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.DataInterface.Commands.Group;
using SolutionsAI.DataInterface.Commands.Profile;
using SolutionsAI.DataInterface.Commands.User;
using SolutionsAI.DataInterface.DataRetrievers;
using SolutionsAI.DataInterface.Requests.Implementations.GroupsRequests;
using SolutionsAI.DataInterface.Requests.Implementations.ProfileRequests;
using SolutionsAI.DataInterface.Requests.Implementations.UserRequests;
using SolutionsAI.Domain;
using IProfileService = SolutionsAI.BusinessLogic.Services.Interface.IProfileService;

namespace SolutionsAI.BusinessLogic
{
    public static class RepostitoryRegistrations
    {
        public static void AddRepositoryRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataRetriverRegistrations();

            serviceCollection.AddScoped<IProfileService, ProfileService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IGroupService, GroupService>();
            
            serviceCollection.AddScoped<IRepository<User>, BaseMySqlRepository<User>>();
            serviceCollection.AddScoped<IRepository<Group>, BaseMySqlRepository<Group>>();

            serviceCollection.AddProfileCommandsRegistrations();
            serviceCollection.AddUserCommandsRegistrations();
            serviceCollection.AddGroupCommandsRegistrations();
        }

        private static void AddProfileCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICanExecuteRequest<UpdateProfileRequest, User>, UpdateProfileCommand>();
        }

        private static void AddUserCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICanExecuteRequest<CreateUserRequest, User>, CreateUserCommand>();
            serviceCollection.AddTransient<ICanExecuteRequest<GetUserRequest, User>, GetUserCommand>();
            serviceCollection.AddTransient<ICanExecuteRequest<CheckIfUserExistsRequest, bool>,CheckIfUserExistsCommand>();
            serviceCollection.AddTransient<ICanExecuteRequest<GetUserByIdRequest, User>, GetUserByIdCommand>();
        }

        private static void AddGroupCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICanExecuteRequest<CreateGroupRequest, Group>, CreateGroupCommand>();
        }
    }
}
