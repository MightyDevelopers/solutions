using Microsoft.Extensions.DependencyInjection;
using SolutionsAI.BusinessLogic.DataRetrievers;
using SolutionsAI.DatabaseTools;
using SolutionsAI.Domain;

namespace SolutionsAI.BusinessLogic
{
    public static class RetrieverRegistrations
    {
        public static void AddMySqlDataRetriverRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IDataRetriever<Profile>, ProfileDataRetriever>();
        }
    }
}
