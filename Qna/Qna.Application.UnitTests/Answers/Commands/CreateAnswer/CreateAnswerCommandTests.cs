using MediatR;
using Moq;
using Qna.Application.Answers.Commands.CreateAnswer;
using Qna.Application.UnitTests.Common;
using Qna.Domain.Models;
using Shouldly;
using System;
using System.Threading;
using Xunit;

namespace Qna.Application.UnitTests.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandTests : CommandTestBase
    {
        [Fact]
        public async void GivenValidRequest_ShouldCreateAnswer()
        {
            // Arrange //
            var mediatorMock = new Mock<IMediator>();
            var handler = new CreateAnswerCommand.Handler(_context, mediatorMock.Object);
            var author = new Author
            {
                DisplayName = "Test User",
                EmailAddress = "test-user@mock.test"
            };

            // Act //
            var response =
                await handler.Handle(new CreateAnswerCommand(1, "Answer Text", author, DateTime.Now),
                    CancellationToken.None);

            // Assert //
            response.ShouldBeGreaterThan(3);
        }
    }
}