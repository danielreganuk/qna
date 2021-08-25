using Qna.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qna.Persistence.Initialisers
{
    public class DevelopmentInit
    {
        private readonly Dictionary<int, Question> Questions = new Dictionary<int, Question>();

        public static void Init(DatabaseContext context)
        {
            var initialiser = new DevelopmentInit();
            initialiser.Seed(context);
        }

        public void Seed(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            //check if exists
            if (context.Questions.Any())
            {
                return; // db already seeded
            }

            //SeedUsers(context);
            SeedQuestions(context);
        }

        private void SeedQuestions(DatabaseContext context)
        {
            context.Authors.AddRange(new[]
            {
                new Author { AuthorId = 1, DisplayName = "QuestionMaker1", EmailAddress = "qm1@moq.com" },
                new Author { AuthorId = 2, DisplayName = "AnswerMaker1", EmailAddress = "am1@moq.com" },
                new Author { AuthorId = 3, DisplayName = "AnswerMaker2", EmailAddress = "am2@moq.com" },
            });

            var answers1 = new List<Answer>
            {
                new Answer
                {
                    AnswerText = "I'm not sure either, but hi!", Author = new Author { DisplayName = "AnswerMaker1", EmailAddress = "am1@moq.com" }, CreatedDate = DateTime.Now
                },
                new Answer
                {
                    AnswerText = "I'm sure, but I'm not saying how", Author = new Author { DisplayName = "AnswerMaker1", EmailAddress = "am1@moq.com" }, CreatedDate = DateTime.Now
                },
                new Answer
                {
                    AnswerText = "This is the best answer, hands down!", Author = new Author { DisplayName = "AnswerMaker1", EmailAddress = "am1@moq.com" }, CreatedDate = DateTime.Now
                }
            };


            Questions.Add(0, new Question
            {
                CreatedDate = DateTime.Now.AddMinutes(-2),
                QuestionText = "I don't know how to do this?",
                Title = "Who is Creed Bratton?",
                Answers = answers1,
                Author = new Author { DisplayName = "Phyllis Vance", EmailAddress = "p.vance@dundermifflin.com" }

            });

            Questions.Add(1, new Question
            {
                CreatedDate = DateTime.Now.AddMinutes(-2),
                QuestionText = "I don't know how to do this?",
                Title = "Ryan started the fire!",
                Answers = answers1,
                Author = new Author { DisplayName = "Dwight Schrute", EmailAddress = "d.schrute@dundermifflin.com" }

            });

            Questions.Add(2, new Question
            {
                CreatedDate = DateTime.Now.AddMinutes(-2),
                QuestionText = "I don't know how to do this?",
                Title = "Michael Scott is bankrupt?",
                Answers = answers1,
                Author = new Author { DisplayName = "Oscar Martinez", EmailAddress = "o.martinez@dundermifflin.com" }

            });


            foreach (var value in Questions.Values)
            {
                context.Questions.Add(value);
            }

            context.SaveChanges();

        }
    }
}