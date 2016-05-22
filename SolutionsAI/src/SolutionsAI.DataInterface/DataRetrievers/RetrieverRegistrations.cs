using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.DatabaseTools;
using SolutionsAI.Domain;

namespace SolutionsAI.DataInterface.DataRetrievers
{
    public static class RetrieverRegistrations
    {
        public static void AddDataRetriverRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IDataRetriever<Profile>, ProfileDataRetriever>();
            services.AddTransient<IDataRetriever<User>, UserDataRetriever>();
        }
    }
}
