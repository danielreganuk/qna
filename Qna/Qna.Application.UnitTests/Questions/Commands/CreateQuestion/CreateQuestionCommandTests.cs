using MediatR;
using Moq;
using Qna.Application.Questions.Commands.CreateQuestion;
using Qna.Application.UnitTests.Common;
using Qna.Domain.Models;
using Shouldly;
using System;
using System.Threading;
using Xunit;

namespace Qna.Application.UnitTests.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandTests : CommandTestBase
    {
        [Fact]
        public async void GivenValidRequest_ShouldCreateQuestion()
        {
            // Arrange //
            var mediatorMock = new Mock<IMediator>();
            var handler = new CreateQuestionCommand.Handler(_context, mediatorMock.Object);
            var author = new Author
            {
                DisplayName = "Test User",
                EmailAddress = "test-user@mock.test"
            };

            // Act //
            var response =
                await handler.Handle(new CreateQuestionCommand("Question Title", "Question Text", author, DateTime.Now),
                    CancellationToken.None);

            // Assert //
            response.QuestionId.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async void GivenExistingAuthor_ShouldCreateQuestionWithExistingAuthorsId()
        {
            // Arrange //
            var mediatorMock = new Mock<IMediator>();
            var handler = new CreateQuestionCommand.Handler(_context, mediatorMock.Object);
            // Act //
            var response =
                await handler.Handle(new CreateQuestionCommand("Question Title", "Question Text", null, DateTime.Now, 1),
                    CancellationToken.None);

            // Assert //
            response.Author.AuthorId.ShouldBe(1);
            response.Author.DisplayName.ShouldBe("QuestionMaker1");
        }

    }
}