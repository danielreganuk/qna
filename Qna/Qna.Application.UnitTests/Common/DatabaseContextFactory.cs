using Microsoft.EntityFrameworkCore;
using Qna.Domain.Models;
using Qna.Persistence;
using System;

namespace Qna.Application.UnitTests.Common
{
    public class DatabaseContextFactory
    {
        public static DatabaseContext Create()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DatabaseContext(options);

            context.Database.EnsureCreated();

            context.Authors.AddRange(new[]
            {
                new Author { AuthorId = 1, DisplayName = "QuestionMaker1", EmailAddress = "qm1@moq.com" },
                new Author { AuthorId = 2, DisplayName = "AnswerMaker1", EmailAddress = "am1@moq.com" },
                new Author { AuthorId = 3, DisplayName = "AnswerMaker2", EmailAddress = "am2@moq.com" },
            });

            context.Questions.Add(new Question
            {
                QuestionId = 1,
                AuthorId = 1,
                CreatedDate = DateTime.Now,
                QuestionText = "I don't know how to do this?",
                Title = "Please help!"
            });

            context.Answers.AddRange(new[]
            {
                new Answer { AnswerId = 1, AnswerText = "I'm not sure either, but hi!", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 },
                new Answer { AnswerId = 2, AnswerText = "I'm sure, but I'm not saying how", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 },
                new Answer { AnswerId = 3, AnswerText = "This is the best answer, hands down!", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 }
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(DatabaseContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}