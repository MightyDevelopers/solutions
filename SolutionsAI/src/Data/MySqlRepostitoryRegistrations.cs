using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.DataInterface;

namespace SolutionsAI.Data
{
    public static class MySqlRepostitoryRegistrations
    {
        public static void AddMySqlRepositoryRegistrations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProfileRepository, ProfileRepository>();
        }
    }
}
