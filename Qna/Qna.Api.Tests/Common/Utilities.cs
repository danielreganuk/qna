using Newtonsoft.Json;
using Qna.Domain.Models;
using Qna.Persistence;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qna.Api.Tests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void TestingDbInitialiser(DatabaseContext context)
        {
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
                CreatedDate = DateTime.Now.AddMinutes(-2),
                QuestionText = "I don't know how to do this?",
                Title = "Please help!"
            });

            context.Questions.Add(new Question
            {
                QuestionId = 2,
                AuthorId = 1,
                CreatedDate = DateTime.Now.AddMinutes(-1),
                QuestionText = "Sorry, another question fellas?",
                Title = "Please help me, again!"
            });

            context.Questions.Add(new Question
            {
                QuestionId = 3,
                AuthorId = 1,
                CreatedDate = DateTime.Now,
                QuestionText = "This is another example of me asking a question?",
                Title = "I have one last question!"
            });

            context.Answers.AddRange(new[]
            {
                new Answer { AnswerId = 1, AnswerText = "I'm not sure either, but hi!", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 },
                new Answer { AnswerId = 2, AnswerText = "I'm sure, but I'm not saying how", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 },
                new Answer { AnswerId = 3, AnswerText = "This is the best answer, hands down!", AuthorId = 2, CreatedDate = DateTime.Now, QuestionId = 1 }
            });

            context.SaveChanges();
        }
    }
}