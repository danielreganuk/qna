using System;
using AutoMapper;
using Qna.Application.Interfaces;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.UnitTests.Common;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Qna.Application.UnitTests.Questions.Queries.GetQuestionDetail
{
    [Collection("QueryCollection")]
    public class GetQuestionDetailQueryTests
    {
        public IDatabaseContext _context;
        public IMapper _mapper;

        public GetQuestionDetailQueryTests(QueryTestFixture fixture)
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
        }

        [Fact]
        public async Task GivenInvalidRequest_ShouldThrowException()
        {
            // Arrange //
            var handler = new GetQuestionDetailQuery.Handler(_context, _mapper);

            // Act //
            var result = await Should.ThrowAsync<Exception>(async () => await handler.Handle(new GetQuestionDetailQuery(2), CancellationToken.None));

            // Assert //
            result.ShouldBeOfType<Exception>();
        }
    }
}