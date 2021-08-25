using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qna.Persistence.MySql;

namespace Qna.Api.Extensions
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredDbContext(this IServiceCollection serviceCollection,
            IConfiguration config = null)
        {
            var persistenceConfig = config?.GetSection("Persistence")?.Get<PersistenceConfiguration>();

            if (persistenceConfig?.Provider.ToUpper() == "MYSQL")
            {
                serviceCollection.AddMySqlDbContext(config);
            }

            return serviceCollection;
        }
    }

    public class PersistenceConfiguration
    {
        public string Provider { get; set; }
    }
}