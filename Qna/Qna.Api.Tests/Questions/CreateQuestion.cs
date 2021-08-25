using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Qna.Api.Shared;
using Qna.Api.Tests.Common;
using Qna.Application.Questions.Commands.CreateQuestion;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Domain.Models;
using Shouldly;
using Xunit;

namespace Qna.Api.Tests.Questions
{
    public class CreateQuestion : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateQuestion(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCreateQuestionCommand_ReturnsSuccessStatusCode()
        {
            // Arrange //
            var client = await _factory.GetHttpClient();

            var author = new Author
            {
                DisplayName = "Test Fixture",
                EmailAddress = "test-fixture@test.com"
            };

            // Act //
            var command = new CreateQuestionCommand("Test Question", "Test Question Body", author, DateTime.Now);
            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/questions/create", content);
            var responseObject = await Utilities.GetResponseContent<ApiResponse>(response);
            var viewModel = JsonConvert.DeserializeObject<Question>(responseObject.Data.ToString());

            // Assert //
            response.EnsureSuccessStatusCode();
            responseObject.Success.ShouldBe(true);

        }

        [Fact]
        public async Task GivenCreateQuestionCommand_WithExistingAuthor_ReturnsSuccessWithCorrectAuthorId()
        {
            // Arrange //
            var client = await _factory.GetHttpClient();

            var author = new Author
            {
                DisplayName = "This shouldn't be updated",
                EmailAddress = "qm1@moq.com"
            };

            // Act //
            var command = new CreateQuestionCommand("Test Question", "Test Question Body", author, DateTime.Now);
            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/questions/create", content);
            var responseObject = await Utilities.GetResponseContent<ApiResponse>(response);
            var viewModel = JsonConvert.DeserializeObject<Question>(responseObject.Data.ToString());

            // Assert //
            response.EnsureSuccessStatusCode();
            responseObject.Success.ShouldBe(true);
            viewModel.Author.AuthorId.ShouldBe(1);
            viewModel.Author.DisplayName.ShouldBe("QuestionMaker1");

        }
    }
}
