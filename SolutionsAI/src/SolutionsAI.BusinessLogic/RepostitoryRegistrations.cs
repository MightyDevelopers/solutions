using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.BusinessLogic.Services.Implementation;
using SolutionsAI.BusinessLogic.Services.Interface;
using SolutionsAI.Data.MySql;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Profile;
using SolutionsAI.DataInterface.Commands.User;
using SolutionsAI.DataInterface.DataRetrievers;
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

            serviceCollection.AddScoped<IRepository<Profile>, BaseMySqlRepository<Profile>>();
            serviceCollection.AddScoped<IRepository<User>, BaseMySqlRepository<User>>();

            serviceCollection.AddProfileCommandsRegistrations();
            serviceCollection.AddUserCommandsRegistrations();
        }

        private static void AddProfileCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GetAllProfilesCommand>();
            serviceCollection.AddTransient<GetProfileByEmailCommand>();
            serviceCollection.AddTransient<UpdateProfileCommand>();
        }

        private static void AddUserCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CheckIfUserExistsCommand>();
            serviceCollection.AddTransient<CreateUserCommand>();
        }
    }
}
