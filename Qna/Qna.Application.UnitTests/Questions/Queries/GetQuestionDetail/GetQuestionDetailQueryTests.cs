using AutoMapper;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.UnitTests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Qna.Application.UnitTests.Questions.Queries.GetQuestionDetail
{
    [Collection("QueryCollection")]
    public class GetQuestionsListQueryTests
    {
        public IDatabaseContext _context;
        public IMapper _mapper;

        public GetQuestionsListQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GivenValidRequest_ShouldGetQuestion()
        {
            // Arrange //
            var handler = new GetQuestionDetailQuery.Handler(_context, _mapper);

            // Act //
            var result = await handler.Handle(new GetQuestionDetailQuery(1), CancellationToken.None);

            // Assert //
            result.ShouldBeOfType<QuestionDetailVm>();
            result.Title.ShouldBe("Please help!");
            result.Id.ShouldBe(1);
            result.Answers.Count.ShouldBe(3);
        }

        [Fact]
        public async Task GivenInvalidRequest_ShouldThrowException()
        {
            // Arrange //
            var handler = new GetQuestionDetailQuery.Handler(_context, _mapper);

            // Act //
            var result = await Should.ThrowAsync<Exception>(async () => await handler.Handle(new GetQuestionDetailQuery(500), CancellationToken.None));

            // Assert //
            result.ShouldBeOfType<Exception>();
        }
    }
}