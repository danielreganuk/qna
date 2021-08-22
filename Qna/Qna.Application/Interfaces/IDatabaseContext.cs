using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Qna.Domain.Models;

namespace Qna.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Author> Authors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}