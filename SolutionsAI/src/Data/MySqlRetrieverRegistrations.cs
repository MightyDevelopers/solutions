using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.Data.DataRetrievers;
using SolutionsAI.DatabaseTools;

namespace SolutionsAI.Data
{
    public static class MySqlRetrieverRegistrations
    {
        public static void AddMySqlDataRetriverRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IDataRetriever<Profile>, ProfileDataRetriever>();
        }
    }
}
