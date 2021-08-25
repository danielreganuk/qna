using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Qna.Persistence.MySql
{
    public class MySqlDatabaseContextFactory : IDesignTimeDbContextFactory<MySqlDatabaseContext>
    {
        public MySqlDatabaseContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.local.json", true)
                .Build();

            var connectionString = config.GetConnectionString("DatabaseContext");


            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 22)),
                b => b.MigrationsAssembly("Qna.Persistence.MySql"));

            return new MySqlDatabaseContext(builder.Options);
        }
    }
}
