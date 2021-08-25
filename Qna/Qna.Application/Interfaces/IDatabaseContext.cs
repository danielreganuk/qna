using Microsoft.EntityFrameworkCore;
using Qna.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

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