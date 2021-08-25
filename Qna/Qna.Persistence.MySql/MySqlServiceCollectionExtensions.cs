using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qna.Persistence.MySql
{
    public static class MySqlServiceCollectionExtensions
    {
        public static IServiceCollection AddMySqlDbContext(this IServiceCollection serviceCollection,
            IConfiguration config = null)
        {
            Console.WriteLine($"Connection: {config.GetConnectionString("DatabaseContext")}");
            var connectionString = config.GetConnectionString("DatabaseContext");
            serviceCollection.AddDbContext<DatabaseContext, MySqlDatabaseContext>(opts =>
            {
                opts.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Qna.Persistence.MySql");
                    });
            });

            return serviceCollection;
        }
    }
}