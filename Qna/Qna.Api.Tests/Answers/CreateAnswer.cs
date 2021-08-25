using Qna.Api.Shared;
using Qna.Api.Tests.Common;
using Qna.Application.Answers.Commands.CreateAnswer;
using Qna.Domain.Models;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Qna.Api.Tests.Answers
{
    public class CreateAnswer : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateAnswer(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCreateAnswerCommand_ReturnsSuccessStatusCode()
        {
            // Arrange //
            var client = await _factory.GetHttpClient();

            var author = new Author
            {
                DisplayName = "Test Fixture",
                EmailAddress = "test-fixture@test.com"
            };

            // Act //
            var command = new CreateAnswerCommand(1, "Test answer body", author, DateTime.Now);
            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/answers/create", content);
            var responseObject = await Utilities.GetResponseContent<ApiResponse>(response);

            // Assert //
            response.EnsureSuccessStatusCode();
            responseObject.Success.ShouldBe(true);
        }
    }
}