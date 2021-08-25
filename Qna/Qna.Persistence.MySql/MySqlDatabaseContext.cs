using Microsoft.EntityFrameworkCore;

namespace Qna.Persistence.MySql
{
    public class MySqlDatabaseContext : DatabaseContext
    {
        public MySqlDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}