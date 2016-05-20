using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.BusinessLogic.Services.Implementation;
using SolutionsAI.Data.MySql;
using SolutionsAI.DatabaseTools;
using SolutionsAI.DataInterface.Commands.Profile;
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
            serviceCollection.AddScoped<IRepository<Profile>, BaseMySqlRepository<Profile>>();

            serviceCollection.AddProfileCommandsRegistrations();
        }

        private static void AddProfileCommandsRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GetAllProfilesCommand>();
            serviceCollection.AddTransient<GetProfileByEmail>();
        }
    }
}
